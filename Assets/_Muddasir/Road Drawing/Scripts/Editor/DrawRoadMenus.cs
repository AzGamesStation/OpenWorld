using UnityEditor;

public static class DrawRoadMenus
{
    [MenuItem("Tools/AbdulRafay/Road Point Links/Add Draw RoadPoint Component")]
    public static void AddDraw()
    {
        if (Selection.activeGameObject)
        {
            Selection.activeGameObject.AddComponent<DrawRoad>();
        }
    }
}