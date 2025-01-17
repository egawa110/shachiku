using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要
using UnityEngine.UI;

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
        Time.timeScale = 1;
        // ボタンコンポーネントを取得し、クリック時にメソッドを呼び出すよう設定
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(LoadSceneAsync()));
    }
    void Update()
    {

    }
    // シーンを読み込む
    private IEnumerator LoadSceneAsync()
    {
        ClearCount clearcount = GetComponent<ClearCount>();
        CC = clearcount.Count;
        if (CC == 0)
        {
            clearcount.GameStart();
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Opening);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(Opening);
        }
        else if (CC == 1)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Stage1);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(Stage1);
        }
        else if (CC == 2)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Stage2);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(Stage2);
        }
        else if (CC == 3)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Stage3);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(Stage3);
        }
        else if (CC == 4)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Stage4);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(Stage4);
        }
        else if (CC == 5)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Stage5);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(Stage5);
        }
        else if (CC == 6)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(StageAll);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log(StageAll);
        }
    }
}
