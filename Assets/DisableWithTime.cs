using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWithTime : MonoBehaviour
{
    public float time;


    private void OnEnable()
    {
        Invoke("Delay", time);
    }

    void Delay()
    {
        this.gameObject.SetActive(false);
    }
}
