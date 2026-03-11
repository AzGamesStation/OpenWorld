using UnityEngine;

namespace Game.Character.Extras
{
	public class SparksHitEffect : BaseHitEffect
	{
		public static SparksHitEffect Instance;

		[SerializeField]
		private ParticleSystem[] m_Particles;

		[SerializeField]
		private int countEmit = 1;

		protected override void Awake()
		{
			Instance = this;
		}

		public override void Emit(Vector3 pos)
		{
			base.transform.position = pos;
			ParticleSystem[] particles = m_Particles;
			foreach (ParticleSystem particleSystem in particles)
			{
				particleSystem.Emit(countEmit);
			}
		}
	}
}
