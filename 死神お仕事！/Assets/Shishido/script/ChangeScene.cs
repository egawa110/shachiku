using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v

public class ChangeScene : MonoBehaviour
{
        public string SceneName; // �ǂݍ��ރV�[����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    // �V�[����ǂݍ���
    public void Load()
    {
        FadeManager.Instance.LoadScene(SceneName, 1.0f);

        SceneManager.LoadScene(SceneName);

    }
}
