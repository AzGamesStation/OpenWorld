using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject balloon;
    public GameObject particle;
    public Transform target;
    public GameObject player;
    private Vector3 spawnPos;
    public float spawnDistance = 10;
    public GameObject box;

    private void Start()
    {
        if (box == null)
            box = transform.GetChild(0).gameObject;
        box.SetActive(false);
        InvokeRepeating("Spawn", 30f, 60f);
    }

    private void Spawn()
    {
        Vector3 playerPos = player.transform.position + new Vector3(0f, 20f, 0f);
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        spawnPos = playerPos + playerDirection * spawnDistance;
        box.transform.position = spawnPos;
        box.SetActive(true);
        Invoke("Delay", 30f);
        //Instantiate(Resources.Load(iconDragging.GetComponent<UISprite>().spriteName), spawnPos, playerRotation);
    }

    void Delay()
    {
        box.SetActive(false);
    }


    public void MoveNearToPlayer()
    {

    }
    //void Update()
    //{
    //    // Move our position a step closer to the target.
    //    var step = speed * Time.deltaTime; // calculate distance to move
    //    transform.position = Vector3.MoveTowards(transform.position, spawnPos, step);

    //    // Check if the position of the cube and sphere are approximately equal.
    //    if (Vector3.Distance(transform.position, spawnPos) < 0.001f)
    //    {
    //        // Swap the position of the cylinder.
    //        //target.position *= -1.0f;
    //        balloon.SetActive(false);
    //        particle.SetActive(true);
    //    }
    //}
}