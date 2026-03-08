using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInternetPing_Ironbolt : MonoBehaviour {

    public static CheckInternetPing_Ironbolt _instance;
    public float timeOut=1f;
    float tempTime;
    bool busy = false;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void CheckInternetConnection(Action<bool,Ping> action)
    {
        //ToastMessage.Instance.MyShowToastMethod("Ping busy ."+busy);
        if (!busy)
        {
            busy = true;
            CheckPing("8.8.8.8", action);
        }
      
    }

    void CheckPing(string ip, Action<bool, Ping> action)
    {
        StartCoroutine(StartPing(ip,action));
    }

    IEnumerator StartPing(string ip, Action<bool, Ping> action)
    {
        WaitForEndOfFrame f = new WaitForEndOfFrame();
        Ping p = new Ping(ip);
        while (p.isDone == false && tempTime<timeOut)
        {
            tempTime += Time.deltaTime;
            yield return f;
        }
        //ToastMessage.Instance.MyShowToastMethod("Ping Finish."+" p : "+p.time);
        PingFinished(p,action);
    }


    void PingFinished(Ping p, Action<bool, Ping> action)
    {
        busy = false;
        //ToastMessage.Instance.MyShowToastMethod("Ping is : " +p.time);
        if (tempTime < timeOut)
        {
            tempTime = 0;
            if (p.time < 120)
            {
                action(true, p);
            }
            else
            {
                action(false, p);
            }
        }
        else
        {
            tempTime = 0;
            action(false, p);
        }
        
    }
}
