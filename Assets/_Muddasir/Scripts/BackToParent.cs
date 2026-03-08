using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToParent : MonoBehaviour
{
    public Transform parentTran;
    public void SetParent()
    {
        this.transform.parent = parentTran;
        this.transform.localPosition = Vector3.zero;
    }
}
