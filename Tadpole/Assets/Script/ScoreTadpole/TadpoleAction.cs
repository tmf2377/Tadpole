using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;
using GoogleMobileAds.Api;

public class TadpoleAction : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    public float moveSpeed = 4.5f;

    //AudioSource walkAudio;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rigid2D;
    Animator anim;

    public GameObject gameOverPanel;
    public bool isStar;
    private float starTime;

    //public GameObject BGM;
    //public GameObject starBGM;
    public AudioSource BGM1;
    public AudioSource BGM2;

    public AudioSource overSound;
    public AudioSource booster;

    string adUnitId;

    private InterstitialAd interstitialAd;


    public void LoadInterstitialAd() //광고 로드
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        var adRequest = new AdRequest.Builder()
                .AddKeyword("unity-admob-sample")
                .Build();

        InterstitialAd.Load(adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }

    public void ShowAd() //광고 보기
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("광고보기");
            interstitialAd.Show();
        }
        else        //이미 한번 광고를 본 경우
        {
            Debug.Log("이미광고를 봄");
            SceneManager.LoadScene("InfiniteTedpole");      //씬 이동
            Time.timeScale = 1;
            RegisterReloadHandler(interstitialAd);      //광고 다시 로드
        }
    }

    private void RegisterEventHandlers(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(System.String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>                          //광고를 닫은 경우
        {
            Debug.Log("광고닫음");          //출력안됨
            interstitialAd.Destroy(); //광고 파괴
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    private void RegisterReloadHandler(InterstitialAd ad) //광고 재로드
    {
        ad.OnAdFullScreenContentClosed += (null);
        {
            Debug.Log("Interstitial Ad full screen content closed.");
            LoadInterstitialAd();
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            LoadInterstitialAd();
        };
    }




    public void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
    }


    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        gameOverPanel.SetActive(false);
        isStar = false;
        starTime = 47f;

        BGM1.Play();
        BGM2.Stop();


        //---------------구글 Admob 세팅

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IOS
                    adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
                    adUnitId = "unexpected_platform";
#endif

        LoadInterstitialAd();
    }

    private void Update()
    {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();

        if (x != 0 || y != 0)
        {
            //transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
            rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

        }

        //방향전환
        if (x < 0)
            spriteRenderer.flipX = true;
        if (x > 0)
            spriteRenderer.flipX = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(isStar == false)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);

                BGM1.Stop();
                BGM2.Stop();
                overSound.Play();
            }
        }

        if (collision.gameObject.tag == "starItem")
        {
            isStar = true;
            anim.SetBool("isStar", true);
            Invoke("StarEnd", 9f);
            starTime += 7f;
            GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().starInterval = starTime;

            BGM1.Pause();
            BGM2.Play();

        }

        if (collision.gameObject.tag == "boosterItem")
        {
            moveSpeed = 9f;
            booster.Play();
            Invoke("BoosterEnd", 4f);
        }
    }

    private void BoosterEnd()
    {
        booster.Stop();
        moveSpeed = 4.5f;
    }

    private void StarEnd()
    {
        anim.SetBool("isStar", false);
        isStar = false;
        BGM1.Play();
        BGM2.Pause();

    }

    public void Replay()
    {
        ShowAd();
        /*SceneManager.LoadScene("InfiniteTedpole");
        Time.timeScale = 1;*/
    }

    public void GoMain()
    {
        SceneManager.LoadScene("0_StartScene");
        Time.timeScale = 1;
    }
}
