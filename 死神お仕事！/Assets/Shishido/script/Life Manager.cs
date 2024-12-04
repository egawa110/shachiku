using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];
    private int lifePoint = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0) && lifePoint < 3)
        {
            lifePoint++;
            lifeArray[lifePoint - 1].SetActive(true);
        }

        else if (Input.GetMouseButtonDown(1) && lifePoint > 0)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }

            //if (collision.gameObject.tag == "Enemy" && lifePoint < 4)
            //{
            //    lifePoint++;
            //    lifeArray[lifePoint - 1].SetActive(true);
            //}

            //else if (collision.gameObject.tag == "Enemy" && lifePoint > 0)
            //{
            //    lifeArray[lifePoint - 1].SetActive(false);
            //    lifePoint--;
            //}
        }
}