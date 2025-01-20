using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer2D : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformを指定

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 2Dゲーム用にZ軸の回転のみを設定
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}