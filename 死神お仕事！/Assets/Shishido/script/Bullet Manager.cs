using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    public float deleteTime = 3.0f; //�폜���鎞�Ԏw��
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime); //�폜�ݒ�
    }

    // Update is called once per frame
    void Update()
    {

    }
<<<<<<< HEAD
=======
    
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
>>>>>>> 803497b97e779d67f9509001fca6a06744e41e38

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }
        //if (other.CompareTag("Player"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        //{
        //    Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        //}
    }
}
