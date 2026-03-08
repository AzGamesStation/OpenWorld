using Game.Character.CharacterController;
using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawMapPath : MonoBehaviour
{
    NavMeshPath path;
    public Transform Target;
    public LineRenderer line;
    public NavMeshAgent agent;
    NavMeshHit hit;
    int RoadArea;
    public Vector3[] aa;
    public int totalPositions;
    public static DrawMapPath _instance;
    bool isTaxi;
    public float waitTime = 2f;
    float counter;
    public float LineWidth;

    private void Awake()
    {
        _instance = this;
        isTaxi = false;
    }
    public void ResetTarget()
    {
       
        isTaxi = true;
    }
    private void Start()
    {
        Target = PlayerManager.Instance.Player.transform;
        line = GameManager.Instance.line;
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void SetDestinationAtFirst(Transform startTrans)
    {
        path = agent.path;
        NavMesh.CalculatePath(startTrans.position, Target.position, RoadArea, path); //Saves the path in the path variable.
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
    }
    private void Update()
    {
        counter++;

        if (Target)
        {
            if (counter > waitTime)
            {
                counter = 0;
                RoadArea = 1 << NavMesh.GetAreaFromName("Terrain");
                if (NavMesh.SamplePosition(transform.position, out hit, 2.0f, RoadArea))
                {
                    path = agent.path;
                    NavMesh.CalculatePath(transform.position, Target.position, RoadArea, path); //Saves the path in the path variable.
                    line.positionCount = path.corners.Length;
                    line.SetPositions(path.corners);

                    if (path.corners.Length > 0)
                    {
                        totalPositions = path.corners.Length;
                        aa = path.corners;
                    }
                }
                else
                {
                    line.positionCount = totalPositions;
                    line.SetPositions(aa);
                }
            }
        }
    }
}
