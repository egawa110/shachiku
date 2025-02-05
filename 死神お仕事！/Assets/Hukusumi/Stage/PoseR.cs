using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class PoseR : MonoBehaviour
{
    public string SceneName; // 読み込むシーン名
    public GameObject pauseMenuUI;
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Initiate.Fade(SceneName, Color.black, 1.0f);

        Debug.Log(SceneName);
    }
}
