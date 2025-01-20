using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveback : MonoBehaviour
{
    //リセットする座標
    [SerializeField] private float ResetPosition;

    //イラストの移動スピード
    private float MoveSpeed = -0.02f;

    //スタートすろ座標
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed, 0, 0, Space.World);

        //今のX軸の座標がリセット座標より小さい場合
        if (transform.position.x < ResetPosition)
        {
            //今のX軸座標に最初の座標を入れる
            transform.position = StartPosition;
        }
    }
}