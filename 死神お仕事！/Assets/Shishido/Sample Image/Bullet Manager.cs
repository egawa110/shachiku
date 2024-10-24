using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //e’e‚ÌƒXƒs[ƒh

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {
        Vector3 lazerPos = transform.position; //Vector3Œ^‚ÌplayerPos‚ÉŒ»İ‚ÌˆÊ’uî•ñ‚ğŠi”[
        lazerPos.x += speed * Time.deltaTime; //xÀ•W‚Éspeed‚ğ‰ÁZ
        transform.position = lazerPos; //Œ»İ‚ÌˆÊ’uî•ñ‚É”½‰f‚³‚¹‚é
    }