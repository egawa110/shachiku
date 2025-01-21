using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    public float deleteTime = 1.0f; //�폜���鎞�Ԏw��

    void Start()
    {
        Destroy(gameObject, deleteTime); //�폜�ݒ�
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //�G�ɓ���������
        if (other.gameObject.tag == "Enemy")
        {
            //�v���C���[�̍U����������
            Destroy(gameObject);
        }
        //�n�ʂɓ���������
        else if (other.gameObject.tag == "Ground")
        {
            //�v���C���[�̍U����������
            Destroy(gameObject);
        }
        if (other.CompareTag("KinKill"))
        {
            //�v���C���[�̍U����������
            Destroy(gameObject);
        }
        if (other.CompareTag("ZeereCore"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
    }


}
