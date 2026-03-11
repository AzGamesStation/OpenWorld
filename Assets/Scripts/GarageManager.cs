using Game.GlobalComponent;
using Game.Items;
using Game.Vehicle;
using UnityEngine;

public class GarageManager : MonoBehaviour
{
	private const string VehicleKey = "MainVehicle";

	private static GarageManager instance;

	public ControlableObjectRespawner MainRespawner;

	public GarageSensor GarageSensor;

	public static GarageManager Instance => (instance != null) ? instance : (instance = UnityEngine.Object.FindObjectOfType<GarageManager>());

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ResetVehicle(checkSpawnAvaible: false);
	}

	public void SetVehicle(GameItemVehicle vehicle)
	{
		if (!(vehicle.VehiclePrefab == MainRespawner.ObjectPrefab))
		{
			BaseProfile.StoreValue(vehicle.ID, "MainVehicle");
			GarageSensor.SpawnNewVehicle(vehicle.VehiclePrefab);
		}
	}

	public void ResetVehicle()
	{
		ResetVehicle(checkSpawnAvaible: true);
	}

	private void ResetVehicle(bool checkSpawnAvaible = false)
	{
		if (!checkSpawnAvaible || GarageSensor.CheckSpawnAvaible())
		{
			int id = BaseProfile.ResolveValue("MainVehicle", 0);
			GameItemVehicle gameItemVehicle = ItemsManager.Instance.GetItem(id) as GameItemVehicle;
			if (gameItemVehicle != null)
			{
				MainRespawner.SetNewObject(gameItemVehicle.VehiclePrefab);
			}
		}
	}
}
