using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawnRoad))]
public class DrawnRoadEditor : Editor
{
    DrawnRoad prop;

    private void OnSceneGUI()
    {
        if(prop.m_DrawPoint)
        {
            prop.m_DrawPoint.RefreshDirection();
        }
    }
    public override void OnInspectorGUI()
    {
        prop = (DrawnRoad)target;
    }
}
