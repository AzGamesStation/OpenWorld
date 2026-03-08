using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAds : MonoBehaviour
{
    public Handler handler;

    public static Handler.AfterLoading Notify;

    //public bool MediumBanner;
    //public bool SmallBanner;
    private void OnEnable()
    {
      
        Invoke(nameof(ShowInt), 1.5f);

    }

    void ShowInt()
    {

        handler.ShowInterstitialAd("loading");
      
        {
            Invoke(nameof(ShowNextScreen), .1f);
        }

    }

    

    void ShowNextScreen()
    {
      
       
        {
            Invoke(nameof(DisableLoading), .1f);
        }

        if (Notify != null)
        {
        Notify();

        }
    }
    void DisableLoading()
    {
        this.gameObject.SetActive(false);
    }
}
