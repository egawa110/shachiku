using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit   = 0.0f; // �E�X�N���[����� 
    public float rightLimit  = 0.0f; // ���X�N���[�����
    public float topLimit    = 0.0f; // ��X�N���[�����
    public float bottomLimit = 0.0f; // ���X�N���[�����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("player");// �v���C���[��T��
        if (player != null)
        {
            //�J�����̍X�V���W
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;
            //������������
            //���[�Ɉړ�����������
            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }
            //�c����������
            //�㉺�Ɉړ���������
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }
            //�J�����ʒu��Vector3�����
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
    }
}
