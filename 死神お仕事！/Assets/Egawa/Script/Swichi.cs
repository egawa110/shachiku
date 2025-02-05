using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichi : MonoBehaviour
{
    private Vector3 initialPosition; //�����ǉ�

    public GameObject targetMoveBlock;
    public Sprite imageOn;
    public Sprite imageOff;
    public bool on = false; //�X�C�b�`�̏�ԁitrue:������Ă��� false:������Ă��Ȃ��j

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�̏����ʒu��ۑ�
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

    //�ڐG�J�n
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
