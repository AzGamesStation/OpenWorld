using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialInfo
{
    public Material mat;
    public Color col;
    public Texture2D tex;
    public bool active = false;
    [HideInInspector]
    public bool isBlackColor;
    [HideInInspector]
    public Color tempColor;
    [HideInInspector]
    public Color tempColorMain;
    public void Toggle(int state)
    {
        if (state == 0)
        {
            isBlackColor = true;
        }
        else
        {
            isBlackColor = false;
        }
    }
}
public class MaterialModifier : MonoBehaviour
{
    public MaterialInfo[] Mats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Color dayColor;
    public Color nightColor;
    public Color dayColorMain;
    public Color nightColorMain;
    public float duration = 5.0F;
    Color tempSkyColor;
    Color tempEmissionColor;
    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < Mats.Length; i++)
        {
            if (Mats[i].isBlackColor)
            {
                Mats[i].tempColorMain = Color.Lerp(Mats[i].tempColorMain, dayColorMain, 0.01f);
                Mats[i]. mat.SetColor("_Color", Mats[i].tempColorMain);
                Mats[i].tempColor = Color.Lerp(Mats[i].tempColor, Color.black, 0.01f);
                Mats[i]. mat.SetColor("_EmissionColor", Mats[i].tempColor);
                Mats[i].mat.SetTexture("_EmissionMap", Mats[i].tex);
                tempEmissionColor = Color.Lerp(tempEmissionColor, Color.black, 0.01f);
                RenderSettings.skybox.SetColor("_EmissionColor", tempEmissionColor);
                tempSkyColor = Color.Lerp(tempSkyColor, dayColor, 0.01f);
                RenderSettings.skybox.SetColor("_Tint", tempSkyColor);
                DayNightManager.Instance.DirLight.shadows = LightShadows.Soft;
                DayNightManager.Instance.DirLight.color = DayNightManager.Instance.DayLightColor;
            }
            else
            {
                Mats[i].tempColorMain = Color.Lerp(Mats[i].tempColorMain, nightColorMain, 0.01f);
                Mats[i].mat.SetColor("_Color", Mats[i].tempColorMain);
                Mats[i].tempColor = Color.Lerp(Mats[i].tempColor, Color.white, 0.01f);
                Mats[i].mat.SetColor("_EmissionColor", Mats[i].tempColor);
                Mats[i].mat.SetTexture("_EmissionMap", Mats[i].tex);
                tempEmissionColor = Color.Lerp(tempEmissionColor, Color.white, 0.01f);
                RenderSettings.skybox.SetColor("_EmissionColor", tempEmissionColor);
                tempSkyColor = Color.Lerp(tempSkyColor, nightColor, 0.01f);
                RenderSettings.skybox.SetColor("_Tint", tempSkyColor);
                DayNightManager.Instance.DirLight.shadows = LightShadows.None;
                DayNightManager.Instance.DirLight.color = DayNightManager.Instance.NightLightColor;

            }
        }
       
    }

    public void Toggle(int state)
    {
        for(int i = 0; i< Mats.Length;i++)
        {
            Mats[i].Toggle(state);
        }
    }
}
