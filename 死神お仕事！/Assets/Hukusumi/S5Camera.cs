using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5Camera : MonoBehaviour
{
    public float leftLimit = 0.0f; // 右スクロール上限 
    public float rightLimit = 0.0f; // 左スクロール上限
    public float topLimit = 0.0f; // 上スクロール上限
    public float bottomLimit = 0.0f; // 下スクロール上限

    float speed = 1.5f;
    bool Boos = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.G))//ON
        //{
        //    Boos = !Boos;
        //}

        if (Boos == false)
        {
            GameObject player =
                GameObject.FindGameObjectWithTag("Player");// プレイヤーを探す
            if (player != null)
            {
                //カメラの更新座標
                float x = player.transform.position.x;
                float y = player.transform.position.y;
                float z = transform.position.z;
                //横同期させる
                //両端に移動制限をつける
                if (x < leftLimit)
                {
                    x = leftLimit;
                }
                else if (x > rightLimit)
                {
                    x = rightLimit;
                }
                //縦同期させる
                //上下に移動制限つける
                if (y < bottomLimit)
                {
                    y = bottomLimit;
                }
                else if (y > topLimit)
                {
                    y = topLimit;
                }
                //カメラ位置のVector3を作る
                Vector3 v3 = new Vector3(x, y, z);
                transform.position = v3;
            }
        }
        else if(Boos==true)
        {
            float z = transform.position.z;
            transform.position = Vector3.MoveTowards(
              transform.position,
              new Vector3(0, 0,z),
              speed * Time.deltaTime);
        }
    }

    public void Booson()
    {
        Boos = true;
    }
}
