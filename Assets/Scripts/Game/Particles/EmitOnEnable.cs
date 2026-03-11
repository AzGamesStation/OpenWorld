using UnityEngine;

namespace Game.Particles
{
	public class EmitOnEnable : MonoBehaviour
	{
        private ParticleSystem emitter;

        private void Awake()
		{
            emitter = GetComponent<ParticleSystem>();
        }

		private void OnEnable()
		{
            emitter.Play();
        }

		private void OnDisable()
		{//
            emitter.Stop();
        }
	}
}
