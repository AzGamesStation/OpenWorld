using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEngine.Networking;
//using GameAnalyticsSDK;

public class PrivacyPolicy : MonoBehaviour
{
    [SerializeField] GameObject ppPanel;
    [SerializeField] GameObject switchScene;

    private void Awake()
    {
        PlayerPrefs.SetInt("Spins", PlayerPrefs.GetInt("Spins") + 1);
        if (PlayerPrefs.GetString("PPAccepted", "No") == "No")
        {
            ppPanel.SetActive(true);
            switchScene.SetActive(false);

        }
        else
        {
            ppPanel.SetActive(false);
            switchScene.SetActive(true);
        }
        //StartCoroutine(CheckInternetConnection(isConnected =>
        //{
        //    if (isConnected)
        //    {
        //        Debug.Log("Internet Available!");
        //        firebasecall.Instance.Event("Internet_Available");
        //        GameAnalytics.NewDesignEvent("Internet Available"); 
              
        //    }
        //    else
        //    {
        //        firebasecall.Instance.Event("Internet_NotAvailable");
        //        GameAnalytics.NewDesignEvent("Internet Not Available");
        //        Debug.Log("Internet Not Available");
        //    }
        //}));
    }

    public void PrivacyPolicyAccepted()
    {
        ppPanel.SetActive(false);
        PlayerPrefs.SetString("PPAccepted", "Yes");
    }

    public void PP()
    {
        Application.OpenURL("https://gametown105.blogspot.com/p/privacy-policy.html");
    }

    //IEnumerator CheckInternetConnection(Action<bool> action)
    //{
    //    UnityWebRequest request = new UnityWebRequest("http://google.com");
    //    yield return request.SendWebRequest();
    //    if (request.error != null)
    //    {
    //        Debug.Log("Error");
    //        action(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Success");
    //        action(true);
    //    }
    //}
}
