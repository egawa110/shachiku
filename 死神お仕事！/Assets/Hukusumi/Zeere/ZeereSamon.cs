using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereSamon : MonoBehaviour
{
    public GameObject[] Prefabs; // 生成するプレファブの配列
    public float deletetime = 3.0f;
    float passedTimes = 0;//経過時間
    private int number; // ランダムに選ばれたプレファブのインデックス
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
        passedTimes += Time.deltaTime;//時間経過
        if (passedTimes >= deletetime)
        {
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
            float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
            float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
            number = Random.Range(0, Prefabs.Length); // プレファブ配列からランダムにインデックスを選ぶ
            Instantiate(Prefabs[number], new Vector2(x, y), Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
