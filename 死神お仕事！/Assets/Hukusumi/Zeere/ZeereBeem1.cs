using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem1 : MonoBehaviour
{
    [SerializeField] GameObject target;
    SpriteRenderer sr;
    [SerializeField] GameObject prefab_A;
    //public GameObject objPrefab;
    public float firetime = 180.0f;//����
    public float fireSpeed = 0.0f;
    bool Bonoff = false;//�N���p
    float transparencyON = 0.0f;//����
    float transparencyOFF = 1.0f;//�s����
    Transform getTransform;
    float passedTimes = 0;//�o�ߎ���

    void Start()
    {
        target = GameObject.Find("Player");
        getTransform = transform.Find("Rockon1");
        
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            // isCheck�̒l�𔽓]������
            Bonoff = true;
        }
        if (Bonoff == false)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyON);//������
            Transform myTransform = this.transform;
            //Debug.Log(target.transform.position);
            Vector3 pos = target.transform.position;
            pos.y = 0;
            myTransform.position = -pos;
        }
        else if(Bonoff==true)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyOFF);//�s������
            passedTimes += Time.deltaTime;//���Ԍo��
            if(passedTimes>=firetime)
            {
                Bonoff = false;
                passedTimes = 0;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
                float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
                Instantiate(prefab_A,new Vector2(x,y), Quaternion.identity);

            }
           
        }

    }
    
}

