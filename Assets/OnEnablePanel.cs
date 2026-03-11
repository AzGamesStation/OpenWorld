using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class OnEnablePanel : MonoBehaviour
{
    private void OnEnable()
    {
        //AdsManager.instance.ShowInterstitial("OnComplete");
        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
        //firebasecall1.Instance.Event("Level No " + (PlayerPrefs.GetInt("LevelNumber") + 1) + " Completed");
        //GameAnalytics.NewDesignEvent("Level No " + (PlayerPrefs.GetInt("LevelNumber") + 1) + " Completed");
        AnalyticsManager.instance.ProgressionEvent(AnalyticsManager.eventType.LevelComplete, GlobalConstant.openWorldMode, (PlayerPrefs.GetInt("LevelNumber") + 1));
    }
}
