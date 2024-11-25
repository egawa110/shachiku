using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    public Transform target;
    float passedTimes = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // 敵の動くスピード
    float ATspeed = 10.0f;
    bool Cool = false;//調整用
    bool AttackLooc = false;//起動用
    bool BusteAttack = false;//突進起動用



    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
    }

    private void Update()
    {
        if(Cool==true)
        {
            coorTime += Time.deltaTime;//時間経過
            if(coorTime>1)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
        passedTimes += Time.deltaTime;//時間経過
        if (Input.GetKeyDown(KeyCode.L))
        {
            // isCheckの値を反転させる
            AttackLooc = !AttackLooc;
            BusteAttack = !BusteAttack;
            passedTimes = 0;
            coorTime = 0;
        }
        if (AttackLooc == false)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Reel.position.x, Reel.position.y),
                speed * Time.deltaTime);
            if(transform.localEulerAngles.z<180)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else if (transform.localEulerAngles.z > 180)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
            }
        }
     
        

        if(BusteAttack==true)//突進
        {
            if (passedTimes < 3)
            {
                // 対象物へのベクトルを算出
                Vector3 toDirection = target.transform.position - transform.position;
                // 対象物へ回転する
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            }
            if (passedTimes>=3)
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, ATspeed, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {

        if (other.CompareTag("Ground")&&BusteAttack==true)//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            BusteAttack = false;
            passedTimes = 0;
            coorTime = 0;
            Cool = true;
            Debug.Log("zzz");
        }

    }
}
