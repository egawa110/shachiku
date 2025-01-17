using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchButton : MonoBehaviour
{
    public string sceneName; // 切り替えたいシーンの名前

    private void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            return;

        // ボタンコンポーネントを取得し、クリック時にメソッドを呼び出すよう設定
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(LoadSceneAsync(sceneName)));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}