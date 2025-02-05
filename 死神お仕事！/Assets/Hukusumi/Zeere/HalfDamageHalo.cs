using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageHalo : MonoBehaviour
{
    int rnd;//乱数
    bool inDamage = false;//点滅
    public bool HalfF = false;//半分確認
    float HalfC ;//ゼーレ初期数値
    // Start is called before the first frame update
    void Start()
    {
        ZeereCore Zeere; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("ZeereCore"); //Playerっていうオブジェクトを探す
        Zeere = obj.GetComponent<ZeereCore>(); //付いているスクリプトを取得
        HalfC = Zeere.BsCT;//初期数値保存
    }

    // Update is called once per frame
    void Update()
    {
        if (HalfF)
        {
            //ランダムで点滅
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
            if (rnd == 0)//点滅起動
            {
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.25f);
            }
        }
        else
        {
            ZeereCore zeere; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("ZeereCore"); //オブジェクトを探す
            zeere = obj.GetComponent<ZeereCore>(); //付いているスクリプトを取得
            if (zeere.BsCT==HalfC/2)//半分確認
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
