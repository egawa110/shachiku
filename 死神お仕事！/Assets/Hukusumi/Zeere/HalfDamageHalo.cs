using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageHalo : MonoBehaviour
{
    int rnd;//����
    bool inDamage = false;//�_��
    public bool HalfF = false;//�����m�F
    float HalfC ;//�[�[���������l
    // Start is called before the first frame update
    void Start()
    {
        ZeereCore Zeere; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("ZeereCore"); //Player���Ă����I�u�W�F�N�g��T��
        Zeere = obj.GetComponent<ZeereCore>(); //�t���Ă���X�N���v�g���擾
        HalfC = Zeere.BsCT;//�������l�ۑ�
    }

    // Update is called once per frame
    void Update()
    {
        if (HalfF)
        {
            //�����_���œ_��
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
            if (rnd == 0)//�_�ŋN��
            {
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.25f);
            }
        }
        else
        {
            ZeereCore zeere; //�ĂԃX�N���v�g�ɂ����Ȃ���
            GameObject obj = GameObject.Find("ZeereCore"); //�I�u�W�F�N�g��T��
            zeere = obj.GetComponent<ZeereCore>(); //�t���Ă���X�N���v�g���擾
            if (zeere.BsCT==HalfC/2)//�����m�F
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
