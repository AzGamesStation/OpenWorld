using UnityEngine;

namespace Game.Traffic
{
	[CreateAssetMenu(fileName = "VehicleList", menuName = "Library/Traffic/Create spawn vehicle List", order = 1)]
	public class SpawnVehicleList : ScriptableObject
	{
		[SerializeField]
		public MonoBehaviour m_AutoPilotPrefab;

		public CarList m_VehicleList;
	}
}
