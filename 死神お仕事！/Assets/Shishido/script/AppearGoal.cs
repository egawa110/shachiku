using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearGoal : MonoBehaviour
{
    private PlayerController PlayCon;

    void Start()
    {
        PlayCon = FindObjectOfType<PlayerController>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        Debug.Log("Updateメソッドが呼び出されています");
        Debug.Log(PlayCon.ALL_SOUL);

        if (PlayCon.ALL_SOUL >= 10)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("ゴールが表示されました");
        }
    }
}