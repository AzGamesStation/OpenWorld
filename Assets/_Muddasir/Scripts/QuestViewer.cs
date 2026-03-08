using Game.GlobalComponent.Qwest;
using System.Collections.Generic;
using UnityEngine;

public class QuestViewer : MonoBehaviour
{
    private static QuestViewer _instance;
    public static QuestViewer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<QuestViewer>();
            }
            return _instance;
        }
    }
   
}
