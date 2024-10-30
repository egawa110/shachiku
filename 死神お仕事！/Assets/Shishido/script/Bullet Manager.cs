using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; //弾のスピード

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
        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　右向き（正面）
        transform.position = bulletPos; //現在の位置情報に反映させる
    }
    public void Move_Left()
    {
        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x -= speed * Time.deltaTime; //x座標にspeedを加算　左向き（後ろ）
        transform.position = bulletPos; //現在の位置情報に反映させる
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);//弾が消える
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);//弾が消える
            Destroy(other.gameObject);//敵も消える
        }
    }

}