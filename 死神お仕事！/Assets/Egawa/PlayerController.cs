using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody;         //Rigidbody2D型の作成
    float axisH = 0.0f;        //入力
    public float speed = 3.0f; //移動速度

    public float jump = 9.0f;     //ジャンプ力
    public LayerMask groundLayer; //着地できるレイヤー
    bool goJump = false;          //ジャンプ開始フラグ


    //アニメーション対応
    Animator animator; //アニメーター
   // public string stopAnime = "Player Stop";
    //public string moveAnime = "PlayerMove";
    //public string jumpAnime = "PlayerJump";
    //public string goalAnime = "playerGoal";
    //public string deadAnime = "PlayerOver";

    //string nowAnime = "";
    //string oldAnime = "";


    // Start is called before the first frame update
    void Start()
    {

        //Rigidbod2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //水平方向の入力をチェック
        axisH = Input.GetAxisRaw("Horizontal");

        //向きの調整
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }

        //キャラクターをジャンプさせる
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            //Debug.Log("ジャンプ");
        }

    }

    void FixedUpdate()
    {
        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position, //発射位置
                                             1.9f,               //円の半径
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
            //Debug.Log("ジャンプ");
            //地面の上でジャンプキーが押された
            //ジャンプさせる
            Vector2 jumpPw = new Vector2(0, jump);  //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //瞬間敵な力を加える
            goJump = false; //ジャンプフラグを下ろす

        }
    }

    //ジャンプ
    public void Jump()
    {
        goJump = true; //ジャンプフラグを立てる
    }


}
