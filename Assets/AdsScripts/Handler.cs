using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public enum AdsLoadingStatus
{
    NotLoaded,
    Loading,
    Loaded,
    NoInventory
}
public abstract class Handler : MonoBehaviour
{
    public bool EnableTestModeAds;
    public bool DisableDebugLogs = true;

    public delegate void RewardUserDelegate();

    public delegate void AfterLoading();

    public static AdsLoadingStatus rAdStatus = AdsLoadingStatus.NotLoaded;
    public static AdsLoadingStatus riAdStatus = AdsLoadingStatus.NotLoaded;

    public static AdsLoadingStatus iAdStatus = AdsLoadingStatus.NotLoaded;

    public static AdsLoadingStatus smallBannerStatus = AdsLoadingStatus.NotLoaded;

    public static AdsLoadingStatus small2ndBannerStatus = AdsLoadingStatus.NotLoaded;

    public static AdsLoadingStatus mediumBannerStatus = AdsLoadingStatus.NotLoaded;
    public abstract bool IsInterstitialAdReady();
    public abstract void ShowInterstitialAd(string placement);

    public abstract void LoadInterstitialAd();


    public abstract bool IsSmallFirstBannerReady();
    public abstract void Load_Left_SmallBanner();

    public abstract void Show_Left_SmallBanner();
    public abstract void Hide_Left_SmallBannerEvent();

    //2nd Banner
    //public abstract bool IsSecondBannerReady();
    //public abstract void Load_Right_SmallBanner();

    //public abstract void Show_Right_SmallBanner();
    //public abstract void Hide_Right_SmallBannerEvent();

    public abstract bool IsMediumBannerReady();

    public abstract void LoadMediumBanner();
    public abstract void ShowMediumBanner(AdPosition pos);
    public abstract void HideMediumBannerEvent();

    public abstract bool IsRewardedAdReady();
    public abstract void LoadRewardedVideo();

    public abstract void ShowRewardedVideo(Action<Reward> action,string placement);

    public abstract void LoadRewardedInterstitial();

    public abstract void ShowRewardedInterstitialAd(Action<Reward> action, string placement);
    public abstract bool IsRewardedInterstitialAdReady();

    public GameObject Loading;

    int a = 0;

    public void ShowInt(AfterLoading afterLoading, bool UseLoading, string placement)
    {
        //Loading.GetComponent<LoadingAds>().MediumBanner = ShowMediumBanner;
        //Loading.GetComponent<LoadingAds>().SmallBanner = ShowSmallBanner;
        if (UseLoading)
        {

            LoadingAds.Notify = afterLoading;
            Loading.SetActive(true);
        }
        else
        {
            ShowInterstitialAd(placement);
            Invoke(nameof(LoadInterstitialAd), 1.2f);
        }
    }

    public void ShowRewardedAdsBoth(Action<Reward> action,string placement)
    {
        if (a == 0)
        {
            ShowRewardedVideo(action, placement);
            a = 1;
        }
        else if (a == 1)
        {
            ShowRewardedInterstitialAd(action, placement);
            a = 0;
        }
    }
    //public void ShowRewardVideo()
    //{
    //    ShowRewardedAdsBoth(GiveReward);
    //}

    //public Reward GiveReward()
    //{

    //}
}
