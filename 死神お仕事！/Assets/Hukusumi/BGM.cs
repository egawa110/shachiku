using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public bool BGMLoop = false;
    bool Cake = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
    if(BGMLoop==true&&Cake==false)
        {
            audioSource.Play();
            Cake = true;
        }
    }

    public void StartL()
    {
        BGMLoop = true;
    }
}

