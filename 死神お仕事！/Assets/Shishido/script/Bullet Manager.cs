using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f; //�e�̃X�s�[�h
    [SerializeField] private int DeleteTime = 1;

    private PlayerController playcon;

    void Start()
    {
        playcon = GetComponent<PlayerController>();
    }

    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj.transform.localScale.x >= 0)
        {
            Move_R();
        }
        else if (playerObj.transform.localScale.x <= 0)
        {
            Move_L();
        }

        Destroy(gameObject, DeleteTime);
    }
    
    public void Move_R()
    {
        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[
        bulletPos.x += speed * Time.deltaTime; //x���W��speed�����Z�@�E�����i�O�j
        transform.position = bulletPos; //���݂̈ʒu���ɔ��f������
    }
    public void Move_L()
    {
        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[
        bulletPos.x += speed * Time.deltaTime; //x���W��speed�����Z�@�������i���j
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
            //Destroy(other.gameObject);//�G��������

        }
    }
}
