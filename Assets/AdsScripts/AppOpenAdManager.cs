using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using com.adjust.sdk;

public class AppOpenAdManager
{
    private const string test_Key = "ca-app-pub-3940256099942544/9257395921";
    private bool isEnableTest = false;

    private const string ID_ANDROID = "ca-app-pub-1042488596199134/6101576166";
    private static AppOpenAdManager instance;

    private AppOpenAd ad;

    private int tierIndex = 1;

    private bool isShowingAd = false;

    private bool isRequesting = false;

    private bool isFirstShow = false;

    public static bool ResumeFromAds = false;

    public static AppOpenAdManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AppOpenAdManager();
            }

            return instance;
        }
    }

    private bool IsAdAvailable => ad != null;

    public void LoadAOA()
    {
        // destroy old instance.
        DestroyAppOpenAd();
        isRequesting = true;
        string id = ID_ANDROID;
        //if (isEnableTest)
        //{
        //    id = test_Key;
        //}
        Debug.Log($"Start request Open App Ads ID: {id}");

        AdRequest request = new AdRequest.Builder().Build();
        try
        {
            AppOpenAd.Load(id, Screen.orientation, request, ((appOpenAd, error) =>
            {
                if (error != null || appOpenAd == null)
                {
                    // Handle the error.
                    Debug.LogFormat(
                        $"Failed to load AppOpen id: {id}. Reason: {error.GetMessage()}");
                    isRequesting = false;
                    return;
                }
                Debug.Log("AppOpen ad loaded");
                // App open ad is loaded.
                ad = appOpenAd;
                isRequesting = false;
                if (!isFirstShow)
                {
                    ShowAdIfAvailable();
                    isFirstShow = true;
                }
            }));
        }
        catch (Exception e)
        {
            isRequesting = false;
        }
    }
    public void ShowAdIfAvailable()
    {
        if (isShowingAd)
        {
            return;
        }

        if (!IsAdAvailable && !isRequesting)
        {
            LoadAOA();
            return;
        }

        ad.OnAdFullScreenContentClosed += HandleAdDidDismissFullScreenContent;
        ad.OnAdFullScreenContentFailed += HandleAdFailedToPresentFullScreenContent;
        ad.OnAdFullScreenContentOpened += HandleAdDidPresentFullScreenContent;
        ad.OnAdImpressionRecorded += HandleAdDidRecordImpression;
        ad.OnAdClicked += HandleAdClicked;
        ad.OnAdPaid += HandlePaidEvent;
        if (ad.CanShowAd())
            ad.Show();
        else
        {
            LoadAOA();
        }
    }

    public void DestroyAppOpenAd()
    {
        if (ad != null)
        {
            ad.Destroy();
            ad = null;
        }
    }

    private void HandleAdDidDismissFullScreenContent()
    {
        //Debug.Log("Closed app open ad");
        isShowingAd = false;
        LoadAOA();
    }

    private void HandleAdFailedToPresentFullScreenContent(AdError error)
    {
        Debug.LogError("App open ad failed to open full screen content " +
                       "with error : " + error);
        LoadAOA();
    }

    private void HandleAdDidPresentFullScreenContent()
    {
        //Debug.Log("Displayed app open ad");
        isShowingAd = true;
    }

    private void HandleAdDidRecordImpression()
    {
        //Debug.Log("Recorded ad impression");
    }

    private void HandleAdClicked()
    {
        //Debug.Log("Ad Clicked");
    }

    private void HandlePaidEvent(AdValue adValue)
    {
        //Debug.Log("Recorded ad impression");
        double revenue = (adValue.Value / 1000000f);
        AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.AppOpen, ID_ANDROID);
        //AdjustAdRevenue adjustAdRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAdMob);
        //adjustAdRevenue.setRevenue(revenue, "USD");
        //adjustAdRevenue.setAdRevenueNetwork("Admob_OPEN");
        //Adjust.trackAdRevenue(adjustAdRevenue);
    }
}