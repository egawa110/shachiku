using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();        //Animator を取ってくる
        nowAnime = stopAnime;                       //停止から開始する
        oldAnime = stopAnime;                       //停止から開始する
        gameState = "playing";                      //ゲーム中にする

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (gameState != "playing" || inDamage)
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
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            //ダメージ中、点滅させる
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //スプライトを非表示
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return; // ダメージ中は操作による移動をさせない
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
            //ジャンプ音を鳴らす
            audioSource.PlayOneShot(Jump_SE);
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
    // 接触開始
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();        // ゴール！！
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();    // ゲームオーバー
        }

        //追加
        else if (collision.gameObject.tag == "Soul")
        {
            //音を鳴らす
            audioSource.PlayOneShot(GetSoul_SE);
            //魂取得する
            Souls item = collision.gameObject.GetComponent<Souls>();
            ALL_SOUL += item.soul_one;
            // 削除する
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
            audioSource.PlayOneShot(Damage_SE);
        }
    }

    //ダメージ
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            HP_P--; //hpが減る
            if (HP_P > 0)
            {
                animator.Play(deadAnime);
                //移動停止
                rbody.velocity = new Vector2(0, 0);
                //敵キャラの反対方向にノックバックさせる
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

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false; // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // スプライトを元に戻す
    }
    // ゴール
    public void Goal()
    {
        //音楽を鳴らす
        audioSource.PlayOneShot(Clear_SE);

        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();             // ゲーム停止
    }

    // ゲームオーバー
    public void GameOver()
    {
        //音楽を鳴らす
        audioSource.PlayOneShot(Over_SE);

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
