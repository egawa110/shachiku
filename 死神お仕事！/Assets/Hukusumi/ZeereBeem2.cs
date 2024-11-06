using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem2 : MonoBehaviour
{
    [SerializeField] GameObject target;
    SpriteRenderer sr;
    [SerializeField] GameObject prefab_A;
    //public GameObject objPrefab;
    public float firetime = 180.0f;//発射
    public float fireSpeed = 0.0f;
    bool onoff = false;
    float transparencyON = 0.0f;//透明
    float transparencyOFF = 1.0f;//不透明
    Transform getTransform;
    float passedTimes = 0;//経過時間

    void Start()
    {
        target = GameObject.Find("Player");
        getTransform = transform.Find("Rockon2");

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // isCheckの値を反転させる
            onoff = true;
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
            passedTimes += Time.deltaTime;
            if (passedTimes >= firetime)
            {
                onoff = false;
                passedTimes = 0;

                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                Instantiate(prefab_A, new Vector2(x, y), Quaternion.identity);
            }

        }

    }
}

