using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lessyn_Rifgo : MonoBehaviour
{
    //�v���n�u
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Heal;
    Transform GateTransform;       //���ˌ���Transform
    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    Transform Zeere;
    public float Speed = 3.0f;  //�ړ����x
    public LayerMask groundLayer;      //�n�ʃ��C���[
    public float FireSpeed = 4.0f; //���ˑ��x

    float PassedTimes = 0;//����
    public float FireTime = 3.0f;//����

    bool Dead = false;//�ߏ萶���h�~

    //���ȍ��W
    float x;
    float y;

    //��
    private AudioSource audioSource;
    public AudioClip Fire_SE;

    void Start()
    {
        GateTransform = transform.Find("gate");
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
        audioSource = GetComponent<AudioSource>();
        //Transform myTransform = this.transform;
        //Vector2 WorldPos = myTransform.position;
        //if(WorldPos.x<0)
        //{
        //    new Vector2(100, 1),
        //       speed);
        //}
        //else
        //{
        //    new Vector2(-100, 1),
        //       speed);
        //}
    }

    void Update()
    {
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        PassedTimes += Time.deltaTime;//���Ԍo��
        //�[�[���Ɉړ�
        transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(Zeere.position.x, worldPos.y),
               Speed * Time.deltaTime);
        if (PassedTimes >= FireTime)
        {
            PassedTimes = 0; //���Ԃ��O�Ƀ��Z�b�g

            //�C�e���v���n�u������
            Vector2 pos = new Vector2(GateTransform.position.x,
                GateTransform.position.y);
            GameObject obj = Instantiate(Bullet, pos, Quaternion.identity);
            //�w��̕����ɔ��˂���
            Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
            Vector2 v = new Vector2(0, 2) * FireSpeed;
            rbody.AddForce(v, ForceMode2D.Impulse);
            audioSource.PlayOneShot(Fire_SE);
        }
        if (GetComponent<BoxCollider2D>().enabled == false&&Dead==false)//�����蔻��ɂ�鎀�S�m�F
        {
            x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
            y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
            Instantiate(Heal, new Vector2(x, y), Quaternion.identity);//�n�[�g����
            Dead = true;//�ߏ萶���h�~
        }

        void FixedUpdate()
        {
            //�n�㔻��
            bool onGround = Physics2D.CircleCast(transform.position, //���ˈʒu
                                                 1.8f,               //�~�̔��a
                                                 Vector2.down,       //���˕���
                                                 0.0f,               //���ˋ���
                                                 groundLayer);       //���o���郌�C���[
        }
    }
}

