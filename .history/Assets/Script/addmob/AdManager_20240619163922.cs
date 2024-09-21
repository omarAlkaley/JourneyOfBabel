using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitialAd;
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

        // Create an interstitial ad request.
        AdRequest adRequest = new AdRequest.().Build();
        InterstitialAd.Load(adUnitId, adRequest, (InterstitialAd ad, LoadAdError loadError) =>
        {
            if (loadError != null || ad == null)
            {
                Debug.LogError("Interstitial ad failed to load: " + loadError);
                return;
            }

            interstitialAd = ad;
            Debug.Log("Interstitial ad loaded.");

            // Register for ad events.
            interstitialAd.OnAdFullScreenContentClosed += HandleOnAdClosed;
            interstitialAd.OnAdFullScreenContentFailed += HandleOnAdFailedToPresent;
        });
    }

    public void ShowInterstitial(Action onAdClosedAction)
    {
        this.onAdClosedAction = onAdClosedAction;

        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            // If the ad is not ready, execute the action immediately.
            onAdClosedAction?.Invoke();
        }
    }

    private void HandleOnAdClosed()
    {
        Debug.Log("Interstitial ad closed.");
        // Reload the ad after it is closed.
        RequestInterstitial();

        // Execute the action after the ad is closed.
        onAdClosedAction?.Invoke();
    }

    private void HandleOnAdFailedToPresent(AdError adError)
    {
        Debug.LogError("Interstitial ad failed to present: " + adError);
        // Retry loading the ad.
        RequestInterstitial();
    }
}
