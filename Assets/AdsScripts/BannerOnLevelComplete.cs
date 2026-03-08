using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerOnLevelComplete : MonoBehaviour
{
    private void OnEnable()
    {
        //  AdsManager.instance.HideBanner();
        //ADsShower.HideBanner();
    }

    private void OnDisable()
    {
        AdsManager.instance.ShowMaxBanner();//comment
    }
}
