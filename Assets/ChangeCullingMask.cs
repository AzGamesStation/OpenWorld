using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCullingMask : MonoBehaviour
{

    public Light directionalLight;

    public void RemoveCharacterLayer()
    {
        directionalLight.cullingMask &= ~(1 << 15);
    }

    public void AddCharacterLayer()
    {
        directionalLight.cullingMask |= (1 << 15);
    }
}
