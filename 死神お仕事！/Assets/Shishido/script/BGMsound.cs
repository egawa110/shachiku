using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMsound : MonoBehaviour
{
    public bool DontDestroyEnabled = true;

    void Start()
    {
        if (DontDestroyEnabled)
        {
            //シーンが切り替わってもこのオブジェクトは消えない
            DontDestroyOnLoad(this);
        }
    }
}
