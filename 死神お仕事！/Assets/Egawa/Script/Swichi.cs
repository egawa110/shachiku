using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichi : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public Sprite imageOn;
    public Sprite imageOff;
    public bool on = false; // �X�C�b�`�̏�ԁitrue:������Ă��� false:������Ă��Ȃ��j

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
    }

    // �ڐG�J�n
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            on = !on;
            UpdateSprite();
            MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
            if (on)
            {
                movBlock.Move();
            }
            else
            {
                movBlock.Stop();
            }
        }
    }

    void UpdateSprite()
    {
        if (on)
        {
            GetComponent<SpriteRenderer>().sprite = imageOn;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = imageOff;
        }
    }
}