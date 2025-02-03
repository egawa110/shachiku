using UnityEngine;


public class MoveBlock2 : MonoBehaviour
{
    private Vector3 originalPosition; // ���̈ʒu
    public Vector3 targetPosition; // �ڕW�ʒu
    private bool isMoving = false;

    void Start()
    {
        originalPosition = transform.position; // �����ʒu��ۑ�
    }

    void Update()
    {
        if (isMoving)
        {
            // �ڕW�ʒu�Ɉړ�
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
        }
        else
        {
            // ���̈ʒu�ɖ߂�
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * 5);
        }
    }

    public void Move()
    {
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
    }
}