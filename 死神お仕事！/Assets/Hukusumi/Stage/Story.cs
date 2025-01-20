using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject[] SS;
    public GameObject[] frame;
    public GameObject[] name;
    int SSC = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SSC==100)
        {
            Destroy(SS[SSC]);
            if (SSC==0)
            {
                frame[SSC].GetComponent<SpriteRenderer>().enabled = true;
                name[SSC].GetComponent<SpriteRenderer>().enabled = true;
                SSC++;
                SS[SSC].GetComponent<SpriteRenderer>().enabled = true;

            }
            if(SSC==2)
            {
                Destroy(frame[0]);
                frame[1].GetComponent<SpriteRenderer>().enabled = true;
                name[1].GetComponent<SpriteRenderer>().enabled = true;
                SSC++;
                SS[SSC].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                SSC++;
                SS[SSC].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
