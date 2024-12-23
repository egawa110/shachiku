using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDR : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip Rain_SE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Rain_SE);
    }

    //接触
    private void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }

    }
}
