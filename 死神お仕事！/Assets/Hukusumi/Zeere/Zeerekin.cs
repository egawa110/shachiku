using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeerekin : MonoBehaviour
{
    Transform playerTr;
    public float speed = 3.0f;  //�ړ����x
    public bool isToRight = false; //true �� �E����  false �� ������
    public LayerMask groundLayer;      //�n�ʃ��C���[

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(playerTr.position.x, playerTr.position.y),
               speed * Time.deltaTime);

    }
    void FixedUpdate()
    {
        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position, //���ˈʒu
                                             0.5f,               //�~�̔��a
                                             Vector2.down,       //���˕���
                                             0.5f,               //���ˋ���
                                             groundLayer);       //���o���郌�C���[

        

    }

    //�ڐG
    private void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {
        if (other.CompareTag("KinKill"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }

    }
}
