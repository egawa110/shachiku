using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //�e�e�̃X�s�[�h

    public float DeleteTime = 2.0f;//�����鎞��

    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 lazerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
        lazerPos.x += speed * Time.deltaTime; //x���W��speed�����Z
        transform.position = lazerPos; //���݂̈ʒu���ɔ��f������
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);//�����ɓ��������������
    }
}