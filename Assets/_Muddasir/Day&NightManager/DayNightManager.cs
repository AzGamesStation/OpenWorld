using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    private static DayNightManager instance;
    public static DayNightManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<DayNightManager>();
            }
            return instance;
        }
    }
    public enum DayStatus { Day = 0, Night = 1 };
    public DayStatus m_Daystatus;

    public Light DirLight;
    public Transform RefPoint;
    public float t;
    public float SunAngle = 50;
    public float SunAngle1 = 50;
    public float Daycount;
    public float secondsInDay = 60;
    private MaterialModifier m_MaterialModifier;
    private LightMapsManager m_LightMapsManager;

    [Header("Day")]
    public ParticleSystem clouds;
    public Color DayLightColor;
    public LayerMask DayLightMask;

    [Header("Night")]
    public ParticleSystem Stars;
    public Color NightLightColor;
    public LayerMask NightLightMask;

    [Header("DawnDusk")]
    public Color DawnDuskLightColor;
    public LayerMask DawnDuskLightMask;
    // Start is called before the first frame update
    private void Start()
    {
        m_MaterialModifier = GetComponent<MaterialModifier>();
        m_LightMapsManager = GetComponent<LightMapsManager>();
        SunAngle1 = SunAngle = 50;

        m_MaterialModifier.Toggle((int)m_Daystatus);
        //if (m_LightMapsManager)
        //    m_LightMapsManager.Switch((int)m_Daystatus);

        TimeOfDayCheck();
    }

   

    // Update is called once per frame
    private void Update()
    {
        
        t = Time.deltaTime * (360 / secondsInDay);
        SunAngle += t;
        SunAngle1 += t;
        if ((int)(SunAngle / 360) >= 1)
        {
            Daycount++;
            SunAngle = 0;
        }
        if (DirLight)
            DirLight.transform.RotateAround(RefPoint.transform.position, Vector3.right, t);

        if (SunAngle1 > 180)
        {
            SunAngle1 = 0;
            m_Daystatus++;
            if ((int)m_Daystatus > 1)
                m_Daystatus = 0;

            m_MaterialModifier.Toggle((int)m_Daystatus);
            
        }
        TimeOfDayCheck();
    }

    void TimeOfDayCheck()
    {
        if (SunAngle < 300 && SunAngle > 60)
        {
            // night
            //DirLight.cullingMask = NightLightMask;
            //DirLight.shadows = LightShadows.None;
            //DirLight.color = NightLightColor;

            //if (!Stars.isPlaying)
            //    Stars.Play(true);
            //if (clouds.isPlaying)
            //{
            //    clouds.Clear(true);
            //    clouds.Stop(true);
            //}

            if (m_LightMapsManager)
                m_LightMapsManager.Switch(1);
        }
        //else if ((SunAngle < 25 && SunAngle > 1) || (SunAngle > 140 && SunAngle < 157))
        //{
        //    // dawn // dusk
        //    DirLight.color = DawnDuskLightColor;
        //    //DirLight.cullingMask = DawnDuskLightMask;
        //    DirLight.shadows = LightShadows.None;

        //    if (m_LightMapsManager)
        //        m_LightMapsManager.Switch(2);

        //    if (!Stars.isPlaying)
        //        Stars.Play(true);
        //    if (clouds.isPlaying)
        //    {
        //        clouds.Clear(true);
        //        clouds.Stop(true);
        //    }
        //}
        else
        {
            // day
            if (Stars.isPlaying)
            {
                Stars.Clear(true);
                Stars.Stop(true);
            }
            if (!clouds.isPlaying)
                clouds.Play(true);

            //DirLight.color = DayLightColor;
            //DirLight.shadows = LightShadows.Soft;

            if (m_LightMapsManager)
                m_LightMapsManager.Switch(0);
        }
    }
}
