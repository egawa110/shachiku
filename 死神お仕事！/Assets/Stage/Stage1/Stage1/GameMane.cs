using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UIを使うのに必要

public class GameMana : MonoBehaviour
{

    public GameObject mainImage;      //画像を持つGameObject
    public Sprite gameOverSpr;        //GAME OVER画像
    public Sprite gameClearSpr;       //GAME CLEAR画像
    public GameObject panel;          //パネル
    public GameObject restartButton;  //RESTARTボタン
    public GameObject nextButton;     //ネクストボタン

    Image titleImage;                 //画像を表示しているImageコンポーネント

    //+++ 時間制限追加 +++
    public GameObject timeBar;  //時間表示イメージ
    public GameObject timeText; //時間テイスト
    TimeController timeCnt;     //TimeController

    public GameObject soulText; //魂のテキスト
    public int stageSoul;       //取得した魂の数

    // Start is called before the first frame update
    void Start()
    {

        //画像を非表示にする
        Invoke("InactiveImage", 1.0f);
        //ボタン（パネル）を非表示にする
        panel.SetActive(false);

        //+++ 時間制限追加 +++
        //TimeContorollerを取得
        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timeBar.SetActive(false); //制限時間なしなら隠す
            }
        }

        UpdateSoul();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerC.gameState == "gameclear")
        {
            //ゲームクリア
            mainImage.SetActive(true);  //画像を表示する
            panel.SetActive(true);  //ボタン（パネル）を表示する

            // RESTARTボタンを無効かする
            Button bt = restartButton.GetComponent<Button>();
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSpr;  //画像を設定する
            PlayerController.gameState = "gameend";

            //+++ 時間制限追加 +++
            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true; //時間カウント停止
            }
        }
        else if (PlayerC.gameState == "gameover")
        {
            //ゲームオーバー
            mainImage.SetActive(true);  //画像を表示する
            panel.SetActive(true);  //ボタン(パネル)を表示する
            //NEXTボタンを無効化する
            Button bt = nextButton.GetComponent<Button>();
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSpr;  //画像を設定する
            PlayerC.gameState = "gameend";

            //+++ 時間制限追加 +++
            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true; //時間カウント停止
            }
        }
        else if (PlayerC.gameState == "playing")
        {
            //ゲーム中
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //playerControllerを取得する
            PlayerC playerCnt = player.GetComponent<PlayerC>();

            //+++ 時間制限追加 +++
            //タイムを更新
            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    //整数に代入することで少数を切り捨てる
                    int time = (int)timeCnt.displayTime;

                    //タイム更新
                    timeText.GetComponent<Text>().text = time.ToString();
                    //タイムオーバー
                    if (time == 0)
                    {
                        playerCnt.GameOver(); //ゲームオーバーにする
                    }
                }
            }
        }

        UpdateSoul();
    }

    //画像を非表示にする
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    void UpdateSoul()
    {
        //ゲーム中
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //playerControllerを取得する
        PlayerC playerCnt = player.GetComponent<PlayerC>();

        soulText.GetComponent<Text>().text = playerCnt.ALL_SOUL.ToString();
    }
}