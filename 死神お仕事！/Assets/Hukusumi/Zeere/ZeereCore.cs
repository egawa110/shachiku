using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] float speed = 5; // �G�̓����X�s�[�h
    bool AttackLooc = false;//�N���p

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // isCheck�̒l�𔽓]������
            AttackLooc = !AttackLooc;
        }
        if (AttackLooc == false)
        {
            // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�

            // �v���C���[�Ɍ����Đi��
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Reel.position.x, Reel.position.y),
                speed * Time.deltaTime);
        }


    }
}
