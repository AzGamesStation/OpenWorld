using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speedX, speedY, speedZ;
    public PlaneDropManager dropManager;
    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="boundary")
        {
            dropManager.SetPlanePosition();
        }
    }
}