using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeereCore : MonoBehaviour
{
    //移動経路
    Transform Reel;
    //プレハブ
    [SerializeField] GameObject Samon;//召喚魔法陣
    [SerializeField] GameObject Ritning;//雷判定
    [SerializeField] GameObject Rain;//雨
    [SerializeField] GameObject Rite;//雷エフェクト
    [SerializeField] GameObject Beem;//ビーム
    [SerializeField] GameObject Helo;//ヘイロー
    [SerializeField] GameObject BossEnd;//死亡時ゼーレ以外のダメージ源を除外
    [SerializeField] GameObject GameClear;//ゴール
    [SerializeField] GameObject Fadeout;//フェードアウト
    [SerializeField] GameObject HeloNull;//ヘイロー破壊
    [SerializeField] GameObject KillEffect;//死亡時に吐く
    [SerializeField] GameObject SoulEat;//起動時に吸収

    //死亡時消去
    public GameObject GameUI;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    Transform STg;//召喚位置
    Transform BoostTraget;//突進ロックオン
    public Transform Target;//ビームロックオン
    float PassedTimes = 0;//アクションの時間経過
    float coorTime = 0;
    [SerializeField] float Speed = 5; // 敵の動くスピード

    public float DAngle = 180.0f;//初期角度

    float x;
    float y;

    //突進系
    float ATspeed = 10.0f;//突進速度
    float BsCT = 3.0f;//ロックオン時間

    public float Attack = 10;//攻撃CT

    float SamonC = 0;//召喚カウンター
    public float Samonfrequency = 3;//召喚回数

    int rnd;//乱数
    
    //雷雨系
    public float R = 0.5f;//雷初期化
    float Rx;//雷x
    public float Ry = 20.0f;//雷y
    public float PRX = 1.0f;//雷ずらし
    public float Boder = 10.0f;//雷オーバーラン防止

    public bool Go = false;//ゼーレ起動
    bool GoOK = false;//イベント確認

    bool Cool = false;//調整用
    bool Cool2 = false;//調整用2
    bool Cool3 = false;//調整用3
    //攻撃起動
    bool AttackLooc = true;//攻撃制限＆確認
    bool BusteAttack = false;//突進起動用
    bool SamonAttack = false;//召喚起動用
    bool RitoningAttack = false;//雷雨起動用
    bool ReeserAttack = false;//ビーム起動用

    //連続同攻撃禁止
    bool BusteLooc = false;//突進ロック
    bool SamonLooc = false;//召喚ロック
    bool RitoningLooc = false;//雷雨ロック
    bool ReeserLooc = false;//ビームロック
    bool LongLooc = false;//延長ロック

    bool EndF = false;//撃破フラグ
    bool Crear = false;//クリア出現
    bool Fade = false;//フェードオブジェフラグ

    //HP
    public int HP_M = 40;//体力マックス
    int HP_z;    //敵の体力
    private bool inDamage;  //ダメージ中のフラグ
    public Slider slider;//スライダー
    bool HalfC = false;

    //ゼーレのパーツ
    GameObject Zeere1;//白目
    GameObject Zeere2;//黒目
    GameObject Zeere3;//カバー
    //GameObject Zeere4;//右肩
    //GameObject Zeere5;//左肩

    //音
    private AudioSource audioSource;
    public AudioClip Samon_SE;//召喚音
    public AudioClip BootZeere_SE;//起動音
    public AudioClip Boost_SE;//突進音
    public AudioClip Attack_SE;//激突音
    public AudioClip AttackC_SE;//チャージ音
    public AudioClip Ritoning_SE;//電撃音
    public AudioClip ZVoiceA;//鳴き声A
    public AudioClip ZVoiceB;//鳴き声B
    public AudioClip ZeereON_SE;//準備1
    public AudioClip ZeereON2_SE;//準備2
    public AudioClip Break_SE;//トドメダメージ音
    public AudioClip Foor_SE;//落下音
    public AudioClip Damage_SE;//ダメージ音

    //BGM
    //イントロ
    public AudioSource Start_BGM;
    public GameObject targetBGMS;
    //ループ
    public AudioSource Loop_BGM;
    public GameObject targetBGM;

    //スタート
    private void Start()
    {
        HP_z = HP_M;
        Rx = R;
        slider.value = HP_M;
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        BoostTraget = GameObject.FindGameObjectWithTag("PlayerLoocon").transform;
        STg = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("Zeerecenter");
        Zeere2 = GameObject.Find("ZeereEye");
        Zeere3 = GameObject.Find("ZeereKabar");

        audioSource = GetComponent<AudioSource>();
    }
    //アップデート
    private void Update()
    {
        PassedTimes += Time.deltaTime;//時間経過
        //自身の位置
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
        y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
        if (Go == true)
        {
            if (inDamage)
            {
                //ダメージ中、点滅させる
                float val = Mathf.Sin(Time.time * 50);
                if (val > 0)
                {
                    RendererTrue();
                }
                else
                {
                    //スプライトを非表示
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere1.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere2.GetComponent<SpriteRenderer>().enabled = false;
                    Zeere3.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                RendererTrue();
            }
        }
        //起動前
        if (Go==false)
        {

            PassedTimes = 0;
            //待機場所へ移動
            transform.position = Vector2.MoveTowards(
               transform.position,
               new Vector2(0, -4.5f),
               Speed * Time.deltaTime);
        }
        //起動
        if(Go==true&&GoOK==false)
        {
            if(PassedTimes>1)
            {
                ZeereEye Eyeon = Zeere2.GetComponent<ZeereEye>();
                Eyeon.ON();
            }
            if (PassedTimes > 2)
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
            if (PassedTimes >= 4&& PassedTimes <= 5)
            {
                if(Cool2==false)
                {
                    Cool2 = true;
                    audioSource.PlayOneShot(ZeereON2_SE);
                    BGM BGML = targetBGM.GetComponent<BGM>();
                    BGML.Loop();
                }
                Create(SoulEat, x, y);
            }

            if (PassedTimes>7&&Cool==false)
            {
                Cool = true;
                Create(Helo, x, y);
            }
            if(PassedTimes>8&&Cool2==true)
            {
                Voice();
                Cool2 = false;
            }
            if(PassedTimes>10)
            {
                slider.gameObject.SetActive(true);
                ReeserAttack = !ReeserAttack;
                ReeserLooc = !ReeserLooc;
                PassedTimes = 0;
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
        //攻撃処理
        rnd = Random.Range(1, 6);
        if (PassedTimes > Attack)
        {
            if (AttackLooc == false)//起動用
            {
                if (rnd == 1 && BusteLooc == false)//突進ON
                {
                    PlayerLoocon LCO = BoostTraget.GetComponent<PlayerLoocon>();
                    LCO.Reset();
                    BusteAttack = !BusteAttack;
                    ONReset();
                }
                if (rnd == 2 && SamonLooc == false)//召喚ON
                {
                    SamonAttack = !SamonAttack;
                    ONReset();
                    Voice();
                }
                if (rnd == 3 && RitoningLooc == false)//雷雨ON
                {
                    RitoningAttack = !RitoningAttack;
                    ONReset();
                    audioSource.PlayOneShot(BootZeere_SE);
                    audioSource.PlayOneShot(ZeereON2_SE);
                }
                if (rnd == 4 && ReeserLooc == false)//ビームON
                {
                    ReeserAttack = !ReeserAttack;
                    ONReset();
                }
                if (rnd == 5 && LongLooc == false)//待機
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    PassedTimes = 0;
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
                Speed * Time.deltaTime);
            if(transform.localEulerAngles.z<DAngle)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else if (transform.localEulerAngles.z > DAngle)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            }
        }


        if (BusteAttack == true)//突進
        {

            if (PassedTimes < 3)
            {
                // 対象物へのベクトルを算出
                Vector3 toDirection = BoostTraget.transform.position - transform.position;
                // 対象物へ回転する
                transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            }
            if (PassedTimes < 3 && Cool2 == false)
            {
                Cool2 = true;
                audioSource.PlayOneShot(AttackC_SE);
            }
            if (PassedTimes >= 3)
            {
                if (Cool2 == true)
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
            transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            coorTime += Time.deltaTime;//時間経過
            
            if (SamonC < Samonfrequency)
            {
                
                if (coorTime > 0.5)
                {
                    SamonC += 1;
                    coorTime = 0;
                    // 生成する
                    Transform STGT = STg.transform;
                    Vector2 SamonPos = STGT.position;
                    float Sx = SamonPos.x;
                    float Sy = SamonPos.y;
                    Create(Samon, Sx, Sy);
                    audioSource.PlayOneShot(Samon_SE);
                }
               
            }
            if (PassedTimes > 4)
            {
                //リセット
                BusteLooc = false;
                RitoningLooc = false;
                ReeserLooc = false;
                AttackReset();
            }
        }


        if (RitoningAttack == true)//雷雨
        {
            //指定位置に移動
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(0, 3),
                Speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            if (SamonC<2)
            {
                SamonC+=1;
                Create(Rain, 0, 7);
            }
            if (PassedTimes > 4)
            {

                if (Cool == false)
                {
                    Create(Ritning, Rx, Ry);
                    Create(Ritning,-Rx, Ry);
                    Rx += PRX;
                }
                if (PassedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Create(Rite, 0, 3);
                    audioSource.PlayOneShot(Ritoning_SE);
                }
                if (Rx > Boder)
                {
                    //過剰生成防止
                    Cool = true;
                }
                if (PassedTimes > 4.5)
                {
                    //リセット         
                    BusteLooc = false;
                    SamonLooc = false;
                    ReeserLooc = false;
                    AttackReset();

                }
            }
        }


        if (ReeserAttack == true)//ビーム
        {
            transform.eulerAngles = new Vector3(0f, 0f, DAngle);
            if (SamonC < 1)
            {
                SamonC += 1;
                Transform HeroTransform = Target.transform;
                Vector2 HeroPos = HeroTransform.position;
                float Bx = HeroPos.x;
                Create(Beem, Bx, 0);
                Create(Beem,-Bx, 0);
            }
            if (PassedTimes > 3.1)
            {
                //リセット
                BusteLooc = false;
                SamonLooc = false;
                RitoningLooc = false;
                AttackReset();
            }
        }

        if(EndF==true)//撃破
        {
            if(PassedTimes>1)
            {
                //指定方向に落下
                transform.position = Vector2.MoveTowards(
                   transform.position,
                   new Vector2(x, -10),
                   0.9f * Time.deltaTime);
                if(Cool==false)
                {
                    Cool = true;
                    Create(KillEffect, x, y);
                    Voice();
                    audioSource.PlayOneShot(Foor_SE);
                }
            }
            if (PassedTimes > 5)
            {
                //フェードアウト
                if(Fade==false)
                {
                    Fade = true;
                    Create(Fadeout, 0, 0);
                    Voice();
                }
            }
            if (PassedTimes > 10 && Crear == false)
            {
                //クリア
                GameObject obj = Instantiate(GameClear, new Vector2(0, 0), Quaternion.identity);
                obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                Crear = true;
            }
        }
        //半分処理
        if(HP_z<=HP_M/2&&AttackLooc==false&&HalfC==false)
        {
            HalfC = true;
            ATspeed = ATspeed/2;
            BsCT = BsCT/2;
        }

    }

    void Voice()//鳴き声
    {
        audioSource.PlayOneShot(ZVoiceA);
        audioSource.PlayOneShot(ZVoiceB);
    }

    void RendererTrue()//パーツ表示
    {
        //スプライトを表示
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Zeere1.GetComponent<SpriteRenderer>().enabled = true;
        Zeere2.GetComponent<SpriteRenderer>().enabled = true;
        Zeere3.GetComponent<SpriteRenderer>().enabled = true;
    }

    void ONReset()//リセット(起動)
    {
        AttackLooc = true;
        BusteLooc = true;
        SamonLooc = true;
        RitoningLooc = true;
        ReeserLooc = true;
        PassedTimes = 0;
        coorTime = 0;
    }
    void AttackReset()//リセット
    {
        Rx = R;
        PassedTimes = 0;
        coorTime = 0;
        AttackLooc = false;
        SamonC = 0;
        Cool = false;
        SamonAttack = false;
        RitoningAttack = false;
        ReeserAttack = false;
        LongLooc = false;
    }

    public void Zeereon()//起動スイッチ
    {
        Go = true;
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (EndF == false)
        {
            if (HP_z > HP_M / 2)
            {
                if (other.CompareTag("Ground") && BusteAttack == true)
                {//リセット
                    BusteAttack = false;
                    PassedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }
            else//後半戦
            {
                if (other.CompareTag("OverGround") && BusteAttack == true)
                {
                    //リセット
                    BusteAttack = false;
                    PassedTimes = 0;
                    coorTime = 0;
                    Cool = true;
                    audioSource.PlayOneShot(Attack_SE);
                }
            }

            if (other.CompareTag("Wall") && BusteAttack == true)
            {
                //リセット
                BusteAttack = false;
                PassedTimes = 0;
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
            HP_z--; //hpが減る
            slider.value = HP_z;
            Debug.Log(HP_z);
            if (HP_z > 0)
            {
                //ダメージフラグ　ON
                inDamage = true;
                audioSource.PlayOneShot(Damage_SE);
                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                //UI&BGM停止
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
                    PassedTimes = 0;
                    EndF = true;
                    Create(BossEnd, 0, 0);
                    Create(HeloNull, x, y);
                }
                

            }
        }
    }

    void Create(GameObject v, float Cx, float Cy)//プレハブ生成
    {
        Instantiate(v, new Vector2(Cx, Cy), Quaternion.identity);
    }

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false; // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // スプライトを元に戻す
    }
}
