using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//���g��
public class SAB : MonoBehaviour
{
    public float deleteTime = 3.0f; //�폜���鎞�Ԏw��
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime); //�폜�ݒ�
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        if (other.CompareTag("ZeereCore"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        
    }
}
