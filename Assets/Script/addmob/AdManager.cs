using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private Action onAdClosedAction;

    void Start()
    {
        MobileAds.Initialize(initStatus => { RequestInterstitial(); });
    }

    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/8691691433"; // Test ad unit ID for interstitial video ads
        AdRequest adRequest = new AdRequest(); // Create an AdRequest object directly

        InterstitialAd.Load(adUnitId, adRequest, (InterstitialAd ad, LoadAdError loadError) =>
        {
            if (loadError != null || ad == null)
            {
                Debug.LogError("Failed to load interstitial ad: " + loadError);
                return;
            }

            interstitialAd = ad;
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
            onAdClosedAction?.Invoke();
        }
    }

    private void HandleOnAdClosed()
    {
        Debug.Log("Interstitial ad closed.");
        RequestInterstitial();
        onAdClosedAction?.Invoke();
    }

    private void HandleOnAdFailedToPresent(AdError adError)
    {
        Debug.LogError("Interstitial ad failed to present: " + adError);
        RequestInterstitial();
        onAdClosedAction?.Invoke();
    }
}
