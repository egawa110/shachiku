using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //銃弾のスピード

    public float DeleteTime = 2.0f;//消える時間

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
        Vector3 lazerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
        lazerPos.x += speed * Time.deltaTime; //x座標にspeedを加算
        transform.position = lazerPos; //現在の位置情報に反映させる
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);//何かに当たったら消える
    }
}