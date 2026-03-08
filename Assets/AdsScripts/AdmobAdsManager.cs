using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using com.adjust.sdk;
using static MaxSdkCallbacks;

[Serializable]
public class ADMobID
{
    [Header("Unity ID")]
    public string UnityId;
    [Header("Unity Interstitial_ID")]
    public string Unity_Interstitial_ID;
    [Header("Unity RewardedVideo_ID")]
    public string Unity_RewardedVideo;
    [Header("AdMobAppID")]
    public string AdmobAPPID;
    [Header("Intersitial")]
    public string Intersitial;

    [Header("SmallBanner_L_Medium_Ecpm")]
    public string SmallBanner_L_Medium_Ecpm;

    [Header("Small_banners_L_Low_Ecpm")]
    public string Small_banners_L_Low_Ecpm;


    [Header("SmallBanner_R_Medium_Ecpm")]
    public string SmallBanner_R_Medium_Ecpm;

    [Header("Small_banners_R_Low_Ecpm")]
    public string Small_banners_R_Low_Ecpm;

    [Header("MediumBanner_Medium_Ecpm")]
    public string MediumBanner_Medium_Ecpm;

    [Header("MediumBanner_Low_Ecpm")]
    public string MediumBanner_Low_Ecpm;

    [Header("RewardedVideo")]
    public string RewardedVideo;

    [Header("RewardedInt")]
    public string RewardedInt;
}
public class AdmobAdsManager : Handler
{
    public ADMobID AndroidAdmob_ID = new ADMobID();
    public ADMobID IosAndroid_ID = new ADMobID();
    public ADMobID TestAdmob_ID = new ADMobID();
    [HideInInspector]
    public ADMobID ADMOB_ID = new ADMobID();

    public static bool isSmallBannerLoadedFirst = false;
    public static bool isSmallBannerLoadedSecond = false;
    public static bool isMediumBannerLoaded = false;
    bool isAdmobInitialized = false;
    double revenue;
    #region IntersitialAds_Var
    [HideInInspector]
    public InterstitialAd Interstitial_High_Ecpm;

    public delegate void InterstitialUnity();
    public static event InterstitialUnity Int_Unity;

    public static bool Interstitial_HighEcpm = true, UnityAds = false;

    #endregion

    #region SmallBanner_Var
    [HideInInspector]
    public BannerView SmallBanner_L_Low_ECPM;

    [HideInInspector]
    public BannerView SmallBanner_L_Medium_Ecpm;

    public delegate void SmallBannerFirstMediumEcpm();
    public static event SmallBannerFirstMediumEcpm First_Small_Banner_Medium_Ecpm;

    public delegate void SmallFirstBannerLow();
    public static event SmallFirstBannerLow First_Small_Banner_Low_Ecpm;

    public static bool FirstBanner_Medium_Ecpm = true, FirstBanner_Low_Ecpm = false;


    /// <summary>
    /// 2nd Banner
    /// </summary>
    [HideInInspector]
    public BannerView SmallBanner_R_Low_ECPM;


    [HideInInspector]
    public BannerView SmallBanner_R_Medium_Ecpm;

    public delegate void SmallBanner2ndMediumEcpm();

    public static event SmallBanner2ndMediumEcpm Second_Small_banner_Medium_Ecpm;


    public delegate void SmallBannr2ndLowEcmp();
    public static event SmallBannr2ndLowEcmp Second_Small_banner_Low_Ecpm;


    public static bool SecondBanner_Medium_Ecpm = true, SecondBanner_Low_Ecpm = false;

    public static bool Logs;

    #endregion

    #region MediumBanner_Var


    [HideInInspector]
    public BannerView MediumBannerMediumEcpm;
    [HideInInspector]
    public BannerView MediumBannerLowEcpm;


    public delegate void MediumBannerMediumECPM();
    public static event MediumBannerMediumECPM MediumbannerMediumEcpm;

    public delegate void MediumBannerLowECPM();
    public static event MediumBannerLowECPM MediumbannerLowEcpm;

    public static bool MediumBanner_Medium_Ecpm = true, MediumBanner_Low_Ecpm = false;




    #endregion

    #region RewardedVideo_Var

    private static RewardUserDelegate NotifyReward;

    [HideInInspector]
    public RewardedAd rewardBasedVideo;



    public delegate void RewardVideoUnity();
    public static event RewardVideoUnity RewardVideo_Unity;

    public static bool RewardVideo_High_Ecpm = true, UnityRewarded = false;

    #endregion

    #region RewardedInterstitialAds

    [HideInInspector]
    public RewardedInterstitialAd rewardedInterstitialAd;



    [HideInInspector]
    public bool rewardedInterstitialHighECPMLoaded;

    #endregion


    public static AdmobAdsManager Instance;

    private void Awake()
    {
        Instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        DontDestroyOnLoad(this.gameObject);
        Logs = DisableDebugLogs;
        if (EnableTestModeAds)
        {
            ADMOB_ID = TestAdmob_ID;
        }
        else
        {
#if UNITY_ANDROID
            ADMOB_ID = AndroidAdmob_ID;
#elif UNITY_IOS
        ADMOB_ID = IosAndroid_ID;
          RequestConfiguration requestConfiguration = new RequestConfiguration.Builder()
       .SetSameAppKeyEnabled(false)
       .build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
#endif
        }
    }

    private void Start()
    {
        InitAdmob();
        InitializeAds();
        GameAnalytics.Initialize();
    }

    public void InitializeAds()
    {
        //ADMOB_ID.UnityId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //    ? AndroidAdmob_ID.UnityId
        //    : AndroidAdmob_ID.UnityId;
        //Advertisement.Initialize(ADMOB_ID.UnityId, EnableTestModeAds, this);
    }

    public void OnInitializationComplete()
    {
        //Admob_LogHelper.LogGAEvent("Unity_Ads_initialization_complete");
    }

    //public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    //{
    //    Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    //}
    private void InitAdmob()
    {
        //Admob_LogHelper.LogSender(AdmobEvents.Initializing);

        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        //Logging.Log("GR >> Adapter: " + status.Description + " not ready.Name=" + className);
                        break;
                    case AdapterState.Ready:
                        //Admob_LogHelper.LogSender(AdmobEvents.Initialized);
                        MediationAdapterConsent(className);
                        break;
                }
            }
        });
#if UNITY_IOS
        MobileAds.SetiOSAppPauseOnBackground(true);    
#endif
    }


    void MediationAdapterConsent(string AdapterClassname)
    {
        if (AdapterClassname.Contains("ExampleClass"))
        {
            isAdmobInitialized = true;
            CreateAdsObjects();
            Load_Left_SmallBanner();
            //Load_Right_SmallBanner();
            LoadMediumBanner();
            LoadRewardedInterstitial();
            LoadRewardedVideo();

        }
        if (AdapterClassname.Contains("MobileAds"))
        {
            isAdmobInitialized = true;
            CreateAdsObjects();
            Load_Left_SmallBanner();
            //Load_Right_SmallBanner();
            LoadMediumBanner();
            LoadRewardedInterstitial();
            LoadRewardedVideo();
            LoadInterstitialAd();
        }
    }

    private void CreateAdsObjects()
    {
        //this.Interstitial_High_Ecpm = new InterstitialAd();
        //this.rewardBasedVideo = new RewardedAd();
    }

    #region IntersititialCodeBlock


    private void BindIntersititialHighEcpmEvents()
    {
        //this.Interstitial_High_Ecpm.OnAdLoaded += HandleOnAdLoaded_High_Ecpm;
        this.Interstitial_High_Ecpm.OnAdFullScreenContentFailed += HandleOnAdFailedToLoad_High_Ecpm;
        this.Interstitial_High_Ecpm.OnAdFullScreenContentOpened += HandleOnAdOpened_High_Ecpm;
        this.Interstitial_High_Ecpm.OnAdFullScreenContentClosed += HandleOnAdClosed_High_Ecpm;
        this.Interstitial_High_Ecpm.OnAdPaid += Interstitial_OnPaidEvent;
    }
    public override bool IsInterstitialAdReady()
    {
        if (this.Interstitial_High_Ecpm != null)
            return this.Interstitial_High_Ecpm.CanShowAd();
        else
            return false;
    }
    private void Interstitial_OnPaidEvent(AdValue impressionData)
    {
        double revenue = (impressionData.Value / 1000000f);
        AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.Interstitial, ADMOB_ID.Intersitial);
    }
    public override void ShowInterstitialAd(string _placement)
    {
        if (!PreferenceManager.GetAdsStatus() || !isAdmobInitialized)
        {
            return;
        }

        if (Interstitial_HighEcpm)
        {
            if (this.Interstitial_High_Ecpm != null)
            {
                if (this.Interstitial_High_Ecpm.CanShowAd())
                {
                    //Admob_LogHelper.LogSender(AdmobEvents.Interstitial_WillDisplay_High_Ecpm);
                    this.Interstitial_High_Ecpm.Show();
                    AnalyticsManager.instance.SendAdEvent("Admob", "Interstitial", "Show", _placement);
                    firebasecall1.Instance.Event("Admob_Int_Show");
                }
                else
                {
                    AnalyticsManager.instance.SendAdEvent("Admob", "Interstitial", "Fail", _placement);
                    firebasecall1.Instance.Event("Admob_Int_Fail");
                }
            }
        }
        else if (UnityAds)
        {
            //Advertisement.Show(ADMOB_ID.Unity_Interstitial_ID, this);
        }
    }
    private void Rewarded_OnPaidEvent(AdValue impressionData)
    {
        double revenue = (impressionData.Value / 1000000f);
        AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.Rewarded, ADMOB_ID.RewardedVideo);
    }
    public override void LoadInterstitialAd()
    {
        if (!isAdmobInitialized || IsInterstitialAdReady() || iAdStatus == AdsLoadingStatus.Loading || !PreferenceManager.GetAdsStatus())
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (Interstitial_HighEcpm)
            {
                Int_Unity += LoadInterstitialAd;
                //Admob_LogHelper.LogSender(AdmobEvents.LoadInterstitial_High_Ecpm);
                //AdRequest request = new AdRequest.Builder().Build();
                //this.Interstitial_High_Ecpm.LoadAd(request);
                // Clean up the old ad before loading a new one.
                if (Interstitial_High_Ecpm != null)
                {
                    Interstitial_High_Ecpm.Destroy();
                    Interstitial_High_Ecpm = null;
                }

                Debug.Log("Loading the interstitial ad.");

                // create our request used to load the ad.
                var adRequest = new AdRequest();

                // send the request to load the ad.
                InterstitialAd.Load(ADMOB_ID.Intersitial, adRequest,
                    (InterstitialAd ad, LoadAdError error) =>
                    {
                        // if error is not null, the load request failed.
                        if (error != null || ad == null)
                        {
                            Debug.LogError("interstitial ad failed to load an ad " +
                                           "with error : " + error);
                            return;
                        }

                        Debug.Log("Interstitial ad loaded with response : "
                                  + ad.GetResponseInfo());

                        Interstitial_High_Ecpm = ad;
                        BindIntersititialHighEcpmEvents();
                    });
                iAdStatus = AdsLoadingStatus.Loading;
            }

            else if (UnityAds)
            {
                //Admob_LogHelper.LogGAEvent("Load_Unity_Int");
                //Advertisement.Load(ADMOB_ID.Unity_Interstitial_ID, this);
            }
        }
    }

    #endregion

    #region IntersititialEventCallBacks
    //HighEcpmEvents
    public void HandleOnAdLoaded_High_Ecpm(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_HighEcpm)
            {
                iAdStatus = AdsLoadingStatus.Loaded;

                //Admob_LogHelper.LogSender(AdmobEvents.Interstitial_Loaded_High_Ecpm);
                Int_Unity -= LoadInterstitialAd;
                Interstitial_HighEcpm = true;
                UnityAds = false;
            }

        });
    }

    public void HandleOnAdFailedToLoad_High_Ecpm(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_HighEcpm)
            {

                iAdStatus = AdsLoadingStatus.NoInventory;
                //Logging.Log("GR >> Admob:iad:NoInventory_H_Ecpm :: " + args.ToString());
                //Admob_LogHelper.LogSender(AdmobEvents.Interstitial_NoInventory_High_Ecpm);
                Interstitial_HighEcpm = false;
                UnityAds = true;
                if (Int_Unity != null)
                    Int_Unity();
            }

        });
    }
    public void HandleOnAdFailedToLoad_High_Ecpm1(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_HighEcpm)
            {

                iAdStatus = AdsLoadingStatus.NoInventory;
                //Logging.Log("GR >> Admob:iad:NoInventory_H_Ecpm :: " + args.ToString());
                //Admob_LogHelper.LogSender(AdmobEvents.Interstitial_NoInventory_High_Ecpm);
                Interstitial_HighEcpm = false;
                UnityAds = true;
                if (Int_Unity != null)
                    Int_Unity();


            }

        });
    }

    public void HandleOnAdOpened_High_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            iAdStatus = AdsLoadingStatus.NotLoaded;
            if (Interstitial_HighEcpm)
            {
                Int_Unity -= LoadInterstitialAd;
            }
        });
    }

    public void HandleOnAdClosed_High_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            iAdStatus = AdsLoadingStatus.NotLoaded;

            if (Interstitial_HighEcpm)
            {
                if (AdsTimer.instance) AdsTimer.instance.ResetAdTime();
                GlobalContants.Ad_time = firebasecall1.interAdTime;

                //this.Interstitial_High_Ecpm.Destroy();
                //this.Interstitial_High_Ecpm = new InterstitialAd(ADMOB_ID.Intersitial);
                LoadInterstitialAd();

                Int_Unity -= LoadInterstitialAd;

                Interstitial_HighEcpm = true;
                UnityAds = false;
            }
        });
        AnalyticsManager.instance.SendAdEvent("Admob", "Interstitial", "Closed", GlobalConstant.ad_placement_name_inter);
    }


    #endregion

    #region BannerCodeBlock

    public override bool IsSmallFirstBannerReady()
    {
        return isSmallBannerLoadedFirst;
    }
    public override void Load_Left_SmallBanner()
    {
        if (!PreferenceManager.GetAdsStatus() || IsSmallFirstBannerReady() || smallBannerStatus == AdsLoadingStatus.Loading)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            this.SmallBanner_L_Low_ECPM = new BannerView(ADMOB_ID.Small_banners_L_Low_Ecpm, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Top);
            BindSmallBannerFirst();
            AdRequest request = new AdRequest.Builder().Build();

            // Load the banner with the request.
            this.SmallBanner_L_Low_ECPM.LoadAd(request);
            this.SmallBanner_L_Low_ECPM.Hide();
        }
    }
    public override void Hide_Left_SmallBannerEvent()
    {
        if (this.SmallBanner_L_Low_ECPM != null)
        {
            this.SmallBanner_L_Low_ECPM.Hide();
        }
    }
    public void HideBanner()
    {
        Hide_Left_SmallBannerEvent();
        //Hide_Right_SmallBannerEvent();
    }

    public void DestroyBanner()
    {
        this.SmallBanner_L_Low_ECPM.Destroy();
    }

    public override void Show_Left_SmallBanner()
    {
        Hide_Left_SmallBannerEvent();
        try
        {
            if (!PreferenceManager.GetAdsStatus() || !isAdmobInitialized)
            {
                return;
            }
            if (SmallBanner_L_Low_ECPM != null)
            {
                this.SmallBanner_L_Low_ECPM.Hide();
                this.SmallBanner_L_Low_ECPM.Show();
                this.SmallBanner_L_Low_ECPM.SetPosition(AdPosition.Top);
                Debug.Log("Admob Banner Showed...");
            }
            else
            {
                Load_Left_SmallBanner();
            }
        }
        catch (Exception error)
        {
            //Logging.Log("Small Banner Error: " + error);
        }
    }
    private void BindSmallBannerFirst()
    {
        this.SmallBanner_L_Low_ECPM.OnBannerAdLoaded += SmallBanner_HandleOnAdLoaded_First;
        this.SmallBanner_L_Low_ECPM.OnBannerAdLoadFailed += SmallBanner_HandleOnAdFailedToLoad_First;
        this.SmallBanner_L_Low_ECPM.OnAdPaid += BannerLow_Left_OnPaidEvent;
    }
    private void BannerLow_Left_OnPaidEvent(AdValue impressionData)
    {
        double revenue = (impressionData.Value / 1000000f);
        AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.Banner, ADMOB_ID.Small_banners_L_Low_Ecpm);
    }
    //private void Banner_Low_LeftOnPaidEvent(AdValue impressionData)
    //{
    //    double revenue = (impressionData.Value / 1000000f);
    //    AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.Banner, ADMOB_ID.Small_banners_L_Low_Ecpm);
    //}
    //private void BannerMedRightSide_OnPaidEvent(AdValue impressionData)
    //{
    //    double revenue = (impressionData.Value / 1000000f);
    //    AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.Banner, ADMOB_ID.Small_banners_L_Low_Ecpm);
    //}
    //private void BannerLowRightSide_OnPaidEvent(AdValue impressionData)
    //{
    //    double revenue = (impressionData.Value / 1000000f);
    //    AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.Banner, ADMOB_ID.Small_banners_L_Low_Ecpm);
    //}
    //private void BindSmallBannerFirstMediumEcpm()
    //{
    //    this.SmallBanner_L_Medium_Ecpm.OnBannerAdLoaded += SmallBanner_HandleOnAdLoaded_First_Medium_Ecpm;
    //    this.SmallBanner_L_Medium_Ecpm.OnBannerAdLoadFailed += SmallBanner_HandleOnAdFailedToLoad_First_Medium_Ecpm;
    //    this.SmallBanner_L_Medium_Ecpm.OnAdPaid += Banner_Low_LeftOnPaidEvent;
    //}
    //private void BindSmallBannerSecondEcpm()
    //{
    //    this.SmallBanner_R_Low_ECPM.OnBannerAdLoaded += SmallBanner_HandleOnAdLoaded_Second;
    //    this.SmallBanner_R_Low_ECPM.OnBannerAdLoadFailed += SmallBanner_HandleOnAdFailedToLoad_Second;
    //    this.SmallBanner_R_Low_ECPM.OnAdPaid += BannerLowRightSide_OnPaidEvent;
    //}
    //private void BindSmallBannerSecondMediumEcpm()
    //{
    //    this.SmallBanner_R_Medium_Ecpm.OnBannerAdLoaded += SmallBanner_HandleOnAdLoaded_Second_Medium_Ecpm;
    //    this.SmallBanner_R_Medium_Ecpm.OnBannerAdLoadFailed += SmallBanner_HandleOnAdFailedToLoad_Second_Medium_Ecpm;
    //    this.SmallBanner_R_Medium_Ecpm.OnAdPaid += BannerMedRightSide_OnPaidEvent;
    //}
    //public override bool IsSecondBannerReady()
    //{
    //    return isSmallBannerLoadedSecond;
    //}
    //public override void Load_Right_SmallBanner()
    //{
    //    if (!PreferenceManager.GetAdsStatus() || IsSecondBannerReady() || small2ndBannerStatus == AdsLoadingStatus.Loading)
    //    {
    //        return;
    //    }
    //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
    //    {


    //        if (SecondBanner_Medium_Ecpm)
    //        {
    //            this.SmallBanner_R_Medium_Ecpm = new BannerView(ADMOB_ID.SmallBanner_R_Medium_Ecpm, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Top);

    //            Second_Small_banner_Low_Ecpm += Load_Right_SmallBanner;
    //            //Logging.Log("SecondSmallBanner_M_Ecpm");
    //            BindSmallBannerSecondMediumEcpm();
    //            // Create an empty ad request.
    //            AdRequest request = new AdRequest.Builder().Build();

    //            // Load the banner with the request.
    //            this.SmallBanner_R_Medium_Ecpm.LoadAd(request);
    //            this.SmallBanner_R_Medium_Ecpm.Hide();
    //        }
    //        else
    //        if (SecondBanner_Low_Ecpm)
    //        {
    //            this.SmallBanner_R_Low_ECPM = new BannerView(ADMOB_ID.Small_banners_R_Low_Ecpm, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), AdPosition.Top);

    //            //Logging.Log("SecondSmallBanner_L_Ecpm");
    //            BindSmallBannerSecondEcpm();

    //            AdRequest request = new AdRequest.Builder().Build();

    //            this.SmallBanner_R_Low_ECPM.LoadAd(request);
    //            this.SmallBanner_R_Low_ECPM.Hide();
    //        }
    //    }
    //}
    //public override void Hide_Right_SmallBannerEvent()
    //{

    //    if (this.SmallBanner_R_Medium_Ecpm != null)
    //    {
    //        this.SmallBanner_R_Medium_Ecpm.Hide();
    //        //Logging.Log("GR >> Admob:smallBanner:Hide_M_Ecpm");
    //    }

    //    if (this.SmallBanner_R_Low_ECPM != null)
    //    {
    //        //Logging.Log("GR >> Admob:smallBanner:Hide_L_Ecpm");
    //        this.SmallBanner_R_Low_ECPM.Hide();
    //    }
    //}


    //public override void Show_Right_SmallBanner()
    //{
    //    Hide_Right_SmallBannerEvent();
    //    try
    //    {
    //        if (!PreferenceManager.GetAdsStatus() || !isAdmobInitialized)
    //        {
    //            return;
    //        }
    //        if (SecondBanner_Medium_Ecpm)
    //        {
    //            if (SmallBanner_R_Medium_Ecpm != null)
    //            {

    //                this.SmallBanner_R_Medium_Ecpm.Hide();

    //                this.SmallBanner_R_Medium_Ecpm.Show();
    //                this.SmallBanner_R_Medium_Ecpm.SetPosition(AdPosition.Top);
    //                //Logging.Log("GR >> SecondBanner_Medium__Ecpm_Show");
    //            }
    //        }
    //        else if (SecondBanner_Low_Ecpm)
    //        {
    //            if (SmallBanner_R_Low_ECPM != null)
    //            {

    //                this.SmallBanner_R_Low_ECPM.Hide();

    //                this.SmallBanner_R_Low_ECPM.Show();
    //                this.SmallBanner_R_Low_ECPM.SetPosition(AdPosition.Top);
    //                //Logging.Log("GR >> SecondBanner_Low_Ecpm_Show");
    //            }
    //        }
    //        else
    //        {
    //            Load_Right_SmallBanner();
    //        }
    //    }
    //    catch (Exception error)
    //    {
    //        //Logging.Log("Small Banner Error: " + error);
    //    }
    //}

    #endregion

    #region SmallBannerEvents
    public void SmallBanner_HandleOnAdLoaded_First()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (FirstBanner_Low_Ecpm)
            {
                smallBannerStatus = AdsLoadingStatus.Loaded;

                isSmallBannerLoadedFirst = true;

                FirstBanner_Medium_Ecpm = false;
                FirstBanner_Low_Ecpm = true;
            }
        });
    }
    public void SmallBanner_HandleOnAdFailedToLoad_First(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            {
                smallBannerStatus = AdsLoadingStatus.NoInventory;
                // Invoke(nameof(Load_Left_SmallBanner), 20);
                isSmallBannerLoadedFirst = false;
            }
        });
    }
    //public void SmallBanner_HandleOnAdLoaded_First_Medium_Ecpm()
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (FirstBanner_Medium_Ecpm)
    //        {
    //            smallBannerStatus = AdsLoadingStatus.Loaded;
    //            First_Small_Banner_Low_Ecpm -= Load_Left_SmallBanner;
    //            //Logging.Log("GR >> FirstSmallBanner_M_Loaded_Ecpm");
    //            isSmallBannerLoadedFirst = true;
    //            FirstBanner_Medium_Ecpm = true;
    //            FirstBanner_Low_Ecpm = false;
    //        }
    //    });
    //}
    //public void SmallBanner_HandleOnAdFailedToLoad_First_Medium_Ecpm(object sender)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (FirstBanner_Medium_Ecpm)
    //        {
    //            smallBannerStatus = AdsLoadingStatus.NoInventory;
    //            isSmallBannerLoadedFirst = false;
    //            FirstBanner_Medium_Ecpm = false;
    //            FirstBanner_Low_Ecpm = true;

    //            if (First_Small_Banner_Low_Ecpm != null)
    //                First_Small_Banner_Low_Ecpm();
    //        }
    //    });
    //}

    //public void SmallBanner_HandleOnAdLoaded_Second_Medium_Ecpm()
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (SecondBanner_Medium_Ecpm)
    //        {
    //            small2ndBannerStatus = AdsLoadingStatus.Loaded;
    //            First_Small_Banner_Low_Ecpm -= Load_Right_SmallBanner;
    //            isSmallBannerLoadedSecond = true;
    //            SecondBanner_Medium_Ecpm = true;
    //            SecondBanner_Low_Ecpm = false;
    //        }
    //    });
    //}
    //public void SmallBanner_HandleOnAdFailedToLoad_Second_Medium_Ecpm(object sender)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (SecondBanner_Medium_Ecpm)
    //        {
    //            small2ndBannerStatus = AdsLoadingStatus.NoInventory;
    //            isSmallBannerLoadedSecond = false;
    //            SecondBanner_Medium_Ecpm = false;
    //            SecondBanner_Low_Ecpm = true;
    //            if (Second_Small_banner_Low_Ecpm != null)
    //                Second_Small_banner_Low_Ecpm();
    //        }
    //    });
    //}
    //public void SmallBanner_HandleOnAdLoaded_Second()
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (SecondBanner_Low_Ecpm)
    //        {
    //            small2ndBannerStatus = AdsLoadingStatus.Loaded;
    //            Second_Small_banner_Low_Ecpm -= Load_Right_SmallBanner;
    //            isSmallBannerLoadedSecond = true;
    //            SecondBanner_Medium_Ecpm = false;
    //            SecondBanner_Low_Ecpm = true;
    //        }
    //    });
    //}
    //public void SmallBanner_HandleOnAdFailedToLoad_Second(object sender)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (SecondBanner_Low_Ecpm)
    //        {
    //            small2ndBannerStatus = AdsLoadingStatus.NoInventory;
    //            isSmallBannerLoadedSecond = false;
    //        }
    //    });
    //}
    #endregion

    #region MediumBannerCodeBlocks
    public override bool IsMediumBannerReady()
    {
        return isMediumBannerLoaded;
    }
    public override void LoadMediumBanner()
    {
        if (!PreferenceManager.GetAdsStatus() || IsMediumBannerReady() || mediumBannerStatus == AdsLoadingStatus.Loading)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            this.MediumBannerLowEcpm = new BannerView(ADMOB_ID.MediumBanner_Low_Ecpm, AdSize.MediumRectangle, AdPosition.BottomLeft);

            BindMediumBannerEvents_L_Ecpm();
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();

            // Load the banner with the request.
            this.MediumBannerLowEcpm.LoadAd(request);
            this.MediumBannerLowEcpm.Hide();
        }
    }
    public override void ShowMediumBanner(AdPosition pos)
    {
        try
        {
            if (!PreferenceManager.GetAdsStatus() || !isAdmobInitialized)
            {
                return;
            }
            if (MediumBannerLowEcpm != null)
            {
                this.MediumBannerLowEcpm.Hide();
                this.MediumBannerLowEcpm.Show();
                this.MediumBannerLowEcpm.SetPosition(pos);
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void HideMediumBannerEvent()
    {
        if (this.MediumBannerLowEcpm != null)
        {
            this.MediumBannerLowEcpm.Hide();
        }
    }
    private void MediumBannerLow_OnPaidEvent(AdValue impressionData)
    {
        double revenue = (impressionData.Value / 1000000f);
        AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.MREC, ADMOB_ID.MediumBanner_Low_Ecpm);
    }
    private void BindMediumBannerEvents_L_Ecpm()
    {
        this.MediumBannerLowEcpm.OnBannerAdLoaded += MediumBanner_HandleOnAdLoaded_L_Ecpm;
        this.MediumBannerLowEcpm.OnBannerAdLoadFailed += MediumBanner_HandleOnAdFailedToLoad_L_Ecpm;
        this.MediumBannerLowEcpm.OnAdFullScreenContentOpened += MediumBanner_HandleOnAdOpened_L_Ecpm;
        this.MediumBannerLowEcpm.OnAdFullScreenContentClosed += MediumBanner_HandleOnAdClosed_L_Ecpm;
        this.MediumBannerLowEcpm.OnAdPaid += MediumBannerLow_OnPaidEvent;
    }
    #endregion

    #region MediumBannerCallBack Handlers
    public void MediumBanner_HandleOnAdLoaded_L_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                mediumBannerStatus = AdsLoadingStatus.Loaded;
                isMediumBannerLoaded = true;
            }
        });
    }

    public void MediumBanner_HandleOnAdFailedToLoad_L_Ecpm(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                mediumBannerStatus = AdsLoadingStatus.NotLoaded;
                isMediumBannerLoaded = false;
            }
        });
    }
    public void MediumBanner_HandleOnAdOpened_L_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
            }
        });
    }
    public void MediumBanner_HandleOnAdClosed_L_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
            }
        });
    }
    #endregion

    #region RewardedVideoCodeBlock
    public override void LoadRewardedVideo()
    {
        if (!isAdmobInitialized || IsRewardedAdReady() || rAdStatus == AdsLoadingStatus.Loading)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (RewardVideo_High_Ecpm)
            {
                RewardVideo_Unity += LoadRewardedVideo;
                //BindRewardedEvents_H_Ecpm();
                //AdRequest request = new AdRequest.Builder().Build();
                //this.rewardBasedVideo.LoadAd(request);
                // Clean up the old ad before loading a new one.
                if (rewardBasedVideo != null)
                {
                    rewardBasedVideo.Destroy();
                    rewardBasedVideo = null;
                }

                Debug.Log("Loading the rewarded ad.");

                // create our request used to load the ad.
                var adRequest = new AdRequest();

                // send the request to load the ad.
                RewardedAd.Load(ADMOB_ID.RewardedVideo, adRequest,
                    (RewardedAd ad, LoadAdError error) =>
                    {
                        // if error is not null, the load request failed.
                        if (error != null || ad == null)
                        {
                            Debug.LogError("Rewarded ad failed to load an ad " + "with error : " + error);
                            return;
                        }

                        Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());
                        rewardBasedVideo = ad;

                        BindRewardedEvents_H_Ecpm();
                    });
                rAdStatus = AdsLoadingStatus.Loading;
            }
            else if (UnityRewarded)
            {
                //Advertisement.Load(ADMOB_ID.Unity_RewardedVideo);
            }
        }
    }
    public override bool IsRewardedAdReady()
    {
        // if (RewardVideo_High_Ecpm)
        {
            if (this.rewardBasedVideo != null)
                return this.rewardBasedVideo.CanShowAd();
            else
                return false;
        }

    }
    private bool giveReward;
    private void Update()
    {
        if (giveReward)
        {
            giveReward = false;
            Invoke("GiveRewardAftertime", .1f);
        }
    }
    void GiveRewardAftertime()
    {
        if (RewardAction != null)
        {
            Data_Ironbolt.RewardedAdWatched();
            AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded", "Complete", GlobalConstant.ad_placement_name_rwd);
        }
    }
    Action<Reward> RewardAction;
    public override void ShowRewardedVideo(Action<Reward> action, string _placement)
    {
        GlobalConstant.ad_placement_name_rwd = _placement;
        if (RewardVideo_High_Ecpm)
        {
            AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded", "Click", _placement);

            if (rewardBasedVideo.CanShowAd())
            {
                RewardAction = null;
                RewardAction = action;
                rewardBasedVideo.Show(HandleRewardBasedVideoRewarded_H_Ecpm);
                AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded", "Show", _placement);
                firebasecall1.Instance.Event("Admob_Rew_Show");
            }
            else
            {
                AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded", "Fail", _placement);
                firebasecall1.Instance.Event("Admob_Rew_Fail");
            }
        }
        else if (UnityRewarded)
        {
            //NotifyReward = _delegate;
            //Advertisement.Show(ADMOB_ID.Unity_RewardedVideo, this);
        }
    }

    private void BindRewardedEvents_H_Ecpm()
    {
        //rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded_H_Ecpm;
        rewardBasedVideo.OnAdFullScreenContentFailed += HandleRewardBasedVideoFailedToLoad_H_Ecpm;
        rewardBasedVideo.OnAdFullScreenContentOpened += HandleRewardBasedVideoOpened_H_Ecpm;
        rewardBasedVideo.OnAdFullScreenContentFailed += HandleRewardedAdFailedToShow_H_Ecpm;
        rewardBasedVideo.OnAdFullScreenContentClosed += HandleRewardBasedVideoClosed_H_Ecpm;
        rewardBasedVideo.OnAdPaid += Rewarded_OnPaidEvent;
    }

    #endregion

    #region RewardedVideoEvents
    //***** Rewarded Events *****//
    public void HandleRewardBasedVideoLoaded_H_Ecpm(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_Ecpm)
            {
                RewardVideo_Unity -= LoadRewardedVideo;
                rAdStatus = AdsLoadingStatus.Loaded;
                UnityRewarded = false;
            }
        });
    }
    public void HandleRewardBasedVideoFailedToLoad_H_Ecpm(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_Ecpm)
            {
                rAdStatus = AdsLoadingStatus.NoInventory;
                RewardVideo_High_Ecpm = false;
                UnityRewarded = true;
                if (RewardVideo_Unity != null)
                {
                    RewardVideo_Unity();
                }
            }
        });
    }
    public void HandleRewardedAdFailedToShow_H_Ecpm(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_Ecpm)
            {
                rAdStatus = AdsLoadingStatus.NotLoaded;
            }
        });
    }
    public void HandleRewardBasedVideoOpened_H_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_Ecpm)
            {
                RewardVideo_Unity -= LoadRewardedVideo;
                rAdStatus = AdsLoadingStatus.NotLoaded;
            }
        });
    }
    public void HandleRewardBasedVideoClosed_H_Ecpm()
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_Ecpm)
            {
                AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded", "Closed", GlobalConstant.ad_placement_name_rwd);

                if (AdsTimer.instance) AdsTimer.instance.ResetAdTime();
                GlobalContants.Ad_time = firebasecall1.interAdTime;

                RewardVideo_Unity -= LoadRewardedVideo;
                rAdStatus = AdsLoadingStatus.NotLoaded;
                LoadRewardedVideo();
            }
        });
    }
    public void HandleRewardBasedVideoRewarded_H_Ecpm(Reward args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_Ecpm)
            {
                giveReward = true;
                RewardVideo_Unity -= LoadRewardedVideo;
            }
        });
    }
    #endregion

    #region RewardedInterstial
    public override void LoadRewardedInterstitial()
    {
        if (!isAdmobInitialized || IsRewardedInterstitialAdReady() || riAdStatus == AdsLoadingStatus.Loading)
        {
            return;
        }

        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            {
                //AdRequest request = new AdRequest.Builder().Build();
                //RewardedInterstitialAd.LoadAd(ADMOB_ID.RewardedInt, request, adLoadCallbackHighECPM);
                if (rewardedInterstitialAd != null)
                {
                    rewardedInterstitialAd.Destroy();
                    rewardedInterstitialAd = null;
                }

                Debug.Log("Loading the rewarded interstitial ad.");

                // create our request used to load the ad.
                var adRequest = new AdRequest();
                adRequest.Keywords.Add("unity-admob-sample");

                // send the request to load the ad.
                RewardedInterstitialAd.Load(ADMOB_ID.RewardedInt, adRequest,
                    (RewardedInterstitialAd ad, LoadAdError error) =>
                    {
                        // if error is not null, the load request failed.
                        if (error != null || ad == null)
                        {
                            Debug.LogError("rewarded interstitial ad failed to load an ad " +
                                           "with error : " + error);
                            return;
                        }

                        Debug.Log("Rewarded interstitial ad loaded with response : "
                                  + ad.GetResponseInfo());

                        rewardedInterstitialAd = ad;
                        adLoadCallbackHighECPM(ad, error);
                    });

                riAdStatus = AdsLoadingStatus.Loading;
            }
        }

    }
    public override void ShowRewardedInterstitialAd(Action<Reward> action, string _placement)
    {
        {
            //NotifyReward = _delegate;
            //Admob_LogHelper.LogSender(AdmobEvents.ShowRewardedInterstitialAd_H_ECPM);
            GlobalConstant.ad_placement_name_rwd = _placement;
            AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded_Inter", "Click", _placement);

            if (this.rewardedInterstitialAd != null)
            {
                if (rewardedInterstitialHighECPMLoaded)
                {
                    RewardAction = null;
                    RewardAction = action;
                    this.rewardedInterstitialAd.Show(userEarnedRewardCallback);
                    AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded_Inter", "Show", _placement);
                    firebasecall1.Instance.Event("Admob_RewInter_Show");

                }
                else
                {
                    AnalyticsManager.instance.SendAdEvent("Admob", "Rewarded_Inter", "Fail", _placement);
                    firebasecall1.Instance.Event("Admob_RewInter_Fail");
                }
            }
        }
    }
    private void userEarnedRewardCallback(Reward reward)
    {
        giveReward = true;
    }
    public override bool IsRewardedInterstitialAdReady()
    {
        if (this.rewardedInterstitialAd != null)
        {
            if (rewardedInterstitialHighECPMLoaded)
            {
                return true;
            }
        }

        return false;
    }
    private void RewardedInterstitial_OnPaidEvent(AdValue impressionData)
    {
        revenue = (impressionData.Value / 1000000f);
        AnalyticsManager.instance.AdjustRevReport_Admob(revenue, AppmetricaAnalytics.AdFormat.RewardedInter, ADMOB_ID.RewardedInt);


    }
    private void adLoadCallbackHighECPM(RewardedInterstitialAd ad, LoadAdError error)
    {
        if (error == null)
        {
            rewardedInterstitialAd = ad;

            rewardedInterstitialAd.OnAdFullScreenContentFailed += RewardedInterstitialHandleAdFailedToPresentHighECPM;
            rewardedInterstitialAd.OnAdFullScreenContentClosed += RewardedInterstitialHandleAdDidDismissHighECPM;
            rewardedInterstitialAd.OnAdPaid += RewardedInterstitial_OnPaidEvent;
            rewardedInterstitialHighECPMLoaded = true;
        }
        else
        {
            // Handle the error.
            Debug.LogFormat("Failed to load the ad. (reason: {0})", error.GetMessage());
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {
                riAdStatus = AdsLoadingStatus.NoInventory;
                //Logging.Log("GR >> Admob:riad:NoInventory_H_Ecpm :: " + error.ToString());
                //Admob_LogHelper.LogSender(AdmobEvents.RewardedInterstitialNoInventory_H_ECPM);

            });
            return;
        }

    }


    #endregion

    #region RewardedInterstitialCallbackHandler

    ///////// Rewarded Interstitial High ECPM Callbacks //////////
    private void RewardedInterstitialHandleAdFailedToPresentHighECPM(object sender)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            {
                riAdStatus = AdsLoadingStatus.NotLoaded;
                //Logging.Log("GR >> Admob:riad:FailedToShow:HCPM");
            }
        });
    }
    private void RewardedInterstitialHandleAdDidPresentHighECPM(object sender, EventArgs args)
    {
        //Logging.Log("Rewarded interstitial ad has presented.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            {
                riAdStatus = AdsLoadingStatus.NotLoaded;
            }
        });
    }
    private void RewardedInterstitialHandleAdDidDismissHighECPM()
    {
        //Logging.Log("Rewarded interstitial ad has dismissed presentation.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            {
                rewardedInterstitialHighECPMLoaded = false;
                if (AdsTimer.instance) AdsTimer.instance.ResetAdTime();
                GlobalContants.Ad_time = firebasecall1.interAdTime;

                riAdStatus = AdsLoadingStatus.NotLoaded;

                //Admob_LogHelper.LogSender(AdmobEvents.RewardedInterstitialAdClosed_H_ECPM);
                //NotifyReward();
                LoadRewardedInterstitial();
                AnalyticsManager.instance.SendAdEvent("Admob", "RewardedInt", "Closed", GlobalConstant.ad_placement_name_rwdInt);
            }
        });
    }
    private void RewardedInterstitialHandlePaidEventHighECPM(object sender, AdValueEventArgs args)
    {
        MonoBehaviour.print("Rewarded interstitial ad has received a paid event.");

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            {
                //Logging.Log("GG >> give reward to user after watching riAd_H_Ecpm");
                //Admob_LogHelper.LogSender(AdmobEvents.RewardedInterstitialAdReward_H_ECPM);
            }
        });
    }

    #endregion

    #region UnityCallBack
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        if (adUnitId == ADMOB_ID.Unity_Interstitial_ID)
        {
            iAdStatus = AdsLoadingStatus.Loaded;
            UnityAds = true;
            Interstitial_HighEcpm = false;


        }
        else if (adUnitId == ADMOB_ID.Unity_RewardedVideo)
        {
            rAdStatus = AdsLoadingStatus.Loaded;
            RewardVideo_High_Ecpm = false;
            UnityRewarded = true;
        }
    }

    //public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    //{
    //    Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    //    if (adUnitId == ADMOB_ID.Unity_Interstitial_ID)
    //    {
    //        iAdStatus = AdsLoadingStatus.Loaded;
    //        UnityAds = true;
    //        Interstitial_HighEcpm = false;
    //    }
    //    else if (adUnitId == ADMOB_ID.Unity_RewardedVideo)
    //    {
    //        rAdStatus = AdsLoadingStatus.Loaded;
    //        RewardVideo_High_Ecpm = false;
    //        UnityRewarded = true;
    //        Debug.Log("Ad_Failed");
    //    }
    //    // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    //}

    //public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    //{
    //    Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    //    if (adUnitId == ADMOB_ID.Unity_Interstitial_ID)
    //    {
    //        iAdStatus = AdsLoadingStatus.Loaded;
    //        UnityAds = false;
    //        Interstitial_HighEcpm = true;


    //    }
    //    else if (adUnitId == ADMOB_ID.Unity_RewardedVideo)
    //    {
    //        rAdStatus = AdsLoadingStatus.Loaded;
    //        RewardVideo_High_Ecpm = true;

    //        UnityRewarded = false;

    //    }
    //    // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    //}

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    //public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    //{


    //    //  ADmobInterstial = true;
    //    if (adUnitId == ADMOB_ID.Unity_Interstitial_ID)
    //    {
    //        iAdStatus = AdsLoadingStatus.NotLoaded;
    //        Interstitial_HighEcpm = true;

    //        UnityAds = false;
    //        Debug.Log("Ad_completed");
    //    }
    //    else

    //    if (adUnitId.Equals(ADMOB_ID.Unity_RewardedVideo) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
    //    {
    //        Debug.Log("Unity Ads Rewarded Ad Completed");
    //        // Grant a reward.
    //        if (adUnitId == ADMOB_ID.Unity_RewardedVideo)
    //        {
    //            RewardVideo_High_Ecpm = true;

    //            UnityRewarded = false;
    //            NotifyReward();
    //            Debug.Log("Ad_completed");
    //        }
    //        // Load another ad:
    //        Advertisement.Load(ADMOB_ID.Unity_RewardedVideo, this);
    //    }



    //}

    #endregion
}
