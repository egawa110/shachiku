using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCB : MonoBehaviour
{
    public float deleteTime = 3.0f; //�폜���鎞�Ԏw��
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime); //�폜�ݒ�
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        
    }
}
