using UnityEngine;
using UnityEngine.UI;

public abstract class UISpriteColorBase : MonoBehaviour
{
	protected MaskableGraphic uispriteRenderer;

	public Shader m_Shader;

	private void OnEnable()
	{
		uispriteRenderer = base.gameObject.GetComponent<MaskableGraphic>();
		if (uispriteRenderer != null)
		{
			CreateMaterial();
			UISpriteColorBase component = base.gameObject.GetComponent<UISpriteColorBase>();
			Initialize();
		}
		else
		{
			UnityEngine.Debug.LogWarning($"'{GetType().ToString()}' without UISpriteRenderer, disabled.");
			base.enabled = false;
		}
	}

	private void OnDisable()
	{
		if (uispriteRenderer != null && uispriteRenderer.material != null && string.CompareOrdinal(uispriteRenderer.material.name, "UI/Default") != 0)
		{
			uispriteRenderer.material = null;
		}
	}

	private void Update()
	{
		if (uispriteRenderer == null)
		{
			uispriteRenderer = base.gameObject.GetComponent<MaskableGraphic>();
		}
		if (uispriteRenderer != null && uispriteRenderer.material != null)
		{
			UpdateShader();
		}
	}

	protected void CreateMaterial()
	{
		string text = GetType().ToString().Replace("UISpriteColorBase.", string.Empty);
		if (m_Shader == null)
		{
			UnityEngine.Debug.LogWarning(string.Format("Failed to load '{0}', {1} disabled.", "Shader", text));
			base.enabled = false;
			return;
		}
		if (!m_Shader.isSupported)
		{
			UnityEngine.Debug.LogWarning(string.Format("Shader '{0}' not supported, {1} disabled.", "Shader", text));
			base.enabled = false;
			return;
		}
		if (uispriteRenderer == null)
		{
			uispriteRenderer = base.gameObject.GetComponent<MaskableGraphic>();
		}
		bool flag = false;
		Color value = Color.white;
		Vector2 value2 = Vector2.zero;
		Vector2 value3 = Vector2.one;
		Vector2 value4 = Vector2.zero;
		Vector2 value5 = Vector2.one;
		bool flag2 = false;
		if (uispriteRenderer.material != null)
		{
			flag = uispriteRenderer.material.IsKeywordEnabled("PIXELSNAP_ON");
			value = uispriteRenderer.material.color;
			value2 = uispriteRenderer.material.GetTextureOffset("_MainTex");
			value3 = uispriteRenderer.material.GetTextureScale("_MainTex");
			value4 = Vector2.zero;
			value5 = Vector2.one;
			flag2 = uispriteRenderer.material.IsKeywordEnabled("_BumpMap");
			if (flag2)
			{
				value4 = uispriteRenderer.material.GetTextureOffset("_BumpMap");
				value5 = uispriteRenderer.material.GetTextureScale("_BumpMap");
			}
		}
		uispriteRenderer.material = new Material(m_Shader);
		uispriteRenderer.material.name = $"UISprite/{text}";
		if (flag)
		{
			uispriteRenderer.material.SetFloat("PixelSnap", 1f);
			uispriteRenderer.material.EnableKeyword("PIXELSNAP_ON");
		}
		uispriteRenderer.material.SetColor("_Color", value);
		uispriteRenderer.material.SetTextureOffset("_MainTex", value2);
		uispriteRenderer.material.SetTextureScale("_MainTex", value3);
		if (flag2)
		{
			uispriteRenderer.material.SetTextureOffset("_BumpMap", value4);
			uispriteRenderer.material.SetTextureScale("_BumpMap", value5);
		}
	}

	protected virtual void Initialize()
	{
	}

	protected abstract void UpdateShader();
}
