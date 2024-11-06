using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem1 : MonoBehaviour
{
    [SerializeField] GameObject target;
    SpriteRenderer sr;
    public GameObject objPrefab;
    public float firetime = 180.0f;//”­ŽË
    public float fireSpeed = 0.0f;
    bool onoff = false;
    float transparencyON = 0.0f;//“§–¾
    float transparencyOFF = 1.0f;//•s“§–¾
    Transform getTransform;
    float passedTimes = 0;//Œo‰ßŽžŠÔ

    void Start()
    {
        target = GameObject.Find("Player");
        getTransform = transform.Find("Rockon1");
        
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            // isCheck‚Ì’l‚ð”½“]‚³‚¹‚é
            onoff = true;
        }
        if (onoff == false)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyON);
            Transform myTransform = this.transform;
            Debug.Log(target.transform.position);
            Vector3 pos = target.transform.position;
            pos.y = 0;
            myTransform.position = -pos;
        }
        else if(onoff==true)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyOFF);
            passedTimes += Time.deltaTime;
            if(passedTimes>=firetime)
            {
                onoff = false;
                passedTimes = 0;

                Vector2 pos = new Vector2(getTransform.position.x, getTransform.position.y);

                GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(getTransform.position.x, getTransform.position.y) * fireSpeed;
                rbody.AddForce(v, ForceMode2D.Impulse);

            }
           
        }

    }
}

