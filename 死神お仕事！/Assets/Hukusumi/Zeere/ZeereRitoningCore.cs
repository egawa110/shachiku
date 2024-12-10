using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereRitoningCore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {
        //Debug.Log("ここ"+other.tag);
        if (other.CompareTag("Ground"))
        {
            //Debug.Log("XXX");
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }

    }
}
