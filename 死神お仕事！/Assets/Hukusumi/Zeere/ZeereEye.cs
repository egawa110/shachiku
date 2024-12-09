using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeereEye : MonoBehaviour
{
    Transform playerTr;
    Transform Zeere;
    [SerializeField] float speed = 1; // 敵の動くスピード
    SpriteRenderer sp;
    Color spriteColor;
    public float duration = 5.0f;
    bool on = false;
    float fade = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        Zeere = GameObject.FindGameObjectWithTag("ZeereCore").transform;
        sp = GetComponent<SpriteRenderer>();
        spriteColor = sp.color;
        StartCoroutine(Fade(fade));
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
    }

    public void ON()
    {
        on = true;
        fade = 1;
    }

    IEnumerator Fade(float targetAlpha)
    {
        
            while (!Mathf.Approximately(spriteColor.a, targetAlpha))
            {
                float changePerFrame = Time.deltaTime / duration;
                spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, changePerFrame);
                sp.color = spriteColor;
                yield return null;
            }
        
    }
}
