using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5; //e’e‚ÌƒXƒs[ƒh

    public float DeleteTime = 2.0f;//Á‚¦‚éŠÔ

    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);//‰½‚©‚É“–‚½‚Á‚½‚çÁ‚¦‚é
    }
}