using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Character.CharacterController;

public class PowerGuidedMove : MonoBehaviour
{
    [SerializeField] float speed;
    //[HideInInspector]
    public Transform spawnPoint, target;
    [SerializeField] Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
           this.transform.position = Vector3.Lerp(this.transform.position, target.position + Offset, Time.deltaTime * speed);
        }
        else
        {
            this.transform.Translate(0, 0, Time.deltaTime * speed*5);
        }
    }


}
