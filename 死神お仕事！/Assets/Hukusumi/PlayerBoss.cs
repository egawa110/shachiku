using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class PlayerBoss : MonoBehaviour
{
    Rigidbody2D rbody;                //Rigidbody2D型の作成
    float axisH = 0.0f;               //入力
    public float speed = 3.0f;        //移動速度

    public float jump = 10.0f;         //ジャンプ力
    public LayerMask groundLayer;     //着地できるレイヤー
    bool goJump = false;              //ジャンプ開始フラグ


    //アニメーション対応
    Animator animator; //アニメーター
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";

    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";// ゲームの状態

    //HP
    public GameObject[] lifeArray = new GameObject[4];
    private int lifePoint = 4;

    //追加
    //public int ALL_SOUL = 0;      //1ステージで取得したすべての魂

    //攻撃用変数
    [SerializeField] private GameObject bullet;     //バレットプレハブを格納
    [SerializeField] private Transform attackPoint; //アタックポイントを格納

    [SerializeField] private float attackTime = 0.2f; //攻撃間隔
    public float fireSpeed = 8.0f;

    private float currentAttackTime;                  //攻撃の間隔を管理
    private bool canAttack;                           //攻撃可能状態かを指定するフラグ

    private float BossIveTime = 0;//イベント計測
    bool BossIve = false;//イベント確認
    bool BICyec = false;//イベント制限


    public int maxHp = 4;      //プレイヤーの最大Hp
    int Hp;                    //プレイヤーの現在Hp
    private bool inDamage = false;  //ダメージ中のフラグ

    //public Slider slider;      //スライダー用の変数

    float SafeTime = 0;
    public float DCoolTime = 0.5f;

    // サウンド再生
    private AudioSource audioSource;
    public AudioClip Jump_SE;
    public AudioClip Damage_SE;
    public AudioClip GetSoul_SE;
    public AudioClip Attack_SE;
    public AudioClip Clear_SE;
    public AudioClip Over_SE;

    public AudioSource Loop_BGM;
    public AudioSource Start_BGM;

    void Start()
    {
        //FPSを60に固定
        Application.targetFrameRate = 60;

        //Rigidbod2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>(); //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();      //Animatorを取ってくる
        nowAnime = stopAnime;                     //停止から開始する
        oldAnime = stopAnime;                     //停止から開始する

        gameState = "playing";//ゲーム中にする

        currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。
        audioSource = GetComponent<AudioSource>();
        //slider.value = 4; // Sliderを最大Hpにする
        Hp = maxHp;       // Hpと最大Hpを同じ値にする
    }

    void Update()
    {
        SafeTime += Time.deltaTime;//無敵カウント
        Transform myTransform = this.transform;
        Vector2 worldPos = myTransform.position;
        //ボスイベント
        if (worldPos.x>-13 && BICyec == false)//ON
        {
            BossIve = true;
        }
        if (Input.GetKeyDown(KeyCode.I))//ON
         {
            BossIve = true;
         }
        if(BossIve==true&&BICyec==false)
        {
            BossIveTime += Time.deltaTime;//時間経過
            if (worldPos.x < -7)
            {
                
                transform.position = Vector2.MoveTowards(
                      transform.position,
                      new Vector2(0, worldPos.y),
                      1 * Time.deltaTime);
            }
            else
            {
                //Rigidbody2Dを取ってくる
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                //速度を０にして強制停止
                rbody.velocity = new Vector2(0, 0);
            }
            if(BossIveTime>11.5f)
            {
                BICyec = true;
                BossIve = false;
            }
        }



        if (Time.timeScale == 0)
        {
            return;
        }
        if (gameState != "playing" || inDamage)
        {
            return;
        }

        speed = 3.0f;
        rbody.gravityScale = 1.1f;
        jump = 10.0f;

        //水平方向の入力をチェック
        axisH = Input.GetAxisRaw("Horizontal");
        if (BossIve == false)
        {
            //向きの調整
            if (axisH > 0.0f)
            {
                transform.localScale = new Vector2(1, 1);
            }

            else if (axisH < 0.0f)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        //キャラクターをジャンプさせる
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (BICyec == true)
        {
            //ダッシュ
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = 5.0f;
                rbody.gravityScale = 1.5f;
                jump = 11.0f;
            }
        }
        else
        {
            speed = 3.0f;
            rbody.gravityScale = 1.1f;
            jump = 11.0f;
        }

        //主人公の攻撃
        Attack();
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            //ダメージ中、点滅させる
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                //スプライトを非表示
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return; // ダメージ中は操作による移動をさせない
        }

        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position,    //発射位置
                                             0.7f,                  //円の半径
                                             Vector2.down,          //発射方向
                                             1.0f,                  //発射距離
                                             groundLayer);          //検出するレイヤー
        if (BossIve == false)
        {
            if (onGround || axisH != 0)
            {
                //速度を更新する
                rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
            }
            if (onGround && goJump)
            {
                //地面の上でジャンプキーが押された
                //ジャンプさせる
                Vector2 jumpPw = new(0, jump);                  //ジャンプさせるベクトルを作る
                rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //瞬間的な力を加える
                goJump = false;
                //ジャンプ音を鳴らす
                audioSource.PlayOneShot(Jump_SE);
            }
        }
        //アニメーション更新
        if (onGround)
        {
            // 地面の上
            if (axisH == 0)
            {
                nowAnime = stopAnime; 		// 停止中
            }
            else
            {
                nowAnime = moveAnime;  		// 移動
            }
        }
        //else
        //{
        //    // 空中
        //    nowAnime = jumpAnime;
        //}
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);        // アニメーション再生
        }

    }

    //ジャンプ
    public void Jump()
    {
        goJump = true;                      //ジャンプフラグを立てる
    }

    //攻撃
    public void Attack()
    {
        attackTime += Time.deltaTime; //attackTimeに毎フレームの時間を加算していく

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //指定時間を超えたら攻撃可能にする
        }
        if (BossIve == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UnityEngine.Debug.Log("ZZZ");

                if (canAttack)
                {
                    GameObject playerObj = GameObject.Find("Player");
                    audioSource.PlayOneShot(Attack_SE);

                    if (playerObj.transform.localScale.x > 0)//右向き
                    {
                        Vector2 pos = new Vector2(attackPoint.position.x,
                                attackPoint.position.y);
                        GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
                        //方針が向いてる方向に発射する
                        Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                        float angleZ = transform.localEulerAngles.z;
                        float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                        float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                        Vector2 v = new Vector2(x, y) * fireSpeed;
                        rbody.AddForce(v, ForceMode2D.Impulse);
                    }
                    else if (playerObj.transform.localScale.x < 0)//左向き
                    {
                        Vector2 pos = new Vector2(attackPoint.position.x,
                                attackPoint.position.y);
                        GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
                        //方針が向いてる方向に発射する
                        Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                        float angleZ = transform.localEulerAngles.z;
                        float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                        float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                        Vector2 v = new Vector2(-x, y) * fireSpeed;
                        rbody.AddForce(v, ForceMode2D.Impulse);
                    }
                    canAttack = false; //攻撃フラグをfalseにする
                    attackTime = 0f;  //attackTimeを0に戻す
                }

            }
        }
    }

    /// <summary>
    /// 接触した当たり判定を取得し、それに応じた処理
    /// </summary>
    /// <param name="collision">プレイヤーに接触した当たり判定</param>
    //接触開始
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead" )
        {
            GameOver(); //ゲームオーバー
        }
        //else if (collision.gameObject.tag == "Soul")
        //{
        //    //魂取得する
        //    ALL_SOUL++;
        //    //音を鳴らす
        //    audioSource.PlayOneShot(GetSoul_SE);
        //    // 削除する
        //    Destroy(collision.gameObject);
        //}
        else if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
           
        }
        else if (collision.gameObject.tag == "ZeereCore")
        {
            GetDamage(collision.gameObject);   
        }
        else if (collision.gameObject.tag == "Heal")
        {
            lifePoint++;
            Hp++;
            audioSource.PlayOneShot(GetSoul_SE);
            if (lifePoint > 4|| Hp > 4) // lifePointが４より大きくなったら
            {
                // lifePointを４にする
                lifePoint = 4;
                Hp = maxHp;
            }
            UnityEngine.Debug.Log("Hp:");
            lifeArray[lifePoint - 1].SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing"&&SafeTime>DCoolTime)
        {
            SafeTime = 0;
            Hp--; //hpが減る
            //slider.value = Hp; // 減ったHPをスライダーに反映する
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
            //敵に当たった時に音を鳴らす
            audioSource.PlayOneShot(Damage_SE);
            if (Hp > 0)
            {
                //移動停止
                rbody.velocity = new Vector2(0, 0);
                //敵キャラの反対方向にヒットバックさせる
                Vector3 v = (transform.position - enemy.transform.position).normalized; rbody.AddForce(new Vector2(v.x * 4.5f, v.y * 4.5f), ForceMode2D.Impulse);
                //ダメージフラグ　ON
                inDamage = true;
                Invoke(nameof(DamageEnd), 0.5f);
            }
            else if (Hp == 0)
            {
                //ゲームオーバー
                GameOver();
            }
        }
    }
    

    //ダメージ終了
    void DamageEnd()
    {
        inDamage = false; // ダメージフラグOFF
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // スプライトを元に戻す
    }
    // ゴール
    public void Goal()
    {
        //slider.gameObject.SetActive(false);
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();             // ゲーム停止
        //音楽を鳴らす
        audioSource.PlayOneShot(Clear_SE);

    }

    // ゲームオーバー
    public void GameOver()
    {
        Loop_BGM.gameObject.SetActive(false);
        Start_BGM.gameObject.SetActive(false);
        animator.Play(deadAnime);
        gameState = "gameover"; GameStop();
        // ゲーム停止（ゲームオーバー演出）
        // プレイヤー当たりを消す
        GetComponent<BoxCollider2D>().enabled = false;
        // プレイヤーを上に少し跳ね上げる演出
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //音楽を鳴らす
        audioSource.PlayOneShot(Over_SE);
    }


    //ゲーム停止
    void GameStop()
    {
        //Rigidbody2Dを取ってくる
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //速度を０にして強制停止
        rbody.velocity = new Vector2(0, 0);
    }

}