using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNum_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //PlayerPrefsのSCOREに3という値を入れる
            PlayerPrefs.SetInt("SCORE", 3);
            //PlayerPrefsをセーブする
            PlayerPrefs.Save();
        }
    }
}
