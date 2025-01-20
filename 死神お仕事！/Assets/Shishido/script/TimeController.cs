using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true�����Ԃ��J�E���g�_�E���h���񂷂�
    public float gameTime = 0;      // �Q�[���̍ő厞��
    public bool isTimeOver = false; // true=�^�C�}�[��~
    public float displayTime = 0;   // �\������

    float times = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isCountDown)
        {
            // �J�E���g�_�E��
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeOver == false)
        {
            times += Time.deltaTime;
            if (isCountDown)
            {
                // �J�E���g�_�E��
                displayTime = gameTime - times;
                if (displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
            else
            {
                // �J�E���g�A�b�v
                displayTime = times;
                if (displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver = true;
                }
            }
        }
    }
}
