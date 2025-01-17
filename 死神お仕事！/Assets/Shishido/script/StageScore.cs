using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScore : MonoBehaviour
{
    public int StageNum;//何ステージ目かを判定する用の変数
    public GameObject two;  //２ステージ目
    public GameObject three;//３ステージ目
    public GameObject four; //４ステージ目
    public GameObject five; //５ステージ目

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        //現在のStageNumを呼び出す
        StageNum = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //StageNumが２以上のとき、ステージ２を解放する
        if(StageNum >= 2)
            two.SetActive(true);

        //StageNumが３以上のとき、ステージ３を解放する
        if (StageNum >= 3)
            three.SetActive(true);

        //StageNumが４以上のとき、ステージ４を解放する
        if ( StageNum >= 4)
            four.SetActive(true);

        //StageNumが５以上のとき、ステージ５を解放する
        if (StageNum >= 5)
            five.SetActive(true);
    }
}
