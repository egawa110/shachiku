using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{

    public float axisH = 0.0f;        //入力


    [SerializeField] private float speed = 5.0f; //弾のスピード

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

        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　左向き（後ろ）
        transform.position = bulletPos; //現在の位置情報に反映させる


    }

    public void Move_Left()
    {

        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　左向き（後ろ）
        transform.position = bulletPos; //現在の位置情報に反映させる
        
    }

    
}
