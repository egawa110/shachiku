using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public Sprite imageOn;
    public Sprite imageOff;
    public bool on = false; //スイッチの状態（true:押されている false:押されていない）

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        if (on)
        {
            GetComponent<SpriteRenderer>().sprite = imageOn;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = imageOff;
        }
    }

    //接触開始
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (on)
            {
                on = false;
                GetComponent<SpriteRenderer>().sprite = imageOff;
                MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movBlock.Stop();
            }
            else
            {
                on = true;
                GetComponent<SpriteRenderer>().sprite = imageOn;
                MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movBlock.Move();
            }
        }
    }
}
