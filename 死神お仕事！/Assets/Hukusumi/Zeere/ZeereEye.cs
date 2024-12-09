using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeereEye : MonoBehaviour
{
    Transform playerTr;
    Transform Zeere;
    [SerializeField] float speed = 1; // 敵の動くスピード
    bool on = false;
    


    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;

        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 0.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(transform.position, Zeere.position) < 0.2f)
        //{
        //    // プレイヤーに向けて進む
        //    transform.position = Vector2.MoveTowards(
        //        Zeere.position,
        //        new Vector2(playerTr.position.x, playerTr.position.y),
        //        speed * Time.deltaTime);
        //}
        //else
        //{
        //    // プレイヤーに向けて進む
        //    transform.position = Vector2.MoveTowards(
        //        transform.position,
        //        new Vector2(Zeere.position.x, Zeere.position.y),
        //        0.1f * Time.deltaTime);
        //}
        if (on == true)
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            if (color.a <= 1.0f)
            {
                color.a += 0.01f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    public void ON()
    {
        on = !on;
    }

    
}
