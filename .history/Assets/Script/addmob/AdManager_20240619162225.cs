using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class AdManager : MonoBehaviour
{
     public static RewardedAd rewardVideoAd;
    public static InterstitialAd interstitial;



    public static void createreInterstitial()
    {

#if UNITY_ANDROID
        string APP_ID = "ca-app-pub-4661270359573456~8325364308";
#elif UNITY_IPHONE
        string APP_ID = "ca-app-pub-4661270359573456~5715512832";
#else
        string APP_ID = "unexpected_platform";
#endif

        MobileAds.Initialize(initStatus =>
        {
            APP_ID.ToString();
        });



    }



    public static void RequestRewarded()
    {
        /////Real Ads Android
        ///string RewardedID = "";

        /////Real Ads IOS
        ///string RewardedID = "";


        //fake Ads
        //string RewardedID = "ca-app-pub-3940256099942544/5224354917";

#if UNITY_ANDROID
        string RewardedID = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string RewardedID = "ca-app-pub-3940256099942544/5224354917";
#else
        string RewardedID = "unexpected_platform";
#endif



        rewardVideoAd = new RewardedAd(RewardedID);

        AdRequest adRequest = new AdRequest.Builder().Build();

        rewardVideoAd.LoadAd(adRequest);

    }

    public static void RequestInterstitial()
    {
        /////Real Ads android
        //string adUnitId = "";

        /////Real Ads IOS
        //string adUnitId = "";

        //fake Ads
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

    }

    public static void onUserreward(Action callback)
    {
        callback();
    }

    public static void Showreward(Action callback = null, Action onclose = null)
    {
        rewardVideoAd.OnUserEarnedReward += (sender, e) => onUserreward(callback);
        rewardVideoAd.OnAdClosed += (sender, e) => onUserreward(onclose);

        rewardVideoAd.Show();


    }



}
