using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] GameObject prefab;
    //public GameObject objPrefab;
    public float firetime = 180.0f;//����
    public float fireSpeed = 0.0f;
    float ApassedTimes = 0;//�o�ߎ���

    void Start()
    { 

    }

    void Update()
    {
        
        
       ApassedTimes += Time.deltaTime;//���Ԍo��
       if(ApassedTimes>=firetime)
       {
           Transform myTransform = this.transform;
           Vector2 worldPos = myTransform.position;
           float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
           float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
           Instantiate(prefab,new Vector2(x,y), Quaternion.identity);
           Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
           
        

    }
    
}

