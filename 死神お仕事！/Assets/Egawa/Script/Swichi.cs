using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichi : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public Sprite imageOn;
    public Sprite imageOff;
    public bool on = false; // スイッチの状態（true:押されている false:押されていない）

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
    }

    // 接触開始
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