using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    float axisH = 0.0f;               //����
    public float speed = 3.0f;        //�ړ����x

    public float jump = 9.0f;         //�W�����v��
    public LayerMask groundLayer;     //���n�ł��郌�C���[
    bool goJump = false;              //�W�����v�J�n�t���O


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
    private float currentAttackTime;                  //�U���̊Ԋu���Ǘ�
    private bool canAttack;                           //�U���\��Ԃ����w�肷��t���O

    public int HP_P = 4;      //�v���C���[�̗̑�
    bool inDamage = false;  //�_���[�W���̃t���O

    // �T�E���h�Đ�
    private AudioSource audioSource;
    public AudioClip Jump_SE;
    public AudioClip Damage_SE;
    public AudioClip GetSoul_SE;
    public AudioClip Over_SE;
    public AudioClip Clear_SE;

    // Start is called before the first frame update
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

        currentAttackTime = attackTime; //currentAttackTime��attackTime���Z�b�g�B
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }

        //���������̓��͂��`�F�b�N
        axisH = Input.GetAxisRaw("Horizontal");

        //�����̒���
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }

        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        //�L�����N�^�[���W�����v������
        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }

        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position, //���ˈʒu
                                             1.8f,               //�~�̔��a
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
            //�W�����v����炷
            audioSource.PlayOneShot(Jump_SE);

            //�n�ʂ̏�ŃW�����v�L�[�������ꂽ
            //�W�����v������
            Vector2 jumpPw = new Vector2(0, jump);  //�W�����v������x�N�g�������
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //�u�ԓG�ȗ͂�������
            goJump = false; //�W�����v�t���O�����낷
        }
        //�A�j���[�V�����X�V
        if (onGround)
        {
            //�n�ʂ̏�
            if (axisH == 0)
            {
                nowAnime = stopAnime; //��~�� 
            }

            else
            {
                nowAnime = moveAnime; //�ړ�
            }
        }
        else
        {
            //��
            nowAnime = jumpAnime;
        }
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);  //�A�j���[�V�����Đ�
        }
    }

    //�W�����v
    public void Jump()
    {
        goJump = true; //�W�����v�t���O�𗧂Ă�
    }

    //�U��
    public void Attack()
    {
        attackTime += Time.deltaTime; //attackTime�ɖ��t���[���̎��Ԃ����Z���Ă���

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //�w�莞�Ԃ𒴂�����U���\�ɂ���
        }

        if (Input.GetKeyDown(KeyCode.Z)) //Z�L�[����������
        {
            if (canAttack)
            {
                GameObject playerObj = GameObject.Find("Player");
                if (playerObj.transform.localScale.x >= 0)
                {
                    CreateBullet();
                }
            }
        }
    }

    public void CreateBullet()
    {
        //�������ɐ�������I�u�W�F�N�g�A��������Vector3�^�̍��W�A��O�����ɉ�]�̏��
        Instantiate(bullet, attackPoint.position, Quaternion.identity);
        canAttack = false; //�U���t���O��false�ɂ���
        attackTime = 0f;�@ //attackTime��0�ɖ߂�
    }

    //�ڐG�J�n
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead"|| collision.gameObject.tag == "ZeereCore")
        {
            GameOver(); //�Q�[���I�[�o�[
        }
        else if (collision.gameObject.tag == "Soul")
        {
            //���擾����
            Souls item = collision.gameObject.GetComponent<Souls>();
            ALL_SOUL += item.soul_one;
            // �I�u�W�F�N�g�폜����
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
            //�G�ɓ����������ɉ���炷
            audioSource.PlayOneShot(Damage_SE);
        }
    }

    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            HP_P--; //hp������
            if (HP_P > 0)
            {
                //�ړ���~
                rbody.velocity = new Vector2(0, 0);
                //�G�L�����̔��Ε����Ƀq�b�g�o�b�N������
                Vector3 v = (transform.position - enemy.transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
                //�_���[�W�t���O�@ON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
            else
            {
                //�Q�[���I�[�o�[
                GameOver();
            }
        }
    }

    // �S�[��
    public void Goal()
    {
        animator.Play(goalAnime);

        //���y��炷
        audioSource.PlayOneShot(Clear_SE);

        gameState = "gameclear";
        GameStop();
    }
    // �Q�[���I�[�o�[
    public void GameOver()
    {
        animator.Play(deadAnime);

        //���y��炷
        audioSource.PlayOneShot(Over_SE);

        gameState = "gameover";
        GameStop();
        //---------------------
        //�Q�[���I�[�o�[���o
        //---------------------
        //�v���C���[�����������
        //---------------------
        GetComponent<BoxCollider2D>().enabled = false;
        //�v���C���[����ɏ������ˏグ�鉉�o
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
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
    

