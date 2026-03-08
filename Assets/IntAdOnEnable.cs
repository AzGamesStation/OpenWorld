using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntAdOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        AdsManager.instance.ShowInterstitial("OnEnable");
    }
}
