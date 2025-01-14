using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[4];
    private int lifePoint = 4;

    //void Update()
    //{
    //if (Input.GetMouseButtonDown(0) && lifePoint < 4)
    //{
    //    lifePoint++;
    //    lifeArray[lifePoint - 1].SetActive(true);
    //}

    //else if (Input.GetMouseButtonDown(1) && lifePoint > 0)
    //{
    //    lifeArray[lifePoint - 1].SetActive(false);
    //    lifePoint--;
    //}
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }
}