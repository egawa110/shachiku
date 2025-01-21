using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject[] Text;//�e�L�X�g
    public GameObject[] Frame;//�����o��
    int SSCount = 0;//��b�J�E���^�[
    public int TChange = 0;//�b�Ґ؂�ւ��^�C�~���O
    public bool MSwitch = false;//���m���[�O�g��Ȃ��Ƃ�
    //��
    private AudioSource audioSource;
    public AudioClip Enter_SE;//�N���b�N��
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
                else if (SSCount == TChange)//�b�Ґ؂�ւ�
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
                Text[SSCount - 1].GetComponent<SpriteRenderer>().enabled = false;//�Z���t�폜
            }

        }
    }
}
