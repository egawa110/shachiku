using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�

    public int HP_E = 4;    //�G�̗̑�

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
                //���S
                //��������폜
                GetComponent<BoxCollider2D>().enabled = false;
                //�ړ���~
                rbody.velocity = Vector2.zero;
                //0.5�b��ɏ���
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
