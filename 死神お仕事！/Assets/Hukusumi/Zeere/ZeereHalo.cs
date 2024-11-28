using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereHalo : MonoBehaviour
{
    Transform playerTr;
    [SerializeField] float speed = 2; // 敵の動くスピード
    [SerializeField] float speedover = 99; // 敵の動くスピード

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("ZeereCore").transform;
    }

    private void Update()
    {

        transform.localScale = Vector2.MoveTowards(
                transform.localScale,
                new Vector2(4,4),
                3 * Time.deltaTime);
        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 1.0f)
        {
            // プレイヤーに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
        else
        {
            // プレイヤーに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speedover * Time.deltaTime);
        }

        
    }
}
