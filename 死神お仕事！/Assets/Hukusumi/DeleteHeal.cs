using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHeal : MonoBehaviour
{
    public float DelTime = 10;
    float PassedTimes = 0;//�A�N�V�����̎��Ԍo��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PassedTimes += Time.deltaTime;//���Ԍo��
        if (DelTime-PassedTimes<3)
        {
            //�_�ł�����
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //�X�v���C�g��\��
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //�X�v���C�g���\��
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if(DelTime<PassedTimes)
        {
            Destroy(gameObject);
        }
    }
}
