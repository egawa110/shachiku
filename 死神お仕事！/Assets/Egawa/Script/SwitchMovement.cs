using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichi : MonoBehaviour
{
    public Transform targetPosition;   //�I���̎��̈ړ��ʒu
    public Transform originalPosition; //�I�t�̎��Ɍ��̈ʒu
    public bool isSwitchOn = false;    //�X�C�b�`�̏��

    // Start is called before the first frame update
    void Start()
    {
        if (isSwitchOn)
        {
            //�X�C�b�`���I���̎��A�ڕW�ʒu�Ɉړ�
            transform.position = Vector3.Lerp(transform.position, 
                targetPosition.position, Time.deltaTime * 5);
        }
        else
        {
            //�X�C�b�`���I�t�̎��A���̈ʒu�ɖ߂�
            transform.position = Vector3.Lerp(transform.position,
                originalPosition.position, Time.deltaTime * 5);
        }
    }

    //�X�C�b�`�̏�Ԃ�؂�ւ��郁�]�b�g
    public void ToggleSwitch()
    {
        isSwitchOn = !isSwitchOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
