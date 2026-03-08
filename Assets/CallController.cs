using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CallController : MonoBehaviour
{
    public static CallController instance;
    [HideInInspector]
    public bool isCallerLevelGet;
    [SerializeField] float delay;
    [SerializeField] GameObject CallerPanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void ActiveCallerPanel()
    {
        CallerPanel.SetActive(true);
    }


    public void ActiveNextCall()
    {
        isCallerLevelGet = false;
        Invoke("ActiveCallerPanel", delay);
    }

    public void RejectCall()
    {
        CallerPanel.SetActive(false);
        ActiveNextCall();
    }




}
