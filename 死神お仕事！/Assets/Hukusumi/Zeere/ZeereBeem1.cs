using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem1 : MonoBehaviour
{
    [SerializeField] GameObject target;
    SpriteRenderer sr;
    [SerializeField] GameObject prefab_A;
    //public GameObject objPrefab;
    public float firetime = 180.0f;//発射
    public float fireSpeed = 0.0f;
    bool Bonoff = false;//起動用
    float transparencyON = 0.0f;//透明
    float transparencyOFF = 1.0f;//不透明
    Transform getTransform;
    float passedTimes = 0;//経過時間

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
            // isCheckの値を反転させる
            Bonoff = true;
        }
        if (Bonoff == false)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyON);//透明化
            Transform myTransform = this.transform;
            //Debug.Log(target.transform.position);
            Vector3 pos = target.transform.position;
            pos.y = 0;
            myTransform.position = -pos;
        }
        else if(Bonoff==true)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparencyOFF);//不透明化
            passedTimes += Time.deltaTime;//時間経過
            if(passedTimes>=firetime)
            {
                Bonoff = false;
                passedTimes = 0;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                Instantiate(prefab_A,new Vector2(x,y), Quaternion.identity);

            }
           
        }

    }
    
}

