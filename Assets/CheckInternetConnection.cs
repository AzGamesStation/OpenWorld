using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using GameAnalyticsSDK;

public class CheckInternetConnection : MonoBehaviour
{
    public static CheckInternetConnection Instance;
    public bool IsInternetConnected = false;
    public GameObject internetMsg;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        InvokeRepeating("CallForInternetCheck", 0.1f, 10f);
    }

    void CallForInternetCheck()
    {
        StartCoroutine(CheckInternet(isConnected =>
        {
            if (isConnected)
            {
                IsInternetConnected = true;
            }
            else
            {
                IsInternetConnected = false;
            }
        }));
    }

    IEnumerator CheckInternet(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }

    public void ToastMsg()
    {
        internetMsg.SetActive(true);
        Invoke("DeActiveText", 2f);
    }
    
    void DeActiveText()
    {
        internetMsg.SetActive(false);
    }
}
