using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwich : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public GameObject Zeere;
    public GameObject Camera;

    public bool on = false; //�X�C�b�`�̏�ԁitrue:������Ă��� false:������Ă��Ȃ��j

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�ڐG�J�n
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (on)
            {
                on = false;
                MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movBlock.Stop();
            }
            else
            {
                on = true;
                MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movBlock.Move();

                ZeereCore ZeereC = Zeere.GetComponent<ZeereCore>();
                ZeereC.Zeereon();

                S5Camera BCamera = Camera.GetComponent<S5Camera>();
                BCamera.Booson();

                Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
            }
        }
    }
}
