using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRewardPanel : MonoBehaviour
{
    public GameObject dropBox;

    public void FreeCoins()
    {
        Time.timeScale = 1;
        GlobalContants.cashPickUp = true;
        RewardedAdsController.Instance.ShowRewarded("FreeCoins");
        this.gameObject.SetActive(false);
    }

    public void FreeGems()
    {
        Time.timeScale = 1;
        GlobalContants.gemsPickUp = true;
        RewardedAdsController.Instance.ShowRewarded("FreeGems");
        this.gameObject.SetActive(false);
    }

    public void ShowAd()
    {
        Time.timeScale = 1;
        dropBox.SetActive(false);
        // AdsManager.instance.ShowInterstitial();
        ADsShower.ShowInterstital(false, "FreeCoins");
        this.gameObject.SetActive(false);
    }
}
