using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migu_Nyumu : MonoBehaviour
{
    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    Transform playerTr;
    public float speed = 3.0f;  //�ړ����x
    public bool isToRight = false; //true �� �E����  false �� ������
    public LayerMask groundLayer;      //�n�ʃ��C���[
    public float jump = 9.0f;
    bool goJump = false;              //�W�����v�J�n�t���O

    private Vector3 movement;
    private float amountX;

    float passedTimes = 0;
    public float firetime = 3.0f;//����

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
    }

    // Update is called once per frame
    void Update()
    {
        
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
        Transform yTransform = playerTr.transform;
        Vector2 orldPos = yTransform.position;
        passedTimes += Time.deltaTime;//���Ԍo��
        if (worldPos.y - orldPos.y > 3&&worldPos.x-orldPos.x<=5||worldPos.y-orldPos.y<-3&&worldPos.x-orldPos.x>=-5)
        {

            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   -speed * Time.deltaTime);
            if (passedTimes >= firetime)
            {
                Jump();
            }
        }
        else
        {

            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   speed * Time.deltaTime);
        }

    }
    
    void FixedUpdate()
    {
        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position, //���ˈʒu
                                             1.8f,               //�~�̔��a
                                             Vector2.down,       //���˕���
                                             0.0f,               //���ˋ���
                                             groundLayer);       //���o���郌�C���[

        if (onGround && goJump)
        {
            //�n�ʂ̏�ŃW�����v�L�[�������ꂽ
            //�W�����v������
            Vector2 jumpPw = new Vector2(0, jump);  //�W�����v������x�N�g�������
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //�u�ԓG�ȗ͂�������
            goJump = false; //�W�����v�t���O�����낷
            passedTimes = 0;



        }

    }
    public void Jump()
    {
        goJump = true; //�W�����v�t���O�𗧂Ă�
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
