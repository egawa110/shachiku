using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereSamon : MonoBehaviour
{
    public GameObject[] Prefabs; // ��������v���t�@�u�̔z��
    public float deletetime = 3.0f;
    float passedTimes = 0;//�o�ߎ���
    private int number; // �����_���ɑI�΂ꂽ�v���t�@�u�̃C���f�b�N�X
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
        passedTimes += Time.deltaTime;//���Ԍo��
        if (passedTimes >= deletetime)
        {
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
            float x = worldPos.x;    // ���[���h���W����ɂ����Ax���W�������Ă���ϐ�
            float y = worldPos.y;    // ���[���h���W����ɂ����Ay���W�������Ă���ϐ�
            number = Random.Range(0, Prefabs.Length); // �v���t�@�u�z�񂩂烉���_���ɃC���f�b�N�X��I��
            Instantiate(Prefabs[number], new Vector2(x, y), Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
