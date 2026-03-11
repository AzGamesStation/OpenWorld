using Game.GlobalComponent;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Game.Character.Config;
using UnityEditor;
using Game.Character.Utils;
using System.IO;
//using UnityEditor.Experimental.UIElements.GraphView;
using System.Text;

namespace Game.Traffic
{
    public class RoadMapPreprocessor : MonoBehaviour
    {
        public HashSet<PointGenerator.RoadPoint> points = new HashSet<PointGenerator.RoadPoint>();

        public HashSet<Node> usedNodes = new HashSet<Node>();

        public HashSet<PointGenerator.RoadPoint> usedRPs = new HashSet<PointGenerator.RoadPoint>();

        public IDictionary<Node, PointGenerator.RoadPoint> nodeToPoints = new Dictionary<Node, PointGenerator.RoadPoint>();

        public class MyConfig : Config
        {
            public override void LoadDefault()
            {
                throw new System.NotImplementedException();
            }
        }
        public PointGenerator[] PointGen;

        [ContextMenu("buttonAssign")]
        public void AssignLinkPoint() {

            for (int h = 0; h < PointGen.Length; h++)
            {
                Mynodes[h].Point = PointGen[h].roadpoint.Point;
                Mynodes[h].LineCount = 1;
                Mynodes[h].SpeedLimit = 15;
                for (int i = 0; i < PointGen[h].roadpoint.RoadLinks.Length; i++)
                {
                    Mynodes[h].RoadLinks[i].Link.Point = PointGen[h].roadpoint.RoadLinks[i].Link.Point;
                    Mynodes[h].RoadLinks[i].Link.LineCount = 1;
                    Mynodes[h].RoadLinks[i].Link.SpeedLimit = 15;
                    for (int j = 0; j < PointGen[h].roadpoint.RoadLinks[i].Link.RoadLinks.Length; j++)
                    {
                        Mynodes[h].RoadLinks[i].Link.RoadLinks[j].Link.Point = PointGen[h].roadpoint.RoadLinks[i].Link.RoadLinks[j].Link.Point;
                        Mynodes[h].RoadLinks[i].Link.RoadLinks[j].Link.LineCount = 1;
                        Mynodes[h].RoadLinks[i].Link.RoadLinks[j].Link.SpeedLimit = 15;
                        for (int k = 0; k < PointGen[h].roadpoint.RoadLinks[i].Link.RoadLinks[j].Link.RoadLinks.Length; k++)
                        {
                            Mynodes[h].RoadLinks[i].Link.RoadLinks[j].Link.RoadLinks[k].Link.Point = PointGen[h].roadpoint.RoadLinks[i].Link.RoadLinks[j].Link.RoadLinks[k].Link.Point;
                            Mynodes[h].RoadLinks[i].Link.RoadLinks[j].Link.RoadLinks[k].Link.LineCount = 1;
                            Mynodes[h].RoadLinks[i].Link.RoadLinks[j].Link.RoadLinks[k].Link.SpeedLimit = 15;
                        }
                    }
                }
            }
        }
        private string PrebuildRoadPoints(PointGenerator.RoadPoint[] nodes)
        {
            if (nodes == null)
            {
                return string.Empty;
            }
            usedNodes.Clear();
            nodeToPoints.Clear();
            points.Clear();
            //foreach (Node node in nodes)
            //{
            //    NodeBypass(node);
            //}
            usedRPs.Clear();
            foreach (PointGenerator.RoadPoint value in nodeToPoints.Values)
            {
                RoadPointDistanceBypass(value);
            }
            return MiamiSerializier.JSONSerialize(Mynodes.ToArray());
            
        }

        private object Decoder(string str)
        {

            return MiamiSerializier.JSONDeserialize (str);
        }
        private void NodeBypass(Node node)
        {
            if (!usedNodes.Contains(node) && node.NodeLinks != null && node.NodeLinks.Count != 0)
            {
                usedNodes.Add(node);
                PointGenerator.RoadPoint roadPoint = new PointGenerator.RoadPoint();
               // roadPoint.NodeObject.position = node.transform.position;
                roadPoint.LineCount = node.LineCount;
                roadPoint.SpeedLimit = ((!node.SpeedLimit.Equals(float.PositiveInfinity)) ? node.SpeedLimit : float.MaxValue);
                roadPoint.RoadLinks = new PointGenerator.RoadLink[node.NodeLinks.Count];
                points.Add(roadPoint);
                nodeToPoints.Add(node, roadPoint);
                int num = 0;
                foreach (Node linkedNodes in node.GetLinkedNodesList())
                {
                    if (!usedNodes.Contains(linkedNodes))
                    {
                        NodeBypass(linkedNodes);
                    }
                    PointGenerator.RoadPoint link = nodeToPoints[linkedNodes];
                    roadPoint.RoadLinks[num] = new PointGenerator.RoadLink
                    {
                        Link = link,
                        SpacerLineWidth = node.GetSpaceLineWidthToNode(linkedNodes)
                    };
                    num++;
                }
            }
        }

        private void RoadPointDistanceBypass(PointGenerator.RoadPoint rp)
        {
            if (usedRPs.Contains(rp))
            {
                return;
            }
            usedRPs.Add(rp);
            int num = 0;
            for (int i = 0; i < rp.RoadLinks.Length; i++)
            {
                PointGenerator.RoadPoint link = rp.RoadLinks[i].Link;
                if (!usedRPs.Contains(link))
                {
                    float num2 = Vector3.Distance(link.Point, rp.Point);
                    if (num2 > TrafficManager.NodesMaxDistance)
                    {
                        int num3 = (int)(num2 / TrafficManager.NodesMaxDistance);
                        float d = num2 / (float)(num3 + 1);
                        Vector3 normalized = (link.Point - rp.Point).normalized;
                        PointGenerator.RoadPoint roadPoint = rp;
                        float spacerLineWidth = (link.GetSpaceLineWidthToNode(rp) + rp.GetSpaceLineWidthToNode(link)) / 2f;
                        for (int j = 0; j < num3; j++)
                        {
                            PointGenerator.RoadPoint roadPoint2 = new PointGenerator.RoadPoint();
                            usedRPs.Add(roadPoint2);
                            points.Add(roadPoint2);
                            roadPoint2.LineCount = rp.LineCount;
                            roadPoint2.Point = rp.Point + normalized * d * (j + 1);
                            roadPoint2.RoadLinks = new PointGenerator.RoadLink[2];
                            roadPoint2.RoadLinks[0] = new PointGenerator.RoadLink
                            {
                                Link = roadPoint,
                                SpacerLineWidth = spacerLineWidth
                            };
                            if (roadPoint.Equals(rp))
                            {
                                roadPoint.RoadLinks[i].Link = roadPoint2;
                                roadPoint.RoadLinks[i].SpacerLineWidth = spacerLineWidth;
                            }
                            else
                            {
                                roadPoint.RoadLinks[1] = new PointGenerator.RoadLink
                                {
                                    Link = roadPoint2,
                                    SpacerLineWidth = spacerLineWidth
                                };
                            }
                            roadPoint = roadPoint2;
                        }
                        for (int k = 0; k < link.RoadLinks.Length; k++)
                        {
                            if (link.RoadLinks[k].Link.Equals(rp))
                            {
                                link.RoadLinks[k].Link = roadPoint;
                                link.RoadLinks[k].SpacerLineWidth = spacerLineWidth;
                                roadPoint.RoadLinks[1] = new PointGenerator.RoadLink
                                {
                                    Link = link,
                                    SpacerLineWidth = spacerLineWidth
                                };
                                break;
                            }
                        }
                    }
                }
                num++;
            }
        }
        [ContextMenu ("rebuild")]
        public void Rebuild()
        {
            //ConvertStringToTextAsset(PrebuildRoadPoints(Mynodes));
        }
        //TextAsset ConvertStringToTextAsset(string text)
        //{
        //    string temporaryTextFileName = "TemporaryTextFile";
        //    File.WriteAllText(Application.dataPath + "/Texts/" + temporaryTextFileName + ".txt", text);
        //    AssetDatabase.SaveAssets();
        //    AssetDatabase.Refresh();
        //    TextAsset textAsset = Resources.Load(temporaryTextFileName) as TextAsset;
        //    return textAsset;
        //}

        public PointGenerator.RoadPoint[] Mynodes;
        private static void CureNodes(Node[] nodes)
        {
            foreach (Node node in nodes)
            {
                List<NodeLink> nodeLinks = node.NodeLinks;
                List<int> list = new List<int>();
                int num = 0;
                foreach (NodeLink item in nodeLinks)
                {
                    if (item.Link == null || item.Link == node)
                    {
                        list.Add(num);
                    }
                    else
                    {
                        List<Node> linkedNodesList = item.Link.GetLinkedNodesList();
                        if (!linkedNodesList.Contains(node))
                        {
                            item.Link.NodeLinks.Add(new NodeLink
                            {
                                Link = node,
                                SpacerLineWidth = item.SpacerLineWidth
                            });
                        }
                    }
                    num++;
                }
                for (int num2 = list.Count - 1; num2 >= 0; num2--)
                {
                    int index = list[num2];
                    nodeLinks.RemoveAt(index);
                }
            }
        }
    }
}
