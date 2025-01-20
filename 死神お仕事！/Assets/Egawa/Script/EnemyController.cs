using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemySpeed        = 2.0f;  //移動速度
    public bool isToRight          = false; //true ＝ 右向き  false ＝ 左向き
    public float revTime           = 0;     //反転時間
    public LayerMask groundLayer;           //地面レイヤー

    private float CircleRadius     = 0.5f;  //地上判定の円半径
    private float Firingdistance   = 0.5f;  ////地上判定の発射距離
    private float time             = 0;     //反転用のタイマー

    void Start()
    {
        //Enemy反転関数
        ChangeDirection(isToRight);
        
    }

    //Update関数
    //説明
    //タイマーを更新し、一定時間ごとに敵の向きを反転させてる
    void Update()
    {
        if (revTime > 0)
        {
            time += Time.deltaTime;
            if (time >= revTime)
            {
                isToRight = !isToRight; //フラグを反転させる
                time = 0;               //タイマーを初期化

                //Enemy反転関数
                ChangeDirection(isToRight);
               
            }
        }
    }

    //FixedUpdate関数
    //説明
    //地上判定を行い、物理演算に基づいて敵の速度を更新してる
    void FixedUpdate()
    {
        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position, //発射位置
                                             CircleRadius,       //円の半径
                                             Vector2.down,       //発射方向
                                             Firingdistance,     //発射距離
                                             groundLayer);       //検出するレイヤー

        if (onGround)
        {
            //速度を更新する
            //Rigidbody2D を取ってくる
            Rigidbody2D rbody = GetComponent<Rigidbody2D>();

            if (isToRight)
            {
                rbody.velocity = new Vector2(EnemySpeed, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(-EnemySpeed, rbody.velocity.y);
            }
        }
    }

    //接触
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isToRight = !isToRight; //フラグを反転させる
        time = 0;               //タイマー初期化

        //Enemy反転関数
        ChangeDirection(isToRight);
       
    }

    //Enemy反転関数
    void ChangeDirection(bool isToRight)
    {
        if (isToRight)
        {
            transform.localScale = new Vector2(-1, 1); // 向きの変更
        }
        else
        {
            transform.localScale = new Vector2(1, 1); // 向きの変更
        }
    }
}
