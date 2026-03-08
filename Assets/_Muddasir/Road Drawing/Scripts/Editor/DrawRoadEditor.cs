using Game.Traffic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(DrawRoad))]
public class DrawRoadEditor : Editor
{
    private bool Add = false;
    private bool Remove = false;
    private bool Connect = false;
    private bool Select = false;
    private bool AddRoadLinks = false;
    private bool RemoveRoadLinks = false;


    public GameObject SelectedRoadPointTOAddLinks;

    private DrawRoad prop;
    private Vector2 scrollPos;
    private SerializedProperty _path;

    private void OnSceneGUI()
    {
        Event e = Event.current;
        if (Add)
        {
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject go;

                    if (prop.RoadPoint)
                    {
                        go = Instantiate(prop.RoadPoint);
                    }
                    else
                    {
                        go = new GameObject();
                    }

                    go.AddComponent<DrawnRoad>();
                    go.GetComponent<DrawnRoad>().m_DrawPoint = prop;
                    go.name = go.name + "(" + (prop.Points.Count + 1) + ")";
                    go.transform.SetParent(prop.gameObject.transform);

                    
                    go.transform.position = hit.point + (hit.normal.normalized * 0.15f);
                    go.transform.rotation = Quaternion.FromToRotation(go.transform.up, hit.normal) * go.transform.rotation;

                    if (prop.Points.Count > 0)
                    {
                        AddLinkto(prop.Points[prop.Points.Count - 1].gameObject, go);
                        AddLinkto(go, prop.Points[prop.Points.Count - 1].gameObject);
                    }

                    prop.Points.Add(go);

                    RefreshName();
                }
                e.Use();
            }
            Selection.activeTransform = prop.gameObject.transform;
        }
        else if (Remove)
        {
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (prop.Points.Contains(hit.transform.gameObject))
                    {
                        prop.Points.Remove(hit.transform.gameObject);
                        DestroyImmediate(hit.transform.gameObject);
                    }
                    else if (hit.collider.GetComponentInParent<DrawnRoad>())
                    {
                        prop.Points.Remove(hit.collider.GetComponentInParent<DrawnRoad>().transform.gameObject);
                        DestroyImmediate(hit.collider.GetComponentInParent<DrawnRoad>().transform.gameObject);
                    }

                    RefreshName();
                }
                e.Use();
            }
            Selection.activeTransform = prop.gameObject.transform;
        }
        else if (Connect)
        {
            if (Select)
            {
                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (prop.Points.Contains(hit.transform.gameObject))
                        {
                            SelectedRoadPointTOAddLinks = hit.transform.gameObject;
                        }
                    }
                }
                Selection.activeTransform = prop.gameObject.transform;
                EditorUtility.SetDirty(prop);
            }
            else if (AddRoadLinks)
            {
                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (prop.Points.Contains(hit.transform.gameObject))
                        {
                            AddLinktoSelectedPoint(hit.transform.gameObject);
                            EditorUtility.SetDirty(prop);
                        }
                    }
                }
                Selection.activeTransform = prop.gameObject.transform;
            }
            else if (RemoveRoadLinks)
            {
                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (prop.Points.Contains(hit.transform.gameObject))
                        {
                            RemoveLinkFromSelectedPoint(hit.transform.gameObject);
                            EditorUtility.SetDirty(prop);
                        }
                    }
                }
                Selection.activeTransform = prop.gameObject.transform;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        prop = (DrawRoad)target;

        EditorGUILayout.LabelField("Road Drawing Editor", EditorStyles.centeredGreyMiniLabel);

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

        Add = GUILayout.Toggle(Add, "Add", EditorStyles.miniButton);
        if (Add)
        {
            prop.RoadPoint = (GameObject)EditorGUILayout.ObjectField("Road point", prop.RoadPoint, typeof(GameObject), false);

            Remove = false;
        }
        EditorGUILayout.Space();

        Remove = GUILayout.Toggle(Remove, "Remove", EditorStyles.miniButton);
        if (Remove)
        {
            Add = false;
        }

        EditorGUILayout.Space();
        if (GUILayout.Button("Clear"))
        {
            for (int i = 0; i < prop.Points.Count; i++)
            {
                DestroyImmediate(prop.Points[i]);
            }
            prop.Points.Clear();
        }

        EditorGUILayout.Space();

        Connect = GUILayout.Toggle(Connect, "Connect", EditorStyles.miniButton);
        if (Connect)
        {
            Add = false;
            Remove = false;

            EditorGUILayout.Space();

            Select = GUILayout.Toggle(Select, "Select Road Point", EditorStyles.miniButton);
            if (Select)
            {
                AddRoadLinks = false;
                RemoveRoadLinks = false;
            }

            EditorGUILayout.Space();

            SelectedRoadPointTOAddLinks = (GameObject)EditorGUILayout.ObjectField("Selected Road Point", SelectedRoadPointTOAddLinks, typeof(GameObject), false);

            if (SelectedRoadPointTOAddLinks != null)
            {
                for (int i = 0; i < SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks.Length; i++)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.ObjectField("link Point " + i.ToString(), SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks[i], typeof(GameObject), false);
                }
                EditorGUILayout.Space();

                AddRoadLinks = GUILayout.Toggle(AddRoadLinks, "Add Road Links", EditorStyles.miniButton);
                if (AddRoadLinks)
                {
                    Select = false;
                    RemoveRoadLinks = false;
                }
                EditorGUILayout.Space();
                RemoveRoadLinks = GUILayout.Toggle(RemoveRoadLinks, "Remove Road Links", EditorStyles.miniButton);
                if (RemoveRoadLinks)
                {
                    Select = false;
                    AddRoadLinks = false;
                }
            }
        }
        else
        {
            Select = false;
            AddRoadLinks = false;
            RemoveRoadLinks = false;
        }
        EditorGUILayout.EndScrollView();

        EditorGUILayout.Space();

        _path = serializedObject.FindProperty("Path");
        EditorGUILayout.PropertyField(_path);

        EditorGUILayout.Space();

        if (GUILayout.Button("Save as File"))
        {
            prop.SaveToFile();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Give RoadPoints to point"))
        {
            for (int i = 0; i < prop.Points.Count; i++)
            {
                prop.Points[i].GetComponent<RoadPoint>().Point = prop.Points[i].transform.position;
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Road Drawing Editor\nCreated by Abdul Rafay", EditorStyles.centeredGreyMiniLabel, GUILayout.MaxHeight(50f));

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
            EditorUtility.SetDirty(prop);

    }
    private void RefreshName()
    {
        for (int i = 0; i < prop.Points.Count; i++)
        {
            prop.Points[i].name = prop.gameObject.name + " (" + (i + 1) + ")";
        }
    }

    private void RefreshName(string name)
    {
        for (int i = 0; i < prop.Points.Count; i++)
        {
            prop.Points[i].name = name + " (" + (i + 1) + ")";
        }
    }

    private void AddLinkto(GameObject link, GameObject RoadPoint)
    {
        if (RoadPoint != null)
        {
            RoadLink[] temp = new RoadLink[RoadPoint.GetComponent<RoadPoint>().RoadLinks.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == temp.Length - 1) // last index
                {
                    temp[i] = link.GetComponent<RoadLink>();
                }
                else
                {
                    temp[i] = RoadPoint.GetComponent<RoadPoint>().RoadLinks[i];
                }
            }

            RoadPoint.GetComponent<RoadPoint>().RoadLinks = new RoadLink[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                RoadPoint.GetComponent<RoadPoint>().RoadLinks[i] = temp[i];
            }
        }
    }
    private void AddLinktoSelectedPoint(GameObject link)
    {
        if (SelectedRoadPointTOAddLinks != null)
        {
            RoadLink[] temp = new RoadLink[SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == temp.Length - 1) // last index
                {
                    temp[i] = link.GetComponent<RoadLink>();
                }
                else
                {
                    temp[i] = SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks[i];
                }
            }

            SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks = new RoadLink[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks[i] = temp[i];
            }
        }
    }
    private void RemoveLinkFromSelectedPoint(GameObject link)
    {
        if (SelectedRoadPointTOAddLinks != null)
        {
            RoadLink[] temp = new RoadLink[SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks.Length - 1];
            int j = 0;
            for (int i = 0; i < SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks.Length; i++)
            {
                if (link != SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks[i].gameObject)
                {
                    temp[j] = SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks[i];
                    j++;
                }
            }

            SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks = new RoadLink[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                SelectedRoadPointTOAddLinks.GetComponent<RoadPoint>().RoadLinks[i] = temp[i];
            }
        }
    }
}
