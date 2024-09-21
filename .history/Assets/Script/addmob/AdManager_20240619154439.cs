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
        InterstitialAd.Load(adUnitId, new AdRequest.Builder().Build(), (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Interstitial ad failed to load an ad " + "with error : " + error);
                return;
            }

            interstitial = ad;

            // Register for ad events.
            interstitial.OnAdClosed += HandleOnAdClosed;
            interstitial.OnAdFailedToPresentFullScreenContent += HandleOnAdFailedToPresent;
        });
    }

    public void ShowInterstitial(Action onAdClosedAction)
    {
        this.onAdClosedAction = onAdClosedAction;

        if (interstitial != null && interstitial.CanShowAd())
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

    private void HandleOnAdFailedToPresent(object sender, AdErrorEventArgs args)
    {
        // إعادة المحاولة لتحميل الإعلان عند الفشل
        RequestInterstitial();
    }
}
