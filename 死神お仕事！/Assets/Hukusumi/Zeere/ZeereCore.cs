using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeereCore : MonoBehaviour
{
    //�ړ��o�H
    Transform Reel;
    //�v���n�u
    [SerializeField] GameObject Samon;//�������@�w
    [SerializeField] GameObject Ritning;//������
    [SerializeField] GameObject Rain;//�J
    [SerializeField] GameObject Rite;//���G�t�F�N�g
    [SerializeField] GameObject Beem;//�r�[��
    [SerializeField] GameObject Helo;//�w�C���[
    [SerializeField] GameObject BossEnd;//���S���[�[���ȊO�̃_���[�W�������O
    [SerializeField] GameObject GameClear;//�S�[��
    [SerializeField] GameObject Fadeout;//�t�F�[�h�A�E�g
    [SerializeField] GameObject HeloNull;//�w�C���[�j��
    [SerializeField] GameObject KillEffect;//���S���ɓf��
    [SerializeField] GameObject SoulEat;//�N�����ɋz��

    //���S������
    public GameObject GameUI;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    Transform STg;//�����ʒu
    Transform BoostTraget;//�ːi���b�N�I��
    public Transform Target;//�r�[�����b�N�I��
    float PassedTimes = 0;//�A�N�V�����̎��Ԍo��
    float coorTime = 0;
    [SerializeField] float Speed = 5; // �G�̓����X�s�[�h

    public float DAngle = 180.0f;//�����p�x

    float x;
    float y;

    //�ːi�n
    float ATspeed = 10.0f;//�ːi���x
    float BsCT = 3.0f;//���b�N�I������

    public float Attack = 10;//�U��CT

    float SamonC = 0;//�����J�E���^�[
    public float Samonfrequency = 3;//������

    int rnd;//����
    
    //���J�n
    public float R = 0.5f;//��������
    float Rx;//��x
    public float Ry = 20.0f;//��y
    public float PRX = 1.0f;//�����炵
    public float Boder = 10.0f;//���I�[�o�[�����h�~

    public bool Go = false;//�[�[���N��
    bool GoOK = false;//�C�x���g�m�F

    bool Cool = false;//�����p
    bool Cool2 = false;//�����p2
    bool Cool3 = false;//�����p3
    //�U���N��
    bool AttackLooc = true;//�U���������m�F
    bool BusteAttack = false;//�ːi�N���p
    bool SamonAttack = false;//�����N���p
    bool RitoningAttack = false;//���J�N���p
    bool ReeserAttack = false;//�r�[���N���p

    //�A�����U���֎~
    bool BusteLooc = false;//�ːi���b�N
    bool SamonLooc = false;//�������b�N
    bool RitoningLooc = false;//���J���b�N
    bool ReeserLooc = false;//�r�[�����b�N
    bool LongLooc = false;//�������b�N

    bool EndF = false;//���j�t���O
    bool Crear = false;//�N���A�o��
    bool Fade = false;//�t�F�[�h�I�u�W�F�t���O

    //HP
    public int HP_M = 40;//�̗̓}�b�N�X
    int HP_z;    //�G�̗̑�
    private bool inDamage;  //�_���[�W���̃t���O
    public Slider slider;//�X���C�_�[
    bool HalfC = false;

    //�[�[���̃p�[�c
    GameObject Zeere1;//����
    GameObject Zeere2;//����
    GameObject Zeere3;//�J�o�[
    //GameObject Zeere4;//�E��
    //GameObject Zeere5;//����

    //��
    private AudioSource audioSource;
    public AudioClip Samon_SE;//������
    public AudioClip BootZeere_SE;//�N����
    public AudioClip Boost_SE;//�ːi��
    public AudioClip Attack_SE;//���ˉ�
    public AudioClip AttackC_SE;//�`���[�W��
    public AudioClip Ritoning_SE;//�d����
    public AudioClip ZVoiceA;//����A
    public AudioClip ZVoiceB;//����B
    public AudioClip ZeereON_SE;//����1
    public AudioClip ZeereON2_SE;//����2
    public AudioClip Break_SE;//�g�h���_���[�W��
    public AudioClip Foor_SE;//������
    public AudioClip Damage_SE;//�_���[�W��

    //BGM
    //�C���g��
    public AudioSource Start_BGM;
    public GameObject targetBGMS;
    //���[�v
    public AudioSource Loop_BGM;
    public GameObject targetBGM;

    //�X�^�[�g
    private void Start()
    {
        HP_z = HP_M;
        Rx = R;
        slider.value = HP_M;
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        BoostTraget = GameObject.FindGameObjectWithTag("PlayerLoocon").transform;
        STg = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("Zeerecenter");
        Zeere2 = GameObject.Find("ZeereEye");
        Zeere3 = GameObject.Find("ZeereKabar");

        audioSource = GetComponent<AudioSource>();
    }
    //�A�b�v�f�[�g
    private void Update()
    {
        PassedTimes += Time.deltaTime;//���Ԍo��
        //���g�̈ʒu
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
        y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
        if (Go == true)
        {
            if (inDamage)
            {
                //�_���[�W���A�_�ł�����
                float val = Mathf.Sin(Time.time * 50);
                if (val > 0)
                {
                    RendererTrue();
                }
                else
                {
                    //�X�v���C�g���\��
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                RendererTrue();
            }
        }
        //�N���O
        if (Go==false)
        {

            PassedTimes = 0;
            //�ҋ@�ꏊ�ֈړ�
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -4.5f),
               Speed * Time.deltaTime);
        }
        //�N��
        if(Go==true&&GoOK==false)
        {
            if(PassedTimes>1)
            {
                ZeereEye Eyeon = Zeere2.GetComponent<ZeereEye>();
                Eyeon.ON();
            }
            if (PassedTimes > 2)
            {
                //�w��ʒu�ɏ㏸
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(0, 3),
                   1 * Time.deltaTime);
                if(Cool3==false)
                {
                    Cool3 = true;
                    audioSource.PlayOneShot(ZeereON_SE);

                    BGMS BGMLS = targetBGMS.GetComponent<BGMS>();
                    BGMLS.BS();
                    
                }
            }
            if (PassedTimes >= 4&& PassedTimes <= 5)
            {
                if(Cool2==false)
                {
                    Cool2 = true;
                    audioSource.PlayOneShot(ZeereON2_SE);
                    BGM BGML = targetBGM.GetComponent<BGM>();
                    BGML.Loop();
                }
                Create(SoulEat, x, y);
            }

            if (PassedTimes>7&&Cool==false)
            {
                Cool = true;
                Create(Helo, x, y);
            }
            if(PassedTimes>8&&Cool2==true)
            {
                Voice();
                Cool2 = false;
            }
            if(PassedTimes>10)
            {
                slider.gameObject.SetActive(true);
                ReeserAttack = !ReeserAttack;
                ReeserLooc = !ReeserLooc;
                PassedTimes = 0;
                coorTime = 0;
                GoOK = true;
                Cool = false;
                Cool3 = false;
            }
        }

        
        //�ːi����
        if (Cool == true && GoOK == true && EndF == false)
        {
            coorTime += Time.deltaTime;//���Ԍo��
            if (coorTime > BsCT)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
        //�U������
        rnd = Random.Range(1, 6);
        if (PassedTimes > Attack)
        {
            if (AttackLooc == false)//�N���p
            {
                if (rnd == 1 && BusteLooc == false)//�ːiON
                {
                    PlayerLoocon LCO = BoostTraget.GetComponent<PlayerLoocon>();
                    LCO.Reset();
                    BusteAttack = !BusteAttack;
                    ONReset();
                }
                if (rnd == 2 && SamonLooc == false)//����ON
                {
                    SamonAttack = !SamonAttack;
                    ONReset();
                    Voice();
                }
                if (rnd == 3 && RitoningLooc == false)//���JON
                {
                    RitoningAttack = !RitoningAttack;
                    ONReset();
                    audioSource.PlayOneShot(BootZeere_SE);
                    audioSource.PlayOneShot(ZeereON2_SE);
                }
                if (rnd == 4 && ReeserLooc == false)//�r�[��ON
                {
                    ReeserAttack = !ReeserAttack;
                    ONReset();
                }
                if (rnd == 5 && LongLooc == false)//�ҋ@
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    PassedTimes = 0;
                    LongLooc = true;
                }

                //��������
                //if (Input.GetKeyDown(KeyCode.L))//�ːiON
                //{
                //    AttackLooc = !AttackLooc;
                //    BusteAttack = !BusteAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
                //if (Input.GetKeyDown(KeyCode.M))//����ON
                //{
                //    AttackLooc = !AttackLooc;
                //    SamonAttack = !SamonAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
                //if (Input.GetKeyDown(KeyCode.R))//���JON
                //{
                //    AttackLooc = !AttackLooc;
                //    RitoningAttack = !RitoningAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
                //if (Input.GetKeyDown(KeyCode.B))//�r�[��ON
                //{

                //    AttackLooc = !AttackLooc;
                //    ReeserAttack = !ReeserAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
            }
        }



        if (AttackLooc == false)//�ҋ@���
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Reel.position.x, Reel.position.y),
                Speed * Time.deltaTime);
            if(transform.localEulerAngles.z<DAngle)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else if (transform.localEulerAngles.z > DAngle)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            }
        }


        if (BusteAttack == true)//�ːi
        {

            if (PassedTimes < 3)
            {
                // �Ώە��ւ̃x�N�g�����Z�o
                Vector3 toDirection = BoostTraget.transform.position - transform.position;
                // �Ώە��։�]����
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            }
            if (PassedTimes < 3 && Cool2 == false)
            {
                Cool2 = true;
                audioSource.PlayOneShot(AttackC_SE);
            }
            if (PassedTimes >= 3)
            {
                if (Cool2 == true)
                {
                    Cool2 = false;
                    audioSource.PlayOneShot(Boost_SE);
                }
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, ATspeed, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
                SamonLooc = false;
                RitoningLooc = false;
                ReeserLooc = false;
                LongLooc = false;
            }
        }


        if (SamonAttack == true)//����
        {
            transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            coorTime += Time.deltaTime;//���Ԍo��
            
            if (SamonC < Samonfrequency)
            {
                
                if (coorTime > 0.5)
                {
                    SamonC += 1;
                    coorTime = 0;
                    // ��������
                    Transform STGT = STg.transform;
                    Vector2 SamonPos = STGT.position;
                    float Sx = SamonPos.x;
                    float Sy = SamonPos.y;
                    Create(Samon, Sx, Sy);
                    audioSource.PlayOneShot(Samon_SE);
                }
               
            }
            if (PassedTimes > 4)
            {
                //���Z�b�g
                BusteLooc = false;
                RitoningLooc = false;
                ReeserLooc = false;
                AttackReset();
            }
        }


        if (RitoningAttack == true)//���J
        {
            //�w��ʒu�Ɉړ�
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(0, 3),
                Speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            if (SamonC<2)
            {
                SamonC+=1;
                Create(Rain, 0, 7);
            }
            if (PassedTimes > 4)
            {

                if (Cool == false)
                {
                    Create(Ritning, Rx, Ry);
                    Create(Ritning,-Rx, Ry);
                    Rx += PRX;
                }
                if (PassedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Create(Rite, 0, 3);
                    audioSource.PlayOneShot(Ritoning_SE);
                }
                if (Rx > Boder)
                {
                    //�ߏ萶���h�~
                    Cool = true;
                }
                if (PassedTimes > 4.5)
                {
                    //���Z�b�g         
                    BusteLooc = false;
                    SamonLooc = false;
                    ReeserLooc = false;
                    AttackReset();

                }
            }
        }


        if (ReeserAttack == true)//�r�[��
        {
            transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            if (SamonC < 1)
            {
                SamonC += 1;
                Transform HeroTransform = Target.transform;
                Vector2 HeroPos = HeroTransform.position;
                float Bx = HeroPos.x;
                Create(Beem, Bx, 0);
                Create(Beem,-Bx, 0);
            }
            if (PassedTimes > 3.1)
            {
                //���Z�b�g
                BusteLooc = false;
                SamonLooc = false;
                RitoningLooc = false;
                AttackReset();
            }
        }

        if(EndF==true)//���j
        {
            if(PassedTimes>1)
            {
                //�w������ɗ���
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(x, -10),
                   0.9f * Time.deltaTime);
                if(Cool==false)
                {
                    Cool = true;
                    Create(KillEffect, x, y);
                    Voice();
                    audioSource.PlayOneShot(Foor_SE);
                }
            }
            if (PassedTimes > 5)
            {
                //�t�F�[�h�A�E�g
                if(Fade==false)
                {
                    Fade = true;
                    Create(Fadeout, 0, 0);
                    Voice();
                }
            }
            if (PassedTimes > 10 && Crear == false)
            {
                //�N���A
                GameObject obj = Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                Crear = true;
            }
        }
        //��������
        if(HP_z<=HP_M/2&&AttackLooc==false&&HalfC==false)
        {
            HalfC = true;
            ATspeed = ATspeed/2;
            BsCT = BsCT/2;
        }

    }

    void Voice()//����
    {
        audioSource.PlayOneShot(ZVoiceA);
        audioSource.PlayOneShot(ZVoiceB);
    }

    void RendererTrue()//�p�[�c�\��
    {
        //�X�v���C�g��\��
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Zeere1.GetComponent<SpriteRenderer>().enabled = true;
        Zeere2.GetComponent<SpriteRenderer>().enabled = true;
        Zeere3.GetComponent<SpriteRenderer>().enabled = true;
    }

    void ONReset()//���Z�b�g(�N��)
    {
        AttackLooc = true;
        BusteLooc = true;
        SamonLooc = true;
        RitoningLooc = true;
        ReeserLooc = true;
        PassedTimes = 0;
        coorTime = 0;
    }
    void AttackReset()//���Z�b�g
    {
        Rx = R;
        PassedTimes = 0;
        coorTime = 0;
        AttackLooc = false;
        SamonC = 0;
        Cool = false;
        SamonAttack = false;
        RitoningAttack = false;
        ReeserAttack = false;
        LongLooc = false;
    }

    public void Zeereon()//�N���X�C�b�`
    {
        Go = true;
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (EndF == false)
        {
            if (HP_z > HP_M / 2)
            {
                if (other.CompareTag("Ground") && BusteAttack == true)
                {//���Z�b�g
                    BusteAttack = false;
                    PassedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }
            else//�㔼��
            {
                if (other.CompareTag("OverGround") && BusteAttack == true)
                {
                    //���Z�b�g
                    BusteAttack = false;
                    PassedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }

            if (other.CompareTag("Wall") && BusteAttack == true)
            {
                //���Z�b�g
                BusteAttack = false;
                PassedTimes = 0;
                coorTime = 0;
                Cool = true;
                audioSource.PlayOneShot(Attack_SE);
            }
        }
        if (other.gameObject.tag == "Bullet")
        {
            // �U�����ꂽ���̃G�t�F�N�g
            GetDamage(other.gameObject);
        }

    }

    void GetDamage(GameObject player)
    {
        if (PlayerBoss.gameState == "playing")
        {
            HP_z--; //hp������
            slider.value = HP_z;
            Debug.Log(HP_z);
            if (HP_z > 0)
            {
                //�_���[�W�t���O�@ON
                inDamage = true;
                audioSource.PlayOneShot(Damage_SE);
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                //UI&BGM��~
                GetComponent<BoxCollider2D>().enabled = false;
                GameManager S5UI = GameUI.GetComponent<GameManager>();
                S5UI.BossKill();
                Loop_BGM.gameObject.SetActive(false);
                Start_BGM.gameObject.SetActive(false);
                Destroy(Heart1);
                Destroy(Heart2);
                Destroy(Heart3);
                Destroy(Heart4);
                //�����
                AttackLooc = true;
                BusteAttack = false;
                SamonAttack = false;
                RitoningAttack = false;
                ReeserAttack = false;
                slider.gameObject.SetActive(false);
                audioSource.PlayOneShot(Break_SE);
                if (EndF ==false)
                {
                    PassedTimes = 0;
                    EndF = true;
                    Create(BossEnd, 0, 0);
                    Create(HeloNull, x, y);
                }
                

            }
        }
    }

    void Create(GameObject v, float Cx, float Cy)//�v���n�u����
    {
        Instantiate(v, new Vector2(Cx, Cy), Quaternion.identity);
    }

    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false; // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // �X�v���C�g�����ɖ߂�
    }
}
