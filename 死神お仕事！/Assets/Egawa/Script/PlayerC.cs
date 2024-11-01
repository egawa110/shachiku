using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数
    float axisH = 0.0f;             //入力
    public float speed = 3.0f;      //移動速度
    public float jump = 9.0f;       //ジャンプ力
    public LayerMask groundLayer;   //着地できるレイヤー
    bool goJump = false;            //ジャンプ開始フラグ
    // アニメーション対応
    Animator animator; // アニメーター
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";
    string nowAnime = "";
    string oldAnime = "";
    public static string gameState = "playing"; // ゲームの状態

    //追加
    public int ALL_SOUL = 0;      //1ステージで取得したすべての魂

    //攻撃用変数
    [SerializeField] private GameObject bullet; //バレットプレハブを格納
    [SerializeField] private Transform attackPoint;//アタックポイントを格納

    [SerializeField] private float attackTime = 0.2f; //攻撃間隔
    private float currentAttackTime; //攻撃の間隔を管理
    private bool canAttack; //攻撃可能状態かを指定するフラグ

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();        //Animator を取ってくる
        nowAnime = stopAnime;                       //停止から開始する
        oldAnime = stopAnime;                       //停止から開始する
        gameState = "playing";                      // ゲーム中にする

        currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }
        //水平方向の入力をチェックする
        axisH = Input.GetAxisRaw("Horizontal");
        //向きの調整
        if (axisH > 0.0f)
        {
            //右移動
            Debug.Log("右移動");
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            Debug.Log("左移動");
            transform.localScale = new Vector2(-1, 1);
        }

        //キャラクターをジャンプさせる
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //主人公の攻撃
        Attack();
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position,    //発射位置
                                             1.8f,                  //円の半径
                                             Vector2.down,          //発射方向
                                             0.0f,                  //発射距離
                                             groundLayer);          //検出するレイヤー
        if (onGround || axisH != 0)
        {
            //速度を更新する
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            //地面の上でジャンプキーが押された
            //ジャンプさせる
            Vector2 jumpPw = new Vector2(0, jump);          //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //瞬間的な力を加える
            goJump = false;
        }
        //アニメーション更新
        if (onGround)
        {
            // 地面の上
            if (axisH == 0)
            {
                nowAnime = stopAnime; 		// 停止中
            }
            else
            {
                nowAnime = moveAnime;  		// 移動
            }
        }
        else
        {
            // 空中
            nowAnime = jumpAnime;
        }
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);        // アニメーション再生
        }

    }

    //ジャンプ
    public void Jump()
    {
        goJump = true;                      //ジャンプフラグを立てる
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
                else
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

    // 接触開始
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();        // ゴール！！
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();     // ゲームオーバー
        }

        //追加
        else if (collision.gameObject.tag == "Soul")
        {
            //魂取得する
            Souls item = collision.gameObject.GetComponent<Souls>();
            ALL_SOUL += item.soul_one;
            // オブジェクト削除する
            Destroy(collision.gameObject);
        }
    }

    // ゴール
    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();             // ゲーム停止
    }

    // ゲームオーバー
    public void GameOver()
    {
        animator.Play(deadAnime);
        gameState = "gameover"; GameStop();
        // ゲーム停止（ゲームオーバー演出）
        // プレイヤー当たりを消す
        GetComponent<CapsuleCollider2D>().enabled = false;
        // プレイヤーを上に少し跳ね上げる演出
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    // ゲーム停止
    void GameStop()
    {
        // Rigidbody2Dを取ってくる
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        // 速度を 0 にして強制停止
        rbody.velocity = new Vector2(0, 0);
    }
}
