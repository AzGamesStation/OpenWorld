using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollWingsHelper : MonoBehaviour
{
    Vector3 IniPos = Vector3.zero;
    Quaternion IniRot = Quaternion.identity;
    private void Start()
    {
        IniPos = transform.localPosition;
        IniRot = transform.localRotation;
    }
    void LateUpdate()
    {
        transform.localPosition = IniPos;
        transform.localRotation = IniRot;
    }
}
