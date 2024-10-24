using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCont : MonoBehaviour
{
    [SerializeField] private float speed;//�v���C���[�̈ړ����x
    [SerializeField] private float maxY, minY; //�ړ��͈͂̐���

    [SerializeField] private GameObject lazer; //���[�U�[�v���n�u���i�[
    [SerializeField] private Transform attackPoint;//�A�^�b�N�|�C���g���i�[

    [SerializeField] private float attackTime = 0.2f; //�U���̊Ԋu
    private float currentAttackTime; //�U���̊Ԋu���Ǘ�
    private bool canAttack; //�U���\��Ԃ����w�肷��t���O

    void Start()
    {
        currentAttackTime = attackTime; //currentAttackTime��attackTime���Z�b�g�B
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //�v���C���[�𓮂������\�b�h���Ăяo��
        Attack();
    }

    void MovePlayer()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            playerPos.y += speed * Time.deltaTime; //y���W��speed�����Z
                                                   //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Vertical") < 0)�@//���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            playerPos.y -= speed * Time.deltaTime;
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }
    }
    void Attack()
    {
        attackTime += Time.deltaTime; //attackTime�ɖ��t���[���̎��Ԃ����Z���Ă���

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //�w�莞�Ԃ𒴂�����U���\�ɂ���
        }

        if (Input.GetKeyDown(KeyCode.K)) //K�L�[����������
        {
            if (canAttack)
            {
                //�������ɐ�������I�u�W�F�N�g�A��������Vector3�^�̍��W�A��O�����ɉ�]�̏��
                Instantiate(lazer, attackPoint.position, Quaternion.identity);
                canAttack = false;�@//�U���t���O��false�ɂ���
                attackTime = 0f;�@//attackTime��0�ɖ߂�
            }
        }

    }
}