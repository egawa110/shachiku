using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject Zeere;
    bool isAudioEnd = false;
    bool SS = false;
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
        if(SS==false)
        {
            Debug.Log("ZZZ");
            SS = true;
            audioSource.Stop();
        }
    }
    public void Loop()
    {
        isAudioEnd = true;
    }
}

