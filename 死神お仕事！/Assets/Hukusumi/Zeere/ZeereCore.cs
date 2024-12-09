using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] GameObject Samon;
    [SerializeField] GameObject Ritning_A;
    [SerializeField] GameObject Ritning_B;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Rite;
    [SerializeField] GameObject Beem;
    [SerializeField] GameObject Helo;
    [SerializeField] GameObject BossEnd;
    [SerializeField] GameObject eye;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject Fadeout;

    public GameObject GameUI;


    Transform gateTransform;
    public Transform target;
    float passedTimes = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // 敵の動くスピード
    //[SerializeField] float RUspeed = 3;
    float ATspeed = 10.0f;
    float SamonC = 0;
    public float Attack = 10;

    int rnd;
    
    public float brx = 0.5f;
    public float bry = 20.0f;
    public float rx = 1.0f;
    public float boder = 10.0f;

    public bool GO = false;
    bool GoOK = false;

    bool Cool = false;//調整用
    bool AttackLooc = true;//起動用
    bool BusteAttack = false;//突進起動用
    bool SamonAttack = false;//召喚起動用
    bool RitoningAttack = false;//雷雨起動用
    bool ReeserAttack = false;//ビーム起動用

    bool BusteLooc = false;//突進ロック
    bool SamonLooc = false;//召喚ロック
    bool RitoningLooc = false;//雷雨ロック
    bool ReeserLooc = false;//ビームロック
    bool LongLooc = false;//延長ロック

    bool EndF = false;
    bool Crear = false;
    bool Fade = false;

    public int HP_Z = 40;    //敵の体力
    private bool inDamage;  //ダメージ中のフラグ

    GameObject Zeere1;
    GameObject Zeere2;
    GameObject Zeere3;
    GameObject Zeere4;

    private void Start()
    {
       
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("ZeerenoTyuusinnZERO");
        Zeere2 = GameObject.Find("ZeerenoTyuusinn");
        Zeere3 = GameObject.Find("ZeereEye");
        Zeere4 = GameObject.Find("ZeereKabar");


    }

    private void Update()
    {
        passedTimes += Time.deltaTime;//時間経過
        if (GO == true)
        {
            if (inDamage)
            {
                //ダメージ中、点滅させる
                float val = Mathf.Sin(Time.time * 50);
                if (val > 0)
                {
                    //スプライトを表示
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere4.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    //スプライトを非表示
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere4.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                Zeere3.GetComponent<SpriteRenderer>().enabled = true;
                Zeere4.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        //if (Input.GetKeyDown(KeyCode.G))//ON
        //{
        //    GO = true;
        //}

        if (GO==false)
        {

            passedTimes = 0;
            //待機場所へ移動
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -4.5f),
               speed * Time.deltaTime);
        }
        if(GO==true&&GoOK==false)
        {
            if(passedTimes>1)
            {
                ZeereEye Eyeon = Zeere3.GetComponent<ZeereEye>();
                Eyeon.ON();
            }
            if (passedTimes > 2)
            {
                //指定位置に上昇
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(0, 3),
                   1 * Time.deltaTime);
            }

            if (passedTimes>7&&Cool==false)
            {
                Cool = true;
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                Instantiate(Helo, new Vector2(x, y), Quaternion.identity);

            }
            if(passedTimes>9)
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
        if (Cool==true&&GoOK==true&&EndF==false)
        {
            coorTime += Time.deltaTime;//時間経過
            if(coorTime>3)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
       
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
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
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
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            coorTime += Time.deltaTime;//時間経過
            if (SamonC < 3)
            {
                if (coorTime > 0.5)
                {
                    SamonC += 1;
                    coorTime = 0;
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
                Instantiate(Rain, new Vector2(0, 7), Quaternion.identity);
            }
            if (passedTimes > 4)
            {

                if (Cool == false)
                {
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(Ritning_A, new Vector2(brx, bry), Quaternion.identity);
                    Instantiate(Ritning_A, new Vector2(-brx, bry), Quaternion.identity);
                    Transform myTransformA = this.transform;
                    Vector2 worldPosA = myTransformA.position;
                    Instantiate(Ritning_B, new Vector2(brx, bry), Quaternion.identity);
                    Instantiate(Ritning_B, new Vector2(-brx, bry), Quaternion.identity);
                    brx += rx;
                }
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                }
                if (brx > boder)
                {
                    Cool = true;
                }
                if (passedTimes > 4.5)
                {
                    brx = 0.5f;
                    passedTimes = 0;
                    AttackLooc = false;
                    RitoningAttack = false;
                    SamonC = 0;
                    BusteLooc = false;
                    SamonLooc = false;
                    ReeserLooc = false;
                    LongLooc = false;
                    Cool = false;
                }
            }
        }


        if (ReeserAttack == true)//ビーム
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
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

        if(EndF==true)
        {
            if (passedTimes > 5)
            {
                if(Fade==false)
                {
                    Fade = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(Fadeout, new Vector2(0, 0), Quaternion.identity);
                }
            }
            if (passedTimes > 10 && Crear == false)
            {
                //Transform myTransform = this.transform;
                //Vector2 worldPos = myTransform.position;
                //Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                GameObject obj = Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                Crear = true;
            }
        }

    }

    public void Zeereon()
    {
        GO = true;
    }

    public void OnTriggerEnter2D(Collider2D other) //ぶつかったら消える命令文開始
    {
        if (EndF == false)
        {
            if (other.CompareTag("Ground") && BusteAttack == true)//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
            {
                BusteAttack = false;
                passedTimes = 0;
                coorTime = 0;
                Cool = true;

            }

            if (other.CompareTag("Wall") && BusteAttack == true)//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
            {
                BusteAttack = false;
                passedTimes = 0;
                coorTime = 0;
                Cool = true;

            }
        }
        if (other.gameObject.tag == "Bullet")
        {
            // 攻撃された時のエフェクト
            GetDamage(other.gameObject);
        }

    }

    void GetDamage(GameObject player)
    {
        if (PlayerController.gameState == "playing")
        {
            HP_Z--; //hpが減る
            Debug.Log(HP_Z);
            if (HP_Z > 0)
            {
                //ダメージフラグ　ON
                inDamage = true;

                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                GameManager S5UI = GameUI.GetComponent<GameManager>();
                S5UI.BossKill();
                //やられる
                AttackLooc = true;
                BusteAttack = false;
                SamonAttack = false;
                RitoningAttack = false;
                ReeserAttack = false;
                if (EndF ==false)
                {
                    passedTimes = 0;
                    EndF = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(BossEnd, new Vector2(0, 0), Quaternion.identity);
                }
                

            }
        }
    }

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false; // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // スプライトを元に戻す
    }
}
