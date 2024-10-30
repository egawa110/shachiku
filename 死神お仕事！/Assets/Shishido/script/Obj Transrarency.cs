using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTransrarency : MonoBehaviour
{
    SpriteRenderer sr;//Sprite Randerer�p�̕ϐ�

    float cla;

    float speed = 0.005f;//�����ɂȂ�܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();//Sprite Renderer���擾
    }

    // Update is called once per frame
    void Update()
    {
        //��l�����߂Â��Ɠ����ɂȂ�i�悤�ɂ������j
        if(Input.GetKeyDown(KeyCode.S))
        {
            cla = sr.color.a;
            StartCoroutine(Display());
        }
    }

    IEnumerator Display()
    {
        //�����ɂȂ鏈��
        while (cla > 0f)
        {
            cla -= speed;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            yield return null;
        }
    }
}