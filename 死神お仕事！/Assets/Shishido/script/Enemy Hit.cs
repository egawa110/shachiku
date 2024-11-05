using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2DŒ^‚Ì•Ï”

    public int HP_E = 4;    //“G‚Ì‘Ì—Í

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP_E--;
            if (HP_E <= 0)
            {
                //€–S
                //“–‚½‚è‚ğíœ
                GetComponent<BoxCollider2D>().enabled = false;
                //ˆÚ“®’â~
                rbody.velocity = Vector2.zero;
                //0.5•bŒã‚ÉÁ‚·
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
