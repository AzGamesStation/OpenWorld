using Game.GlobalComponent;
using UnityEngine;

namespace Game.Character.Extras
{
	public class BloodHitEffect : BaseHitEffect
	{
		public static BloodHitEffect Instance;

		private const float DestructPrefabTime = 5f;

		public GameObject[] BloodSFXPrefabs;

		protected override void Awake()
		{
            emmiters = GetComponentsInChildren<ParticleSystem>();
            Instance = this;
		}

		public override void Emit(Vector3 pos)
		{
			base.transform.position = pos;
			if (BloodSFXPrefabs.Length != 0)
			{
				int num = Random.Range(0, BloodSFXPrefabs.Length);
				GameObject fromPool = PoolManager.Instance.GetFromPool(BloodSFXPrefabs[num]);
				fromPool.transform.position = pos;
				PoolManager.Instance.ReturnToPoolWithDelay(fromPool, 5f);
				return;
			}
            ParticleSystem[] emmiters = base.emmiters;
            foreach (ParticleSystem particleEmitter in emmiters)
			{
				particleEmitter.Play();
			}
        }
	}
}
