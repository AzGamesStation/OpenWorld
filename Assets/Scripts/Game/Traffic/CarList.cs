using Game.Vehicle;
using UnityEngine;

namespace Game.Traffic
{
	[CreateAssetMenu(fileName = "VehicleList", menuName = "Library/Traffic/Create vehicle List", order = 1)]
	public class CarList : BaseListScriptable<DrivableVehicle>
	{
		public DrivableVehicle GetRandomVehicle()
		{
			return m_Details[Random.Range(0, base.Count)];
		}
	}
}
