using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCB : MonoBehaviour
{
    public float deleteTime = 3.0f; //削除する時間指定
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime); //削除設定
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        
    }
}
