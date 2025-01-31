using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lessyn_Rifgo : MonoBehaviour
{
    public GameObject objPrefab;   //����������Prefab�f�[�^
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

    GameObject Zyuto;

    void Start()
    {
        gateTransform = transform.Find("gate");
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
        audioSource = GetComponent<AudioSource>();

        Zyuto = this.transform.Find("name").gameObject;
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
    private void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
    }

}

