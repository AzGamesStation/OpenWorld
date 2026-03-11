using Game.Factions;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRelationsView : MonoBehaviour
{
	[SerializeField]
	private Slider RelationSlider;

	[SerializeField]
	private Slider RelationSubSlider;

	[SerializeField]
	private RelationManager m_RelationManager;

	[Tooltip("If true, will show Range(-min, 0), else Range(-min , +max)")]
	public bool m_ClampInverted = true;

	[SerializeField]
	private Faction m_ObservedFaction = Faction.Police;

	private void Awake()
	{
		Setup();
	}

	private void OnEnable()
	{
		UpdateValues();
	}

	private void Setup()
	{
		if (m_ClampInverted)
		{
			Slider relationSlider = RelationSlider;
			float minValue = 0f;
			RelationSubSlider.minValue = minValue;
			relationSlider.minValue = minValue;
			RelationSlider.maxValue = Mathf.Abs(-5f);
			RelationSubSlider.maxValue = Mathf.Abs(-5f);
		}
		else
		{
			Slider relationSlider2 = RelationSlider;
			float minValue = -10f;
			RelationSubSlider.minValue = minValue;
			relationSlider2.minValue = minValue;
			Slider relationSlider3 = RelationSlider;
			minValue = 10f;
			RelationSubSlider.maxValue = minValue;
			relationSlider3.maxValue = minValue;
		}
	}

	public void UpdateValues()
	{
		if (m_ClampInverted)
		{
			RelationSubSlider.value = Mathf.Abs(m_RelationManager.GetPlayerRelations(m_ObservedFaction).RelationValue / 2f);
			RelationSlider.value = Mathf.Floor(Mathf.Abs(m_RelationManager.GetPlayerRelations(m_ObservedFaction).RelationValue / 2f));
			return;
		}
		Slider relationSubSlider = RelationSubSlider;
		float relationValue = m_RelationManager.GetPlayerRelations(m_ObservedFaction).RelationValue;
		RelationSlider.value = relationValue;
		relationSubSlider.value = relationValue;
	}
}
