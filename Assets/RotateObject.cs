using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public enum rotate {x, y, z }
    public rotate rotateAngle;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateAngle.Equals (rotate.x))
        {
            this.transform.Rotate(speed, 0, 0);
        }
        else if (rotateAngle.Equals(rotate.y))
        {
            this.transform.Rotate(0, speed, 0);
        }
        else if (rotateAngle.Equals(rotate.z))
        {
            this.transform.Rotate(0, 0, speed);
        }
    }
}
