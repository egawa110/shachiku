using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody;                //Rigidbody2D型の作成
    float axisH = 0.0f;               //入力
    public float speed = 3.0f;        //移動速度

    public float jump = 9.0f;         //ジャンプ力
    public LayerMask groundLayer;     //着地できるレイヤー
    bool goJump = false;              //ジャンプ開始フラグ


    //アニメーション対応
    Animator animator; //アニメーター
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";

    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";// ゲームの状態


    //追加
    public int ALL_SOUL = 0;      //1ステージで取得したすべての魂

    //攻撃用変数
    [SerializeField] private GameObject bullet;     //バレットプレハブを格納
    [SerializeField] private Transform attackPoint; //アタックポイントを格納

    [SerializeField] private float attackTime = 0.2f; //攻撃間隔
    private float currentAttackTime;                  //攻撃の間隔を管理
    private bool canAttack;                           //攻撃可能状態かを指定するフラグ

    public int HP_P = 4;      //プレイヤーの体力
    bool inDamage = false;  //ダメージ中のフラグ

    // サウンド再生
    private AudioSource audioSource;
    public AudioClip Jump_SE;
    public AudioClip Damage_SE;
    public AudioClip GetSoul_SE;
    public AudioClip Over_SE;
    public AudioClip Clear_SE;

    // Start is called before the first frame update
    void Start()
    {
        //FPSを60に固定
        Application.targetFrameRate = 60;

        //Rigidbod2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();      //Animatorを取ってくる
        nowAnime = stopAnime;                     //停止から開始する
        oldAnime = stopAnime;                     //停止から開始する

        gameState = "playing";//ゲーム中にする

        currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }

        //水平方向の入力をチェック
        axisH = Input.GetAxisRaw("Horizontal");

        //向きの調整
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }

        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        //キャラクターをジャンプさせる
        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }

        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position, //発射位置
                                             1.8f,               //円の半径
                                             Vector2.down,       //発射方向
                                             0.0f,               //発射距離
                                             groundLayer);       //検出するレイヤー

        if (onGround || axisH != 0)
        {
            //地面の上 or 速度が０ではない
            //速度を更新する
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            //ジャンプ音を鳴らす
            audioSource.PlayOneShot(Jump_SE);

            //地面の上でジャンプキーが押された
            //ジャンプさせる
            Vector2 jumpPw = new Vector2(0, jump);  //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //瞬間敵な力を加える
            goJump = false; //ジャンプフラグを下ろす
        }
        //アニメーション更新
        if (onGround)
        {
            //地面の上
            if (axisH == 0)
            {
                nowAnime = stopAnime; //停止中 
            }

            else
            {
                nowAnime = moveAnime; //移動
            }
        }
        else
        {
            //空中
            nowAnime = jumpAnime;
        }
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);  //アニメーション再生
        }
    }

    //ジャンプ
    public void Jump()
    {
        goJump = true; //ジャンプフラグを立てる
    }

    //攻撃
    public void Attack()
    {
        attackTime += Time.deltaTime; //attackTimeに毎フレームの時間を加算していく

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //指定時間を超えたら攻撃可能にする
        }

        if (Input.GetKeyDown(KeyCode.Z)) //Zキーを押したら
        {
            if (canAttack)
            {
                GameObject playerObj = GameObject.Find("Player");
                if (playerObj.transform.localScale.x >= 0)
                {
                    CreateBullet();
                }
            }
        }
    }

    public void CreateBullet()
    {
        //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
        Instantiate(bullet, attackPoint.position, Quaternion.identity);
        canAttack = false; //攻撃フラグをfalseにする
        attackTime = 0f;　 //attackTimeを0に戻す
    }

    //接触開始
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead"|| collision.gameObject.tag == "ZeereCore")
        {
            GameOver(); //ゲームオーバー
        }
        else if (collision.gameObject.tag == "Soul")
        {
            //魂取得する
            Souls item = collision.gameObject.GetComponent<Souls>();
            ALL_SOUL += item.soul_one;
            // オブジェクト削除する
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
            //敵に当たった時に音を鳴らす
            audioSource.PlayOneShot(Damage_SE);
        }
    }

    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            HP_P--; //hpが減る
            if (HP_P > 0)
            {
                //移動停止
                rbody.velocity = new Vector2(0, 0);
                //敵キャラの反対方向にヒットバックさせる
                Vector3 v = (transform.position - enemy.transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
                //ダメージフラグ　ON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
            else
            {
                //ゲームオーバー
                GameOver();
            }
        }
    }

    // ゴール
    public void Goal()
    {
        animator.Play(goalAnime);

        //音楽を鳴らす
        audioSource.PlayOneShot(Clear_SE);

        gameState = "gameclear";
        GameStop();
    }
    // ゲームオーバー
    public void GameOver()
    {
        animator.Play(deadAnime);

        //音楽を鳴らす
        audioSource.PlayOneShot(Over_SE);

        gameState = "gameover";
        GameStop();
        //---------------------
        //ゲームオーバー演出
        //---------------------
        //プレイヤー当たりを消す
        //---------------------
        GetComponent<BoxCollider2D>().enabled = false;
        //プレイヤーを上に少し跳ね上げる演出
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    //ゲーム停止
    void GameStop()
    {
        //Rigidbody2Dを取ってくる
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //速度を０にして強制停止
        rbody.velocity = new Vector2(0, 0);
    }
  
}
    

