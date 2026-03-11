using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToCameraPos : MonoBehaviour
{
    public Transform target;
    private void OnEnable()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
    //private void Update()
    //{
    //    transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    //}
}
