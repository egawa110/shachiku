using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v

public class ChangeScene : MonoBehaviour
{
    private PauseMenu pausemenu;


    //-----------------------------------------
    // �t�F�[�h����̃X�N���v�g
    //-----------------------------------------
    public string SceneName; // �ǂݍ��ރV�[����

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

    // �V�[����ǂݍ���
    public void Load()
    {
        //SceneManager.LoadScene(SceneName);
        Initiate.Fade(SceneName, Color.black, 1.0f);

        Debug.Log(SceneName);
    }
}
