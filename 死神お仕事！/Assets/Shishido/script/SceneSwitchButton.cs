using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchButton : MonoBehaviour
{
    public string sceneName; // �؂�ւ������V�[���̖��O
    private float originalTimeScale;

    private void Start()
    {
        // �{�^���R���|�[�l���g���擾���A�N���b�N���Ƀ��\�b�h���Ăяo���悤�ݒ�
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(LoadSceneAsync(sceneName)));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // ���݂� Time.timeScale ���L��
        originalTimeScale = Time.timeScale;
        Time.timeScale = 1;  // �V�[�����[�h���Ƀ^�C���X�P�[����1�ɐݒ�

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �V�[�����[�h��Ɍ��� Time.timeScale ��K�p
        Time.timeScale = originalTimeScale;
    }
}
