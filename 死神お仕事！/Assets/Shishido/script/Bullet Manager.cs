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
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で〜という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        if (other.CompareTag("KinKill"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で〜という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }
}
