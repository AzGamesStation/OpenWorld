using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAlphaControl : MonoBehaviour
{
    Material material;
    Color color;
    bool isFade;

    private void OnEnable()
    {
        material = this.gameObject.GetComponent<Renderer>().sharedMaterial;
        color = material.color;
        color.a = 0;
        material.color = color;
        isFade = false;
        CancelInvoke("Delay");
        Invoke("Delay", 3.0f);
    }
    private void Update()
    {
        if (!isFade)
        {
            color.a = Mathf.Lerp(color.a, 1, 10*Time.deltaTime);
            material.color = color;
        }
        else
        {
            //color.a = Mathf.Lerp(color.a, 0, 2* Time.deltaTime);
            //material.color = color;
        }
    }
    void Delay()
    {
        isFade = true;
    }

}
