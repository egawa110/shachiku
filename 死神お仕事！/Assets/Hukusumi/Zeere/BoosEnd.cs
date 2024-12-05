using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ZeereAtach");
        foreach (GameObject ball_Soccer in balls)
        {
            Destroy(ball_Soccer);
        }
    }
}
