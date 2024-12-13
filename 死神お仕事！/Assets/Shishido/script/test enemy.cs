using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class testenemy : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�

    public int E_maxHp = 3;//�G�̍ő�Hp
    int nowHp;//�G�̍���Hp
    //Slider
    public Slider slider;//�X���C�_�[
    private bool inDamage;  //�_���[�W���̃t���O

    private PlayerController playcon;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�R���g���[���[�擾
        playcon = GetComponent<PlayerController>();
        //�X���C�_�[�̗̑͂̒l���ő��
        slider.value = 3;
        //�X�^�[�g���̗̑́inowHp�j���ő�̗́iE_maxHp�j�Ɠ����l��
        nowHp = E_maxHp;

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
            // �U�����ꂽ���̃G�t�F�N�g
            GetDamage(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void GetDamage(GameObject player)
    {
        if (PlayerController.gameState == "playing")
        {
            nowHp--; //hp������

            //�X���C�_�[��-1���ꂽ�̗͂𔽉f
            slider.value = nowHp;

            if (nowHp > 0)
            {
                //�_���[�W�t���O�@ON
                inDamage = true;

                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                //�����
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
