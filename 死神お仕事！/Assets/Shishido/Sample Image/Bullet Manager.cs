using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //e’e‚ÌƒXƒs[ƒh

    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 buletPos = transform.position; //Vector3Œ^‚ÌbulletPos‚ÉŒ»İ‚ÌˆÊ’uî•ñ‚ğŠi”[

        GameObject playerObj = GameObject.Find("Player");

        if (playerObj.transform.localScale.x >= 0)
        {
            buletPos.x += speed * Time.deltaTime; //xÀ•W‚Éspeed‚ğ‰ÁZ
        }
        else if(playerObj.transform.localScale.x <= 0)
        {
            buletPos.x -= speed * Time.deltaTime; //xÀ•W‚Éspeed‚ğ‰ÁZ
        }

        transform.position = buletPos; //Œ»İ‚ÌˆÊ’uî•ñ‚É”½‰f‚³‚¹‚é
    }
}