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
            Debug.Log("lifePoint:");
            Debug.Log(lifePoint);
        }
        else if (collision.gameObject.tag == "Soul") 
        {
            lifePoint++;

            if (lifePoint > 4) // lifePoint���S���傫���Ȃ�����
            {
                // lifePoint���S�ɂ���
                lifePoint = 4;

                return;
            }

            lifeArray[lifePoint - 1].SetActive(true);

            Debug.Log("lifePoint:");
            Debug.Log(lifePoint);
        }
    }
}