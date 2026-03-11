using UnityEngine;

public class WaterAnimator : MonoBehaviour
{
    Material mat;
    public float scrollSpeed = 0.5f;
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
