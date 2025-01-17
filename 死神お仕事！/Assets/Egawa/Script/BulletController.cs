using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject objPrefab;   //発生させるPrefabデータ
    public float delayTime = 3.0f; //遅延時間
    public float fireSpeed = 4.0f; //発射速度
    public float length = 8.0f;    //範囲

    GameObject player;             //プレイヤー
    Transform gateTransform;       //発射口のTransform
    float passedTimes = 0;         //経過時間

    private AudioSource audioSource;
    public AudioClip Enemy_Atk;

    //距離チェック
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d)
        {
            ret = true;
        }
        return ret;
    }

    //Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        //発射口オブジェクトのTransformを取得
        gateTransform = transform.Find("gate");
        //プレイヤーを取得
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    //Update is Called once per frame
    private void Update()
    {
        //待機時間加算
        passedTimes += Time.deltaTime;
        //Playerとの距離チェック
        if (CheckLength(player.transform.position))
        {
            //待機時間経過
            if (passedTimes > delayTime)
            {
                passedTimes = 0; //時間を０にリセット
                //砲弾をプレハブから作る
                Vector2 pos = new Vector2(gateTransform.position.x,
                    gateTransform.position.y);
                GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                //方針が向いてる方向に発射する
                Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                float angleZ = transform.localEulerAngles.z;
                float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                Vector2 v = new Vector2(x, y) * fireSpeed;
                rbody.AddForce(v, ForceMode2D.Impulse);

                audioSource.PlayOneShot(Enemy_Atk);
            }
        }
    }
    //範囲表示
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }

}