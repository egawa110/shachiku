using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//鎌拡張
public class SAB : MonoBehaviour
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
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        if (other.CompareTag("ZeereCore"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
        
    }
}
