using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Traffic;

public class PointGenerator : MonoBehaviour
{
    [System.Serializable]
    public class RoadLink
    {
        public RoadPoint Link;
        public float SpacerLineWidth;
        //public GameObject LinkPoint;
    }
    [System.Serializable]
    public class RoadPoint
    {
        public Vector3 Point;
        
        public RoadLink[] RoadLinks;

        public int LineCount;

        public float SpeedLimit = float.MaxValue;
        //public Vector3 NodeObject;
        public float GetSpaceLineWidthToNode(RoadPoint toNode)
        {
            float result = 0f;
            RoadLink[] roadLinks = RoadLinks;
            foreach (RoadLink roadLink in roadLinks)
            {
                if (roadLink.Link == toNode)
                {
                    result = roadLink.SpacerLineWidth;
                    break;
                }
            }
            return result;
        }
    }
    public RoadPoint roadpoint;

}
