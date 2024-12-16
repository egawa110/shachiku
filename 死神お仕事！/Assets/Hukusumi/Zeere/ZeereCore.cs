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
    [SerializeField] GameObject eye;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject Fadeout;
    [SerializeField] GameObject HeloNull;
    [SerializeField] GameObject KillEffect;
    [SerializeField] GameObject SoulEat;

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

    public int HP_M = 40;
    int HP_Z ;    //敵の体力
    private bool inDamage;  //ダメージ中のフラグ
    public Slider slider;//スライダー

    GameObject Zeere1;
    GameObject Zeere2;
    GameObject Zeere3;
    GameObject Zeere4;

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
    public AudioClip Intor_BGM;

    public AudioSource Loop_BGM;
    public GameObject targetBGM;

    private void Start()
    {
        HP_Z = HP_M;
        slider.value = HP_M;
        Reel = GameObject.FindGameObjectWithTag("ZeeReeL").transform;
        gateTransform = GameObject.FindGameObjectWithTag("SamonTG").transform;
        Zeere1 = GameObject.Find("ZeerenoTyuusinnZERO");
        Zeere2 = GameObject.Find("ZeerenoTyuusinn");
        Zeere3 = GameObject.Find("ZeereEye");
        Zeere4 = GameObject.Find("ZeereKabar");

        audioSource = GetComponent<AudioSource>();
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
                if(Cool3==false)
                {
                    Cool3 = true;
                    audioSource.PlayOneShot(ZeereON_SE);

                    audioSource.Play();
                    BGM BGML = targetBGM.GetComponent<BGM>();
                    BGML.Loop();
                }
            }
            if (passedTimes >= 4&& passedTimes <= 5)
            {
                if(Cool2==false)
                {
                    Cool2 = true;
                    audioSource.PlayOneShot(ZeereON2_SE);
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
            if (coorTime > 3)
            {
                Cool = false;
                AttackLooc = false;
            }
        }

        rnd = Random.Range(1, 6);
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
                    //Debug.Log(AttackLooc);
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
                    //Debug.Log("zzz");
                    // 生成する

                    Transform myTransform = gateTransform.transform;
                    Vector2 worldPos = myTransform.position;
                    float x = worldPos.x;
                    float y = worldPos.y;

                    Instantiate(Samon, new Vector2(x, y), Quaternion.identity);
                    audioSource.PlayOneShot(Samon_SE);

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
                    Instantiate(Ritning, new Vector2(brx, bry), Quaternion.identity);
                    Instantiate(Ritning, new Vector2(-brx, bry), Quaternion.identity);
                    brx += rx;
                }
                if (passedTimes > 4.3&&SamonC < 5)
                {
                    SamonC += 1;
                    Transform myTransformR = this.transform;
                    Vector2 worldPosR = myTransformR.position;
                    Instantiate(Rite, new Vector2(0, 3), Quaternion.identity);
                    audioSource.PlayOneShot(Ritoning_SE);
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

        if(EndF==true)//撃破
        {
            if(passedTimes>1)
            {
                Transform myTransform = this.transform;
                Vector2 worldPos = myTransform.position;
                float x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
                //指定位置に上昇
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
                audioSource.PlayOneShot(Attack_SE);
            }

            if (other.CompareTag("Wall") && BusteAttack == true)//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
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
        if (PlayerController.gameState == "playing")
        {
            HP_Z--; //hpが減る
            slider.value = HP_Z;
            Debug.Log(HP_Z);
            if (HP_Z > 0)
            {
                //ダメージフラグ　ON
                inDamage = true;

                Invoke(nameof(DamageEnd), 0.25f);
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GameManager S5UI = GameUI.GetComponent<GameManager>();
                S5UI.BossKill();
                Loop_BGM.gameObject.SetActive(false);
                audioSource.Stop();
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
