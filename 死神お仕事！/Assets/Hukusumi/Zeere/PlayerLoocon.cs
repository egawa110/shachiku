using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoocon : MonoBehaviour
{
    Transform Player;
    Transform Zeere;
    [SerializeField] float speed = 2;//����
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�Ɉړ�
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Player.position.x, Player.position.y),
                speed * Time.deltaTime);
    }
    //�[�[���ːi���[�[�������Ɉړ�
    public void Reset()
    {
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        transform.position = new Vector3(Zeere.position.x, -4, 0);
    }
}