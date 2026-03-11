using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{

    public string gameURL;
    public string mode;

    public void CareerMode()
    {

    }

    public void OpenWorldMode(string mode)
    {
        GlobalContants.mode = mode;

    }

    public void CrossPromotion()
    {
        Application.OpenURL(gameURL);
    }
}