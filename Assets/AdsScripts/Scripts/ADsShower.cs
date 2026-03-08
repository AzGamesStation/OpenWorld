using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using System;

public class ADsShower : MonoBehaviour
{
    public static ADsShower instance;
    public AdmobAdsManager AdsHandler;
    public delegate void RewardUserDelegate();
    public Action rewardedAction;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        //AdsHandler = new AdmobAdsManager();
    }
    void Showmyad()
    {

    }
    public static void ShowInterstital(bool UseLoading, string placement)
    {
        if (firebasecall1.interRemoteControl)
            instance.AdsHandler.ShowInt(LoadAd, UseLoading, placement);
        //if (UseLoading)
        //{
        //}
        //else
        //{
        //    instance.AdsHandler.ShowInterstitialAd();
        //}
    }
    static void LoadAd() => instance.AdsHandler.LoadInterstitialAd();
    //public static void hideSmallBanners()
    //{
    //    instance.AdsHandler.Hide_Left_SmallBannerEvent();
    //    instance.AdsHandler.Hide_Right_SmallBannerEvent();
    //}
    public static void ShowRectBanner()
    {
        if (firebasecall1.rectBannerRemoteControl)
            instance.AdsHandler.ShowMediumBanner(AdPosition.BottomLeft);
    }

    public static void HideRectBanner()
    {
        instance.AdsHandler.HideMediumBannerEvent();
    }
    public static void ShowAdmobBanner()
    {
        if (firebasecall1.bannerRemoteControl)
            instance.AdsHandler.Show_Left_SmallBanner();
    }
    public static void HideAdmobBanner()
    {
        instance.AdsHandler.HideBanner();
    }

    public static void DestroyBanner()
    {
        instance.AdsHandler.DestroyBanner();
    }

    public static void ShowRewarded(string placement)
    {
        if (firebasecall1.rewardedRemoteControl)
            instance.AdsHandler.ShowRewardedAdsBoth(AdWatch,placement);
    }

    public static void CheckInterstitalIsLoaded()
    {
        if (instance.AdsHandler.IsInterstitialAdReady())
        {
            return;
        }
        instance.AdsHandler.LoadInterstitialAd();
    }
    bool AdWatched;
    private void Update()
    {
        if (AdWatched)
        {
            RewardGiven();
            AdWatched = false;
        }
    }
    public static void AdWatch(Reward reward)
    {
        instance.AdWatched = true;
        Data_Ironbolt.RewardedAdWatched();
        AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded", "Complete", GlobalConstant.ad_placement_name_rwd);

    }
    void RewardGiven()
    {

    }
}
