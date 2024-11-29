using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    public float deleteTime = 3.0f; //削除する時間指定
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime); //削除設定
    }

    // Update is called once per frame
    void Update()
    {

    }
<<<<<<< HEAD
=======
    
    public void Move_R()
    {
        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
        bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算　右向き（前）
        transform.position = bulletPos; //現在の位置情報に反映させる
    }
    public void Move_L()
    {
        Vector3 bulletPos = transform.position; //Vector3型のbulletPosに現在の位置情報を格納
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
>>>>>>> 803497b97e779d67f9509001fca6a06744e41e38

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        //if (other.CompareTag("Player"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        //{
        //    Destroy(gameObject);//このゲームオブジェクトを消滅させる
        //}
    }
}
