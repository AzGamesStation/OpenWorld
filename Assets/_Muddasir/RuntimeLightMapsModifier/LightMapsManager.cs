
using UnityEngine;

public enum LightingModes {Day = 0,Night=1,DawnDusk = 2}
[System.Serializable]
public class LightMapInfo
{
    public Texture2D[] Dir;
    public Texture2D[] Light;
    bool isInitialized = false;
    LightmapData[] data;

    public LightmapData[] GetLightmapData()
    {
        if(!isInitialized)
        {
            data = new LightmapData[Light.Length];
            for(int i = 0;i< data.Length;i++)
            {
                data[i] = new LightmapData();
                if (i<Light.Length && Light[i])
                {
                    data[i].lightmapColor = Light[i];
                }
                if (i<Dir.Length && Dir[i])
                {
                    data[i].lightmapDir = Dir[i];
                }
            }
            isInitialized = true;
        }
        return data;
    }
}

public class LightMapsManager : MonoBehaviour
{
    [SerializeField]
    public static LightingModes LightingMode = 0;

    public LightMapInfo[] Infos;
    LightmapData[] data;

    // Start is called before the first frame update
    private void Start()
    {

    }
    public void Switch()
    {
        OnEnable_();
    }
    public void Switch(int index)
    {
        if (index >= Infos.Length)
            return;

        LightmapSettings.lightmaps = Infos[index].GetLightmapData();
    }

    private void OnEnable_()
    {
        LightingMode++;
        if((int)LightingMode >= Infos.Length)
        {
            LightingMode = 0;
        }

        Switch((int)LightingMode);
    }
}
