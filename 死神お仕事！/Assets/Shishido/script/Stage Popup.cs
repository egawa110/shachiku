using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopup : MonoBehaviour
{
    public GameObject Popup;//ステージが解放されてない時に出るパネル

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
