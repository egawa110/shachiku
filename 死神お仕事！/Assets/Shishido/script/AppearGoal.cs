using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearGoal : MonoBehaviour
{
    private PlayerController _playCon;
    public GameObject GoalObj;

    void Start()
    {
        _playCon = FindObjectOfType<PlayerController>();
        GoalObj.SetActive(false);
    }

    void Update()
    {
        Debug.Log("UpDate�Ăяo��");
        Debug.Log(_playCon.ALL_SOUL);

        if (_playCon.ALL_SOUL >= 10)
        {
            GoalObj.SetActive(true);
            Debug.Log("�S�[�����\������܂���");
        }
    }
}
