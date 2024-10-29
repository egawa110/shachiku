using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; //弾のスピード

    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納

        //GameObject playerObj = GameObject.Find("Player");

        //if (playerObj.transform.localScale.x >= 0)
        //{
        //    bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　右向き（正面）
        //    transform.position = bulletPos; //現在の位置情報に反映させる

        //}
        //else
        //{
            bulletPos.x -= speed * Time.deltaTime; //x座標にspeedを加算　左向き（後ろ）
            transform.position = bulletPos; //現在の位置情報に反映させる
        //}

    }
}