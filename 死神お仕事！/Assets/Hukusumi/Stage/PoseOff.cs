using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseOff : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void Off()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
