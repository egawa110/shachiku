using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数

    public int HP_E = 6;    //敵の体力
    private bool inDamage;  //ダメージ中のフラグ

    //サウンド再生
    private AudioSource audioSource;
    public AudioClip EnemyDamage_SE;

    private PlayerController playcon;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントを取得する
        audioSource = GetComponent<AudioSource>();

        playcon = GetComponent<PlayerController>();

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
            HP_E--;

            if (HP_E > 0)
            {
                //ダメージフラグをONに
                inDamage = true;

                //主人公の攻撃に当たったら音が鳴る
                audioSource.PlayOneShot(EnemyDamage_SE);

                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
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
