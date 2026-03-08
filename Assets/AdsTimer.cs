using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class AdsTimer : MonoBehaviour
{
    public float Ad_delay;
    public ButtonHandler sprintBtn;
    public GameObject adsCaller;
    public GameObject rateUs;
    public float rateUsDelay;
    public static AdsTimer instance;
    bool isAdCalled = true;
    private void Start()
    {
        instance = this;
        Ad_delay = firebasecall1.AdPanel_timer;

        if (rateUs && PlayerPrefs.GetInt("RateUs") == 0)
            InvokeRepeating(nameof(RateUs), rateUsDelay, rateUsDelay);
    }
    private void Update()
    {
        if (isAdCalled)
        {
            if (Ad_delay <= 0)
            {
                CallAd();
            }
            else
                Ad_delay -= Time.deltaTime * 1;
        }
    }
    public void ResetAdTime()
    {
        isAdCalled = true;
        Ad_delay = firebasecall1.AdPanel_timer;
    }
    void CallAd()
    {
        isAdCalled = false;
        adsCaller.SetActive(true);
        sprintBtn.SetUpState("Sprint");
    }
    void RateUs()
    {
        if (rateUs && PlayerPrefs.GetInt("RateUs") == 0)
        {
            rateUs.SetActive(true);
        }
    }
}