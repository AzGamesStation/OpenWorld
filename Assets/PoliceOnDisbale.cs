using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOnDisbale : MonoBehaviour
{
    public tutorialScript tutorial;
    public bool isWebThrow, isBalloonThrow, isBubbleThrow, isCarSpawn, isGetInCar;
   

    private void OnDisable()
    {
        if (isWebThrow)
            tutorial.WebThrow();
        if (isBalloonThrow)
            tutorial.BalloonThrow();
        if (isBubbleThrow)
            tutorial.BubbleThrow();
        if (isCarSpawn)
        {
            print("222");
            tutorial.SpawnCar();
        }
            
        if (isGetInCar)
            isGetInCar = false;
    }

    private void OnEnable()
    {
        if (isGetInCar)
            tutorial.SitInCar();
        //if (!isGetInCar)
        //    this.gameObject.SetActive(false);
    }
}
