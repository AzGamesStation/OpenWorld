using Game.Vehicle;
using UnityEngine;

namespace Game.Items
{
	public class GameItemVehicle : GameItem
	{
		public GameObject VehiclePrefab;

		public static float maxSpeed
		{
			get;
			private set;
		}

		public static float maxAcceleration
		{
			get;
			private set;
		}

		public override void Init()
		{
			base.Init();
            Debug.Log("log p: "+ VehiclePrefab.gameObject.name);
			DrivableVehicle component = VehiclePrefab.GetComponent<DrivableVehicle>();
			if (component.MaxSpeed > maxSpeed)
			{
				maxSpeed = component.MaxSpeed;
			}
			if (component.Acceleration > maxAcceleration)
			{
				maxAcceleration = component.Acceleration;
			}
		}

		public override bool SameParametrWithOther(object[] parametrs)
		{
			return VehiclePrefab == (GameObject)parametrs[0];
		}
	}
}
