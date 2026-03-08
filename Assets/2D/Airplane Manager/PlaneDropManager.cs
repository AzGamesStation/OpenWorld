using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDropManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] targetDropPoints;
    public Transform dropPoint;
    public GameObject airplane;
    public DropMovement dropPrefab;
    public Transform player;
    int randNumber;
    int randTarget=0;
    public bool isDrop = false;

    void Start()
    {
        //SetPlanePosition();
        Invoke("Drop", 20f);
    }

    public void SetPlanePosition()
    {
        //if(isDrop)
        //    Invoke("Drop", 20f);
        //airplane.SetActive(true);
        //randNumber = Random.Range(0, 4);
        //airplane.transform.rotation = spawnPoints[randNumber].rotation;
        //airplane.transform.position = new Vector3(spawnPoints[randNumber].position.x, spawnPoints[randNumber].position.y, spawnPoints[randNumber].position.z);
    }

    public void Drop()
    {
        dropPrefab.balloon.SetActive(true);
        dropPrefab.particle.SetActive(false);
        dropPrefab.transform.position = dropPoint.transform.position;
        dropPrefab.gameObject.SetActive(true);
        //randTarget = Random.Range(0, targetDropPoints.Length);
        for(int i=0;i<targetDropPoints.Length;i++)
        {
            if(Vector3.Distance(player.position,targetDropPoints[i].position)<40f)
            {
                Vector3 playerPositionRelativeToDoor = player.transform.position - targetDropPoints[i].position;
                float dotProduct = Vector3.Dot(playerPositionRelativeToDoor, targetDropPoints[i].transform.forward);

                if (dotProduct > 0)
                {
                    randTarget = i;
                }
            }
        }
        if(randTarget==0)
            randTarget = Random.Range(0, targetDropPoints.Length);
        dropPrefab.target = targetDropPoints[randTarget];
        isDrop = false;
    }

    public void ReInstDrop()
    {
        isDrop = true;
        dropPrefab.gameObject.SetActive(false);
    }
}