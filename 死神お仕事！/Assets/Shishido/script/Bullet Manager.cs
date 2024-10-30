using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; //�e�̃X�s�[�h

    [SerializeField] private int DeleteTime = 2;

    void Start()
    {
    }

    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");

        if (playerObj.transform.localScale.x >= 0)
        {
            Move_Right();
        }
        else
        {
            Move_Left();
        }

        Destroy(gameObject, DeleteTime);
    }

    public void Move_Right()
    {
        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[
        bulletPos.x += speed * Time.deltaTime; //x���W��speed�����Z�@�E�����i���ʁj
        transform.position = bulletPos; //���݂̈ʒu���ɔ��f������
    }
    public void Move_Left()
    {
        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[
        bulletPos.x -= speed * Time.deltaTime; //x���W��speed�����Z�@�������i���j
        transform.position = bulletPos; //���݂̈ʒu���ɔ��f������
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);//�e��������
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);//�e��������
            Destroy(other.gameObject);//�G��������
        }
    }

}