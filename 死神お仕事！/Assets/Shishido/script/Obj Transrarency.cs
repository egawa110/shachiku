using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTransrarency : MonoBehaviour
{
    SpriteRenderer sr;//Sprite Randerer用の変数

    float cla;

    float speed = 0.0005f;//透明になるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();//Sprite Rendererを取得
    }

    IEnumerator Display()
    {
        //透明になる処理
        while (cla > 0f)
        {
            cla -= speed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }
    }

    private void OnTriggerStay2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            cla = sr.color.a;
            StartCoroutine(Display());
        }

    }
}