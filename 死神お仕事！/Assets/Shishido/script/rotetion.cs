using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotetion : MonoBehaviour
{
    public int s = 90;

    private void FixedUpdate()
    {
        //transform.Rotate(new Vector3(0, 0, s));//���
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, s));//���
    }


}
