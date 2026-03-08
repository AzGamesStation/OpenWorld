using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AppOpenAdLauncher : MonoBehaviour
{
    public static AppOpenAdLauncher instance;
    private AppOpenAdManager appOpenAdManager;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        appOpenAdManager = AppOpenAdManager.Instance;
    }

    private void Start()
    {
        LoadAppOpen();
    }

    private void LoadAppOpen()
    {
#if UNITY_EDITOR
        return;
#endif
        MobileAds.Initialize(initStatus => { appOpenAdManager.LoadAOA(); AppStateEventNotifier.AppStateChanged += OnAppStateChanged; });
    }
    private void OnAppStateChanged(AppState state)
    {
        // Display the app open ad when the app is foregrounded.
        Debug.Log("App State is " + state);
        if (state == AppState.Foreground)
        {
            appOpenAdManager.ShowAdIfAvailable();
        }
    }
}