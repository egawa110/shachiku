using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�

    public int HP_E = 3;    //�G�̗̑�
    private bool inDamage;  //�_���[�W���̃t���O

    bool ZERO = false;//���S�m�F

    private PlayerController playcon;

    private AudioSource audioSource;
    public AudioClip Damage_SE;

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        //�v���C���[�R���g���[���[�擾
        playcon = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inDamage&&ZERO==false)
        {
            //�_���[�W���A�_�ł�����
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //�X�v���C�g��\��
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //�X�v���C�g���\��
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
            // �U�����ꂽ���̃G�t�F�N�g
            GetDamage(collision.gameObject);
        }
    }

    void GetDamage(GameObject player)
    {
        if (PlayerController.gameState == "playing"|| PlayerBoss.gameState == "playing")
        {
            HP_E--; //hp������
            if (HP_E > 0)
            {
                //�_���[�W�t���O�@ON
                inDamage = true;
                audioSource.PlayOneShot(Damage_SE);
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                //�����
                inDamage = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                ZERO = true;
                audioSource.Play();
            }
        }
    }

    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false; // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // �X�v���C�g�����ɖ߂�
    }
}
