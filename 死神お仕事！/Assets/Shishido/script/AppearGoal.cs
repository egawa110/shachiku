using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearGoal : MonoBehaviour
{
    private PlayerController PlayCon;
    

    void Start()
    {
        PlayCon = FindObjectOfType<PlayerController>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (PlayCon.ALL_SOUL >= 10)
        {
            gameObject.SetActive(true);
        }
    }
}