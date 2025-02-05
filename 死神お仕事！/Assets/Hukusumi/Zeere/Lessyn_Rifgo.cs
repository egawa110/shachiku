using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lessyn_Rifgo : MonoBehaviour
{
    //プレハブ
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Heal;
    Transform GateTransform;       //発射口のTransform
    Rigidbody2D rbody;                //Rigidbody2D型の作成
    Transform Zeere;
    public float Speed = 3.0f;  //移動速度
    public LayerMask groundLayer;      //地面レイヤー
    public float FireSpeed = 4.0f; //発射速度

    float PassedTimes = 0;//時間
    public float FireTime = 3.0f;//発射

    bool Dead = false;//過剰生成防止

    //自己座標
    float x;
    float y;

    //音
    private AudioSource audioSource;
    public AudioClip Fire_SE;

    void Start()
    {
        GateTransform = transform.Find("gate");
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
        audioSource = GetComponent<AudioSource>();
        //Transform myTransform = this.transform;
        //Vector2 WorldPos = myTransform.position;
        //if(WorldPos.x<0)
        //{
        //    new Vector2(100, 1),
        //       speed);
        //}
        //else
        //{
        //    new Vector2(-100, 1),
        //       speed);
        //}
    }

    void Update()
    {
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        PassedTimes += Time.deltaTime;//時間経過
        //ゼーレに移動
        transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(Zeere.position.x, worldPos.y),
               Speed * Time.deltaTime);
        if (PassedTimes >= FireTime)
        {
            PassedTimes = 0; //時間を０にリセット

            //砲弾をプレハブから作る
            Vector2 pos = new Vector2(GateTransform.position.x,
                GateTransform.position.y);
            GameObject obj = Instantiate(Bullet, pos, Quaternion.identity);
            //指定の方向に発射する
            Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
            Vector2 v = new Vector2(0, 2) * FireSpeed;
            rbody.AddForce(v, ForceMode2D.Impulse);
            audioSource.PlayOneShot(Fire_SE);
        }
        if (GetComponent<BoxCollider2D>().enabled == false&&Dead==false)//当たり判定による死亡確認
        {
            x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
            y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
            Instantiate(Heal, new Vector2(x, y), Quaternion.identity);//ハート生成
            Dead = true;//過剰生成防止
        }

        void FixedUpdate()
        {
            //地上判定
            bool onGround = Physics2D.CircleCast(transform.position, //発射位置
                                                 1.8f,               //円の半径
                                                 Vector2.down,       //発射方向
                                                 0.0f,               //発射距離
                                                 groundLayer);       //検出するレイヤー
        }
    }
}

