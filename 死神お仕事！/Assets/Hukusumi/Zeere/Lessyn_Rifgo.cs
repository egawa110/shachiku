using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lessyn_Rifgo : MonoBehaviour
{
    public GameObject objPrefab;   //発生させるPrefabデータ
    Transform gateTransform;       //発射口のTransform
    Rigidbody2D rbody;                //Rigidbody2D型の作成
    Transform Zeere;
    public float speed = 3.0f;  //移動速度
    public LayerMask groundLayer;      //地面レイヤー
    public float fireSpeed = 4.0f; //発射速度

    float passedTimes = 0;
    public float firetime = 3.0f;//発射

    private AudioSource audioSource;
    public AudioClip Fire_SE;

    GameObject Zyuto;

    void Start()
    {
        gateTransform = transform.Find("gate");
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
        audioSource = GetComponent<AudioSource>();

        Zyuto = this.transform.Find("name").gameObject;
    }

    void Update()
    {
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        passedTimes += Time.deltaTime;//時間経過
            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(Zeere.position.x, worldPos.y),
                   speed * Time.deltaTime);
           
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            foreach (Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
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
    }

    //接触
    private void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }

}

