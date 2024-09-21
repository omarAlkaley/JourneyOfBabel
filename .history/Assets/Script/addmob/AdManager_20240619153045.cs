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
        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
        // Replace with your ad unit id from AdMob.
        string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxxxx";

        // Create an interstitial ad.
        interstitial = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        // Register for ad events.
        interstitial.OnAdClosed += HandleOnAdClosed;
    }

    public void ShowInterstitial(Action onAdClosedAction)
    {
        if (interstitial.IsLoaded())
        {
            this.onAdClosedAction = onAdClosedAction;
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
}
