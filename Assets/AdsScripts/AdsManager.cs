
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using GoogleMobileAds;
using com.adjust.sdk;
using ToastPlugin;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;
    private const string MaxSdkKey = "xMMUorXXT_twzcRqV_cszilvGuOzVT1QqNvcCR8lR0fOc6D66ry3XhzoaLm5qnVe8PFLsO5IOlg_sv6yk3_Gmy";
    private const string InterstitialAdUnitId = "e7f856c3ec6f3054";
    private const string RewardedAdUnitId = "7856fee616c8edbf";
    private const string RewardedInterstitialAdUnitId = "ENTER_REWARD_INTER_AD_UNIT_ID_HERE";
    private const string BannerAdUnitId = "bb375ac5c6f5a83d";
    private const string MRecAdUnitId = "";
    public string AppOpenAdUnitId = "999fc5e1f1d89618";

    private bool isBannerShowing;
    private bool isMRecShowing;

    private int interstitialRetryAttempt;
    private int rewardedRetryAttempt;
    private int rewardedInterstitialRetryAttempt;

    public TypeAdsMax TypeAdsUse;

    public static bool IsInterPresent = false;
    private DateTime LastPauseTime;
    private bool isFirstLoad = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (PlayerPrefs.GetInt("Remove_Ads") == 1)
        {
            RemoveAds();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameAnalytics.Initialize();
     //   Init();

    }

    //public void Init()
    //{
    //    MaxSdkCallbacks.OnSdkInitializedEvent += sdkConfiguration =>
    //    {
    //        // AppLovin SDK is initialized, configure and start loading ads.
    //        Debug.Log("MAX SDK Initialized");
    //        if (TypeAdsUse.HasFlag(TypeAdsMax.Inter))
    //            InitializeInterstitialAds();

    //        if (TypeAdsUse.HasFlag(TypeAdsMax.Reward))
    //            InitializeRewardedAds();

    //        if (TypeAdsUse.HasFlag(TypeAdsMax.Inter_Reward))
    //            InitializeRewardedInterstitialAds();

    //        if (TypeAdsUse.HasFlag(TypeAdsMax.Banner))
    //            InitializeBannerAds();

    //        if (TypeAdsUse.HasFlag(TypeAdsMax.MRec))
    //            InitializeMRecAds();
    //        //InitAOA();
    //        //MaxSdk.ShowMediationDebugger();
    //    };

    //    MaxSdk.SetSdkKey(MaxSdkKey);
    //    MaxSdk.InitializeSdk();
    //}

    public bool removeAdsFlag = false;
    public void RemoveAds()
    {
        removeAdsFlag = true;
        ADsShower.HideAdmobBanner();
     //   HideMaxBanner();
    }

    #region AOA Ad Methods
    //private void InitAOA()
    //{
    //    MaxSdkCallbacks.AppOpen.OnAdHiddenEvent += OnAppOpenDismissedEvent;
    //    MaxSdkCallbacks.AppOpen.OnAdLoadedEvent += OnAppOpenLoadedEvent;
    //    MaxSdkCallbacks.AppOpen.OnAdLoadFailedEvent += OnAppOpenLoadFailedEvent;
    //    MaxSdkCallbacks.AppOpen.OnAdDisplayFailedEvent += OnAppOpenFailedToDisplayEvent;
    //    MaxSdkCallbacks.AppOpen.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
    //    ShowAdIfReady();
    //}

    //public void ShowAdIfReady()
    //{
    //    if (MaxSdk.IsAppOpenAdReady(AppOpenAdUnitId))
    //    {
    //        if (removeAdsFlag == false)
    //        {
    //            MaxSdk.ShowAppOpenAd(AppOpenAdUnitId);
    //        }
    //    }
    //    else
    //    {
    //        MaxSdk.LoadAppOpenAd(AppOpenAdUnitId);
    //    }
    //}

    //public void OnAppOpenDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    MaxSdk.LoadAppOpenAd(AppOpenAdUnitId);
    //}

    //private void OnApplicationPause(bool pauseStatus)
    //{
    //    if (!pauseStatus)
    //    {
    //        if (IsInterPresent)
    //        {
    //            IsInterPresent = false;
    //            return;
    //        }
    //        //ShowAdIfReady();

    //    }
    //}


    //TimeSpan pauseDuration = DateTime.Now - LastPauseTime;
    //if (pauseDuration.TotalSeconds >= 20)
    //{

    //}
    //else
    //{
    //    LastPauseTime = DateTime.Now;
    //}

    //public void OnAppOpenLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    Debug.Log("Aoa loaded successfully, ID: " + AppOpenAdUnitId);
    //    if (isFirstLoad)
    //    {
    //        isFirstLoad = false;
    //        ShowAdIfReady();
    //        LoadInterstitial();
    //        LoadRewardedAd();
    //    }
    //}

    //private void OnAppOpenLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    //{
    //    if (isFirstLoad)
    //    {
    //        isFirstLoad = false;
    //        LoadInterstitial();
    //        LoadRewardedAd();
    //    }

    //    Debug.Log("Load AOA Failed.");
    //}

    //private void OnAppOpenFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo,
    //    MaxSdkBase.AdInfo adInfo)
    //{
    //    // Rewarded ad failed to display. We recommend loading the next ad
    //    Debug.Log("AOA ad failed to display with error code: " + errorInfo.Code);

    //    MaxSdk.LoadAppOpenAd(AppOpenAdUnitId);
    //}
    #endregion

    //#region Interstitial Ad Methods

    //private void InitializeInterstitialAds()
    //{
    //    MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
    //    MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialFailedEvent;
    //    MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialFailedToDisplayEvent;
    //    MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialDismissedEvent;
    //    MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
    //    MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;
    //    MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;

    //    // Load the first interstitial
    //    LoadInterstitial();
    //}

    //public void LoadInterstitial()
    //{
    //    MaxSdk.LoadInterstitial(InterstitialAdUnitId);
    //}

    //public void ShowInterstitial(string _placement)
    //{
    //    //if (!removeAdsFlag)
    //    //{
    //    if (MaxSdk.IsInterstitialReady(InterstitialAdUnitId))
    //    {
    //        //AppOpenAdManager.isInterstialAdPresent = true;
    //        MaxSdk.ShowInterstitial(InterstitialAdUnitId);
    //        AnalyticsManager.instance.SendAdEvent("Max", "Interstitial", "Show", _placement);
    //        firebasecall1.Instance.Event("Max_Inter_Show");
    //    }
    //    else
    //    {
    //        ADsShower.ShowInterstital(false, _placement);
    //        AnalyticsManager.instance.SendAdEvent("Max", "Interstitial", "Fail", _placement);
    //        firebasecall1.Instance.Event("Max_Inter_Fail");
    //    }
    //    //}
    //}

    ////public bool IsLoadInterstitial()
    ////{
    ////    return MaxSdk.IsInterstitialReady(InterstitialAdUnitId);
    ////}

    ////private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    ////{
    ////    // Reset retry attempt
    ////    interstitialRetryAttempt = 0;
    ////}

    ////private void OnInterstitialFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    ////{
    ////    // Interstitial ad failed to load. We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds).
    ////    interstitialRetryAttempt++;
    ////    double retryDelay = Math.Pow(2, Math.Min(6, interstitialRetryAttempt));

    ////    Invoke("LoadInterstitial", (float)retryDelay);
    ////    firebasecall1.Instance.Event("Max_Inter_FailToLoad");
    ////}

    ////private void OnInterstitialFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    ////{
    ////    // Interstitial ad failed to display. We recommend loading the next ad
    ////    //DebugCustom.Log("Interstitial failed to display with error code: " + errorCode);
    ////    LoadInterstitial();
    ////}

    ////private void OnInterstitialDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    ////{
    ////    // Interstitial ad is hidden. Pre-load the next ad
    ////    if (AdsTimer.instance) AdsTimer.instance.ResetAdTime();
    ////    GlobalContants.Ad_time = firebasecall1.interAdTime;
    ////    LoadInterstitial();
    ////    AnalyticsManager.instance.SendAdEvent("Max", "Interstitial", "Closed", GlobalConstant.ad_placement_name_inter);
    ////}

    ////private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    ////{
    ////    // Reset retry attempt
    ////    interstitialRetryAttempt = 0;
    ////    AnalyticsManager.instance.SendAdEvent("Max", "Interstitial", "Clicked", GlobalConstant.ad_placement_name_inter);
    ////}

    ////private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    ////{
    ////    // Reset retry attempt
    ////    //interstitialRetryAttempt = 0;  

    ////}
    //#endregion

    //#region Rewarded Ad Methods

    //private void InitializeRewardedAds()
    //{
    //    MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdFailedEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdDismissedEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
    //    MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;

    //    // Load the first RewardedAd
    //    LoadRewardedAd();
    //}

    //public void LoadRewardedAd()
    //{
    //    MaxSdk.LoadRewardedAd(RewardedAdUnitId);
    //}

    //public bool IsLoadRewardedAd()
    //{
    //    return MaxSdk.IsRewardedAdReady(RewardedAdUnitId);
    //}
    //public void ShowMaxRewarded()
    //{

    //    if (MaxSdk.IsRewardedAdReady(RewardedAdUnitId))
    //    {
    //        //AppOpenAdManager.isInterstialAdPresent = true;
    //        MaxSdk.ShowRewardedAd(RewardedAdUnitId);
    //    }
    //}
    //public void ShowRewardedAd(string _placement)
    //{
    //    AnalyticsManager.instance.SendAdEvent("Max", "Rewarded", "Click", _placement);

    //    if (MaxSdk.IsRewardedAdReady(RewardedAdUnitId))
    //    {
    //        //AppOpenAdManager.isInterstialAdPresent = true;
    //        MaxSdk.ShowRewardedAd(RewardedAdUnitId);
    //        AnalyticsManager.instance.SendAdEvent("Max", "Rewarded", "Show", _placement);
    //        firebasecall1.Instance.Event("Max_Rew_Show");
    //    }
    //    else
    //    {
    //        AnalyticsManager.instance.SendAdEvent("Max", "Rewarded", "Fail", _placement);
    //        firebasecall1.Instance.Event("Max_Rew_Fail");

    //        ADsShower.ShowRewarded(_placement);
    //    }
    //}
    //private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    // Rewarded ad is ready to be shown. MaxSdk.IsRewardedAdReady(rewardedAdUnitId) will now return 'true'

    //    // Reset retry attempt
    //    rewardedRetryAttempt = 0;
    //}

    //private void OnRewardedAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    //{
    //    // Rewarded ad failed to load. We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds).
    //    rewardedRetryAttempt++;
    //    double retryDelay = Math.Pow(2, Math.Min(6, rewardedRetryAttempt));

    //    //Debug.Log("Rewarded ad failed to load with error code: " + error);

    //    Invoke("LoadRewardedAd", (float)retryDelay);
    //}

    //private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    //{
    //    // Rewarded ad failed to display. We recommend loading the next ad
    //    //Debug.Log("Rewarded ad failed to display with error code: " + errorCode);
    //    LoadRewardedAd();
    //}

    //private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //}

    //private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{

    //}

    //private void OnRewardedAdDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    // Rewarded ad is hidden. Pre-load the next ad
    //    if (AdsTimer.instance) AdsTimer.instance.ResetAdTime();
    //    GlobalContants.Ad_time = 30;

    //    LoadRewardedAd();
    //}

    //private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    //{
    //    isRewarded = true;
    //}
    //bool isRewarded = false;
    //private void Update()
    //{
    //    if (isRewarded)
    //    {
    //        isRewarded = false;
    //        Data_Ironbolt.RewardedAdWatched();
    //        AnalyticsManager.instance.SendAdEvent("Max", "Rewarded", "Complete", GlobalConstant.ad_placement_name_rwd);
    //    }
    //}


    //#endregion

    #region Rewarded Interstitial Ad Methods

    //private void InitializeRewardedInterstitialAds()
    //{

    //    LoadRewardedInterstitialAd();
    //}

    //public void LoadRewardedInterstitialAd()
    //{
    //    if (MaxSdk.IsRewardedInterstitialAdReady(RewardedInterstitialAdUnitId))
    //    {
    //        return;
    //    }

    //    MaxSdk.LoadRewardedInterstitialAd(RewardedInterstitialAdUnitId);
    //}

    //public bool IsRewardedInterstitialAdReady()
    //{
    //    return MaxSdk.IsRewardedInterstitialAdReady(RewardedInterstitialAdUnitId);
    //}

    //public void ShowRewardedInterstitialAd(string placeId)
    //{
    //    if (MaxSdk.IsRewardedInterstitialAdReady(RewardedInterstitialAdUnitId))
    //    {
    //        MaxSdk.ShowRewardedInterstitialAd(RewardedInterstitialAdUnitId, placeId);
    //    }
    //}

    private void OnRewardedInterstitialAdLoadedEvent(string adUnitId)
    {
        // Rewarded interstitial ad is ready to be shown. MaxSdk.IsRewardedInterstitialAdReady(rewardedInterstitialAdUnitId) will now return 'true'

        // Reset retry attempt
        rewardedInterstitialRetryAttempt = 0;
    }

    private void OnRewardedInterstitialAdFailedEvent(string adUnitId, int errorCode)
    {
        // Rewarded interstitial ad failed to load. We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds).
        rewardedInterstitialRetryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, rewardedInterstitialRetryAttempt));
        Debug.Log("Rewarded interstitial ad failed to load with error code: " + errorCode);

        Invoke("LoadRewardedInterstitialAd", (float)retryDelay);
    }

    //private void OnRewardedInterstitialAdFailedToDisplayEvent(string adUnitId, int errorCode)
    //{
    //    // Rewarded interstitial ad failed to display. We recommend loading the next ad
    //    Debug.Log("Rewarded interstitial ad failed to display with error code: " + errorCode);
    //    LoadRewardedInterstitialAd();
    //}

    //private void OnRewardedInterstitialAdDisplayedEvent(string adUnitId)
    //{
    //}

    //private void OnRewardedInterstitialAdClickedEvent(string adUnitId)
    //{
    //}

    //private void OnRewardedInterstitialAdDismissedEvent(string adUnitId)
    //{
    //    // Rewarded interstitial ad is hidden. Pre-load the next ad
    //    LoadRewardedInterstitialAd();
    //}

    //private void OnRewardedInterstitialAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward)
    //{
    //    // Rewarded interstitial ad was displayed and user should receive the reward

    //}

    #endregion

    //#region Banner Ad Methods

    //private void InitializeBannerAds()
    //{
    //    MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
    //    MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdFailedEvent;
    //    MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
    //    MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnAdRevenuePaidEvent;

    //    // Banners are automatically sized to 320x50 on phones and 728x90 on tablets.
    //    // You may use the utility method `MaxSdkUtils.isTablet()` to help with view sizing adjustments.
    //    MaxSdk.CreateBanner(BannerAdUnitId, MaxSdkBase.BannerPosition.TopCenter);
    //    MaxSdk.SetBannerExtraParameter(BannerAdUnitId, "adaptive_banner", "true");
    //    // Set background or background color for banners to be fully functional.
    //    MaxSdk.SetBannerBackgroundColor(BannerAdUnitId, Color.clear);

    //}

    //private void ToggleBannerVisibility()
    //{
    //    if (!isBannerShowing)
    //    {
    //        MaxSdk.ShowBanner(BannerAdUnitId);
    //    }
    //    else
    //    {
    //        MaxSdk.HideBanner(BannerAdUnitId);
    //    }

    //    isBannerShowing = !isBannerShowing;
    //}

    //public bool ShowMaxBanner()
    //{
    //    if (!removeAdsFlag)
    //    {
    //        if (firebasecall1.bannerRemoteControl)
    //        {
    //            ADsShower.ShowAdmobBanner();
    //        }
    //        else if (firebasecall1.max_banner)
    //        {
    //            if (MaxBannerLoaded == true)
    //            {
    //                MaxSdk.ShowBanner(BannerAdUnitId);
    //                MaxSdk.StartBannerAutoRefresh(BannerAdUnitId);
    //                ADsShower.DestroyBanner();
    //            }
    //            else if (MaxBannerLoaded == false)
    //            {
    //                DestroyBanner();
    //            }
    //        }
    //    }

    //    return true;
    //}

    //public void HideMaxBanner()
    //{
    //    if (firebasecall1.max_banner)
    //        MaxSdk.HideBanner(BannerAdUnitId);
    //}

    //public void DestroyBanner()
    //{
    //    if (firebasecall1.max_banner)
    //        MaxSdk.DestroyBanner(BannerAdUnitId);
    //}

    //bool MaxBannerLoaded = false;
    //private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    // Banner ad is ready to be shown.
    //    // If you have already called MaxSdk.ShowBanner(BannerAdUnitId) it will automatically be shown on the next ad refresh.
    //    MaxBannerLoaded = true;
    //    //GameManager.Instance.ShowBannerAds();
    //}

    //private void OnBannerAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    //{
    //    MaxBannerLoaded = false;
    //    // Banner ad failed to load. MAX will automatically try loading a new ad internally.
    //    Debug.Log("Banner ad failed to load with error code: " + errorInfo.Code);
    //}

    //private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //}


    //#endregion

    //#region MREC Ad Methods

    //public void ShowMRecBanner()
    //{
    //    if (!removeAdsFlag)
    //        ADsShower.ShowRectBanner();
    //}

    //private void InitializeMRecAds()
    //{
    //    // MRECs are automatically sized to 300x250.
    //    MaxSdk.CreateMRec(MRecAdUnitId, MaxSdkBase.AdViewPosition.BottomCenter);
    //}

    //private void ToggleMRecVisibility()
    //{
    //    if (!isMRecShowing)
    //    {
    //        MaxSdk.ShowMRec(MRecAdUnitId);
    //    }
    //    else
    //    {
    //        MaxSdk.HideMRec(MRecAdUnitId);
    //    }

    //    isMRecShowing = !isMRecShowing;
    //}

    //#endregion
    //private void OnAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo impressionData)
    //{
    //    AnalyticsManager.instance.AdjustRevReport_Max(adUnitId, impressionData);
    //}
    //private void OnAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo impressionData)
    //{
    //    double revenue = impressionData.Revenue;

    //    AdjustAdRevenue adjustAdRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
    //    adjustAdRevenue.setRevenue(impressionData.Revenue, "USD");
    //    adjustAdRevenue.setAdRevenueNetwork(impressionData.NetworkName);
    //    adjustAdRevenue.setAdRevenueUnit($"{impressionData.AdFormat}_{impressionData.AdUnitIdentifier}");
    //    Adjust.trackAdRevenue(adjustAdRevenue);


    //    var impressionParameters = new[] {
    //      new Firebase.Analytics.Parameter("ad_platform", "AppLovin"),
    //      new Firebase.Analytics.Parameter("ad_source", impressionData.NetworkName),
    //      new Firebase.Analytics.Parameter("ad_unit_name", impressionData.AdUnitIdentifier),
    //      new Firebase.Analytics.Parameter("ad_format", impressionData.AdFormat),
    //      new Firebase.Analytics.Parameter("value", revenue),
    //      new Firebase.Analytics.Parameter("currency", "USD"),
    //    };
    //    if (impressionData.NetworkName == "AdMob" || impressionData.NetworkName == "Google Ad Manager Native" || impressionData.NetworkName == "Google AdMob")
    //    {
    //        return;
    //    }
    //    else
    //        Firebase.Analytics.FirebaseAnalytics.LogEvent("ad_impression", impressionParameters);
    //    //Debug.Log("Firebase ad_impressionDataEvent= " + impressionData.AdFormat);

    //}
    //private void OnRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    //{
    //    // Interstitial ad revenue paid. Use this callback to track user revenue.
    //    Debug.Log(" revenue paid");

    //    AdjustAdRevenue adjustAdRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
    //    adjustAdRevenue.setRevenue(adInfo.Revenue, "USD");
    //    adjustAdRevenue.setAdRevenueNetwork(adInfo.Placement);
    //    Adjust.trackAdRevenue(adjustAdRevenue);


    //    // Ad revenue
    //    double revenue = adInfo.Revenue;

    //    // Miscellaneous data
    //    string countryCode = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD" in most cases!
    //    string networkName = adInfo.NetworkName; // Display name of the network that showed the ad (e.g. "AdColony")
    //    string adUnitIdentifier = adInfo.AdUnitIdentifier; // The MAX Ad Unit ID
    //    string placement = adInfo.Placement; // The placement this ad's postbacks are tied to

    //    var data = new ImpressionData();
    //    data.AdFormat = adInfo.AdFormat;
    //    data.AdUnitIdentifier = adUnitIdentifier;
    //    data.CountryCode = countryCode;
    //    data.NetworkName = networkName;
    //    data.Placement = placement;
    //    data.Revenue = revenue;

    //    AnalyticsRevenueAds.SendEvent(data);


    //}
}

[Flags]
public enum TypeAdsMax
{
    Inter = 1 << 0,
    Banner = 1 << 1,
    Reward = 1 << 2,
    Inter_Reward = 1 << 3,
    MRec = 1 << 4
}


