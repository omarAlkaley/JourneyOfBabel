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

        // Create an interstitial ad.
        interstitialAd = new InterstitialAd(adUnitId);

        // Register for ad events.
        interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitialAd.OnAdOpening += HandleOnAdOpening;
        interstitialAd.OnAdClosed += HandleOnAdClosed;

        // Load an interstitial ad.
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }

    public void ShowInterstitial(Action onAdClosedAction)
    {
        this.onAdClosedAction = onAdClosedAction;

        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            // If the ad is not ready, execute the action immediately.
            onAdClosedAction?.Invoke();
        }
    }

    private void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Interstitial ad loaded.");
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.LogError("Interstitial ad failed to load: " + args.Message);
        // Retry loading the ad.
        RequestInterstitial();
    }

    private void HandleOnAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Interstitial ad opened.");
    }

    private void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Interstitial ad closed.");
        // Reload the ad.
        RequestInterstitial();

        // Execute the action after the ad is closed.
        onAdClosedAction?.Invoke();
    }
}
