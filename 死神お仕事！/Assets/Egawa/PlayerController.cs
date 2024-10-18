using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody;         //Rigidbody2D�^�̍쐬
    float axisH = 0.0f;        //����
    public float speed = 3.0f; //�ړ����x

    public float jump = 9.0f;     //�W�����v��
    public LayerMask groundLayer; //���n�ł��郌�C���[
    bool goJump = false;          //�W�����v�J�n�t���O


    //�A�j���[�V�����Ή�
    Animator animator; //�A�j���[�^�[
   // public string stopAnime = "Player Stop";
    //public string moveAnime = "PlayerMove";
    //public string jumpAnime = "PlayerJump";
    //public string goalAnime = "playerGoal";
    //public string deadAnime = "PlayerOver";

    //string nowAnime = "";
    //string oldAnime = "";


    // Start is called before the first frame update
    void Start()
    {

        //Rigidbod2D������Ă���
        rbody = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //���������̓��͂��`�F�b�N
        axisH = Input.GetAxisRaw("Horizontal");

        //�����̒���
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }

        //�L�����N�^�[���W�����v������
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            //Debug.Log("�W�����v");
        }

    }

    void FixedUpdate()
    {
        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position, //���ˈʒu
                                             1.9f,               //�~�̔��a
                                             Vector2.down,       //���˕���
                                             0.0f,               //���ˋ���
                                             groundLayer);       //���o���郌�C���[

        if (onGround || axisH != 0)
        {
            //�n�ʂ̏� or ���x���O�ł͂Ȃ�
            //���x���X�V����
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            //Debug.Log("�W�����v");
            //�n�ʂ̏�ŃW�����v�L�[�������ꂽ
            //�W�����v������
            Vector2 jumpPw = new Vector2(0, jump);  //�W�����v������x�N�g�������
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //�u�ԓG�ȗ͂�������
            goJump = false; //�W�����v�t���O�����낷

        }
    }

    //�W�����v
    public void Jump()
    {
        goJump = true; //�W�����v�t���O�𗧂Ă�
    }


}
