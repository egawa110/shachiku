using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameObject : MonoBehaviour
{
    [SerializeField][Header("メッセージ（キャラ名）")] private string[] msgCaraName;
    [SerializeField][Header("メッセージ（内容）")] private string[] msgContent;

    GameObject objCanvas = null;

    // Start is called before the first frame update
    void Start()
    {
        objCanvas = gameObject.transform.Find("Canvas").gameObject;
        objCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("ShowLog");
        }
    }

    IEnumerator ShowLog()
    {
        GameObject objCaraName = objCanvas.transform.Find("CaraName").gameObject;
        GameObject objContent = objCanvas.transform.Find("Content").gameObject;

        objCanvas.SetActive(true);

        for (int i = msgCaraName.GetLowerBound(0); i <= msgCaraName.GetUpperBound(0); i++)
        {
            objCaraName.GetComponent<Text>().text = msgCaraName[i];
            objContent.GetComponent<Text>().text = msgContent[i];

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }

        objCanvas.SetActive(false);
    }

}
