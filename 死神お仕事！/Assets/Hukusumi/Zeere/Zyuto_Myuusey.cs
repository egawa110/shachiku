using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zyuto_Myuusey : MonoBehaviour
{
    public GameObject objPrefab;   //����������Prefab�f�[�^
    Transform gateTransform;       //���ˌ���Transform
    Rigidbody2D rbody;                //Rigidbody2D�^�̍쐬
    Transform playerTr;
    public float speed = 3.0f;  //�ړ����x
    public bool isToRight = false; //true �� �E����  false �� ������
    public LayerMask groundLayer;      //�n�ʃ��C���[
    public float fireSpeed = 4.0f; //���ˑ��x


    private Vector3 movement;
    private float amountX;

    float passedTimes = 0;
    public float firetime = 3.0f;//����

    // Start is called before the first frame update
    void Start()
    {
        gateTransform = transform.Find("gate");
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        //rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2D������Ă���
    }

    // Update is called once per frame
    void Update()
    {

        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        Transform yTransform = playerTr.transform;
        Vector2 orldPos = yTransform.position;
        passedTimes += Time.deltaTime;//���Ԍo��
        if ( worldPos.x - orldPos.x >= 5 || worldPos.x - orldPos.x <= -5)
        {
            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   speed * Time.deltaTime);
            if (worldPos.y - orldPos.y < 2 && worldPos.y - orldPos.y > -2)//�ˌ�����
            {
                if (passedTimes >= firetime)
                {
                    passedTimes = 0; //���Ԃ��O�Ƀ��Z�b�g
                                     //�C�e���v���n�u������
                    if (worldPos.x - orldPos.x >= 1)//�Ώۂ̕���
                    {
                        Vector2 pos = new Vector2(gateTransform.position.x,
                            gateTransform.position.y);
                        GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                        //���j�������Ă�����ɔ��˂���
                        Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                        float angleZ = transform.localEulerAngles.z;
                        float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                        float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                        Vector2 v = new Vector2(-x, y) * fireSpeed;
                        rbody.AddForce(v, ForceMode2D.Impulse);
                    }
                    else if (worldPos.x - orldPos.x <= -1)//�Ώۂ̕���
                    {
                        Vector2 pos = new Vector2(gateTransform.position.x,
                            gateTransform.position.y);
                        GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                        //���j�������Ă�����ɔ��˂���
                        Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                        float angleZ = transform.localEulerAngles.z;
                        float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                        float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                        Vector2 v = new Vector2(x, y) * fireSpeed;
                        rbody.AddForce(v, ForceMode2D.Impulse);
                    }
                }
            }

            
            
        }
        else
        {

            transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(playerTr.position.x, worldPos.y),
                   -speed * Time.deltaTime);
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
        if (other.CompareTag("KinKill"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        if (other.CompareTag("Foff"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }

    }
}
