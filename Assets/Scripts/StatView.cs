using UnityEngine;
using UnityEngine.UI;

public class StatView : MonoBehaviour
{
	[SerializeField]
	private Image m_Icon;

	[SerializeField]
	private Text m_NameStat;

	[SerializeField]
	private Text m_Value;

	public void SetIcon(Sprite sp)
	{
		m_Icon.sprite = sp;
	}

	public void SetNameStat(string nameStat)
	{
		m_NameStat.text = nameStat.ToUpper();
	}

	public void SetValue(float value)
	{
		if (value > 0f)
		{
			m_Value.text = "+" + value.ToString("F2");
		}
		else if (value < 0f)
		{
			m_Value.text = value.ToString("F2");
		}
		else
		{
			m_Value.text = value.ToString("F2");
		}
	}
}
