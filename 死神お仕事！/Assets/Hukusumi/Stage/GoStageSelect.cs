using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v
using UnityEngine.UI;

public class GOStageSelect : MonoBehaviour
{
    private PauseMenu pausemenu;

    //-----------------------------------------
    // �t�F�[�h����̃X�N���v�g
    //-----------------------------------------
    public string Opening; // �ǂݍ��ރV�[����
    public string Stage1; // �ǂݍ��ރV�[����
    public string Stage2; // �ǂݍ��ރV�[����
    public string Stage3; // �ǂݍ��ރV�[����
    public string Stage4; // �ǂݍ��ރV�[����
    public string Stage5; // �ǂݍ��ރV�[����
    public string StageAll; // �ǂݍ��ރV�[����
    int CC;
    void Start()
    {
        Time.timeScale = 1;
        // �{�^���R���|�[�l���g���擾���A�N���b�N���Ƀ��\�b�h���Ăяo���悤�ݒ�
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(LoadSceneAsync()));
    }
    void Update()
    {

    }
    // �V�[����ǂݍ���
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
