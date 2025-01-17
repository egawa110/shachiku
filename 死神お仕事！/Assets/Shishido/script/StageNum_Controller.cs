using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // コレ重要


public class StageNum_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //PlayerPrefsのSCOREに3という値を入れる
            PlayerPrefs.SetInt("SCORE", 3);
            //PlayerPrefsをセーブする
            PlayerPrefs.Save();
            ClearCount clearcount = GetComponent<ClearCount>();
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                clearcount.S1C();
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                clearcount.S2C();
            }
            else if (SceneManager.GetActiveScene().name == "Stage3")
            {
                clearcount.S3C();
            }
            else if (SceneManager.GetActiveScene().name == "Stage4")
            {
                clearcount.S4C();
            }
            else if (SceneManager.GetActiveScene().name == "Stage5")
            {
                clearcount.S5C();
            }
        }
    }
}
