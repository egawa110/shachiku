using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearGoal : MonoBehaviour
{
    private PlayerController PlayCon;

    void Start()
    {
        PlayCon = GetComponent<PlayerController>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if(PlayCon.ALL_SOUL == 10)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}