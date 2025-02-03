using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageHalo : MonoBehaviour
{
    int rnd;//����
    bool inDamage = false;
    public bool HalfF = false;
    float HalfC ;
    // Start is called before the first frame update
    void Start()
    {
        ZeereCore zeere; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("ZeereCore"); //Player���Ă����I�u�W�F�N�g��T��
        zeere = obj.GetComponent<ZeereCore>(); //�t���Ă���X�N���v�g���擾
        HalfC = zeere.BsCT;
    }

    // Update is called once per frame
    void Update()
    {
        if (HalfF)
        {
            //�����ň�u�����銴���ł��Ȃ��Ⴗ
            rnd = Random.Range(0, 100);//����
            if (inDamage)
            {
                //�_���[�W���A�_�ł�����
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
                rnd = 100;
            }
            if (rnd == 0)
            {
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.25f);
            }
        }
        else
        {
            ZeereCore zeere; //�ĂԃX�N���v�g�ɂ����Ȃ���
            GameObject obj = GameObject.Find("ZeereCore"); //Player���Ă����I�u�W�F�N�g��T��
            zeere = obj.GetComponent<ZeereCore>(); //�t���Ă���X�N���v�g���擾
            if (zeere.BsCT==HalfC/2)
            {
                HarfFON();
            }
        }

    }

    //�_���[�W�I��
    void DamageEnd()
    {
        inDamage = false; // �_���[�W�t���OOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // �X�v���C�g�����ɖ߂�
    }
    void HarfFON()
    {
        HalfF = true;
    }
}
