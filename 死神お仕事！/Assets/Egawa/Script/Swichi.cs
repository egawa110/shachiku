using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMovement : MonoBehaviour
{
    public Transform targetPosition; // �I���̎��̖ڕW�ʒu
    public Transform originalPosition; // �I�t�̎��̌��̈ʒu
    public bool isSwitchOn = false; // �X�C�b�`�̏��

    void Update()
    {
        if (isSwitchOn)
        {
            // �X�C�b�`���I���̎��A�ڕW�ʒu�Ɉړ�
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * 5);
        }
        else
        {
            // �X�C�b�`���I�t�̎��A���̈ʒu�ɖ߂�
            transform.position = Vector3.Lerp(transform.position, originalPosition.position, Time.deltaTime * 5);
        }
    }

    // �X�C�b�`�̏�Ԃ�؂�ւ��郁�\�b�h
    public void ToggleSwitch()
    {
        isSwitchOn = !isSwitchOn;
    }
}