using UnityEngine;

public class GizmoObject : MonoBehaviour
{
    [System.Serializable]
    public enum ObjectType {Box,Ball}
    [SerializeField]
    private ObjectType m_ObjectType;
    [SerializeField]
    private Color m_Color = Color.blue;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = m_Color;
        switch(m_ObjectType)
        {
            case ObjectType.Box:
                Gizmos.DrawCube(transform.position, transform.localScale);
                break;
            case ObjectType.Ball:
                Gizmos.DrawSphere(transform.position, transform.localScale.magnitude);
                break;
        }
    }
}
