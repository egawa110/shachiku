using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; //�e�̃X�s�[�h

    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[

        //GameObject playerObj = GameObject.Find("Player");

        //if (playerObj.transform.localScale.x >= 0)
        //{
        //    bulletPos.x += speed * Time.deltaTime; //x���W��speed�����Z�@�E�����i���ʁj
        //    transform.position = bulletPos; //���݂̈ʒu���ɔ��f������

        //}
        //else
        //{
            bulletPos.x -= speed * Time.deltaTime; //x���W��speed�����Z�@�������i���j
            transform.position = bulletPos; //���݂̈ʒu���ɔ��f������
        //}

    }
}