using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichi : MonoBehaviour
{
    public Transform targetPosition;   //オンの時の移動位置
    public Transform originalPosition; //オフの時に元の位置
    public bool isSwitchOn = false;    //スイッチの状態

    // Start is called before the first frame update
    void Start()
    {
        if (isSwitchOn)
        {
            //スイッチがオンの時、目標位置に移動
            transform.position = Vector3.Lerp(transform.position, 
                targetPosition.position, Time.deltaTime * 5);
        }
        else
        {
            //スイッチがオフの時、元の位置に戻る
            transform.position = Vector3.Lerp(transform.position,
                originalPosition.position, Time.deltaTime * 5);
        }
    }

    //スイッチの状態を切り替えるメゾット
    public void ToggleSwitch()
    {
        isSwitchOn = !isSwitchOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
