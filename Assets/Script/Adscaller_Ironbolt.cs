using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System;

public class Adscaller_Ironbolt : MonoBehaviour
{
    [SerializeField] GameObject Loading;
    public bool isGamePlay = false;
    public GameObject[] panels;
    float tempTime = 0;
    int tempNum;
    private void OnEnable()
    {

        if (Time.time >= tempTime && isGamePlay == false)
        {
            tempTime = Time.time + 10;
            Loading.SetActive(true);
            StartCoroutine("Delay");
            //LeanTween.delayedCall(3, () =>
            //{
            //    Loading.SetActive(false);
            //    if (PlayerPrefs.GetInt("RemoveAds") == 0)
            //    {
            //        AdsManager.instance.ShowInterstitial();
            //    }
            //});
        }
        else if (isGamePlay)
        {
            tempNum = UnityEngine.Random.Range(0, 3);
            panels[tempNum].SetActive(true);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3f);
        Loading.SetActive(false);
        //AdsManager.instance.ShowInterstitial("FreeCoins");
    }

    public void ShowAd()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        this.gameObject.SetActive(false);
        //if (GlobalContants.Ad_time <= 0)
        //    AdsManager.instance.ShowInterstitial("FreeGems");
    }

    public void FreeCoins()
    {
        GlobalContants.cashPickUp = true;
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        this.gameObject.SetActive(false);
        RewardedAdsController.Instance.ShowRewarded("FreeCoins");
    }

    public void FreeGems()
    {
        GlobalContants.gemsPickUp = true;
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        this.gameObject.SetActive(false);
        RewardedAdsController.Instance.ShowRewarded("FreeGems");
    }
}