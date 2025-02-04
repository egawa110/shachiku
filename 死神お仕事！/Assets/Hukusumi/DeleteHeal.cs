using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHeal : MonoBehaviour
{
    public float DelTime = 10;
    float PassedTimes = 0;//アクションの時間経過
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PassedTimes += Time.deltaTime;//時間経過
        if (DelTime-PassedTimes<3)
        {
            //点滅させる
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
        }
        if(DelTime<PassedTimes)
        {
            Destroy(gameObject);
        }
    }
}
