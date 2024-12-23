using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : MonoBehaviour
{
    void Update()
    {
        GameObject[] End = GameObject.FindGameObjectsWithTag("ZeereAtach");
        foreach (GameObject Dell in End)
        {
            Destroy(Dell);
        }
    }
}
