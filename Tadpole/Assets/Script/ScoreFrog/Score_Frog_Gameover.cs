using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;


public class Score_Frog_Gameover : MonoBehaviour
{
    bool isGameOver;
    Animator anim;

    string adUnitId;

    //private InterstitialAd interstitialAd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        // Initialize the Google Mobile Ads SDK.
        /*MobileAds.Initialize((InitializationStatus initStatus) =>
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

        LoadInterstitialAd();*/
    }

    /*public void LoadInterstitialAd() //광고 로드
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
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else        //이미 한번 광고를 본 경우
        {
            SceneManager.LoadScene("Frog_intro");       //씬 이동
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
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
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
    }*/


    private void Update()
    {
        isGameOver = GameObject.Find("Player").GetComponent<ScoreMode_Frog_PlayController_Jump>().isGameOver;

        if (isGameOver == true)
        {
            anim.SetBool("isGameOver", true);
            isGameOver = false;
        }
        //anim.SetBool("isGameOver", isGameOver);

    }
    public void RePlay()
    {
        //ShowAd();
        SceneManager.LoadScene("Frog_intro");       //씬 이동
    }

    public void QUIT()
    {
        SceneManager.LoadScene("0_StartScene");
    }
}