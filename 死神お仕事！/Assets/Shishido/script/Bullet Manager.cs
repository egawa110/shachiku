using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{

    public float axisH = 0.0f;        //“ü—Í


    [SerializeField] private float speed = 5.0f; //’e‚ÌƒXƒs[ƒh

    [SerializeField] private int DeleteTime = 2;

    void Start()
    {
    }

    void Update()
    {
<<<<<<< HEAD


        
        GameObject playerObj = GameObject.Find("Player");



        if (playerObj.transform.localScale.x >= 0)
        {
            Move_Right();
        }
        else
        {
            Move_Left();
        }

        Destroy(gameObject, 2);
        


    }

    
    public void Move_Right()
=======
            Move();

        Destroy(gameObject, DeleteTime);
    }

    public void Move()
>>>>>>> b270e0101c702fcc9426e5780f59ad5933dce0ac
    {

        Vector3 bulletPos = transform.position; //Vector3Œ^‚ÌbulletPos‚ÉŒ»İ‚ÌˆÊ’uî•ñ‚ğŠi”[
        bulletPos.x += speed * Time.deltaTime; //xÀ•W‚Éspeed‚ğ‰ÁZ@¶Œü‚«iŒã‚ëj
        transform.position = bulletPos; //Œ»İ‚ÌˆÊ’uî•ñ‚É”½‰f‚³‚¹‚é


    }

<<<<<<< HEAD
    public void Move_Left()
    {

        Vector3 bulletPos = transform.position; //Vector3Œ^‚ÌbulletPos‚ÉŒ»İ‚ÌˆÊ’uî•ñ‚ğŠi”[
        bulletPos.x += speed * Time.deltaTime; //xÀ•W‚Éspeed‚ğ‰ÁZ@¶Œü‚«iŒã‚ëj
        transform.position = bulletPos; //Œ»İ‚ÌˆÊ’uî•ñ‚É”½‰f‚³‚¹‚é
        
    }

    
}
=======
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
>>>>>>> b270e0101c702fcc9426e5780f59ad5933dce0ac
