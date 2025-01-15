using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTransrarency : MonoBehaviour
{
    SpriteRenderer sr;//Sprite RandererópÇÃïœêî

    float cla;

    float speed = 0.0005f;//ìßñæÇ…Ç»ÇÈÇ‹Ç≈ÇÃéûä‘

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        sr = GetComponent<SpriteRenderer>();//Sprite RendererÇéÊìæ
    }

    IEnumerator Display()
    {
        //ìßñæÇ…Ç»ÇÈèàóù
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