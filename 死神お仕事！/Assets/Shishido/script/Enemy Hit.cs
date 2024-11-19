using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数

    public int HP_E = 4;    //敵の体力

    //サウンド再生
    public AudioSource audioSource;
    public AudioClip EnemyDamage_SE;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントを取得する
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP_E--;

            //主人公の攻撃に当たったら音が鳴る
            audioSource.PlayOneShot(EnemyDamage_SE);

            if (HP_E <= 0)
            {
                ////死亡
                ////当たりを削除
                //GetComponent<BoxCollider2D>().enabled = false;
                ////移動停止
                //rbody.velocity = Vector2.zero;
                //0.5秒後に消す
                Destroy(gameObject);
            }
        }
    }
}
