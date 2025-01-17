using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数

    public int HP_E = 3;    //敵の体力
    private bool inDamage;  //ダメージ中のフラグ

    bool ZERO = false;//死亡確認

    private PlayerController playcon;

    private AudioSource audioSource;
    public AudioClip Damage_SE;

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        //プレイヤーコントローラー取得
        playcon = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inDamage&&ZERO==false)
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

        if(ZERO)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(!audioSource.isPlaying && ZERO)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // 攻撃された時のエフェクト
            GetDamage(collision.gameObject);
        }
    }

    void GetDamage(GameObject player)
    {
        if (PlayerController.gameState == "playing"|| PlayerBoss.gameState == "playing")
        {
            HP_E--; //hpが減る
            if (HP_E > 0)
            {
                //ダメージフラグ　ON
                inDamage = true;
                audioSource.PlayOneShot(Damage_SE);
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                //やられる
                inDamage = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                ZERO = true;
                audioSource.Play();
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
