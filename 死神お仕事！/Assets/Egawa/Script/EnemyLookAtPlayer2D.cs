using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer2D : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform���w��

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 2D�Q�[���p��Z���̉�]�݂̂�ݒ�
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}