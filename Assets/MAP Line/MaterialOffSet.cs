using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffSet : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Renderer rend;
    [HideInInspector]
    public float Distance;

    void Start()
    {
        rend = GetComponent<LineRenderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }

    
}
