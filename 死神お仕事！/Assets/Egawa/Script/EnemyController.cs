using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemySpeed        = 2.0f;  //�ړ����x
    public bool isToRight          = false; //true �� �E����  false �� ������
    public float revTime           = 0;     //���]����
    public LayerMask groundLayer;           //�n�ʃ��C���[

    private float CircleRadius     = 0.5f;  //�n�㔻��̉~���a
    private float Firingdistance   = 0.5f;  ////�n�㔻��̔��ˋ���
    private float time             = 0;     //���]�p�̃^�C�}�[

    void Start()
    {
        //Enemy���]�֐�
        ChangeDirection(isToRight);
        
    }

    //Update�֐�
    //����
    //�^�C�}�[���X�V���A��莞�Ԃ��ƂɓG�̌����𔽓]�����Ă�
    void Update()
    {
        if (revTime > 0)
        {
            time += Time.deltaTime;
            if (time >= revTime)
            {
                isToRight = !isToRight; //�t���O�𔽓]������
                time = 0;               //�^�C�}�[��������

                //Enemy���]�֐�
                ChangeDirection(isToRight);
               
            }
        }
    }

    //FixedUpdate�֐�
    //����
    //�n�㔻����s���A�������Z�Ɋ�Â��ēG�̑��x���X�V���Ă�
    void FixedUpdate()
    {
        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position, //���ˈʒu
                                             CircleRadius,       //�~�̔��a
                                             Vector2.down,       //���˕���
                                             Firingdistance,     //���ˋ���
                                             groundLayer);       //���o���郌�C���[

        if (onGround)
        {
            //���x���X�V����
            //Rigidbody2D ������Ă���
            Rigidbody2D rbody = GetComponent<Rigidbody2D>();

            if (isToRight)
            {
                rbody.velocity = new Vector2(EnemySpeed, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(-EnemySpeed, rbody.velocity.y);
            }
        }
    }

    //�ڐG
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isToRight = !isToRight; //�t���O�𔽓]������
        time = 0;               //�^�C�}�[������

        //Enemy���]�֐�
        ChangeDirection(isToRight);
       
    }

    //Enemy���]�֐�
    void ChangeDirection(bool isToRight)
    {
        if (isToRight)
        {
            transform.localScale = new Vector2(-1, 1); // �����̕ύX
        }
        else
        {
            transform.localScale = new Vector2(1, 1); // �����̕ύX
        }
    }
}
