using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class inti : MonoBehaviour
{
    string appid = "ca-app-pub-2001875684419121~2888396338";
    private InterstitialAd interstitial;
    string adu= "ca-app-pub-2001875684419121/4748272917";


    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(appid);
        
        RequestInterstitial();
        showinter();

    }
    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adu);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
        

    }
    public void showinter()
    {
        Debug.Log("shown");
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();

        }
    }
    
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        this.interstitial.Show();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
