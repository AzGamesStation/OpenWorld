using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPickUpAd : MonoBehaviour
{
    public Text description;
    public Text countDownText;
    public bool isCash, isDiamond, isWings;
    int count = 5;

    private void OnEnable()
    {
        if (isDiamond == true)
            description.text = "Watch a Video AD to get <color=yellow>50 DIAMONDS</color>";
        else if (isCash == true)
            description.text = "Watch a Video AD to get <color=yellow>500 CASH</color>";
        else if (isWings == true)
            description.text = "Watch a Video AD to get <color=yellow>Hovering Wings</color>";
        count = 5;
        //StartCoroutine("CountDownToRewardedAD");
    }

    IEnumerator CountDownToRewardedAD()
    {
        countDownText.text = "Showing Ad in " + count;
        yield return new WaitForSeconds(1f);
        if (count > 0)
        {
            count -= 1;
            StartCoroutine("CountDownToRewardedAD");
        }

        else
        {
            if (RewardedAdsController.Instance)
                RewardedAdsController.Instance.ShowRewarded("PickUpAd");
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            StopCoroutine("CountDownToRewardedAD");
        }

    }

    public void ShowRewardAd()
    {
        Time.timeScale = 1;
        if (RewardedAdsController.Instance)
            RewardedAdsController.Instance.ShowRewarded("PickUpAd");

    }

    public void ShowAd()
    {
        //if (GlobalContants.Ad_time <= 0)
        //    AdsManager.instance.ShowInterstitial("PickUpAd");
        //ADsShower.ShowInterstital(false);
        Time.timeScale = 1;
        GlobalContants.cashPickUp = false;
        GlobalContants.gemsPickUp = false;
        GlobalContants.wingsPickUp = false;
        this.gameObject.SetActive(false);
    }
}
