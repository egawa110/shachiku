using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamonTG : MonoBehaviour
{
    //回転速度
    public int s=121;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, s));//回る
    }
}
