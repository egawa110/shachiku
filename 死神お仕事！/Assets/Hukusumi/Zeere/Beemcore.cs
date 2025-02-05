using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beemcore : MonoBehaviour
{
    public float Deletetime = 0.3f;//è¡ãééûä‘
    private AudioSource audioSource;
    public AudioClip Beem_SE;//SE

    void Start()
    {
        //âπ
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Beem_SE);

        Destroy(gameObject, Deletetime);//è¡ãé
    }
}
