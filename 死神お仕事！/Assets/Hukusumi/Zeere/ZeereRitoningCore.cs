using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereRitoningCore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {
        //Debug.Log("����"+other.tag);
        if (other.CompareTag("Ground"))
        {
            //Debug.Log("XXX");
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }

    }
}
