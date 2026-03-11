using UnityEngine;

public class DrawAllBoxColliders : MonoBehaviour
{
	public Color m_Color = Color.white;

	public bool m_Draw;

	private void OnDrawGizmos()
	{
		if (m_Draw)
		{
			Gizmos.color = m_Color;
			BoxCollider[] componentsInChildren = base.transform.GetComponentsInChildren<BoxCollider>();
			foreach (BoxCollider boxCollider in componentsInChildren)
			{
				Gizmos.matrix = boxCollider.transform.localToWorldMatrix;
				Gizmos.DrawCube(Vector3.zero + boxCollider.center, boxCollider.size);
			}
		}
	}
}
