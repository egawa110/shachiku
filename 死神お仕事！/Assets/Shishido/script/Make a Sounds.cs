using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeaSounds : MonoBehaviour
{
    public AudioClip Select_Sounds;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            //右矢印キーを押したら音が鳴る
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(Select_Sounds);
            }
            //左矢印キーを押したら音が鳴る
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(Select_Sounds);
            }
        }
        else
        {
            return;
        }
    }
}
