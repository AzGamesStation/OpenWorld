using UnityEngine;

namespace Game.Weapons
{
	public class TraceSFX : MonoBehaviour
	{
        private ParticleSystem[] emmiters;

        public static TraceSFX Instance;

		protected void Awake()
		{
            emmiters = GetComponentsInChildren<ParticleSystem>();
            Instance = this;
		}

		public void Emit(Vector3 pos, Vector3 direction)
		{
			base.transform.position = pos;
			base.transform.forward = direction;
			ParticleSystem[] array = emmiters;
			foreach (ParticleSystem particleEmitter in array)
			{
				particleEmitter.Play();
			}
		}
	}
}
