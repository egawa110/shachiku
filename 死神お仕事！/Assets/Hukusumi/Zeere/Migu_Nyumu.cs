using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migu_Nyumu : MonoBehaviour
{
    Rigidbody2D rbody;                //Rigidbody2D型の作成
    Transform playerTr;
    public float Speed = 3.0f;  //移動速度
    public LayerMask groundLayer;      //地面レイヤー
    public float jump = 9.0f;//ジャンプ力
    bool goJump = false;              //ジャンプ開始フラグ

    float PassedTimes = 0;//時間
    public float FireTime = 3.0f;//発射

    //音
    private AudioSource audioSource;
    public AudioClip Junp_SE;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //自身の位置
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        //プレイヤーの位置
        Transform myTransformP = playerTr.transform;
        Vector2 worldPosP = myTransformP.position;
        PassedTimes += Time.deltaTime;//時間経過
        if (worldPos.y - worldPosP.y > 2 || worldPos.y - worldPosP.y < -2)
        {
            if (worldPos.x - worldPosP.x <= 5&& worldPos.x - worldPosP.x >0 || worldPos.x - worldPosP.x >= -5 && worldPos.x - worldPosP.x < 0)//高さが違うとき離れて跳ぶ
            {
                transform.position = Vector2.MoveTowards(
                       transform.position,
                       new Vector2(playerTr.position.x, worldPos.y),
                       -Speed * Time.deltaTime);
                if (PassedTimes >= FireTime)
                {
                    Jump();
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(
                       transform.position,
                       new Vector2(playerTr.position.x, worldPos.y),
                       Speed * Time.deltaTime);
            }
        }
        else//同ｙ時
        {
            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   Speed * Time.deltaTime);
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
        if (onGround && goJump)
        {
            //地面の上でジャンプキーが押された
            //ジャンプさせる
            audioSource.PlayOneShot(Junp_SE);
            Vector2 jumpPw = new Vector2(0, jump);  //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //瞬間敵な力を加える
            goJump = false; //ジャンプフラグを下ろす
            PassedTimes = 0;
        }
    }
    public void Jump()
    {
        goJump = true; //ジャンプフラグを立てる
    }
}
