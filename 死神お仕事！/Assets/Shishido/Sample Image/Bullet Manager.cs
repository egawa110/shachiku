using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //銃弾のスピード

    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 buletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納

        GameObject playerObj = GameObject.Find("Player");

        if (playerObj.transform.localScale.x >= 0)
        {
            buletPos.x += speed * Time.deltaTime; //x座標にspeedを加算
        }
        else if(playerObj.transform.localScale.x <= 0)
        {
            buletPos.x -= speed * Time.deltaTime; //x座標にspeedを加算
        }

        transform.position = buletPos; //現在の位置情報に反映させる
    }
}