using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem2 : MonoBehaviour
{
    [SerializeField] GameObject target;
    SpriteRenderer sr;
    bool onoff = false;
    float transparencyON = 0.0f;
    float transparencyOFF = 1.0f;

    void Start()
    {
        target = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // isCheck‚Ì’l‚ð”½“]‚³‚¹‚é
            onoff = !onoff;
        }
        if (onoff == false)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyON);
            Transform myTransform = this.transform;
            Debug.Log(target.transform.position);
            Vector3 pos = target.transform.position;
            pos.y = 0;
            myTransform.position = pos;
        }
        else if (onoff == true)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyOFF);
        }
    }
}

