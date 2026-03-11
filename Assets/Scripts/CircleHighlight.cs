using UnityEngine;

public class CircleHighlight : MonoBehaviour
{
	[SerializeField]
	private Renderer m_Renderer;

	public SpriteRenderer m_ControlSpriteRender;

	private MaterialPropertyBlock m_PropertyBlock;

	[SerializeField]
	private float m_Speed = 1f;

	private void Update()
	{
		if (m_PropertyBlock == null)
		{
			m_PropertyBlock = new MaterialPropertyBlock();
		}
		m_Renderer.GetPropertyBlock(m_PropertyBlock);
		m_PropertyBlock.SetFloat("_Progress", Mathf.Repeat(Time.unscaledTime * m_Speed, 1f));
		if (m_ControlSpriteRender != null)
		{
			m_PropertyBlock.SetColor("_Color", m_ControlSpriteRender.color);
		}
		m_Renderer.SetPropertyBlock(m_PropertyBlock);
	}
}
