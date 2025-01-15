using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchButton : MonoBehaviour
{
    public string sceneName; // �؂�ւ������V�[���̖��O

    private void Start()
    {
        Time.timeScale = 1;
        // �{�^���R���|�[�l���g���擾���A�N���b�N���Ƀ��\�b�h���Ăяo���悤�ݒ�
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