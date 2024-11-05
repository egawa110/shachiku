using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTransrarency : MonoBehaviour
{
    SpriteRenderer sr;//Sprite Randerer—p‚Ì•Ï”

    float cla;

    float speed = 0.0005f;//“§–¾‚É‚È‚é‚Ü‚Å‚ÌŠÔ

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();//Sprite Renderer‚ğæ“¾
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Display()
    {
        //“§–¾‚É‚È‚éˆ—
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