using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v

public class ChangeStory : MonoBehaviour
{
    //---------------------------------------------------------------
    // �X�g�[���[�Œ��̃V�[���؂�ւ���p�X�N���v�g
    // �i�t�F�[�h�����j
    //---------------------------------------------------------------

    public string SceneName; // �ǂݍ��ރV�[����

    // �V�[����ǂݍ���
    public void Load()
    {
        SceneManager.LoadScene(SceneName);

        Debug.Log(SceneName);
    }
}
