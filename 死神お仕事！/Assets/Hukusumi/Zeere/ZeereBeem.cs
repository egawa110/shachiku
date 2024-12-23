using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereBeem : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] GameObject prefab;
    //public GameObject objPrefab;
    public float firetime = 180.0f;//発射
    float ApassedTimes = 0;//経過時間

    private AudioSource audioSource;
    public AudioClip Charge_SE;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Charge_SE);
    }

    void Update()
    {
        ApassedTimes += Time.deltaTime;//時間経過
        if (ApassedTimes >= firetime)
        {
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
            float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
            float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
            Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
            
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KinKill"))
        {
            Destroy(gameObject);//このゲームオブジェクトを消滅させる
        }
    }

}