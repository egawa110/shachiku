using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migu_Nyumu : MonoBehaviour
{
    Rigidbody2D rbody;                //Rigidbody2D型の作成
    Transform playerTr;
    public float speed = 3.0f;  //移動速度
    public bool isToRight = false; //true ＝ 右向き  false ＝ 左向き
    public LayerMask groundLayer;      //地面レイヤー
    public float jump = 9.0f;
    bool goJump = false;              //ジャンプ開始フラグ

    private Vector3 movement;
    private float amountX;

    float passedTimes = 0;
    public float firetime = 3.0f;//発射

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
    }

    // Update is called once per frame
    void Update()
    {
        
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
        Transform yTransform = playerTr.transform;
        Vector2 orldPos = yTransform.position;
        passedTimes += Time.deltaTime;//時間経過
        if (worldPos.y - orldPos.y > 3&&worldPos.x-orldPos.x<=5||worldPos.y-orldPos.y<-3&&worldPos.x-orldPos.x>=-5)
        {

            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   -speed * Time.deltaTime);
            if (passedTimes >= firetime)
            {
                Jump();
            }
        }
        else
        {

            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   speed * Time.deltaTime);
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
            Vector2 jumpPw = new Vector2(0, jump);  //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //瞬間敵な力を加える
            goJump = false; //ジャンプフラグを下ろす
            passedTimes = 0;



        }

    }
    public void Jump()
    {
        goJump = true; //ジャンプフラグを立てる
    }

    //接触
    private void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {
        if (other.CompareTag("KinKill"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }

    }
}
