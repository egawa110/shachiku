using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] float speed = 5; // 敵の動くスピード

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
    }

    private void Update()
    {

        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        
            // プレイヤーに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Reel.position.x, Reel.position.y),
                speed * Time.deltaTime);
        


    }
}
