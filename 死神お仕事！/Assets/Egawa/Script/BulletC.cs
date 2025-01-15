using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : MonoBehaviour
{
    public float deleteTime = 3.0f; //íœ‚·‚éŠÔw’è

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //‰½‚©‚ÉÚG‚µ‚½‚çÁ‚·
    }
}
