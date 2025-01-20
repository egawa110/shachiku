using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryFrame : MonoBehaviour
{
    public GameObject name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            name.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            name.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
