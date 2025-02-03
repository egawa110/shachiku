using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lessyn_Rifgo : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Heal;
    Transform gateTransform;       //���ˌ���Transform
    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    Transform Zeere;
    public float speed = 3.0f;  //�ړ����x
    public LayerMask groundLayer;      //�n�ʃ��C���[
    public float fireSpeed = 4.0f; //���ˑ��x

    float passedTimes = 0;
    public float firetime = 3.0f;//����

    private AudioSource audioSource;
    public AudioClip Fire_SE;

    void Start()
    {
        gateTransform = transform.Find("gate");
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        passedTimes += Time.deltaTime;//���Ԍo��
        transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(Zeere.position.x, worldPos.y),
               speed * Time.deltaTime);
        if (passedTimes >= firetime)
        {
            passedTimes = 0; //���Ԃ��O�Ƀ��Z�b�g

            //�C�e���v���n�u������
            Vector2 pos = new Vector2(gateTransform.position.x,
                gateTransform.position.y);
            GameObject obj = Instantiate(Bullet, pos, Quaternion.identity);
            //���j�������Ă�����ɔ��˂���
            Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
            Vector2 v = new Vector2(0, 1) * fireSpeed;
            rbody.AddForce(v, ForceMode2D.Impulse);
            audioSource.PlayOneShot(Fire_SE);
            if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
            {
                foreach (Transform child in gameObject.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
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

        //�ڐG
        void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
        {
            if (other.CompareTag("KinKill"))
            {
                Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
            }
        }

    }
}

