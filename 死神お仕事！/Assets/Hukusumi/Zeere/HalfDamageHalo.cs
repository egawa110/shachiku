using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageHalo : MonoBehaviour
{
    int rnd;//乱数
    bool inDamage = false;
    bool HalfF = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
