using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migu_Nyumu : MonoBehaviour
{
    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    Transform playerTr;
    public float Speed = 3.0f;  //�ړ����x
    public LayerMask groundLayer;      //�n�ʃ��C���[
    public float jump = 9.0f;//�W�����v��
    bool goJump = false;              //�W�����v�J�n�t���O

    float PassedTimes = 0;//����
    public float FireTime = 3.0f;//����

    //��
    private AudioSource audioSource;
    public AudioClip Junp_SE;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���g�̈ʒu
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        //�v���C���[�̈ʒu
        Transform myTransformP = playerTr.transform;
        Vector2 worldPosP = myTransformP.position;
        PassedTimes += Time.deltaTime;//���Ԍo��
        if (worldPos.y - worldPosP.y > 2 || worldPos.y - worldPosP.y < -2)
        {
            if (worldPos.x - worldPosP.x <= 5&& worldPos.x - worldPosP.x >0 || worldPos.x - worldPosP.x >= -5 && worldPos.x - worldPosP.x < 0)//�������Ⴄ�Ƃ�����Ē���
            {
                transform.position = Vector2.MoveTowards(
                       transform.position,
                       new Vector2(playerTr.position.x, worldPos.y),
                       -Speed * Time.deltaTime);
                if (PassedTimes >= FireTime)
                {
                    Jump();
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(
                       transform.position,
                       new Vector2(playerTr.position.x, worldPos.y),
                       Speed * Time.deltaTime);
            }
        }
        else//������
        {
            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   Speed * Time.deltaTime);
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
            audioSource.PlayOneShot(Junp_SE);
            Vector2 jumpPw = new Vector2(0, jump);  //�W�����v������x�N�g�������
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //�u�ԓG�ȗ͂�������
            goJump = false; //�W�����v�t���O�����낷
            PassedTimes = 0;
        }
    }
    public void Jump()
    {
        goJump = true; //�W�����v�t���O�𗧂Ă�
    }
}
