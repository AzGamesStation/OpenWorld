using UnityEngine;

namespace Game.Particles
{
	public class FadeOutParticles : MonoBehaviour
	{
		public float DelayBeforeFade;

		public float StartedFadeProgress = 1f;

        private ParticleSystem emitter;

        private float minEmission;

		private float maxEmission;

		private float delayTimer;

		private float fadeOutProgress;

		private void Awake()
		{
            emitter = GetComponent<ParticleSystem>();
            //minEmission = emitter.minEmission;
            //maxEmission = emitter.maxEmission;
        }

		private void OnEnable()
		{
			delayTimer = DelayBeforeFade;
			fadeOutProgress = StartedFadeProgress;
            //emitter.minEmission = minEmission;
            //emitter.maxEmission = maxEmission;
            emitter.Play();
        }

		private void Update()
		{
            if (!emitter.isPlaying)
            {
                return;
            }
            if (delayTimer > 0f)
            {
                delayTimer -= Time.deltaTime;
                return;
            }
            //emitter.minEmission = minEmission * fadeOutProgress;
            //emitter.maxEmission = maxEmission * fadeOutProgress;
            if (fadeOutProgress > 0f)
            {
                fadeOutProgress -= Time.deltaTime;
            }
            else
            {
                emitter.Stop();
            }
        }
	}
}
