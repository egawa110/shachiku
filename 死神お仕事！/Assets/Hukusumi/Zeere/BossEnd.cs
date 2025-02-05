using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : MonoBehaviour
{
    void Update()
    {
        GameObject[] End = GameObject.FindGameObjectsWithTag("ZeereAtach");//ゼーレパーツタグ
        GameObject[] Endh = GameObject.FindGameObjectsWithTag("Heal");//ハート
        //全消去
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
