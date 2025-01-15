using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    public float deleteTime = 1.0f; //削除する時間指定

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Destroy(gameObject, deleteTime); //削除設定
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //敵に当たったら
        if(other.gameObject.tag == "Enemy")
        {
            //プレイヤーの攻撃が消える
            Destroy(gameObject);
        }
        //地面に当たったら
        else if (other.gameObject.tag == "Ground")
        {
            //プレイヤーの攻撃が消える
            Destroy(gameObject);
        }
        if (other.CompareTag("KinKill"))
        {
            //プレイヤーの攻撃が消える
            Destroy(gameObject);
        }
        if (other.CompareTag("ZeereCore"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }
}
