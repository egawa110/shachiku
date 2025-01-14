using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v

public class ChangeBack : MonoBehaviour
{
    private PauseMenu pausemenu;

    //-----------------------------------------
    // �t�F�[�h����̃X�N���v�g(�|�[�Y��ʂ̃{�^���ɂ̂ݎg�p)
    //-----------------------------------------
    public string SceneName; // �ǂݍ��ރV�[����
     
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

    // �V�[����ǂݍ���
    public void Load()
    {
        //SceneManager.LoadScene(SceneName);
        Initiate.Fade(SceneName, Color.black, 1.0f);

        Debug.Log(SceneName);
    }
}
