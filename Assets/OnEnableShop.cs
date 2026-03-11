using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableShop : MonoBehaviour
{
    public GameObject HUDCanvas;

    private void OnEnable()
    {
        if(HUDCanvas)
        HUDCanvas.SetActive(false);
        //AdsManager.instance.ShowInterstitial("OnEnableShop");
        //ADsShower.HideBanner();
        ADsShower.HideRectBanner();
    }

    private void OnDisable()
    {
        if(HUDCanvas)
        HUDCanvas.SetActive(true);
    }
}