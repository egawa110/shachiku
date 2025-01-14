using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[4];
    private PlayerController player;
    int HP;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        HP = player.maxHp;
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy")
        {
            lifeArray[HP - 1].SetActive(false);
            HP--;
        }
    }
}