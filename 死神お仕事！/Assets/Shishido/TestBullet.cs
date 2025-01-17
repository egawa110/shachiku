using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifetime = 2.0f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たったオブジェクトに応じて処理を行う（例: プレイヤーの体力を減らす）
        Destroy(gameObject);
    }
}
