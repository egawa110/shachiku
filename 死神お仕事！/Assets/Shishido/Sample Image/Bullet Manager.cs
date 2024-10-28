using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //�e�e�̃X�s�[�h

    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 buletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[

        GameObject playerObj = GameObject.Find("Player");

        if (playerObj.transform.localScale.x >= 0)
        {
            buletPos.x += speed * Time.deltaTime; //x���W��speed�����Z
        }
        else if(playerObj.transform.localScale.x <= 0)
        {
            buletPos.x -= speed * Time.deltaTime; //x���W��speed�����Z
        }

        transform.position = buletPos; //���݂̈ʒu���ɔ��f������
    }
}