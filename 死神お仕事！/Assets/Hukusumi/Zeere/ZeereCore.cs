using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeereCore : MonoBehaviour
{
    Transform Reel;
    [SerializeField] GameObject Samon;
    [SerializeField] GameObject Ritning;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Rite;
    [SerializeField] GameObject Beem;
    [SerializeField] GameObject Helo;
    [SerializeField] GameObject BossEnd;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject Fadeout;
    [SerializeField] GameObject HeloNull;
    [SerializeField] GameObject KillEffect;
    [SerializeField] GameObject SoulEat;

    public GameObject GameUI;

    public GameObject LoocON;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    Transform gateTransform;
    Transform BoostTraget;
    public Transform target;
    float passedTimes = 0;
    float BGMTime = 0;
    float coorTime = 0;
    [SerializeField] float speed = 5; // 敵の動くスピード

    //突進系
    float ATspeed = 10.0f;
    public float Attack = 10;
    float BsCT = 3.0f;

    float SamonC = 0;//召喚カウンター

    int rnd;//乱数
    
    public float r = 0.5f;//雷初期化
    float rx;//雷x
    public float ry = 20.0f;//雷y
    public float prx = 1.0f;//雷ずらし
    public float boder = 10.0f;//雷オーバーラン防止

    public bool GO = false;//ゼーレ起動
    bool GoOK = false;//イベント確認

    bool Cool = false;//調整用
    bool Cool2 = false;//調整用2
    bool Cool3 = false;//調整用3
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

    bool EndF = false;//撃破フラグ
    bool Crear = false;//クリア出現
    bool Fade = false;//フェードオブジェフラグ

    public int HP_M = 40;//体力マックス
    int HP_Z ;    //敵の体力
    private bool inDamage;  //ダメージ中のフラグ
    public Slider slider;//スライダー
    bool HalfC = false;

    //ゼーレのパーツ
    GameObject Zeere1;
    GameObject Zeere2;
    GameObject Zeere3;

    //音
    private AudioSource audioSource;
    public AudioClip Samon_SE;
    public AudioClip SamonR_SE;
    public AudioClip Boost_SE;
    public AudioClip Attack_SE;
    public AudioClip AttackC_SE;
    public AudioClip Ritoning_SE;
    public AudioClip ZVoiceA;
    public AudioClip ZVoiceB;
    public AudioClip ZeereON_SE;
    public AudioClip ZeereON2_SE;
    public AudioClip Break_SE;
    public AudioClip Foor_SE;
    public AudioClip Damage_SE;

    public AudioSource Loop_BGM;
    public AudioSource Start_BGM;
    public GameObject targetBGM;
    public GameObject targetBGMS;
    bool LoopC = false;

    private void Start()
    {
        HP_Z = HP_M;
        rx = r;
        slider.value = HP_M;
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        BoostTraget = GameObject.FindGameObjectWithTag("PlayerLoocon").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("Zeerecenter");
        Zeere2 = GameObject.Find("ZeereEye");
        Zeere3 = GameObject.Find("ZeereKabar");

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        passedTimes += Time.deltaTime;//時間経過
        if (LoopC == false)
        {
            BGMTime += Time.deltaTime;//時間経過
        }
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
                    //Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    //スプライトを非表示
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    //Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                //Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                Zeere1.GetComponent<SpriteRenderer>().enabled = true;
                Zeere2.GetComponent<SpriteRenderer>().enabled = true;
                Zeere3.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        //開始時
        if (GO==false)
        {

            passedTimes = 0;
            BGMTime = 0;
            //待機場所へ移動
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -4.5f),
               speed * Time.deltaTime);
        }
        //起動
        if(GO==true&&GoOK==false)
        {
            if(passedTimes>1)
            {
                ZeereEye Eyeon = Zeere2.GetComponent<ZeereEye>();
                Eyeon.ON();
            }
            if (passedTimes > 2)
            {
                //指定位置に上昇
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(0, 3),
                   1 * Time.deltaTime);
                if(Cool3==false)
                {
                    Cool3 = true;
                    audioSource.PlayOneShot(ZeereON_SE);

                    BGMS BGMLS = targetBGMS.GetComponent<BGMS>();
                    BGMLS.BS();
                    
                }
            }
            if (passedTimes >= 4&& passedTimes <= 5)
            {
                if(Cool2==false)
                {
                    Cool2 = true;
                    audioSource.PlayOneShot(ZeereON2_SE);
                    BGM BGML = targetBGM.GetComponent<BGM>();
                    BGML.Loop();
                }
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                Instantiate(SoulEat, new Vector2(x, y), Quaternion.identity);
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
            if(passedTimes>8&&Cool2==true)
            {
                audioSource.PlayOneShot(ZVoiceA);
                audioSource.PlayOneShot(ZVoiceB);
                Cool2 = false;
            }
            if(passedTimes>10)
            {
                slider.gameObject.SetActive(true);
                ReeserAttack = !ReeserAttack;
                ReeserLooc = !ReeserLooc;
                passedTimes = 0;
                coorTime = 0;
                GoOK = true;
                Cool = false;
                Cool3 = false;
            }
        }

        
        //突進解除
        if (Cool == true && GoOK == true && EndF == false)
        {
            coorTime += Time.deltaTime;//時間経過
            if (coorTime > BsCT)
            {
                Cool = false;
                AttackLooc = false;
            }
        }
        //BGMループ
        //if (BGMTime <= 45 && BGMTime >=35&&LoopC==false&&AttackLooc==false)
        //{
        //    passedTimes = 0;
        //    Debug.Log("Lady?");
        //}
        //else if(BGMTime>46&&LoopC==false&&AttackLooc==false)
        //{
        //    Debug.Log("GO!");
        //    passedTimes = 99;
        //    LoopC = true;
        //}
        //攻撃処理
        rnd = Random.Range(1, 6);
        if (passedTimes > Attack)
        {
            if (AttackLooc == false)//起動用
            {
                if (rnd == 1 && BusteLooc == false)//突進ON
                {
                    PlayerLoocon LCO = LoocON.GetComponent<PlayerLoocon>();
                    LCO.Reset();
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
                    audioSource.PlayOneShot(ZVoiceA);
                    audioSource.PlayOneShot(ZVoiceB);
                }
                if (rnd == 3 && RitoningLooc == false)//雷雨ON
                {
                    AttackLooc = !AttackLooc;
                    RitoningAttack = !RitoningAttack;
                    RitoningLooc = !RitoningLooc;
                    passedTimes = 0;
                    coorTime = 0;
                    audioSource.PlayOneShot(SamonR_SE);
                    audioSource.PlayOneShot(ZeereON2_SE);
                }
                if (rnd == 4 && ReeserLooc == false)//ビームON
                {
                    AttackLooc = !AttackLooc;
                    ReeserAttack = !ReeserAttack;
                    ReeserLooc = !ReeserLooc;
                    passedTimes = 0;
                    coorTime = 0;
                }
                if (rnd == 5 && LongLooc == false)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    passedTimes = 0;
                    LongLooc = true;
                }

                //強制発動
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
                Vector3 toDirection = BoostTraget.transform.position - transform.position;
                // 対象物へ回転する
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            }
            if (passedTimes < 3 && Cool2 == false)
            {
                Cool2 = true;
                audioSource.PlayOneShot(AttackC_SE);
            }
            if (passedTimes>=3)
            {
                if(Cool2==true)
                {
                    Cool2 = false;
                    audioSource.PlayOneShot(Boost_SE);
                }
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
                    // 生成する
                    Transform myTransform = gateTransform.transform;
                    Vector2 worldPos = myTransform.position;
                    float x = worldPos.x;
                    float y = worldPos.y;

                    Instantiate(Samon, new Vector2(x, y), Quaternion.identity);
                    audioSource.PlayOneShot(Samon_SE);
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
                Cool = false;
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
                    Instantiate(Ritning, new Vector2(rx, ry), Quaternion.identity);
                    Instantiate(Ritning, new Vector2(-rx, ry), Quaternion.identity);
                    rx += prx;
                }
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                    audioSource.PlayOneShot(Ritoning_SE);
                }
                if (rx > boder)
                {
                    Cool = true;
                }
                if (passedTimes > 4.5)
                {
                    rx = r;
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

        if(EndF==true)//撃破
        {
            if(passedTimes>1)
            {
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                //指定位置に下降
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(x, -10),
                   0.9f * Time.deltaTime);
                if(Cool==false)
                {
                    Cool = true;
                    float ex = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                    float ey = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                    Instantiate(KillEffect, new Vector2(ex, ey), Quaternion.identity);
                    audioSource.PlayOneShot(ZVoiceA);
                    audioSource.PlayOneShot(ZVoiceB);
                    audioSource.PlayOneShot(Foor_SE);
                }
            }
            if (passedTimes > 5)
            {
                if(Fade==false)
                {
                    Fade = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(Fadeout, new Vector2(0, 0), Quaternion.identity);
                    audioSource.PlayOneShot(ZVoiceA);
                    audioSource.PlayOneShot(ZVoiceB);
                }
            }
            if (passedTimes > 10 && Crear == false)
            {
                GameObject obj = Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                Crear = true;
            }
        }
        //半分処理
        if(HP_Z<=HP_M/2&&AttackLooc==false&&HalfC==false)
        {
            HalfC = true;
            ATspeed = ATspeed/2;
            BsCT = BsCT/2;
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
            if (HP_Z > HP_M / 2)
            {
                if (other.CompareTag("Ground") && BusteAttack == true)
                {
                    BusteAttack = false;
                    passedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }
            else
            {
                if (other.CompareTag("OverGround") && BusteAttack == true)
                {
                    BusteAttack = false;
                    passedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }

            if (other.CompareTag("Wall") && BusteAttack == true)
            {
                BusteAttack = false;
                passedTimes = 0;
                coorTime = 0;
                Cool = true;
                audioSource.PlayOneShot(Attack_SE);
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
        if (PlayerBoss.gameState == "playing")
        {
            HP_Z--; //hpが減る
            slider.value = HP_Z;
            Debug.Log(HP_Z);
            if (HP_Z > 0)
            {
                //ダメージフラグ　ON
                inDamage = true;
                audioSource.PlayOneShot(Damage_SE);
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GameManager S5UI = GameUI.GetComponent<GameManager>();
                S5UI.BossKill();
                Loop_BGM.gameObject.SetActive(false);
                Start_BGM.gameObject.SetActive(false);
                Destroy(Heart1);
                Destroy(Heart2);
                Destroy(Heart3);
                Destroy(Heart4);
                //やられる
                AttackLooc = true;
                BusteAttack = false;
                SamonAttack = false;
                RitoningAttack = false;
                ReeserAttack = false;
                slider.gameObject.SetActive(false);
                audioSource.PlayOneShot(Break_SE);
                if (EndF ==false)
                {
                    passedTimes = 0;
                    EndF = true;
                    Transform myTransform = this.transform;
                    Vector2 worldPos = myTransform.position;
                    Instantiate(BossEnd, new Vector2(0, 0), Quaternion.identity);
                    float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                    float y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
                    Instantiate(HeloNull, new Vector2(x, y), Quaternion.identity);
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
