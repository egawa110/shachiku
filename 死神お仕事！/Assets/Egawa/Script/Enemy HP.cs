using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    Rigidbody2D rbody; public int HP_E = 3;
    //�G�̗̑�
    private bool inDamage;
    //�_���[�W���̃t���O
    bool ZERO = false;

    //���S�m�F
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
            // �U�����ꂽ���̃G�t�F�N�g
            GetDamage();
        }
    }

    void GetDamage()
    {
        if (PlayerController.gameState == "playing" || PlayerBoss.gameState == "playing")
        {
            if (!inDamage) // �_���[�W���łȂ��ꍇ�̂ݎ��s
            {
                HP_E--; //hp������

                if (HP_E > 0)
                {
                    //�_���[�W�t���O ON
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
        // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; 
        
    }
}
