using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Character.Utils;
using Game.GlobalComponent;
using Game.Traffic;

public class DrawRoad : MonoBehaviour
{
    public GameObject RoadPoint;
    public List<GameObject> Points = new List<GameObject>();

    public void RefreshDirection()
    {
        for (int i = 0; i < Points.Count - 1; i++)
        {
            Quaternion lookrot = Quaternion.LookRotation(Points[i + 1].transform.position - Points[i].transform.position);
            //Vector3 eul = new Vector3(Points[i].transform.eulerAngles.x, lookrot.eulerAngles.y, Points[i].transform.eulerAngles.z);
            //Points[i].transform.rotation = Quaternion.Euler(eul);
            Points[i].transform.rotation = lookrot;
            RaycastHit hit;
            if (Physics.Raycast(Points[i].transform.position, -Points[i].transform.up, out hit))
            {
                Points[i].transform.rotation = Quaternion.FromToRotation(Points[i].transform.up, hit.normal) * Points[i].transform.rotation;
            }
        }
    }

    public string Path;
    public void SaveToFile()
    {
        RoadPoint[] points_ = new RoadPoint[Points.Count];
        for(int i = 0;i< points_.Length;i++)
        {
            points_[i] = Points[i].GetComponent<RoadPoint>();
        }

        string text = MiamiSerializier.JSONSerialize(points_);
        if (!string.IsNullOrEmpty(text))
        {
            IO.WriteTextFile(Path, text);
        }
    }
}
