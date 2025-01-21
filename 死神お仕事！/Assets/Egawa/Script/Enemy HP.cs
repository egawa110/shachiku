using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    Rigidbody2D rbody; public int HP_E = 3;
    //敵の体力
    private bool inDamage;
    //ダメージ中のフラグ
    bool ZERO = false;

    //死亡確認
    private PlayerController playcon;
    private AudioSource audioSource;
    public AudioClip Damage_SE;

    void Start()
    {
        playcon = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (inDamage && !ZERO)
        {
            float val = Mathf.Sin(Time.time * 50);
            gameObject.GetComponent<SpriteRenderer>().enabled = val > 0;
        }

        if (ZERO)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (!audioSource.isPlaying && ZERO)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 攻撃された時のエフェクト
            GetDamage();
        }
    }

    void GetDamage()
    {
        if (PlayerController.gameState == "playing" || PlayerBoss.gameState == "playing")
        {
            if (!inDamage) // ダメージ中でない場合のみ実行
            {
                HP_E--; //hpが減る

                if (HP_E > 0)
                {
                    //ダメージフラグ ON
                    inDamage = true; 
                    audioSource.PlayOneShot(Damage_SE); 
                    Invoke(nameof(DamageEnd), 0.25f);
                }
                else
                {
                    ZERO = true; 
                    inDamage = false; 
                    gameObject.GetComponent<SpriteRenderer>().enabled = false; 
                    GetComponent<BoxCollider2D>().enabled = false; 
                    GetComponent<CircleCollider2D>().enabled = false; 
                    audioSource.Play();
                }
            }
        }
    }

    void DamageEnd()
    {
        inDamage = false; 
        // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; 
        
    }
}
