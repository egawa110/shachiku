using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beemcore : MonoBehaviour
{
    public float deletetime = 0.3f;

    private AudioSource audioSource;
    public AudioClip Beem_SE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Beem_SE);
        Destroy(gameObject, deletetime);//è¡ãé
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
