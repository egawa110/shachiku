using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�

    public int HP_E = 6;    //�G�̗̑�
    private bool inDamage;  //�_���[�W���̃t���O

    //�T�E���h�Đ�
    private AudioSource audioSource;
    public AudioClip EnemyDamage_SE;

    private PlayerController playcon;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g���擾����
        audioSource = GetComponent<AudioSource>();

        playcon = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inDamage)
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetDamage(collision.gameObject);

            //HP_E--;

            //��l���̍U���ɓ��������特����
            audioSource.PlayOneShot(EnemyDamage_SE);


            //if (HP_E > 0)
            //{
            //    //�ړ���~
            //    rbody.velocity = new Vector2(0, 0);
            //    //�G�L�����̔��Ε����Ƀq�b�g�o�b�N������
            //    Vector3 v = (transform.position - transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
            //    //�_���[�W�t���O�@ON
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
            HP_E--; //hp������
            if (HP_E > 0)
            {
                //�ړ���~
                rbody.velocity = new Vector2(0, 0);
                //�G�L�����̔��Ε����Ƀq�b�g�o�b�N������
                Vector3 v = (transform.position - player.transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
                //�_���[�W�t���O�@ON
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                Destroy(gameObject);
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
