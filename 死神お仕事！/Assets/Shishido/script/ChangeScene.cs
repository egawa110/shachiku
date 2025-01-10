using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class ChangeScene : MonoBehaviour
{
    private PauseMenu pausemenu;


    //-----------------------------------------
    // フェードありのスクリプト
    //-----------------------------------------
    public string SceneName; // 読み込むシーン名

    private void Start()
    {
        pausemenu = GetComponent<PauseMenu>();
    }
    private void Update()
    {
        if (pausemenu.pauseUI.activeSelf == true)
        {
            Load();
        }
    }

    // シーンを読み込む
    public void Load()
    {
        //SceneManager.LoadScene(SceneName);
        Initiate.Fade(SceneName, Color.black, 1.0f);

        Debug.Log(SceneName);
    }
}
