using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshPath : MonoBehaviour
{
    private NavMeshAgent myNavMeshAgent;
    private LineRenderer myLineRenderer;
    public Transform target;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myLineRenderer = GetComponent<LineRenderer>();
        myLineRenderer.startWidth = 0.15f;
        myLineRenderer.endWidth = 0.15f;
        myLineRenderer.positionCount = 0;
    }

    void Update()
    {
        if(target)
        {
            myNavMeshAgent.SetDestination(target.position);
            if (Vector3.Distance(myNavMeshAgent.destination, transform.position) <= myNavMeshAgent.stoppingDistance)
            {

            }
            else if (myNavMeshAgent.hasPath)
            {
                DrawPath();
            }
        }
    }

    private void DrawPath()
    {
        myLineRenderer.positionCount = myNavMeshAgent.path.corners.Length;
        myLineRenderer.SetPosition(0, transform.position);

        if(myNavMeshAgent.path.corners.Length<2)
        {
            return;
        }

        for(int i=1;i<myNavMeshAgent.path.corners.Length;i++)
        {
            Vector3 pointPosition = new Vector3(myNavMeshAgent.path.corners[i].x, myNavMeshAgent.path.corners[i].y, myNavMeshAgent.path.corners[i].z);
            myLineRenderer.SetPosition(i, pointPosition);
        }
    }
}