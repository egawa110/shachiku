using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : MonoBehaviour
{
    void Update()
    {
        GameObject[] End = GameObject.FindGameObjectsWithTag("ZeereAtach");//�[�[���p�[�c�^�O
        GameObject[] Endh = GameObject.FindGameObjectsWithTag("Heal");//�n�[�g
        //�S����
        foreach (GameObject Dell in End)
        {
            Destroy(Dell);
        }
        foreach (GameObject Dell in Endh)
        {
            Destroy(Dell);
        }
    }
}
