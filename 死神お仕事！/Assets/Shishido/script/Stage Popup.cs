using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopup : MonoBehaviour
{
    public GameObject Popup;//ステージが解放されてない時に出るパネル

    public void Appear()
    {
        Popup.SetActive(true);
    }
    public void Delete()
    {
        Popup?.SetActive(false);
    }
}
