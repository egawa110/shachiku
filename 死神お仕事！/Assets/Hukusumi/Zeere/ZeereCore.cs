using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    public Transform target;
    float passedTimes = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // �G�̓����X�s�[�h
    float ATspeed = 10.0f;
    bool Cool = false;//�����p
    bool AttackLooc = false;//�N���p
    bool BusteAttack = false;//�ːi�N���p



    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
    }

    private void Update()
    {
        if(Cool==true)
        {
            coorTime += Time.deltaTime;//���Ԍo��
            if(coorTime>1)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
        passedTimes += Time.deltaTime;//���Ԍo��
        if (Input.GetKeyDown(KeyCode.L))
        {
            // isCheck�̒l�𔽓]������
            AttackLooc = !AttackLooc;
            BusteAttack = !BusteAttack;
            passedTimes = 0;
            coorTime = 0;
        }
        if (AttackLooc == false)
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
                // �Ώە��։�]����
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            }
            if (passedTimes>=3)
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, ATspeed, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
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
            Debug.Log("zzz");
        }

    }
}
