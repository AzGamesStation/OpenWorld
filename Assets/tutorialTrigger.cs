using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTrigger : MonoBehaviour
{
    public tutorialScript tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="CheckPoint")
        {
            tutorial.OpenShop();
            other.gameObject.SetActive(false);
        }
    }
}