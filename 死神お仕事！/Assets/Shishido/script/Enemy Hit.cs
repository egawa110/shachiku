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
            GetDamage(collision.gameObject);

            //HP_E--;

            //主人公の攻撃に当たったら音が鳴る
            audioSource.PlayOneShot(EnemyDamage_SE);


            //if (HP_E > 0)
            //{
            //    //移動停止
            //    rbody.velocity = new Vector2(0, 0);
            //    //敵キャラの反対方向にヒットバックさせる
            //    Vector3 v = (transform.position - transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
            //    //ダメージフラグ　ON
            //    inDamage = true;
            //}
            //else
            //{
            //    Destroy(gameObject);
            //}

        }
    }

    void GetDamage(GameObject player)
    {
        if (PlayerController.gameState == "playing")
        {
            HP_E--; //hpが減る
            if (HP_E > 0)
            {
                //移動停止
                rbody.velocity = new Vector2(0, 0);
                //敵キャラの反対方向にヒットバックさせる
                Vector3 v = (transform.position - player.transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
                //ダメージフラグ　ON
                inDamage = true;
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
