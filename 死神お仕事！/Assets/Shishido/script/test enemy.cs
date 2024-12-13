using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class testenemy : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数

    public int E_maxHp = 3;//敵の最大Hp
    int nowHp;//敵の今のHp
    //Slider
    public Slider slider;//スライダー
    private bool inDamage;  //ダメージ中のフラグ

    private PlayerController playcon;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーコントローラー取得
        playcon = GetComponent<PlayerController>();
        //スライダーの体力の値を最大に
        slider.value = 3;
        //スタート時の体力（nowHp）を最大体力（E_maxHp）と同じ値に
        nowHp = E_maxHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (inDamage)
        {
            //ダメージ中、点滅させる
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //スプライトを非表示
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // 攻撃された時のエフェクト
            GetDamage(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void GetDamage(GameObject player)
    {
        if (PlayerController.gameState == "playing")
        {
            nowHp--; //hpが減る

            //スライダーに-1された体力を反映
            slider.value = nowHp;

            if (nowHp > 0)
            {
                //ダメージフラグ　ON
                inDamage = true;

                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                //やられる
                Destroy(gameObject);
            }
        }
    }

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false; // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // スプライトを元に戻す
    }

}
