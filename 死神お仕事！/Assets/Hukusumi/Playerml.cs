using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerml : MonoBehaviour
{
    [SerializeField] GameObject target;

    void Start()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        Transform myTransform = this.transform;
        Debug.Log(target.transform.position);
        Vector3 pos = target.transform.position;
        pos.y = 0;
       myTransform.position = -pos;
    }
}
