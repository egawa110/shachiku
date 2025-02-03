using UnityEngine;


public class MoveBlock2 : MonoBehaviour
{
    private Vector3 originalPosition; // 元の位置
    public Vector3 targetPosition; // 目標位置
    private bool isMoving = false;

    void Start()
    {
        originalPosition = transform.position; // 初期位置を保存
    }

    void Update()
    {
        if (isMoving)
        {
            // 目標位置に移動
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
        }
        else
        {
            // 元の位置に戻る
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