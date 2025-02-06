using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLooc : MonoBehaviour
{
    public GameObject AnotherStage;
    int CC;
    // Start is called before the first frame update
    void Start()
    {
        ClearCount clearcount = GetComponent<ClearCount>();
        CC = clearcount.Count;
        if (CC < 6)
        {
            AnotherStage.SetActive(false);
        }
    }
}
