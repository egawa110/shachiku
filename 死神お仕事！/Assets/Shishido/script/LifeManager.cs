using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[4];
    private int lifePoint = 4;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
        else if (collision.gameObject.tag == "Soul") 
        {
            lifePoint++;

            if (lifePoint > 4) // lifePointが４より大きくなったら
            {
                // lifePointを４にする
                lifePoint = 4;

                return;
            }

            lifeArray[lifePoint - 1].SetActive(true);

        }
    }
}