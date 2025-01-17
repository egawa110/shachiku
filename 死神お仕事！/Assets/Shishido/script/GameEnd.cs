using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    //--------------------------------------------------------------------------------------
    // タイトルの「ゲーム終了ボタン」を押したときに呼び出されるスクリプト
    //--------------------------------------------------------------------------------------

    public GameObject confirmationPanel;

    //ゲーム開始時に呼ばれる
    private void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            return;

        //確認パネルを非表示
        confirmationPanel.SetActive(false);
    }

    //確認
    public void confirmation()
    {
        confirmationPanel.SetActive(true);
    }


    //ゲーム終了
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
