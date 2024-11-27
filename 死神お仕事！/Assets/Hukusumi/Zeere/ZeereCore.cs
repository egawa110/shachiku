using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] GameObject Samon;
    [SerializeField] GameObject prefab_A;
    [SerializeField] GameObject prefab_B;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Rite;
    [SerializeField] GameObject Beem;
    [SerializeField] GameObject Helo;

    Transform gateTransform;
    public Transform target;
    float passedTimes = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // 敵の動くスピード
    [SerializeField] float RUspeed = 3;
    float ATspeed = 10.0f;
    float SamonC = 0;
    public float Attack = 10;

    int rnd;
    
    public float brx = 0.5f;
    public float bry = 20.0f;
    public float rx = 1.0f;
    public float boder = 10.0f;

    bool GO = false;
    bool GoOK = false;

    bool Cool = false;//調整用
    bool AttackLooc = true;//起動用
    bool BusteAttack = false;//突進起動用
    bool SamonAttack = false;//召喚起動用
    bool RitoningAttack = false;//雷雨起動用
    bool ReeserAttack = false;//ビーム起動用

    bool BusteLooc = false;//突進起動用
    bool SamonLooc = false;//召喚起動用
    bool RitoningLooc = false;//雷雨起動用
    bool ReeserLooc = false;//ビーム起動用
    bool LongLooc = false;

    private void Start()
    {
       
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))//突進ON
        {
            GO = true;
        }

        if (GO==false)
        {
            passedTimes = 0;
            //待機場所へ移動
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -3),
               speed * Time.deltaTime);
        }
        if(GO==true&&GoOK==false)
        {
            //指定位置に上昇
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, 3),
               1 * Time.deltaTime);

            if (passedTimes>5&&Cool==false)
            {
                Cool = true;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                Instantiate(Helo, new Vector2(x, y), Quaternion.identity);

            }
            if(passedTimes>7)
            {
                ReeserAttack = !ReeserAttack;
                ReeserLooc = !ReeserLooc;
                passedTimes = 0;
                coorTime = 0;
                GoOK = true;
                Cool = false;
            }
        }
        rnd = Random.Range(1, 6);
        if (Cool==true&&GoOK==true)
        {
            coorTime += Time.deltaTime;//時間経過
            if(coorTime>3)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
        passedTimes += Time.deltaTime;//時間経過
        if (passedTimes > Attack)
        {
            if (AttackLooc == false)//起動用
            {


                if (rnd == 1 && BusteLooc == false)//突進ON
                {
                    AttackLooc = !AttackLooc;
                    BusteAttack = !BusteAttack;
                    BusteLooc = !BusteLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 2 && SamonLooc == false)//召喚ON
                {
                    AttackLooc = !AttackLooc;
                    SamonAttack = !SamonAttack;
                    SamonLooc = !SamonLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 3 && RitoningLooc == false)//雷雨ON
                {
                    AttackLooc = !AttackLooc;
                    RitoningAttack = !RitoningAttack;
                    RitoningLooc = !RitoningLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 4 && ReeserLooc == false)//ビームON
                {
                    AttackLooc = !AttackLooc;
                    ReeserAttack = !ReeserAttack;
                    ReeserLooc = !ReeserLooc;
                    passedTimes = 0;
                    coorTime = 0;
                    Debug.Log(AttackLooc);
                }
                if (rnd == 5 && LongLooc == false)
                {
                    passedTimes = 0;
                    LongLooc = true;
                }

                //if (Input.GetKeyDown(KeyCode.L))//突進ON
                //{
                //    AttackLooc = !AttackLooc;
                //    BusteAttack = !BusteAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
                //if (Input.GetKeyDown(KeyCode.M))//召喚ON
                //{
                //    AttackLooc = !AttackLooc;
                //    SamonAttack = !SamonAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
                //if (Input.GetKeyDown(KeyCode.R))//雷雨ON
                //{
                //    AttackLooc = !AttackLooc;
                //    RitoningAttack = !RitoningAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //}
                //if (Input.GetKeyDown(KeyCode.B))//ビームON
                //{

                //    AttackLooc = !AttackLooc;
                //    ReeserAttack = !ReeserAttack;
                //    passedTimes = 0;
                //    coorTime = 0;
                //    Debug.Log(AttackLooc);
                //}
            }
        }



        if (AttackLooc == false)//待機状態
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
                //Debug.Log(toDirection);
                // 対象物へ回転する
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);

                //プロト低速ロックオン
                //if(toDirection.x>0&& transform.localEulerAngles.x-toDirection.x>0)
                //{
                //    transform.Rotate(new Vector3(0, 0, 1));
                //}
            }
            if (passedTimes>=3)
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, ATspeed, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
                SamonLooc = false;
                RitoningLooc = false;
                ReeserLooc = false;
                LongLooc = false;
            }
        }


        if (SamonAttack == true)//召喚
        {
            SamonC += Time.deltaTime;//時間経過
            if (coorTime < 3)
            {
                if (SamonC > 0.5)
                {
                    coorTime += 1;
                    SamonC = 0;
                    //Debug.Log("zzz");
                    // 生成する

                    Transform myTransform = gateTransform.transform;
                    Vector2 worldPos = myTransform.position;
                    float x = worldPos.x;
                    float y = worldPos.y;

                    Instantiate(Samon, new Vector2(x, y), Quaternion.identity);

                    //Instantiate(Samon, gateTransform.position, gateTransform.rotation);
                }
            }
            if (passedTimes > 4)
            {

                AttackLooc = !AttackLooc;
                SamonAttack = !SamonAttack;
                passedTimes = 0;
                coorTime = 0;
                SamonC = 0;
                BusteLooc = false;
                RitoningLooc = false;
                ReeserLooc = false;
                LongLooc = false;
            }
        }


        if (RitoningAttack == true)//雷雨
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(0, 3),
                speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            if (SamonC<2)
            {
                SamonC+=1;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                Instantiate(Rain, new Vector2(0, 6), Quaternion.identity);
            }
            if (passedTimes > 4)
            {
                

                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                Instantiate(prefab_A, new Vector2(brx, bry), Quaternion.identity);
                Instantiate(prefab_A, new Vector2(-brx, bry), Quaternion.identity);
                Transform myTransformA = this.transform;
                Vector2 worldPosA = myTransformA.position;
                Instantiate(prefab_B, new Vector2(brx, bry), Quaternion.identity);
                Instantiate(prefab_B, new Vector2(-brx, bry), Quaternion.identity);
                brx += rx;
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                }
                if (brx > boder)
                {
                    brx = 0.5f;
                   
                }
                if (passedTimes > 4.5)
                {
                    passedTimes = 0;
                    AttackLooc = false;
                    RitoningAttack = false;
                    SamonC = 0;
                    BusteLooc = false;
                    SamonLooc = false;
                    ReeserLooc = false;
                    LongLooc = false;
                }
            }
        }


        if (ReeserAttack == true)
        {
            if (SamonC < 1)
            {
                SamonC += 1;
                Transform myTransform = target.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;
                float y = 0;

                Instantiate(Beem, new Vector2(x, y), Quaternion.identity);
                Instantiate(Beem, new Vector2(-x, y), Quaternion.identity);
            }
            if (passedTimes > 3.1)
            {
                passedTimes = 0;
                AttackLooc = false;
                ReeserAttack = false;
                SamonC = 0;
                BusteLooc = false;
                SamonLooc = false;
                RitoningLooc = false;
                LongLooc = false;
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
            
        }

    }
}
