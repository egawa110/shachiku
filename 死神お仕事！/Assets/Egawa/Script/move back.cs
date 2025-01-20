using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveback : MonoBehaviour
{
    //���Z�b�g������W
    [SerializeField] private float ResetPosition;

    //�C���X�g�̈ړ��X�s�[�h
    private float MoveSpeed = -0.02f;

    //�X�^�[�g������W
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed, 0, 0, Space.World);

        //����X���̍��W�����Z�b�g���W��菬�����ꍇ
        if (transform.position.x < ResetPosition)
        {
            //����X�����W�ɍŏ��̍��W������
            transform.position = StartPosition;
        }
    }
}