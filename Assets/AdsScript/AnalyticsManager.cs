using com.adjust.sdk;
using Firebase.Analytics;
using GameAnalyticsSDK;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    //public string[] Adjust_LevelCompleteTokens;
    //public string Adjust_adrevenue_key;
   
    public enum eventType
    {
        LevelStart = 1,
        LevelComplete = 2,
        LevelFail = 3,
        LevelRestart = 4,
        LevelTie = 5,
        LevelCenter = 6,
        FinishLine = 7

    }
    public static AnalyticsManager instance;
    private void Awake()
    {
        instance = this;
        GameAnalytics.Initialize();
        DontDestroyOnLoad(gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    #region Events

    string _eventType = "";
    public void ProgressionEvent(eventType eventId, string modeName, int _levelNumber)
    {
        if (eventId == eventType.LevelStart)
            _eventType = "GD_LVL_Start_";
        else if (eventId == eventType.LevelComplete)
            _eventType = "GD_LVL_Complete_";
        else if (eventId == eventType.LevelFail)
            _eventType = "GD_LVL_Fail_";
        else if (eventId == eventType.LevelRestart)
            _eventType = "GD_LVL_Restart_";
        else if (eventId == eventType.LevelTie)
            _eventType = "GD_LVL_Tie_";
        else if (eventId == eventType.LevelCenter)
            _eventType = "GD_LVL_Center_";
        else if (eventId == eventType.LevelCenter)
            _eventType = "GD_LVL_FinishLine_";
        FB_ProgressionEvent(_eventType, _levelNumber);
        GA_ProgressionEvent((int)eventId, _eventType, _levelNumber);
        //ProgressionEventAppMetrica(eventId, _levelNumber);
        ProgressionEventAppMetrica_withMode(eventId, modeName, _levelNumber);
    }

    public void CustomScreenEvent(string placement)
    {
        FB_CustomScreenEvent(placement);
        GA_CustomScreenEvent(placement);
    }
    public void CustomBtnEvent(string placement)
    {
        FB_CustomBtnEvent(placement);
        GA_CustomBtnEvent(placement);
    }
    public void CustomOtherEvent(string placement)
    {
        FB_CustomOtherEvent(placement);
        GA_CustomOtherEvent(placement);

    }
    public void IAPEvent(string sku)
    {
        FB_IAPEvent(sku);
        GA_IAPEvent(sku);
    }
    public void SendAdEvent(string sdkName, string AdType, string Adaction, string placement)
    {
        //AppmetricaAnalytics.ReportCustomEvent(AnalyticsType.AdsData, sdkName, AdType, Adaction, placement);
        AppmetricaAnalytics.ReportCustomEvent(AnalyticsType.AdsData, sdkName, AdType, placement, Adaction);

        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent(sdkName + $"_{AdType}" + $"_{Adaction}" + $"_{placement}");
            ShowLogs(sdkName + $"_{AdType}" + $"_{Adaction}" + $"_{placement}"); ;
        }
        GameAnalytics.NewDesignEvent(sdkName + $"_{AdType}" + $"_{Adaction}" + $"_{placement}");
    }
    #endregion

    #region AppmetricaEvents
    void ProgressionEventAppMetrica(eventType eventId, int _levelNumber)
    {
        if (eventId == eventType.LevelStart)
            _eventType = "Start";
        else if (eventId == eventType.LevelComplete)
            _eventType = "Complete";
        else if (eventId == eventType.LevelFail)
            _eventType = "Fail";
        else if (eventId == eventType.LevelRestart)
            _eventType = "Restart";
        else if (eventId == eventType.LevelTie)
            _eventType = "Tie";
        else if (eventId == eventType.LevelCenter)
            _eventType = "Center";
        else if (eventId == eventType.FinishLine)
            _eventType = "FinishLine";

        AppmetricaAnalytics.ReportCustomEvent(AnalyticsType.GameData, $"Level_{_levelNumber}", _eventType);
    }
    void ProgressionEventAppMetrica_withMode(eventType eventId, string modeName, int _levelNumber)
    {
        if (eventId == eventType.LevelStart)
            _eventType = "Start";
        else if (eventId == eventType.LevelComplete)
            _eventType = "Complete";
        else if (eventId == eventType.LevelFail)
            _eventType = "Fail";
        else if (eventId == eventType.LevelRestart)
            _eventType = "Restart";
        else if (eventId == eventType.LevelTie)
            _eventType = "Tie";
        else if (eventId == eventType.LevelCenter)
            _eventType = "Center";
        else if (eventId == eventType.FinishLine)
            _eventType = "FinishLine";
        AppmetricaAnalytics.ReportCustomEvent(AnalyticsType.GameData, modeName, $"Level_{_levelNumber}", _eventType);
    }

    public void ExtraEvent()
    {
        AppmetricaAnalytics.ReportCustomEvent(AnalyticsType.Extras, "DeviceInfo", "ProcessorCount", SystemInfo.processorCount.ToString());
    }
    #endregion

    #region firebaseEvents

    public void FB_ProgressionEvent(string msg, int LevelNumber)
    {
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent(msg + LevelNumber);
            ShowLogs(msg + LevelNumber);
        }
    }

    public void FB_InterstitialEvent(string placement)
    {
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent("ADS_INTER_" + placement);
            // ShowLogs("FB_ADS_INTER_" + placement);
        }
    }
    public void FB_CustomScreenEvent(string placement)
    {
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent("GD_SCREEN_" + placement);
            //ShowLogs("FB_GD_SCREEN_" + placement);
        }
    }
    public void FB_CustomBtnEvent(string placement)
    {
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent("GD_BTN_" + placement);
            //ShowLogs("FB_GD_BTN_" + placement);
        }
    }
    public void FB_CustomOtherEvent(string placement)
    {
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent("GD_Other_" + placement);
            ShowLogs("GD_Other_" + placement);
        }
    }
    public void FB_IAPEvent(string sku)
    {
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent("IAP_" + sku);
            //ShowLogs("FB_IAP_" + sku);
        }
    }
    #endregion

    void ShowLogs(string str)
    {
        //print(str);
    }
    public static void SentDesignEvent(string eventname, string placement)
    {
        GameAnalytics.NewDesignEvent(eventname + placement);
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent(eventname + placement);
        }
    }
    public static void SentDesignEvent(string name, int levelNum)
    {
        GameAnalytics.NewDesignEvent(name + levelNum);
        if (firebasecall1.firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent(name + levelNum);
        }
    }

    #region GameAnalyticsEvent
    public void GA_ProgressionEvent(int Id, string msg, int LevelNumber)
    {
        GameAnalytics.NewDesignEvent(msg + LevelNumber);//GD_LVL_Start_1
        GameAnalytics.NewProgressionEvent((GAProgressionStatus)Id, msg + LevelNumber.ToString());
    }
    public void GA_CustomScreenEvent(string placement)
    {
        GameAnalytics.NewDesignEvent("GD_SCREEN_" + placement);
        //ShowLogs("GA_GD_SCREEN_" + placement);
    }
    public void GA_CustomBtnEvent(string placement)
    {
        GameAnalytics.NewDesignEvent("GD_BTN_" + placement);
        // ShowLogs("GA_GD_BTN_" + placement);
    }

    public void GA_InterstitialEvent(string placement)
    {
        GameAnalytics.NewDesignEvent("ADS_INTER_" + placement);
        // ShowLogs("GA_ADS_INTER_" + placement);
    }
    public void GA_CustomOtherEvent(string placement)
    {
        GameAnalytics.NewDesignEvent("GD_Other_" + placement);
        ShowLogs("GD_Other_" + placement);
    }
    public void GA_IAPEvent(string sku)
    {
        GameAnalytics.NewDesignEvent("IAP_" + sku);
        //ShowLogs("GA_IAP_" + sku);
    }
    #endregion

    #region 

    public void AdjustRevReport_Max(string adUnitId, MaxSdkBase.AdInfo impressionData)
    {
        double revenue = impressionData.Revenue;
        AdjustAdRevenue adjustAdRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adjustAdRevenue.setRevenue(revenue, "USD");
        adjustAdRevenue.setAdRevenueNetwork(impressionData.NetworkName);
        adjustAdRevenue.setAdRevenueUnit($"{impressionData.AdFormat}_{impressionData.AdUnitIdentifier}");
        Adjust.trackAdRevenue(adjustAdRevenue);

        AppmetricaAnalytics.AdFormat _adFormat = AppmetricaAnalytics.AdFormat.None;

        string maxAdFormat = impressionData.AdFormat.ToString();
        if (maxAdFormat != null)
        {
            if (maxAdFormat.Equals("BANNER"))
            {
                _adFormat = AppmetricaAnalytics.AdFormat.Banner;
            }
            else if (maxAdFormat.Equals("INTER"))
            {
                _adFormat = AppmetricaAnalytics.AdFormat.Interstitial;
            }
            else if (maxAdFormat.Equals("REWARDED"))
            {
                _adFormat = AppmetricaAnalytics.AdFormat.Rewarded;
            }
            else if (maxAdFormat.Equals("APPOPEN"))
            {
                _adFormat = AppmetricaAnalytics.AdFormat.AppOpen;
            }
        }
        AppmetricaAnalytics.ReportRevenue_Applovin(impressionData, _adFormat);

        if (firebasecall1.firebaseInitialized)
        {
            var impressionParameters = new[] {
          new Firebase.Analytics.Parameter("ad_platform", "AppLovin"),
          new Firebase.Analytics.Parameter("ad_source", impressionData.NetworkName),
          new Firebase.Analytics.Parameter("ad_unit_name", impressionData.AdUnitIdentifier),
          new Firebase.Analytics.Parameter("ad_format", impressionData.AdFormat),
          new Firebase.Analytics.Parameter("value", revenue),
          new Firebase.Analytics.Parameter("currency", "USD"),
        };
            if (impressionData.NetworkName == "AdMob" ||
                impressionData.NetworkName == "Google Ad Manager Native" ||
                impressionData.NetworkName == "Google AdMob")
            {
                return;
            }
            else
            {
                Firebase.Analytics.FirebaseAnalytics.LogEvent("ad_impression", impressionParameters);

                if (impressionData.AdFormat.Equals("INTER"))
                    Firebase.Analytics.FirebaseAnalytics.LogEvent("paid_int_" + GlobalConstant.ad_placement_name_inter, impressionParameters);
                if (impressionData.AdFormat.Equals("REWARDED"))
                    Firebase.Analytics.FirebaseAnalytics.LogEvent("paid_Rwd_" + GlobalConstant.ad_placement_name_rwd, impressionParameters);
            }
        }
    }
    public void AdjustRevReport_Admob(double _rev, AppmetricaAnalytics.AdFormat ad_formate, string ad_unitId)
    {
        AdjustAdRevenue adjustAdRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAdMob);
        adjustAdRevenue.setRevenue(_rev, "USD");
        Adjust.trackAdRevenue(adjustAdRevenue);
        AppmetricaAnalytics.ReportRevenue_Admob(_rev, ad_formate, ad_unitId);
    }

    //void AdjustFacebookAdRevenueEvent(double _rev)
    //{
    //    AdjustEvent adjust_adrevenue_Event = new AdjustEvent(Adjust_adrevenue_key);//ad_Revenue Event
    //    adjust_adrevenue_Event.addCallbackParameter("ad_revenue", _rev.ToString());
    //    //adjust_adrevenue_Event.addCallbackParameter("value_to_sum", _rev.ToString());
    //    Adjust.trackEvent(adjust_adrevenue_Event);
    //}

    //public void AdjustFacebook_CompleteEvent(int level_num)
    //{
    //    if (level_num < Adjust_LevelCompleteTokens.Length)
    //    {
    //        AdjustEvent adjustEvent = new AdjustEvent(Adjust_LevelCompleteTokens[level_num-1]);
    //        Adjust.trackEvent(adjustEvent);
    //    }
    //}
    #endregion
}
