using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMS : MonoBehaviour
{
    bool Load = false;
    bool ON = false;
    bool GoOK = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoOK==false && ON==true)
        {
            audioSource.Play();
            GoOK=true;
        }
        if (Load == false)
        {
            Load = true;
            audioSource.Stop();
        }
    }

    public void BS()
    {
        ON = true;
    }
}
