using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageHalo : MonoBehaviour
{
    int rnd;//乱数
    bool inDamage = false;
    public bool HalfF = false;
    float HalfC ;
    // Start is called before the first frame update
    void Start()
    {
        ZeereCore zeere; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("ZeereCore"); //Playerっていうオブジェクトを探す
        zeere = obj.GetComponent<ZeereCore>(); //付いているスクリプトを取得
        HalfC = zeere.BsCT;
    }

    // Update is called once per frame
    void Update()
    {
        if (HalfF)
        {
            //乱数で一瞬消える感じでおなしゃす
            rnd = Random.Range(0, 100);//乱数
            if (inDamage)
            {
                //ダメージ中、点滅させる
                float val = Mathf.Sin(Time.time * 50);
                if (val > 0)
                {
                    //スプライトを表示
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    //スプライトを非表示
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                rnd = 100;
            }
            if (rnd == 0)
            {
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.25f);
            }
        }
        else
        {
            ZeereCore zeere; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("ZeereCore"); //Playerっていうオブジェクトを探す
            zeere = obj.GetComponent<ZeereCore>(); //付いているスクリプトを取得
            if (zeere.BsCT==HalfC/2)
            {
                HarfFON();
            }
        }

    }

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false; // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // スプライトを元に戻す
    }
    void HarfFON()
    {
        HalfF = true;
    }
}
