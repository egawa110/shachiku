using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeerekin : MonoBehaviour
{
    Transform playerTr;
    public float speed = 3.0f;  //移動速度
    public bool isToRight = false; //true ＝ 右向き  false ＝ 左向き
    public LayerMask groundLayer;      //地面レイヤー

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(playerTr.position.x, playerTr.position.y),
               speed * Time.deltaTime);

    }
    void FixedUpdate()
    {
        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position, //発射位置
                                             0.5f,               //円の半径
                                             Vector2.down,       //発射方向
                                             0.5f,               //発射距離
                                             groundLayer);       //検出するレイヤー

        

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
