using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereHalo : MonoBehaviour
{
    Transform playerTr;
    [SerializeField] float speed = 2; // �G�̓����X�s�[�h
    [SerializeField] float speedover = 99; // �G�̓����X�s�[�h

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        playerTr = GameObject.FindGameObjectWithTag("ZeereCore").transform;
    }

    private void Update()
    {

        transform.localScale = Vector2.MoveTowards(
                transform.localScale,
                new Vector2(4,4),
                3 * Time.deltaTime);
        // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 1.0f)
        {
            // �v���C���[�Ɍ����Đi��
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
        else
        {
            // �v���C���[�Ɍ����Đi��
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speedover * Time.deltaTime);
        }

        
    }
}
