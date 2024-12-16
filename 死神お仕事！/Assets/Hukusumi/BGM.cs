using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject Zeere;
    bool isAudioEnd = false;
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
            audioSource.Play();
            isAudioEnd = false;
        }
    }
    public void Loop()
    {
        isAudioEnd = true;
    }
}

