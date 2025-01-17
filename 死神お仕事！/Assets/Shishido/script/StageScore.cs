using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScore : MonoBehaviour
{
    public int StageNum;//���X�e�[�W�ڂ��𔻒肷��p�̕ϐ�
    public GameObject two;  //�Q�X�e�[�W��
    public GameObject three;//�R�X�e�[�W��
    public GameObject four; //�S�X�e�[�W��
    public GameObject five; //�T�X�e�[�W��

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        //���݂�StageNum���Ăяo��
        StageNum = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //StageNum���Q�ȏ�̂Ƃ��A�X�e�[�W�Q���������
        if(StageNum >= 2)
            two.SetActive(true);

        //StageNum���R�ȏ�̂Ƃ��A�X�e�[�W�R���������
        if (StageNum >= 3)
            three.SetActive(true);

        //StageNum���S�ȏ�̂Ƃ��A�X�e�[�W�S���������
        if ( StageNum >= 4)
            four.SetActive(true);

        //StageNum���T�ȏ�̂Ƃ��A�X�e�[�W�T���������
        if (StageNum >= 5)
            five.SetActive(true);
    }
}
