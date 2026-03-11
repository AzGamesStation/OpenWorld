using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using UnitySampleAssets.CrossPlatformInput;

public class RefillStamina : MonoBehaviour
{
    public ButtonHandler sprintBtn;
    //public GameObject popUpAd;

    private void OnEnable()
    {
        //if(popUpAd.activeInHierarchy==true)
        //{
        //    popUpAd.SetActive(false);
        //}
    }
    public void RefilStamina()
    {
        RewardedAdsController.Instance.ShowRewarded("RefillStamina");
        sprintBtn.SetUpState("Sprint");
        GlobalContants.refillStamina = true;
        UIGame.Instance.staminaPanel.SetActive(false);
    }
    public void ShowIntAD()
    {
        sprintBtn.SetUpState("Sprint");
        //if (GlobalContants.Ad_time <= 0)
        //    AdsManager.instance.ShowInterstitial("RefilStamina");
        UIGame.Instance.staminaPanel.SetActive(false);
    }
}