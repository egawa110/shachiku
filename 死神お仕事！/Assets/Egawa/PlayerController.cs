using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody;         //Rigidbody2D型の作成
    float axisH = 0.0f;        //入力
    public float speed = 3.0f; //移動速度

    public float jump = 9.0f;     //ジャンプ力
    public LayerMask groundLayer; //着地できるレイヤー
    bool goJump = false;          //ジャンプ開始フラグ


<<<<<<< HEAD
    //アニメーション対応
    Animator animator; //アニメーター
    public string stopAnime = "Player Stop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
=======
    ////アニメーション対応
    //Animator animator; //アニメーター
    //public string stopAnime = "Player Stop";
    //public string moveAnime = "PlayerMove";
    //public string jumpAnime = "PlayerJump";
>>>>>>> b1adeec8ff0e6419a08051f9b53bc59f46b202c0
    //public string goalAnime = "playerGoal";
    public string deadAnime = "PlayerOver";

    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";// ゲームの状態

    //public int Soul_num;//魂何個取ったか

    public int score = 0;//スコア

    // Start is called before the first frame update
    void Start()
    {

<<<<<<< HEAD
        //Rigidbod2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();      //Animatorを取ってくる
        nowAnime = stopAnime;                     //停止から開始する
        oldAnime = stopAnime;                     //停止から開始する
=======
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbod2Dを取ってくる
        //animator = GetComponent<Animator>();        //Animatorを取ってくる
        //nowAnime = stopAnime;   //停止から開始する
        //oldAnime = stopAnime;   //停止から開始する
>>>>>>> b1adeec8ff0e6419a08051f9b53bc59f46b202c0

        gameState = "playing";//ゲーム中
    }

    // Update is called once per frame
    void Update()
    {

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

        if (gameState != "playing")
        {
            return;
        }

    }

    void FixedUpdate()
    {
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
            //地面の上でジャンプキーが押された
            //ジャンプさせる
            Vector2 jumpPw = new Vector2(0, jump);  //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //瞬間敵な力を加える
            goJump = false; //ジャンプフラグを下ろす

            // アニメーション更新
            if (onGround)
            {
                // 地面の上
                if(axisH == 0)
                {
                    //nowAnime = stopAnime;//停止中
                }
                else
                {
                    //nowAnime = moveAnime;//移動
                }
            }
            else
            {
                //空中
                //    //nowAnime = jumpAnime;
                //}
                //if (nowAnime != oldAnime)
                //{
                //    oldAnime = nowAnime;
                //    animator.Play(nowAnime);// アニメーション再生
            }
        }

        if (gameState != "playing")
        {
            return;
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

<<<<<<< HEAD
    //接触開始
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            //Goal();
        }

        else if (collision.gameObject.tag == "Dead")
        {
            GameOver(); //ゲームオーバー
        }
    }

   
        


=======
    // 接触開始
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "ScoreItem")
        {
<<<<<<< HEAD
            //スコアアイテム
            //ItemDataを取る
            Souls item = collision.gameObject.GetComponent<Souls>();
            //スコアを得る
            score = item.value;
=======
            if (Input.GetKey(KeyCode.X)) // 魂を取る
            {
                Souls soul = collision.gameObject.GetComponent<Souls>();
                Soul_num = soul.soul_one;
>>>>>>> b1adeec8ff0e6419a08051f9b53bc59f46b202c0
>>>>>>> 039c9e7fa3dd4a7519a7809f46cfb6d27b8e61a3

            //アイテムを削除する
            Destroy(collision.gameObject);


            //if (Input.GetKey(KeyCode.X)) // 魂を取る
            //{
            //    Souls soul = collision.gameObject.GetComponent<Souls>();
            //    Soul_num = soul.soul_one;

            //    Destroy(collision.gameObject);
            //}
        }
    }
    // ゴール
    public void Goal()
    {
        //animator.Play(goalAnime);

        gameState = "gameclear";
        GameStop();
    }
    // ゲームオーバー
    public void GameOver()
    {
        //animator.Play(deadAnime);

        gameState = "gameover";
        GameStop();
        //===================
        // ゲームオーバー演出
        //===================
        // プレイヤー当たりを消す
        GetComponent<CapsuleCollider2D>().enabled = false;
        // プレイヤーを上に少し跳ね上げる演出
        rbody.AddForce(new Vector2(0,5),ForceMode2D.Impulse);
    }
    // ゲーム停止
    void GameStop()
    {
        // Rigidbody2Dを取ってくる
        Rigidbody2D rbody=GetComponent<Rigidbody2D>();
        // 速度を０にして強制停止
        rbody.velocity=new Vector2(0,0);
    }
}
