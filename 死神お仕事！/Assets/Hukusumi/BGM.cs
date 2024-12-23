using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject Zeere;
    bool isAudioEnd = false;
    bool Load = false;
    private AudioSource audioSource;
    private AudioSource audioSourceZ;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSourceZ =Zeere.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!audioSourceZ.isPlaying && isAudioEnd)
        {
            Debug.Log("RRR");
            audioSource.Play();
            isAudioEnd = false;
        }
        if(Load==false)
        {
            Debug.Log("ZZZ");
            Load = true;
            audioSource.Stop();
        }
    }
    public void Loop()
    {
        isAudioEnd = true;
    }
}

