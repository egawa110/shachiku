using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : MonoBehaviour
{
    public float deleteTime = 3.0f; //�폜���鎞�Ԏw��

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //�����ɐڐG���������
    }
}
