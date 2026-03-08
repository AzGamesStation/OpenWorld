using UnityEngine;

public class Adscaller_GF : MonoBehaviour
{
    //In all modes except Parking : MAX Mediation Backed By Flooring Admob onEnable
    //In Parking Mode : All Ads from Admob
    public bool UseLoading;
    void OnEnable()
    {
        //if (StaticVariables.ModeID == 1)  // Parking Mode
        //{
        //    //Flooring Admob
        //    AdsMediatorManagerZR.instance.showInterstitial();
        //}
        //else
        //{
        //    //MAX Mediation Backed By Flooring Admob
        //    AdsMediatorManagerZR.instance.showInterstitial();
        //}
        ADsShower.ShowInterstital(UseLoading, "flooring");
    }
}