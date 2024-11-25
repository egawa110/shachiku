using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerC : MonoBehaviour
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
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        animator = GetComponent<Animator>();        //Animator ������Ă���
        nowAnime = stopAnime;                       //��~����J�n����
        oldAnime = stopAnime;                       //��~����J�n����
        gameState = "playing";                      //�Q�[�����ɂ���

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (gameState != "playing" || inDamage)
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
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
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
    // �ڐG�J�n
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();        // �S�[���I�I
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();    // �Q�[���I�[�o�[
        }

        //�ǉ�
        else if (collision.gameObject.tag == "Soul")
        {
            //����炷
            audioSource.PlayOneShot(GetSoul_SE);
            //���擾����
            Souls item = collision.gameObject.GetComponent<Souls>();
            ALL_SOUL += item.soul_one;
            // �폜����
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
            audioSource.PlayOneShot(Damage_SE);
        }
    }

    //�_���[�W
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            HP_P--; //hp������
            if (HP_P > 0)
            {
                animator.Play(deadAnime);
                //�ړ���~
                rbody.velocity = new Vector2(0, 0);
                //�G�L�����̔��Ε����Ƀm�b�N�o�b�N������
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

    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false; // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // �X�v���C�g�����ɖ߂�
    }
    // �S�[��
    public void Goal()
    {
        //���y��炷
        audioSource.PlayOneShot(Clear_SE);

        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();             // �Q�[����~
    }

    // �Q�[���I�[�o�[
    public void GameOver()
    {
        //���y��炷
        audioSource.PlayOneShot(Over_SE);

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
