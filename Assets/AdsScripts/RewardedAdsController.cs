using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ToastPlugin;

public class RewardedAdsController : MonoBehaviour
{

    public static RewardedAdsController Instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowRewarded(string placement)
    {
        if (CheckInternetConnection.Instance.IsInternetConnected == true)
        {
            if (AdsManager.instance)
            {
                //AdsManager.instance.ShowRewardedAd(placement);
            }
        }
        else
            CheckInternetConnection.Instance.ToastMsg();

    }

}
