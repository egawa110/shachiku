using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMsound : MonoBehaviour
{
    public bool DontDestroyEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyEnabled)
        {
            //�V�[�����؂�ւ���Ă����̃I�u�W�F�N�g�͏����Ȃ�
            DontDestroyOnLoad(this);
        }
    }
}
