using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : MonoBehaviour
{
    public float deleteTime = 3.0f; //削除する時間指定

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //何かに接触したら消す
    }
}
