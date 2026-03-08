using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{
    public GameObject[] pickUpObjects;
    public Transform[] pickUpPoints;
    int tempNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<pickUpPoints.Length;i++)
        {
            GameObject pickUps=Instantiate(pickUpObjects[tempNum], pickUpPoints[i].position, pickUpObjects[tempNum].transform.rotation) as GameObject;
            if(tempNum==2)
                pickUps.transform.parent = transform;
            tempNum++;
            if(tempNum>=pickUpObjects.Length)
            {
                tempNum = 0;
            }
        }
    }
}