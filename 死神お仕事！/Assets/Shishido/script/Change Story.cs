using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class ChangeStory : MonoBehaviour
{
    //---------------------------------------------------------------
    // ストーリー最中のシーン切り替え専用スクリプト
    // （フェード無し）
    //---------------------------------------------------------------

    public string SceneName; // 読み込むシーン名

    private void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            return;
    }

    // シーンを読み込む
    public void Load()
    {
        SceneManager.LoadScene(SceneName);

        Debug.Log(SceneName);
    }
}
