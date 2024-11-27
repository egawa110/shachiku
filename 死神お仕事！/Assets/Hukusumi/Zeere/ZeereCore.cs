using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] GameObject Samon;
    [SerializeField] GameObject prefab_A;
    [SerializeField] GameObject prefab_B;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Rite;
    [SerializeField] GameObject Beem;
    [SerializeField] GameObject Helo;

    Transform gateTransform;
    public Transform target;
    float passedTimes = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // �G�̓����X�s�[�h
    [SerializeField] float RUspeed = 3;
    float ATspeed = 10.0f;
    float SamonC = 0;
    public float Attack = 10;

    int rnd;
    
    public float brx = 0.5f;
    public float bry = 20.0f;
    public float rx = 1.0f;
    public float boder = 10.0f;

    bool GO = false;
    bool GoOK = false;

    bool Cool = false;//�����p
    bool AttackLooc = true;//�N���p
    bool BusteAttack = false;//�ːi�N���p
    bool SamonAttack = false;//�����N���p
    bool RitoningAttack = false;//���J�N���p
    bool ReeserAttack = false;//�r�[���N���p

    bool BusteLooc = false;//�ːi�N���p
    bool SamonLooc = false;//�����N���p
    bool RitoningLooc = false;//���J�N���p
    bool ReeserLooc = false;//�r�[���N���p
    bool LongLooc = false;

    private void Start()
    {
       
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))//�ːiON
        {
            GO = true;
        }

        if (GO==false)
        {
            passedTimes = 0;
            //�ҋ@�ꏊ�ֈړ�
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -3),
               speed * Time.deltaTime);
        }
        if(GO==true&&GoOK==false)
        {
            //�w��ʒu�ɏ㏸
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, 3),
               1 * Time.deltaTime);

            if (passedTimes>5&&Cool==false)
            {
                Cool = true;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
                Instantiate(Helo, new Vector2(x, y), Quaternion.identity);

            }
            if(passedTimes>7)
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
        if (Cool==true&&GoOK==true)
        {
            coorTime += Time.deltaTime;//���Ԍo��
            if(coorTime>3)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
        passedTimes += Time.deltaTime;//���Ԍo��
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
            SamonC += Time.deltaTime;//���Ԍo��
            if (coorTime < 3)
            {
                if (SamonC > 0.5)
                {
                    coorTime += 1;
                    SamonC = 0;
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
                Instantiate(Rain, new Vector2(0, 6), Quaternion.identity);
            }
            if (passedTimes > 4)
            {
                

                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                Instantiate(prefab_A, new Vector2(brx, bry), Quaternion.identity);
                Instantiate(prefab_A, new Vector2(-brx, bry), Quaternion.identity);
                Transform myTransformA = this.transform;
                Vector2 worldPosA = myTransformA.position;
                Instantiate(prefab_B, new Vector2(brx, bry), Quaternion.identity);
                Instantiate(prefab_B, new Vector2(-brx, bry), Quaternion.identity);
                brx += rx;
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                }
                if (brx > boder)
                {
                    brx = 0.5f;
                   
                }
                if (passedTimes > 4.5)
                {
                    passedTimes = 0;
                    AttackLooc = false;
                    RitoningAttack = false;
                    SamonC = 0;
                    BusteLooc = false;
                    SamonLooc = false;
                    ReeserLooc = false;
                    LongLooc = false;
                }
            }
        }


        if (ReeserAttack == true)
        {
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

    }

    public void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {

        if (other.CompareTag("Ground")&&BusteAttack==true)//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            BusteAttack = false;
            passedTimes = 0;
            coorTime = 0;
            Cool = true;
            
        }

    }
}
