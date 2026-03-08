using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerRectCaller : MonoBehaviour
{
    private void OnEnable()
    {
        // AdsManager.instance.ShowMREC();
        ADsShower.ShowRectBanner();
    }

    private void OnDisable()
    {
        // AdsManager.instance.HideMREC();
        ADsShower.HideRectBanner();
    }
}
