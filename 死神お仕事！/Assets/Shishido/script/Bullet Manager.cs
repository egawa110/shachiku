using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f; //íeÇÃÉXÉsÅ[Éh
    [SerializeField] private int DeleteTime = 1;

    private PlayerController playcon;

    void Start()
    {
        playcon = GetComponent<PlayerController>();
    }

    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj.transform.localScale.x >= 0)
        {
            Move_R();
        }
        else if (playerObj.transform.localScale.x <= 0)
        {
            Move_L();
        }

        Destroy(gameObject, DeleteTime);
    }
    
    public void Move_R()
    {
        Vector3 bulletPos = transform.position; //Vector3å^ÇÃbulletPosÇ…åªç›ÇÃà íuèÓïÒÇäiî[
        bulletPos.x += speed * Time.deltaTime; //xç¿ïWÇ…speedÇâ¡éZÅ@âEå¸Ç´ÅiëOÅj
        transform.position = bulletPos; //åªç›ÇÃà íuèÓïÒÇ…îΩâfÇ≥ÇπÇÈ
    }
    public void Move_L()
    {
        Vector3 bulletPos = transform.position; //Vector3å^ÇÃbulletPosÇ…åªç›ÇÃà íuèÓïÒÇäiî[
        bulletPos.x += speed * Time.deltaTime; //xç¿ïWÇ…speedÇâ¡éZÅ@ç∂å¸Ç´Åiå„ÇÎÅj
        transform.position = bulletPos; //åªç›ÇÃà íuèÓïÒÇ…îΩâfÇ≥ÇπÇÈ
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);//íeÇ™è¡Ç¶ÇÈ
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);//íeÇ™è¡Ç¶ÇÈ
            //Destroy(other.gameObject);//ìGÇ‡è¡Ç¶ÇÈ

        }
    }
}
