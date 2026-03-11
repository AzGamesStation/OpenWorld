using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class OnPlayerDeath : MonoBehaviour
{
    private void OnEnable()
    {
        //firebasecall1.Instance.Event("Player_Respawned_After_Death");
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Player_Respawned_After_Death");
        AnalyticsManager.instance.ProgressionEvent(AnalyticsManager.eventType.LevelFail, GlobalConstant.openWorldMode, MApplication.CurrentLevel);

        Debug.Log("Firebase death event called");
    }
}