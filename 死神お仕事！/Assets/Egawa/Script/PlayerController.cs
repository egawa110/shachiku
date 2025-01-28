using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    
    float axisH = 0.0f;               //����
    public float Speed = 3.0f;        //�ړ����x
    public float Jump = 10.0f;         //�W�����v��
    public LayerMask groundLayer;     //���n�ł��郌�C���[
    bool goJump = false;              //�W�����v�J�n�t���O

    //�v���C���[�̑������n�ʂ��ǂ����𔻒肷��ׂɎg�p����ϐ�
    private float Radius_Cicle = 0.7f;       //�~�̔��a
    private float Firing_Distance = 1.0f;    //���ˋ���

    Vector2 Left = new Vector2(-1, 1);     //������
    Vector2 Right = new Vector2(1, 1);     //�E����

    //�A�j���[�V�����Ή�
    Animator animator; //�A�j���[�^�[
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";

    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";// �Q�[���̏��

    //�ǉ�
    public int ALL_SOUL = 0;      //1�X�e�[�W�Ŏ擾�������ׂĂ̍�

    //�U���p�ϐ�
    [SerializeField] private GameObject bullet;     //�o���b�g�v���n�u���i�[
    [SerializeField] private Transform attackPoint; //�A�^�b�N�|�C���g���i�[

    [SerializeField] private float attackTime = 0.2f; //�U���Ԋu
    public float fireSpeed = 8.0f;

    private float currentAttackTime;    //�U���̊Ԋu���Ǘ�
    private bool canAttack;             //�U���\��Ԃ����w�肷��t���O

    public int maxHp = 4;      //�v���C���[�̍ő�Hp
    int Hp;                    //�v���C���[�̌���Hp
    private bool inDamage = false;  //�_���[�W���̃t���O


    // �T�E���h�Đ�
    private AudioSource audioSource; // �I�[�f�B�I�\�[�X
    public AudioClip Jump_SE;        // �W�����v
    public AudioClip Damage_SE;      // �_���[�W��H�炤
    public AudioClip GetSoul_SE;     // �������
    public AudioClip Attack_SE;      // �U������
    public AudioClip Switch_Act_SE;  // �X�C�b�`���|�`�b�Ƃ���
    public AudioClip Clear_SE;       // �Q�[���N���A�[
    public AudioClip Over_SE;        // �Q�[���I�[�o�[

    public AudioSource BGM;//�N���A���A�܂��̓Q�[���I�[�o�[����BGM���~�߂�


    void Start()
    {
        //FPS��60�ɌŒ�
        Application.targetFrameRate = 60;

        //Rigidbod2D������Ă���
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
        animator = GetComponent<Animator>();      //Animator������Ă���
        nowAnime = stopAnime;                     //��~����J�n����
        oldAnime = stopAnime;                     //��~����J�n����

        gameState = "playing";//�Q�[�����ɂ���

        //currentAttackTime��attackTime���Z�b�g�B
        currentAttackTime = attackTime;
       
        //AudioSouce���擾
        audioSource = GetComponent<AudioSource>();

        Hp = maxHp;       // Hp�ƍő�Hp�𓯂��l�ɂ���
    }


    //�A�b�v�f�[�g�֐�
    //����
    //�v���C���[�̓��͂𔻒肷�邽��
    void Update()
    {
        //�|�[�Y��ʂ��o�Ă�Ԃ̓A�b�v�f�[�g�֐��𔲂���
        if (Time.timeScale == 0)
        {
            return;
        }
        //�Q�[�����v���C������Ȃ����A
        //�܂��̓_���[�W���󂯂Ă���Œ��̓A�b�v�f�[�g�֐��𔲂���
        if (gameState != "playing" || inDamage)
        {
            return;
        }

        //���������̓��͂��`�F�b�N
        axisH = Input.GetAxisRaw("Horizontal");

        //�����̒���
        if (axisH > 0.0f)
        {
            transform.localScale = Right;
        }
        else  if (axisH < 0.0f)
        {
            transform.localScale = Left;
        }

        //��Ƀv���C���[�̕������x�E�d�͂̒l�E�W�����v�͂�
        //���̒l�ɂ�������
        Speed = 3.0f;
        rbody.gravityScale = 1.1f;
        Jump = 10.0f;

        //�L�����N�^�[���W�����v������
        if (Input.GetButtonDown("Jump"))
        {
            goJump = true;      //�W�����v�t���O�𗧂Ă�
        }

        //�_�b�V��
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //Shift�L�[���������Ƃ��ɁA�������x�E�d�͂̒l�E�W�����v�͂�ύX
            Speed = 5.0f;
            rbody.gravityScale = 1.5f;
            Jump = 11.0f;
        }
        //��l���̍U��
        Attack();
    }

    //
    void FixedUpdate()
    {
        //�Q�[�����v���C������Ȃ����A�A�b�v�f�[�g�֐��𔲂���
        if (gameState != "playing")
        {
            return;
        }

        //�_���[�W���󂯂Ă���Œ��̏���
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
           return; // �_���[�W���͑���ɂ��ړ��������Ȃ�
        }

        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position,    //���ˈʒu
                                             Radius_Cicle,                  //�~�̔��a
                                             Vector2.down,          //���˕���
                                             Firing_Distance,                  //���ˋ���
                                             groundLayer);          //���o���郌�C���[
        if (onGround || axisH != 0)
        {
            //���x���X�V����
            rbody.velocity = new Vector2(axisH * Speed, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            //�n�ʂ̏�ŃW�����v�L�[�������ꂽ
            //�W�����v������
            Vector2 jumpPw = new(0, Jump);                  //�W�����v������x�N�g�������
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //�u�ԓI�ȗ͂�������
            goJump = false;
            //�W�����v����炷
            audioSource.PlayOneShot(Jump_SE);
        }
        //�A�j���[�V�����X�V
        if (onGround)
        {
            // �n�ʂ̏�
            if (axisH == 0)
            {
                nowAnime = stopAnime; 		// ��~��
            }
            else
            {
                nowAnime = moveAnime;  		// �ړ�
            }
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);        // �A�j���[�V�����Đ�
        }
    }


    //�U��
    public void Attack()
    {
        attackTime += Time.deltaTime; //attackTime�ɖ��t���[���̎��Ԃ����Z���Ă���

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //�w�莞�Ԃ𒴂�����U���\�ɂ���
        }

        if (Input.GetMouseButtonDown(0)) // ���N���b�N������
        {
            if (canAttack)
            {
                GameObject playerObj = GameObject.Find("Player");
                audioSource.PlayOneShot(Attack_SE);

                if (playerObj.transform.localScale.x > 0)//�E����
                {
                    Vector2 pos = new Vector2(attackPoint.position.x,
                    attackPoint.position.y);
                    GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
                    //���j�������Ă�����ɔ��˂���
                    Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                    float angleZ = transform.localEulerAngles.z;
                    float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                    Vector2 v = new Vector2(x, y) * fireSpeed;
                    rbody.AddForce(v, ForceMode2D.Impulse);
                }
                else if (playerObj.transform.localScale.x < 0)//������
                {
                    Vector2 pos = new Vector2(attackPoint.position.x,
                    attackPoint.position.y);
                    GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
                    //���j�������Ă�����ɔ��˂���
                    Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                    float angleZ = transform.localEulerAngles.z;
                    float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                    Vector2 v = new Vector2(-x, y) * fireSpeed;
                    rbody.AddForce(v, ForceMode2D.Impulse);
                }
                canAttack = false; //�U���t���O��false�ɂ���
                attackTime = 0f;�@ //attackTime��0�ɖ߂�
            }
        }
    }
    //void ShotBullet(Vector2 vector2)
    //{
    //    Vector2 pos = new Vector2(attackPoint.position.x,
    //    attackPoint.position.y);
    //    GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
    //    //���j�������Ă�����ɔ��˂���
    //    Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
    //    float angleZ = transform.localEulerAngles.z;
    //    float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
    //    float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
    //    Vector2 v = new Vector2(x, y) * fireSpeed;
    //    rbody.AddForce(v, ForceMode2D.Impulse);
    //}

    //�ڐG�J�n
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag=="Dead" || collision.gameObject.tag=="ZeereCore")
        {
            GameOver(); //�Q�[���I�[�o�[
        }
        else if (collision.gameObject.tag=="Soul")
        {
            ALL_SOUL++;
            //����炷
            audioSource.PlayOneShot(GetSoul_SE);
            // �폜����
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag=="Enemy")
        {
            GetDamage(collision.gameObject);
            //�G�ɓ����������ɉ���炷
            audioSource.PlayOneShot(Damage_SE);
        }
        else if(collision.gameObject.tag == "Switch")
        {
            // �X�C�b�`�ɐG�ꂽ�特��炷
            audioSource.PlayOneShot(Switch_Act_SE);
        }
        else if(collision.gameObject.tag == "Heal")
        {
            Hp++;
            Destroy(collision.gameObject);
        }
    }

    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            Hp--; //hp������

            if (Hp > 0)
            {
                //�ړ���~
                rbody.velocity = new Vector2(0, 0);
                //�G�L�����̔��Ε����Ƀq�b�g�o�b�N������
                Vector3 v = (transform.position - enemy.transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4.5f, v.y * 4.5f), ForceMode2D.Impulse);
                //�_���[�W�t���O�@ON
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.7f);
            }
            else if(Hp == 0)
            {
                //�Q�[���I�[�o�[
                GameOver();
            }
        }
    }

    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false; // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // �X�v���C�g�����ɖ߂�
    }

    // �S�[��
    public void Goal()
    {
        BGM.gameObject.SetActive(false);
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();             // �Q�[����~
        //���y��炷
        audioSource.PlayOneShot(Clear_SE);
    }
    // �Q�[���I�[�o�[
    public void GameOver()
    {
        BGM.gameObject.SetActive(false);
        animator.Play(deadAnime);
        gameState = "gameover"; GameStop();
        // �Q�[����~�i�Q�[���I�[�o�[���o�j
        // �v���C���[�����������
        GetComponent<BoxCollider2D>().enabled = false;
        // �v���C���[����ɏ������ˏグ�鉉�o
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //���y��炷
        audioSource.PlayOneShot(Over_SE);
    }
    //�Q�[����~
    void GameStop()
    {
        //Rigidbody2D������Ă���
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //���x���O�ɂ��ċ�����~
        rbody.velocity = new Vector2(0, 0);
    }
  
}