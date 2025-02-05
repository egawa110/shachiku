using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichi : MonoBehaviour
{
    private Vector3 initialPosition; //試し追加

    public GameObject targetMoveBlock;
    public Sprite imageOn;
    public Sprite imageOff;
    public bool on = false; //スイッチの状態（true:押されている false:押されていない）

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの初期位置を保存
        initialPosition = transform.position;

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
                MoveBlock2 movBlock = targetMoveBlock.GetComponent<MoveBlock2>();
                movBlock.Stop();
            }

            else
            {
                on = true;
                GetComponent<SpriteRenderer>().sprite = imageOn;
                MoveBlock2 movBlock = targetMoveBlock.GetComponent<MoveBlock2>();
                movBlock.Move();
            }
        }
    }
}
