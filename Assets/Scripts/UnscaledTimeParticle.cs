using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class UnscaledTimeParticle : MonoBehaviour
{
	private ParticleSystem m_ParticleSystem;

	private void OnEnable()
	{
		m_ParticleSystem = GetComponent<ParticleSystem>();
	}

	private void Update()
	{
		if (Time.timeScale < 0.01f)
		{
			m_ParticleSystem.Simulate(Time.unscaledDeltaTime, withChildren: true, restart: false);
		}
	}
}
