using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereRitoningCore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {
        Debug.Log("����"+other.tag);
        if (other.CompareTag("Ground"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Debug.Log("XXX");
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }

    }
}
