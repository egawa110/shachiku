using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamonTest : MonoBehaviour
{
    [SerializeField] GameObject prefab_A;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
            float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
            float y = 2.5f;    // ワールド座標を基準にした、y座標が入っている変数
            Instantiate(prefab_A, new Vector2(x, y), Quaternion.identity);
        }
    }
}
