using Game.Character;
using UnityEngine;

namespace Game.GlobalComponent.Qwest
{
	public class QwestStart : MonoBehaviour
	{
		public Qwest Qwest;

		private void OnTriggerEnter(Collider col)
		{
			if (!GameEventManager.Instance.TimeQwestActive && (bool)col.GetComponent<CharacterSensor>())
			{
				Debug.Log("trigger");
				GameEventManager.Instance.StartQwest(Qwest);
				PoolManager.Instance.ReturnToPool(this);
			}
		}
	}
}
