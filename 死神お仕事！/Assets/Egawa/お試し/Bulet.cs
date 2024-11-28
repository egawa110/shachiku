using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f; //弾のスピード
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
        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　右向き（前）
        transform.position = bulletPos; //現在の位置情報に反映させる
    }
    public void Move_L()
    {
        Vector3 bulletPos = -transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　左向き（後ろ）
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
            //Destroy(other.gameObject);//敵も消える

        }
    }
}
