using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_s : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�
    float axisH = 0.0f;             //����
    public float speed = 3.0f;      //�ړ����x
    public float jump = 9.0f;       //�W�����v��
    public LayerMask groundLayer;   //���n�ł��郌�C���[
    bool goJump = false;            //�W�����v�J�n�t���O
    // �A�j���[�V�����Ή�
    Animator animator; // �A�j���[�^�[
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";
    string nowAnime = "";
    string oldAnime = "";
    public static string gameState = "playing"; // �Q�[���̏��

    //�ǉ�
    public int ALL_SOUL = 0;      //1�X�e�[�W�Ŏ擾�������ׂĂ̍�

    //�U���p�ϐ�
    [SerializeField] private GameObject bullet; //�o���b�g�v���n�u���i�[
    [SerializeField] private Transform attackPoint;//�A�^�b�N�|�C���g���i�[

    [SerializeField] private float attackTime = 0.2f; //�U���Ԋu
    private float currentAttackTime; //�U���̊Ԋu���Ǘ�
    private bool canAttack; //�U���\��Ԃ����w�肷��t���O
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        animator = GetComponent<Animator>();        //Animator ������Ă���
        nowAnime = stopAnime;                       //��~����J�n����
        oldAnime = stopAnime;                       //��~����J�n����
        gameState = "playing";                      // �Q�[�����ɂ���

        currentAttackTime = attackTime; //currentAttackTime��attackTime���Z�b�g�B
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }
        //���������̓��͂��`�F�b�N����
        axisH = Input.GetAxisRaw("Horizontal");
        //�����̒���
        if (axisH > 0.0f)
        {
            //�E�ړ�
            Debug.Log("�E�ړ�");
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            Debug.Log("���ړ�");
            transform.localScale = new Vector2(-1, 1);
        }

        //�L�����N�^�[���W�����v������
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //��l���̍U��
        Attack();
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        //�n�㔻��
        bool onGround = Physics2D.CircleCast(transform.position,    //���ˈʒu
                                             1.8f,                  //�~�̔��a
                                             Vector2.down,          //���˕���
                                             0.0f,                  //���ˋ���
                                             groundLayer);          //���o���郌�C���[
        if (onGround || axisH != 0)
        {
            //���x���X�V����
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            //�n�ʂ̏�ŃW�����v�L�[�������ꂽ
            //�W�����v������
            Vector2 jumpPw = new Vector2(0, jump);          //�W�����v������x�N�g�������
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //�u�ԓI�ȗ͂�������
            goJump = false;
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
        else
        {
            // ��
            nowAnime = jumpAnime;
        }
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);        // �A�j���[�V�����Đ�
        }

    }

    //�W�����v
    public void Jump()
    {
        goJump = true;                      //�W�����v�t���O�𗧂Ă�
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
                else
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

    // �ڐG�J�n
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();        // �S�[���I�I
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();     // �Q�[���I�[�o�[
        }
        
        //�ǉ�
        else if (collision.gameObject.tag == "Soul")
        {
                //���擾����
                Souls item = collision.gameObject.GetComponent<Souls>();
                ALL_SOUL += item.soul_one;
                // �I�u�W�F�N�g�폜����
                Destroy(collision.gameObject);
        }
    }

    // �S�[��
    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();             // �Q�[����~
    }
    
    // �Q�[���I�[�o�[
    public void GameOver()
    {
        animator.Play(deadAnime);
        gameState = "gameover"; GameStop();
        // �Q�[����~�i�Q�[���I�[�o�[���o�j
        // �v���C���[�����������
        GetComponent<CapsuleCollider2D>().enabled = false;
        // �v���C���[����ɏ������ˏグ�鉉�o
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    // �Q�[����~
    void GameStop()
    {
        // Rigidbody2D������Ă���
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        // ���x�� 0 �ɂ��ċ�����~
        rbody.velocity = new Vector2(0, 0);
    }
}
