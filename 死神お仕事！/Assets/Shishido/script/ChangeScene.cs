using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v

public class ChangeScene : MonoBehaviour
{
    //-----------------------------------------
    // �t�F�[�h����̃X�N���v�g
    //-----------------------------------------

    public string SceneName; // �ǂݍ��ރV�[����

    // �V�[����ǂݍ���
    public void Load()
    {
        //SceneManager.LoadScene(SceneName);
        Initiate.Fade(SceneName, Color.black, 1.0f);

        Debug.Log(SceneName);
    }
}
