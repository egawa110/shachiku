using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopup : MonoBehaviour
{
    public GameObject Popup;//�X�e�[�W���������ĂȂ����ɏo��p�l��

    public void Appear()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        Popup.SetActive(true);
    }
    public void Delete()
    {
        Popup?.SetActive(false);
    }
}
