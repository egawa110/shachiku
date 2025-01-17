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
        // ���������I�u�W�F�N�g�ɉ����ď������s���i��: �v���C���[�̗̑͂����炷�j
        Destroy(gameObject);
    }
}
