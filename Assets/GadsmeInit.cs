using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gadsme;

public class GadsmeInit : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        GadsmeSDK.SetMainCamera(mainCamera); // Register Main Camera
        GadsmeSDK.Init(); // Init Gadsme SDK
        GadsmeSDK.SetUserAge(21);
        GadsmeSDK.SetUserGender(Gender.MALE);
    }

    void OnGamePhaseChange(Camera newCamera)
    {
        GadsmeSDK.SetMainCamera(newCamera); // Update Main camera
    }
}
