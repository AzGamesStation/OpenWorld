using UnityEngine;

namespace Game.Character.CharacterController
{
	public class GunSFX : MonoBehaviour
	{
		private ParticleSystem[] emmiters;

		protected void Awake()
		{
			emmiters = GetComponentsInChildren<ParticleSystem>();
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
