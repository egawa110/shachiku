using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class ChangeStory : MonoBehaviour
{
    public string SceneName; // 読み込むシーン名

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // シーンを読み込む
    public void Load()
    {
        SceneManager.LoadScene(SceneName);

        Debug.Log(SceneName);
    }
}
