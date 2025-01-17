using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchButton : MonoBehaviour
{
    public string sceneName; // 切り替えたいシーンの名前
    private float originalTimeScale;

    private void Start()
    {
        // ボタンコンポーネントを取得し、クリック時にメソッドを呼び出すよう設定
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(LoadSceneAsync(sceneName)));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // 現在の Time.timeScale を記憶
        originalTimeScale = Time.timeScale;
        Time.timeScale = 1;  // シーンロード時にタイムスケールを1に設定

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // シーンロード後に元の Time.timeScale を適用
        Time.timeScale = originalTimeScale;
    }
}
