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

    //�ڐG
    private void OnTriggerEnter2D(Collider2D other) //�Ԃ�����������閽�ߕ��J�n
    {
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
        }

    }
}
