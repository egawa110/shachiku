using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�

    public int HP_E = 4;    //�G�̗̑�

    //�T�E���h�Đ�
    public AudioSource audioSource;
    public AudioClip EnemyDamage_SE;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g���擾����
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

            //��l���̍U���ɓ��������特����
            audioSource.PlayOneShot(EnemyDamage_SE);

            if (HP_E <= 0)
            {
                ////���S
                ////��������폜
                //GetComponent<BoxCollider2D>().enabled = false;
                ////�ړ���~
                //rbody.velocity = Vector2.zero;
                //0.5�b��ɏ���
                Destroy(gameObject);
            }
        }
    }
}
