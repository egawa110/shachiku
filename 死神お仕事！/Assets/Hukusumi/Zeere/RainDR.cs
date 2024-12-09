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

    // Update is called once per frame
    void Update()
    {
        
    }
    //接触
    private void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {
        if (other.CompareTag("KinKill"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で〜という条件の下
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }

    }
}
