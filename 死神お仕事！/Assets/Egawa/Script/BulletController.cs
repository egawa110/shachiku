using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject objPrefab;   //����������Prefab�f�[�^
    public float delayTime = 3.0f; //�x������
    public float fireSpeed = 4.0f; //���ˑ��x
    public float length = 8.0f;    //�͈�

    GameObject player;             //�v���C���[
    Transform gateTransform;       //���ˌ���Transform
    float passedTimes = 0;         //�o�ߎ���

    private AudioSource audioSource;
    public AudioClip Enemy_Atk;

    //�����`�F�b�N
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d)
        {
            ret = true;
        }
        return ret;
    }

    //Start is called before the first frame update
    private void Start()
    {
        //���ˌ��I�u�W�F�N�g��Transform���擾
        gateTransform = transform.Find("gate");
        //�v���C���[���擾
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Update is Called once per frame
    private void Update()
    {
        //�ҋ@���ԉ��Z
        passedTimes += Time.deltaTime;
        //Player�Ƃ̋����`�F�b�N
        if (CheckLength(player.transform.position))
        {
            //�ҋ@���Ԍo��
            if (passedTimes > delayTime)
            {
                passedTimes = 0; //���Ԃ��O�Ƀ��Z�b�g
                //�C�e���v���n�u������
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
                //�U������炷
                audioSource.PlayOneShot(Enemy_Atk);
            }
        }
    }
    //�͈͕\��
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }

}