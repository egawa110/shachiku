using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beemcore1 : MonoBehaviour
{
    public float deletetime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deletetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
