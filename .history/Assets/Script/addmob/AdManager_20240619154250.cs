using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    private Action onAdClosedAction;

    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { RequestInterstitial(); });
    }

    private void RequestInterstitial()
    {
        // Replace with your ad unit id from AdMob.
        string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxxxx";

        // Create an interstitial ad.
        interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        interstitial.OnAdClosed += HandleOnAdClosed;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitial.OnAdLoaded += HandleOnAdLoaded;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void ShowInterstitial(Action onAdClosedAction)
    {
        this.onAdClosedAction = onAdClosedAction;

        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            // إذا لم يكن الإعلان جاهزًا، نفذ العمل مباشرة.
            onAdClosedAction?.Invoke();
        }
    }

    private void HandleOnAdClosed(object sender, EventArgs args)
    {
        // إعادة تحميل الإعلان بعد إغلاقه
        RequestInterstitial();

        // تنفيذ العمل بعد إغلاق الإعلان
        onAdClosedAction?.Invoke();
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // إعادة المحاولة لتحميل الإعلان عند الفشل
        RequestInterstitial();
    }

    private void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Interstitial ad loaded.");
    }
}
