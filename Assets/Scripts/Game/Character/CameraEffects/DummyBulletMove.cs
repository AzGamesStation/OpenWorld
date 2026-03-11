using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBulletMove : MonoBehaviour
{

    [SerializeField] float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.Translate(0, 0, speed*Time.deltaTime);
    }
}
