using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class StageClear
{
    // どのシーンからでもアクセスできる変数
    public static int StageCC = 0;
}

public class ClearcCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        StageClear.StageCC++;
        Debug.Log(StageClear.StageCC.ToString());
    }

    public void S1C()
    {
        if (StageClear.StageCC < 2)
        {
            StageClear.StageCC++;
        }
        Debug.Log(StageClear.StageCC.ToString());
    }
    public void S2C()
    {
        if (StageClear.StageCC < 3)
        {
            StageClear.StageCC++;
        }
        Debug.Log(StageClear.StageCC.ToString());
    }
    public void S3C()
    {
        if (StageClear.StageCC < 4)
        {
            StageClear.StageCC++;
        }
        Debug.Log(StageClear.StageCC.ToString());
    }
    public void S4C()
    {
        if (StageClear.StageCC < 5)
        {
            StageClear.StageCC++;
        }
        Debug.Log(StageClear.StageCC.ToString());
    }
    public void S5C()
    {
        if (StageClear.StageCC < 6)
        {
            StageClear.StageCC++;
        }
        Debug.Log(StageClear.StageCC.ToString());
    }
}
