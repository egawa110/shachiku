using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopup : MonoBehaviour
{
    public GameObject Popup;//�X�e�[�W���������ĂȂ����ɏo��p�l��

    public void Appear()
    {
        Popup.SetActive(true);
    }
    public void Delete()
    {
        Popup?.SetActive(false);
    }
}
