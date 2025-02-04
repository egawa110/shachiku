using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearGoal : MonoBehaviour
{
    private PlayerController PlayCon;

    void Start()
    {
        PlayCon = FindObjectOfType<PlayerController>();
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.Log(PlayCon.ALL_SOUL);
        if (PlayCon.ALL_SOUL >= 10)
        {
            //gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(true);
            Debug.Log("ÉSÅ[ÉãÇ™ï\é¶Ç≥ÇÍÇ‹ÇµÇΩ");
        }
    }
}