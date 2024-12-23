using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereHalo : MonoBehaviour
{
    Transform Zeere;
    [SerializeField] float speed = 2; // ヘイローの動くスピード
    [SerializeField] float speedover = 99; // ヘイローの動くスピード範囲外

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
    }

    private void Update()
    {
        transform.localScale = Vector2.MoveTowards(
                transform.localScale,
                new Vector2(4,4),
                3 * Time.deltaTime);
        if (Vector2.Distance(transform.position, Zeere.position) < 1.0f)
        {
            // ゼーレに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Zeere.position.x, Zeere.position.y),
                speed * Time.deltaTime);
        }
        else
        {
            // ゼーレに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Zeere.position.x, Zeere.position.y),
                speedover * Time.deltaTime);
        }   
    }
}
