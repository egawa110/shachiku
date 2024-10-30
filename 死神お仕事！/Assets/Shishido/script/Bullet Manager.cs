using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{

    public float axisH = 0.0f;        //����


    [SerializeField] private float speed = 5.0f; //�e�̃X�s�[�h

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

        Destroy(gameObject, 2);
        


    }

    
    public void Move_Right()
    {

        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[
        bulletPos.x += speed * Time.deltaTime; //x���W��speed�����Z�@�������i���j
        transform.position = bulletPos; //���݂̈ʒu���ɔ��f������


    }

    public void Move_Left()
    {

        Vector3 bulletPos = transform.position; //Vector3�^��bulletPos�Ɍ��݂̈ʒu�����i�[
        bulletPos.x += speed * Time.deltaTime; //x���W��speed�����Z�@�������i���j
        transform.position = bulletPos; //���݂̈ʒu���ɔ��f������
        
    }

    
}
