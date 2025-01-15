using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class GOStageSelect : MonoBehaviour
{
    private PauseMenu pausemenu;

    //-----------------------------------------
    // フェードありのスクリプト
    //-----------------------------------------
    public string Opening; // 読み込むシーン名
    public string Stage1; // 読み込むシーン名
    public string Stage2; // 読み込むシーン名
    public string Stage3; // 読み込むシーン名
    public string Stage4; // 読み込むシーン名
    public string Stage5; // 読み込むシーン名
    public string StageAll; // 読み込むシーン名
    int CC;
    void Start()
    {
        pausemenu = GetComponent<PauseMenu>();
    }
    void Update()
    {
        if (pausemenu.pauseUI.activeSelf == false)
        {
            Load();
        }
    }
    // シーンを読み込む
    public void Load()
    {
        ClearCount clearcount = GetComponent<ClearCount>();
        CC = clearcount.Count;
        if (CC == 0)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(Opening, Color.black, 1.0f);
            clearcount.GameStart();
            Debug.Log(Opening);
        }
        else if (CC == 1)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(Stage1, Color.black, 1.0f);

            Debug.Log(Stage1);
        }
        else if (CC == 2)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(Stage2, Color.black, 1.0f);

            Debug.Log(Stage2);
        }
        else if (CC == 3)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(Stage3, Color.black, 1.0f);

            Debug.Log(Stage3);
        }
        else if (CC == 4)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(Stage4, Color.black, 1.0f);

            Debug.Log(Stage4);
        }
        else if (CC == 5)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(Stage5, Color.black, 1.0f);

            Debug.Log(Stage5);
        }
        else if (CC == 6)
        {
            //SceneManager.LoadScene(SceneName);
            Initiate.Fade(StageAll, Color.black, 1.0f);

            Debug.Log(StageAll);
        }
    }
}
