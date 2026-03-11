using UnityEngine;
public class DestroyMe : MonoBehaviour
{
    public int DestroyTime;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
