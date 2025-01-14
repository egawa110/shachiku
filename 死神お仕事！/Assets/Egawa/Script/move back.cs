using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveback : MonoBehaviour
{
    [SerializeField] private float ResetPosition;

    private float MoveSpeed = -0.05f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed, 0, 0, Space.World);

        if (transform.position.x < ResetPosition)
            transform.position = StartPosition;
    }
}