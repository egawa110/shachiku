using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] GameObject Samon;
    [SerializeField] GameObject Ritning;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Rite;
    [SerializeField] GameObject Beem;
    [SerializeField] GameObject Helo;
    [SerializeField] GameObject BossEnd;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject Fadeout;
    [SerializeField] GameObject HeloNull;
    [SerializeField] GameObject KillEffect;
    [SerializeField] GameObject SoulEat;

    public GameObject GameUI;

    public GameObject LoocON;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    Transform gateTransform;
    Transform BoostTraget;
    public Transform target;
    float passedTimes = 0;
    float BGMTime = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // �G�̓����X�s�[�h

    //�ːi�n
    float ATspeed = 10.0f;
    public float Attack = 10;
    float BsCT = 3.0f;

    float SamonC = 0;//�����J�E���^�[

    int rnd;//����
    
    public float r = 0.5f;//��������
    float rx;//��x
    public float ry = 20.0f;//��y
    public float prx = 1.0f;//�����炵
    public float boder = 10.0f;//���I�[�o�[�����h�~

    public bool GO = false;//�[�[���N��
    bool GoOK = false;//�C�x���g�m�F

    bool Cool = false;//�����p
    bool Cool2 = false;//�����p2
    bool Cool3 = false;//�����p3
    bool AttackLooc = true;//�N���p
    bool BusteAttack = false;//�ːi�N���p
    bool SamonAttack = false;//�����N���p
    bool RitoningAttack = false;//���J�N���p
    bool ReeserAttack = false;//�r�[���N���p

    bool BusteLooc = false;//�ːi���b�N
    bool SamonLooc = false;//�������b�N
    bool RitoningLooc = false;//���J���b�N
    bool ReeserLooc = false;//�r�[�����b�N
    bool LongLooc = false;//�������b�N

    bool EndF = false;//���j�t���O
    bool Crear = false;//�N���A�o��
    bool Fade = false;//�t�F�[�h�I�u�W�F�t���O

    public int HP_M = 40;//�̗̓}�b�N�X
    int HP_Z ;    //�G�̗̑�
    private bool inDamage;  //�_���[�W���̃t���O
    public Slider slider;//�X���C�_�[
    bool HalfC = false;

    //�[�[���̃p�[�c
    GameObject Zeere1;
    GameObject Zeere2;
    GameObject Zeere3;

    //��
    private AudioSource audioSource;
    public AudioClip Samon_SE;
    public AudioClip SamonR_SE;
    public AudioClip Boost_SE;
    public AudioClip Attack_SE;
    public AudioClip AttackC_SE;
    public AudioClip Ritoning_SE;
    public AudioClip ZVoiceA;
    public AudioClip ZVoiceB;
    public AudioClip ZeereON_SE;
    public AudioClip ZeereON2_SE;
    public AudioClip Break_SE;
    public AudioClip Foor_SE;
    public AudioClip Damage_SE;

    public AudioSource Loop_BGM;
    public AudioSource Start_BGM;
    public GameObject targetBGM;
    public GameObject targetBGMS;
    bool LoopC = false;

    private void Start()
    {
        HP_Z = HP_M;
        rx = r;
        slider.value = HP_M;
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        BoostTraget = GameObject.FindGameObjectWithTag("PlayerLoocon").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("Zeerecenter");
        Zeere2 = GameObject.Find("ZeereEye");
        Zeere3 = GameObject.Find("ZeereKabar");

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        passedTimes += Time.deltaTime;//���Ԍo��
        if (LoopC == false)
        {
            BGMTime += Time.deltaTime;//���Ԍo��
        }
        if (GO == true)
        {
            if (inDamage)
            {
                //�_���[�W���A�_�ł�����
                float val = Mathf.Sin(Time.time * 50);
                if (val > 0)
                {
                    //�X�v���C�g��\��
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    //Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    //�X�v���C�g���\��
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    //Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                //�X�v���C�g��\��
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                //Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                Zeere3.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        //�J�n��
        if (GO==false)
        {

            passedTimes = 0;
            BGMTime = 0;
            //�ҋ@�ꏊ�ֈړ�
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -4.5f),
               speed * Time.deltaTime);
        }
        //�N��
        if(GO==true&&GoOK==false)
        {
            if(passedTimes>1)
            {
                ZeereEye Eyeon = Zeere2.GetComponent<ZeereEye>();
                Eyeon.ON();
            }
            if (passedTimes > 2)
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
            if (passedTimes >= 4&& passedTimes <= 5)
            {
                if(Cool2==false)
                {
                    Cool2 = true;
                    audioSource.PlayOneShot(ZeereON2_SE);
                    BGM BGML = targetBGM.GetComponent<BGM>();
                    BGML.Loop();
                }
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
                Instantiate(SoulEat, new Vector2(x, y), Quaternion.identity);
            }

            if (passedTimes>7&&Cool==false)
            {
                Cool = true;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
                Instantiate(Helo, new Vector2(x, y), Quaternion.identity);
                

            }
            if(passedTimes>8&&Cool2==true)
            {
                audioSource.PlayOneShot(ZVoiceA);
                audioSource.PlayOneShot(ZVoiceB);
                Cool2 = false;
            }
            if(passedTimes>10)
            {
                slider.gameObject.SetActive(true);
                ReeserAttack = !ReeserAttack;
                ReeserLooc = !ReeserLooc;
                passedTimes = 0;
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
        //BGM���[�v
        //if (BGMTime <= 45 && BGMTime >=35&&LoopC==false&&AttackLooc==false)
        //{
        //    passedTimes = 0;
        //    Debug.Log("Lady?");
        //}
        //else if(BGMTime>46&&LoopC==false&&AttackLooc==false)
        //{
        //    Debug.Log("GO!");
        //    passedTimes = 99;
        //    LoopC = true;
        //}
        //�U������
        rnd = Random.Range(1, 6);
        if (passedTimes > Attack)
        {
            if (AttackLooc == false)//�N���p
            {
                if (rnd == 1 && BusteLooc == false)//�ːiON
                {
                    PlayerLoocon LCO = LoocON.GetComponent<PlayerLoocon>();
                    LCO.Reset();
                    AttackLooc = !AttackLooc;
                    BusteAttack = !BusteAttack;
                    BusteLooc = !BusteLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 2 && SamonLooc == false)//����ON
                {
                    AttackLooc = !AttackLooc;
                    SamonAttack = !SamonAttack;
                    SamonLooc = !SamonLooc;
                    passedTimes = 0;
                    coorTime = 0;
                    audioSource.PlayOneShot(ZVoiceA);
                    audioSource.PlayOneShot(ZVoiceB);
                }
                if (rnd == 3 && RitoningLooc == false)//���JON
                {
                    AttackLooc = !AttackLooc;
                    RitoningAttack = !RitoningAttack;
                    RitoningLooc = !RitoningLooc;
                    passedTimes = 0;
                    coorTime = 0;
                    audioSource.PlayOneShot(SamonR_SE);
                    audioSource.PlayOneShot(ZeereON2_SE);
                }
                if (rnd == 4 && ReeserLooc == false)//�r�[��ON
                {
                    AttackLooc = !AttackLooc;
                    ReeserAttack = !ReeserAttack;
                    ReeserLooc = !ReeserLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 5 && LongLooc == false)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    passedTimes = 0;
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
                speed * Time.deltaTime);
            if(transform.localEulerAngles.z<180)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else if (transform.localEulerAngles.z > 180)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
            }
        }
     

        if(BusteAttack==true)//�ːi
        {
            
            if (passedTimes < 3)
            {
                // �Ώە��ւ̃x�N�g�����Z�o
                Vector3 toDirection = BoostTraget.transform.position - transform.position;
                // �Ώە��։�]����
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            }
            if (passedTimes < 3 && Cool2 == false)
            {
                Cool2 = true;
                audioSource.PlayOneShot(AttackC_SE);
            }
            if (passedTimes>=3)
            {
                if(Cool2==true)
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
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            coorTime += Time.deltaTime;//���Ԍo��
            
            if (SamonC < 3)
            {
                
                if (coorTime > 0.5)
                {
                    SamonC += 1;
                    coorTime = 0;
                    // ��������
                    Transform myTransform = gateTransform.transform;
                    Vector2 worldPos = myTransform.position;
                    float x = worldPos.x;
                    float y = worldPos.y;

                    Instantiate(Samon, new Vector2(x, y), Quaternion.identity);
                    audioSource.PlayOneShot(Samon_SE);
                }
               
            }
            if (passedTimes > 4)
            {
                AttackLooc = !AttackLooc;
                SamonAttack = !SamonAttack;
                passedTimes = 0;
                coorTime = 0;
                SamonC = 0;
                BusteLooc = false;
                RitoningLooc = false;
                ReeserLooc = false;
                LongLooc = false;
                Cool = false;
            }
        }


        if (RitoningAttack == true)//���J
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(0, 3),
                speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            if (SamonC<2)
            {
                SamonC+=1;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                Instantiate(Rain, new Vector2(0, 7), Quaternion.identity);
            }
            if (passedTimes > 4)
            {

                if (Cool == false)
                {
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(Ritning, new Vector2(rx, ry), Quaternion.identity);
                    Instantiate(Ritning, new Vector2(-rx, ry), Quaternion.identity);
                    rx += prx;
                }
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                    audioSource.PlayOneShot(Ritoning_SE);
                }
                if (rx > boder)
                {
                    Cool = true;
                }
                if (passedTimes > 4.5)
                {
                    rx = r;
                    passedTimes = 0;
                    AttackLooc = false;
                    RitoningAttack = false;
                    SamonC = 0;
                    BusteLooc = false;
                    SamonLooc = false;
                    ReeserLooc = false;
                    LongLooc = false;
                    Cool = false;
                }
            }
        }


        if (ReeserAttack == true)//�r�[��
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            if (SamonC < 1)
            {
                SamonC += 1;
                Transform myTransform = target.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;
                float y = 0;

                Instantiate(Beem, new Vector2(x, y), Quaternion.identity);
                Instantiate(Beem, new Vector2(-x, y), Quaternion.identity);
            }
            if (passedTimes > 3.1)
            {
                passedTimes = 0;
                AttackLooc = false;
                ReeserAttack = false;
                SamonC = 0;
                BusteLooc = false;
                SamonLooc = false;
                RitoningLooc = false;
                LongLooc = false;
            }
        }

        if(EndF==true)//���j
        {
            if(passedTimes>1)
            {
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                //�w��ʒu�ɉ��~
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(x, -10),
                   0.9f * Time.deltaTime);
                if(Cool==false)
                {
                    Cool = true;
                    float ex = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                    float ey = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
                    Instantiate(KillEffect, new Vector2(ex, ey), Quaternion.identity);
                    audioSource.PlayOneShot(ZVoiceA);
                    audioSource.PlayOneShot(ZVoiceB);
                    audioSource.PlayOneShot(Foor_SE);
                }
            }
            if (passedTimes > 5)
            {
                if(Fade==false)
                {
                    Fade = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(Fadeout, new Vector2(0, 0), Quaternion.identity);
                    audioSource.PlayOneShot(ZVoiceA);
                    audioSource.PlayOneShot(ZVoiceB);
                }
            }
            if (passedTimes > 10 && Crear == false)
            {
                GameObject obj = Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                Crear = true;
            }
        }
        //��������
        if(HP_Z<=HP_M/2&&AttackLooc==false&&HalfC==false)
        {
            HalfC = true;
            ATspeed = ATspeed/2;
            BsCT = BsCT/2;
        }

    }

    public void Zeereon()
    {
        GO = true;
    }

    public void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {
        if (EndF == false)
        {
            if (HP_Z > HP_M / 2)
            {
                if (other.CompareTag("Ground") && BusteAttack == true)
                {
                    BusteAttack = false;
                    passedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }
            else
            {
                if (other.CompareTag("OverGround") && BusteAttack == true)
                {
                    BusteAttack = false;
                    passedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }

            if (other.CompareTag("Wall") && BusteAttack == true)
            {
                BusteAttack = false;
                passedTimes = 0;
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
            HP_Z--; //hp������
            slider.value = HP_Z;
            Debug.Log(HP_Z);
            if (HP_Z > 0)
            {
                //�_���[�W�t���O�@ON
                inDamage = true;
                audioSource.PlayOneShot(Damage_SE);
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
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
                    passedTimes = 0;
                    EndF = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(BossEnd, new Vector2(0, 0), Quaternion.identity);
                    float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                    float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
                    Instantiate(HeloNull, new Vector2(x, y), Quaternion.identity);
                }
                

            }
        }
    }

    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false; // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // �X�v���C�g�����ɖ߂�
    }
}
