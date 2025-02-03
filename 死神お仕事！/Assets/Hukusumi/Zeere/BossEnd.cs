using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : MonoBehaviour
{
    void Update()
    {
        GameObject[] End = GameObject.FindGameObjectsWithTag("ZeereAtach");
        GameObject[] Endh = GameObject.FindGameObjectsWithTag("Heal");
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
