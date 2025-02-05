using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwich : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public GameObject Zeere;
    public GameObject Camera;
    public GameObject Wall;

    //接触開始
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
                MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movBlock.Move();

                ZeereCore ZeereC = Zeere.GetComponent<ZeereCore>();
                ZeereC.Zeereon();

                S5Camera BCamera = Camera.GetComponent<S5Camera>();
                BCamera.Booson();

                WallON Block = Wall.GetComponent<WallON>();
                Block.ON();

            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }
}
