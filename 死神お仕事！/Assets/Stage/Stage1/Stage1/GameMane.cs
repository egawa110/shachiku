using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI���g���̂ɕK�v

public class GameMana : MonoBehaviour
{

    public GameObject mainImage;      //�摜������GameObject
    public Sprite gameOverSpr;        //GAME OVER�摜
    public Sprite gameClearSpr;       //GAME CLEAR�摜
    public GameObject panel;          //�p�l��
    public GameObject restartButton;  //RESTART�{�^��
    public GameObject nextButton;     //�l�N�X�g�{�^��

    Image titleImage;                 //�摜��\�����Ă���Image�R���|�[�l���g

    //+++ ���Ԑ����ǉ� +++
    public GameObject timeBar;  //���ԕ\���C���[�W
    public GameObject timeText; //���ԃe�C�X�g
    TimeController timeCnt;     //TimeController

    public GameObject soulText; //���̃e�L�X�g
    public int stageSoul;       //�擾�������̐�

    // Start is called before the first frame update
    void Start()
    {

        //�摜���\���ɂ���
        Invoke("InactiveImage", 1.0f);
        //�{�^���i�p�l���j���\���ɂ���
        panel.SetActive(false);

        //+++ ���Ԑ����ǉ� +++
        //TimeContoroller���擾
        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timeBar.SetActive(false); //�������ԂȂ��Ȃ�B��
            }
        }

        UpdateSoul();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerC.gameState == "gameclear")
        {
            //�Q�[���N���A
            mainImage.SetActive(true);  //�摜��\������
            panel.SetActive(true);  //�{�^���i�p�l���j��\������

            // RESTART�{�^���𖳌�������
            Button bt = restartButton.GetComponent<Button>();
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSpr;  //�摜��ݒ肷��
            PlayerController.gameState = "gameend";

            //+++ ���Ԑ����ǉ� +++
            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true; //���ԃJ�E���g��~
            }
        }
        else if (PlayerC.gameState == "gameover")
        {
            //�Q�[���I�[�o�[
            mainImage.SetActive(true);  //�摜��\������
            panel.SetActive(true);  //�{�^��(�p�l��)��\������
            //NEXT�{�^���𖳌�������
            Button bt = nextButton.GetComponent<Button>();
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSpr;  //�摜��ݒ肷��
            PlayerC.gameState = "gameend";

            //+++ ���Ԑ����ǉ� +++
            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true; //���ԃJ�E���g��~
            }
        }
        else if (PlayerC.gameState == "playing")
        {
            //�Q�[����
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //playerController���擾����
            PlayerC playerCnt = player.GetComponent<PlayerC>();

            //+++ ���Ԑ����ǉ� +++
            //�^�C�����X�V
            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    //�����ɑ�����邱�Ƃŏ�����؂�̂Ă�
                    int time = (int)timeCnt.displayTime;

                    //�^�C���X�V
                    timeText.GetComponent<Text>().text = time.ToString();
                    //�^�C���I�[�o�[
                    if (time == 0)
                    {
                        playerCnt.GameOver(); //�Q�[���I�[�o�[�ɂ���
                    }
                }
            }
        }

        UpdateSoul();
    }

    //�摜���\���ɂ���
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    void UpdateSoul()
    {
        //�Q�[����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //playerController���擾����
        PlayerC playerCnt = player.GetComponent<PlayerC>();

        soulText.GetComponent<Text>().text = playerCnt.ALL_SOUL.ToString();
    }
}