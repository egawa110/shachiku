using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereHalo : MonoBehaviour
{
    Transform Zeere;
    [SerializeField] float speed = 2; // �w�C���[�̓����X�s�[�h
    [SerializeField] float speedover = 99; // �w�C���[�̓����X�s�[�h�͈͊O

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
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
            // �[�[���Ɍ����Đi��
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Zeere.position.x, Zeere.position.y),
                speed * Time.deltaTime);
        }
        else
        {
            // �[�[���Ɍ����Đi��
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Zeere.position.x, Zeere.position.y),
                speedover * Time.deltaTime);
        }   
    }
}
