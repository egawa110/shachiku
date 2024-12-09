using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] GameObject Samon;
    [SerializeField] GameObject Ritning_A;
    [SerializeField] GameObject Ritning_B;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Rite;
    [SerializeField] GameObject Beem;
    [SerializeField] GameObject Helo;
    [SerializeField] GameObject BossEnd;
    [SerializeField] GameObject eye;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject Fadeout;

    public GameObject GameUI;


    Transform gateTransform;
    public Transform target;
    float passedTimes = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // �G�̓����X�s�[�h
    //[SerializeField] float RUspeed = 3;
    float ATspeed = 10.0f;
    float SamonC = 0;
    public float Attack = 10;

    int rnd;
    
    public float brx = 0.5f;
    public float bry = 20.0f;
    public float rx = 1.0f;
    public float boder = 10.0f;

    public bool GO = false;
    bool GoOK = false;

    bool Cool = false;//�����p
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

    bool EndF = false;
    bool Crear = false;
    bool Fade = false;

    public int HP_Z = 40;    //�G�̗̑�
    private bool inDamage;  //�_���[�W���̃t���O

    GameObject Zeere1;
    GameObject Zeere2;
    GameObject Zeere3;
    GameObject Zeere4;

    private void Start()
    {
       
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("ZeerenoTyuusinnZERO");
        Zeere2 = GameObject.Find("ZeerenoTyuusinn");
        Zeere3 = GameObject.Find("ZeereEye");
        Zeere4 = GameObject.Find("ZeereKabar");


    }

    private void Update()
    {
        passedTimes += Time.deltaTime;//���Ԍo��
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
                    Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere4.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    //�X�v���C�g���\��
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere4.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                //�X�v���C�g��\��
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                Zeere3.GetComponent<SpriteRenderer>().enabled = true;
                Zeere4.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        //if (Input.GetKeyDown(KeyCode.G))//ON
        //{
        //    GO = true;
        //}

        if (GO==false)
        {

            passedTimes = 0;
            //�ҋ@�ꏊ�ֈړ�
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -4.5f),
               speed * Time.deltaTime);
        }
        if(GO==true&&GoOK==false)
        {
            if(passedTimes>1)
            {
                ZeereEye Eyeon = Zeere3.GetComponent<ZeereEye>();
                Eyeon.ON();
            }
            if (passedTimes > 2)
            {
                //�w��ʒu�ɏ㏸
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(0, 3),
                   1 * Time.deltaTime);
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
            if(passedTimes>9)
            {
                ReeserAttack = !ReeserAttack;
                ReeserLooc = !ReeserLooc;
                passedTimes = 0;
                coorTime = 0;
                GoOK = true;
                Cool = false;
            }
        }
        rnd = Random.Range(1, 6);
        if (Cool==true&&GoOK==true&&EndF==false)
        {
            coorTime += Time.deltaTime;//���Ԍo��
            if(coorTime>3)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
       
        if (passedTimes > Attack)
        {
            if (AttackLooc == false)//�N���p
            {


                if (rnd == 1 && BusteLooc == false)//�ːiON
                {
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
                }
                if (rnd == 3 && RitoningLooc == false)//���JON
                {
                    AttackLooc = !AttackLooc;
                    RitoningAttack = !RitoningAttack;
                    RitoningLooc = !RitoningLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 4 && ReeserLooc == false)//�r�[��ON
                {
                    AttackLooc = !AttackLooc;
                    ReeserAttack = !ReeserAttack;
                    ReeserLooc = !ReeserLooc;
                    passedTimes = 0;
                    coorTime = 0;
                    Debug.Log(AttackLooc);
                }
                if (rnd == 5 && LongLooc == false)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    passedTimes = 0;
                    LongLooc = true;
                }

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
                //    Debug.Log(AttackLooc);
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
                Vector3 toDirection = target.transform.position - transform.position;
                //Debug.Log(toDirection);
                // �Ώە��։�]����
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);

                //�v���g�ᑬ���b�N�I��
                //if(toDirection.x>0&& transform.localEulerAngles.x-toDirection.x>0)
                //{
                //    transform.Rotate(new Vector3(0, 0, 1));
                //}
            }
            if (passedTimes>=3)
            {
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
                    //Debug.Log("zzz");
                    // ��������

                    Transform myTransform = gateTransform.transform;
                    Vector2 worldPos = myTransform.position;
                    float x = worldPos.x;
                    float y = worldPos.y;

                    Instantiate(Samon, new Vector2(x, y), Quaternion.identity);

                    //Instantiate(Samon, gateTransform.position, gateTransform.rotation);
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
                    Instantiate(Ritning_A, new Vector2(brx, bry), Quaternion.identity);
                    Instantiate(Ritning_A, new Vector2(-brx, bry), Quaternion.identity);
                    Transform myTransformA = this.transform;
                    Vector2 worldPosA = myTransformA.position;
                    Instantiate(Ritning_B, new Vector2(brx, bry), Quaternion.identity);
                    Instantiate(Ritning_B, new Vector2(-brx, bry), Quaternion.identity);
                    brx += rx;
                }
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                }
                if (brx > boder)
                {
                    Cool = true;
                }
                if (passedTimes > 4.5)
                {
                    brx = 0.5f;
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

        if(EndF==true)
        {
            if (passedTimes > 5)
            {
                if(Fade==false)
                {
                    Fade = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(Fadeout, new Vector2(0, 0), Quaternion.identity);
                }
            }
            if (passedTimes > 10 && Crear == false)
            {
                //Transform myTransform = this.transform;
                //Vector2 worldPos = myTransform.position;
                //Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                GameObject obj = Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                Crear = true;
            }
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
            if (other.CompareTag("Ground") && BusteAttack == true)//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
            {
                BusteAttack = false;
                passedTimes = 0;
                coorTime = 0;
                Cool = true;

            }

            if (other.CompareTag("Wall") && BusteAttack == true)//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
            {
                BusteAttack = false;
                passedTimes = 0;
                coorTime = 0;
                Cool = true;

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
        if (PlayerController.gameState == "playing")
        {
            HP_Z--; //hp������
            Debug.Log(HP_Z);
            if (HP_Z > 0)
            {
                //�_���[�W�t���O�@ON
                inDamage = true;

                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                GameManager S5UI = GameUI.GetComponent<GameManager>();
                S5UI.BossKill();
                //�����
                AttackLooc = true;
                BusteAttack = false;
                SamonAttack = false;
                RitoningAttack = false;
                ReeserAttack = false;
                if (EndF ==false)
                {
                    passedTimes = 0;
                    EndF = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(BossEnd, new Vector2(0, 0), Quaternion.identity);
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
