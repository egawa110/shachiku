using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMovement : MonoBehaviour
{
    public Transform targetPosition; // オンの時の目標位置
    public Transform originalPosition; // オフの時の元の位置
    public bool isSwitchOn = false; // スイッチの状態

    void Update()
    {
        if (isSwitchOn)
        {
            // スイッチがオンの時、目標位置に移動
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * 5);
        }
        else
        {
            // スイッチがオフの時、元の位置に戻る
            transform.position = Vector3.Lerp(transform.position, originalPosition.position, Time.deltaTime * 5);
        }
    }

    // スイッチの状態を切り替えるメソッド
    public void ToggleSwitch()
    {
        isSwitchOn = !isSwitchOn;
    }
}