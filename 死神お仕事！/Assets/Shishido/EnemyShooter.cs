using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // 弾のプレハブ
    public float shootInterval = 1.0f;  // 発射間隔
    public Transform player;  // プレイヤーの位置
    public float bulletSpeed = 3.0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
