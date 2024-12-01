using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zyuto_Myuusey : MonoBehaviour
{
    public GameObject objPrefab;   //発生させるPrefabデータ
    Transform gateTransform;       //発射口のTransform
    Rigidbody2D rbody;                //Rigidbody2D型の作成
    Transform playerTr;
    public float speed = 3.0f;  //移動速度
    public bool isToRight = false; //true ＝ 右向き  false ＝ 左向き
    public LayerMask groundLayer;      //地面レイヤー
    public float fireSpeed = 4.0f; //発射速度


    private Vector3 movement;
    private float amountX;

    float passedTimes = 0;
    public float firetime = 3.0f;//発射

    // Start is called before the first frame update
    void Start()
    {
        gateTransform = transform.Find("gate");
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
    }

    // Update is called once per frame
    void Update()
    {

        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        Transform yTransform = playerTr.transform;
        Vector2 orldPos = yTransform.position;
        passedTimes += Time.deltaTime;//時間経過
        if ( worldPos.x - orldPos.x >= 5 || worldPos.x - orldPos.x <= -5)
        {
            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   speed * Time.deltaTime);
            if (worldPos.y - orldPos.y < 2 && worldPos.y - orldPos.y > -2)//射撃条件
            {
                if (passedTimes >= firetime)
                {
                    passedTimes = 0; //時間を０にリセット
                                     //砲弾をプレハブから作る
                    if (worldPos.x - orldPos.x >= 1)//対象の方向
                    {
                        Vector2 pos = new Vector2(gateTransform.position.x,
                            gateTransform.position.y);
                        GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                        //方針が向いてる方向に発射する
                        Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                        float angleZ = transform.localEulerAngles.z;
                        float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                        float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                        Vector2 v = new Vector2(-x, y) * fireSpeed;
                        rbody.AddForce(v, ForceMode2D.Impulse);
                    }
                    else if (worldPos.x - orldPos.x <= -1)//対象の方向
                    {
                        Vector2 pos = new Vector2(gateTransform.position.x,
                            gateTransform.position.y);
                        GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                        //方針が向いてる方向に発射する
                        Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                        float angleZ = transform.localEulerAngles.z;
                        float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                        float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                        Vector2 v = new Vector2(x, y) * fireSpeed;
                        rbody.AddForce(v, ForceMode2D.Impulse);
                    }
                }
            }

            
            
        }
        else
        {

            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   -speed * Time.deltaTime);
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
        if (other.CompareTag("KinKill"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        if (other.CompareTag("Foff"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }

    }
}
