using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using System;
using Firebase.RemoteConfig;
using System.Threading.Tasks;

public class firebasecall1 : MonoBehaviour
{
    public static firebasecall1 Instance;
    public static bool interRemoteControl;
    public static bool bannerRemoteControl;
    public static bool rectBannerRemoteControl;
    public static bool rewardedRemoteControl;
    public static bool appOpenRemoteControl;
    public static bool max_banner;
    public static float AdPanel_timer;
    public static float interAdTime;

    public static string appOpenID = "";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        OnFireBase();
    }
    #region Firebase
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    public static bool firebaseInitialized = false;


    void OnFireBase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                    "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    void InitializeFirebase()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);


        // Set the user's sign up method.
        FirebaseAnalytics.SetUserProperty(FirebaseAnalytics.UserPropertySignUpMethod, "Google");

        firebaseInitialized = true;
        FirebaseApp app = FirebaseApp.DefaultInstance;

        System.Collections.Generic.Dictionary<string, object> defaults = new System.Collections.Generic.Dictionary<string, object>();
        defaults.Add("Ads_Status", false);
        defaults.Add("maxBanner", false);
        defaults.Add("adpanel_timer", 70);
        defaults.Add("interAdTime", 30);
        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults)
        .ContinueWithOnMainThread(task =>
        {
            FetchDataAsync();
        });
    }
    public void Event(string name)
    {
        if (firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent(name);
        }
    }

    public void Config_value()
    {
        interRemoteControl = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("interRemoteControl").BooleanValue;
        bannerRemoteControl = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("bannerRemoteControl").BooleanValue;
        rectBannerRemoteControl = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("rectBannerRemoteControl").BooleanValue;
        rewardedRemoteControl = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("rewardedRemoteControl").BooleanValue;
        appOpenRemoteControl = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("appOpenRemoteControl").BooleanValue;

        max_banner = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("maxBanner").BooleanValue;

        appOpenID = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("appOpenID").StringValue;
        AdPanel_timer = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("adpanel_timer").LongValue;
        interAdTime = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("interAdTime").LongValue;
        //Debug.Log("Firebase_Remote_Coinfig_Ads_Status ==: " + ads_Status);
    }

    public void FetchFireBase()
    {
        FetchDataAsync();
    }

    public Task FetchDataAsync()
    {
        //Debug.Log("Fetching data...");
        System.Threading.Tasks.Task fetchTask =
        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }

    private void FetchComplete(Task fetchTask)
    {
        if (fetchTask.IsCanceled)
        {
            Debug.Log("Fetch canceled.");
        }
        else if (fetchTask.IsFaulted)
        {
            Debug.Log("Fetch encountered an error.");
        }
        else if (fetchTask.IsCompleted)
        {
            Debug.Log("Fetch completed successfully!");
        }

        var info = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.Info;
        switch (info.LastFetchStatus)
        {
            case Firebase.RemoteConfig.LastFetchStatus.Success:

                Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync()
                .ContinueWithOnMainThread(task =>
                {
                    Debug.Log(String.Format("Remote data loaded and ready (last fetch time {0}).",
                                   info.FetchTime));
                    Config_value();
                });

                break;
            case Firebase.RemoteConfig.LastFetchStatus.Failure:
                switch (info.LastFetchFailureReason)
                {
                    case Firebase.RemoteConfig.FetchFailureReason.Error:
                        Debug.Log("Fetch failed for unknown reason");
                        break;
                    case Firebase.RemoteConfig.FetchFailureReason.Throttled:
                        Debug.Log("Fetch throttled until " + info.ThrottledEndTime);
                        break;
                }
                break;
            case Firebase.RemoteConfig.LastFetchStatus.Pending:
                Debug.Log("Latest Fetch call still pending.");
                break;
        }
    }


    public void Event(string name, string parameterName, string parameterValue)
    {
        if (firebaseInitialized)
        {
            FirebaseAnalytics.LogEvent(name, parameterName, parameterValue);

        }
    }
    #endregion
}
