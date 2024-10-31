using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; //’e‚ÌƒXƒs[ƒh

    [SerializeField] private int DeleteTime = 2;

    void Start()
    {

    }

    void Update()
    {
        Move();

        Destroy(gameObject, DeleteTime);
    }
    
    public void Move()
    {

        Vector3 bulletPos = transform.position; //Vector3Œ^‚ÌbulletPos‚ÉŒ»İ‚ÌˆÊ’uî•ñ‚ğŠi”[
        bulletPos.x += speed * Time.deltaTime; //xÀ•W‚Éspeed‚ğ‰ÁZ@¶Œü‚«iŒã‚ëj
        transform.position = bulletPos; //Œ»İ‚ÌˆÊ’uî•ñ‚É”½‰f‚³‚¹‚é


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);//’e‚ªÁ‚¦‚é
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);//’e‚ªÁ‚¦‚é
            Destroy(other.gameObject);//“G‚àÁ‚¦‚é
        }
    }
}
