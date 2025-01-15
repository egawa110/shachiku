using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTransrarency : MonoBehaviour
{
    SpriteRenderer sr;//Sprite Randerer�p�̕ϐ�

    float cla;

    float speed = 0.0005f;//�����ɂȂ�܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        sr = GetComponent<SpriteRenderer>();//Sprite Renderer���擾
    }

    IEnumerator Display()
    {
        //�����ɂȂ鏈��
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