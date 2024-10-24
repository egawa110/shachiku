using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCont : MonoBehaviour
{
    [SerializeField] private float speed;//プレイヤーの移動速度
    [SerializeField] private float maxY, minY; //移動範囲の制限

    [SerializeField] private GameObject lazer; //レーザープレハブを格納
    [SerializeField] private Transform attackPoint;//アタックポイントを格納

    [SerializeField] private float attackTime = 0.2f; //攻撃の間隔
    private float currentAttackTime; //攻撃の間隔を管理
    private bool canAttack; //攻撃可能状態かを指定するフラグ

    void Start()
    {
        currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //プレイヤーを動かすメソッドを呼び出す
        Attack();
    }

    void MovePlayer()
    {
        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            playerPos.y += speed * Time.deltaTime; //y座標にspeedを加算
                                                   //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Vertical") < 0)　//もし下矢印キーが押されたら
        {
            Vector3 playerPos = transform.position;
            playerPos.y -= speed * Time.deltaTime;
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }
    }
    void Attack()
    {
        attackTime += Time.deltaTime; //attackTimeに毎フレームの時間を加算していく

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //指定時間を超えたら攻撃可能にする
        }

        if (Input.GetKeyDown(KeyCode.K)) //Kキーを押したら
        {
            if (canAttack)
            {
                //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
                Instantiate(lazer, attackPoint.position, Quaternion.identity);
                canAttack = false;　//攻撃フラグをfalseにする
                attackTime = 0f;　//attackTimeを0に戻す
            }
        }

    }
}