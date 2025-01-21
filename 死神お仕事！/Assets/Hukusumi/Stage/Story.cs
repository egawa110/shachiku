using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject[] Text;//テキスト
    public GameObject[] Frame;//吹き出し
    int SSCount = 0;//会話カウンター
    public int TChange = 0;//話者切り替えタイミング
    public bool MSwitch = false;//モノローグ使わないとき
    //音
    private AudioSource audioSource;
    public AudioClip Enter_SE;//クリック音
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Text.Length; i++)
        {
            Text[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int j= 0; j < Frame.Length; j++)
        {
            Frame[j].GetComponent<SpriteRenderer>().enabled = false;
        }
        if (MSwitch == false)
        {
            Text[SSCount].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            Frame[SSCount].GetComponent<SpriteRenderer>().enabled = true;
            SSCount++;
            Text[SSCount].GetComponent<SpriteRenderer>().enabled = true;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(Enter_SE);
            if (SSCount == 0)
                {
                    Frame[SSCount].GetComponent<SpriteRenderer>().enabled = true;
                    SSCount++;
                    Text[SSCount].GetComponent<SpriteRenderer>().enabled = true;

                }
                else if (SSCount == TChange)//話者切り替え
                {
                    Frame[0].GetComponent<SpriteRenderer>().enabled = false;
                    Frame[1].GetComponent<SpriteRenderer>().enabled = true;
                    SSCount++;
                    Text[SSCount].GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    SSCount++;
                    if (SSCount >= Text.Length)
                    {
                        Debug.Log("GO");
                        ChangeStory changestory = GetComponent<ChangeStory>();
                        changestory.Load();
                    }
                    Text[SSCount].GetComponent<SpriteRenderer>().enabled = true;
                }
            if (SSCount < Text.Length)
            {
                Text[SSCount - 1].GetComponent<SpriteRenderer>().enabled = false;//セリフ削除
            }

        }
    }
}
