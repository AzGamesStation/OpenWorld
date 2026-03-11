using Game.Character;
using Game.Factions;
using Game.GlobalComponent;
using Game.Vehicle;
using UnityEngine;
using Game.UI;

namespace Game.PickUps
{
	public class PickUp : MonoBehaviour
	{
		public GameObject RotateCenter;

		private SlowUpdateProc slowUpdateProc;

		public PickUp pickup;

		public Collider colliderInTrigger;

		public void Awake()
		{
			slowUpdateProc = new SlowUpdateProc(SlowUpdate, 2f);
		}

		private void Start()
		{
			pickup = GetComponent<PickUp>();
		}

		private void Update()
		{
			RotateCenter.transform.Rotate(Vector3.up);
		}

		private void FixedUpdate()
		{
			slowUpdateProc.ProceedOnFixedUpdate();
		}

		private void SlowUpdate()
		{
			if (!SectorManager.Instance.IsInActiveSector(base.transform.position))
			{
				ReturnPickup();
			}
		}

		private void ReturnPickup()
		{
			if (!PoolManager.Instance.ReturnToPool(base.gameObject))
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		protected virtual void TakePickUp()
		{
			PickUpManager.Instance.OnTakedPickup(this);
			ReturnPickup();
		}

		private void OnTriggerEnter(Collider col)
		{
			if ((bool)col.gameObject.GetComponent<CharacterSensor>())
			{
				TakePickUp();
				return;
			}
			VehicleStatus componentInParent = col.gameObject.GetComponentInParent<VehicleStatus>();
			if ((bool)componentInParent && componentInParent.Faction == Faction.Player)
			{
				TakePickUp();

			}
		}

		public void GivePickup()
		{
			Time.timeScale = 1;
			//UIGame.Instance.WeaponRewardPanel.SetActive(false);
			Game.UI.UIGame.Instance.boosterPackage.adscaller.SetActive(false);
			Game.UI.UIGame.Instance.boosterPackage.gameObject.SetActive(false);
			if (GlobalContants.giveBoosterWeapon)
			{

				TakePickUp();
				GlobalContants.giveBoosterWeapon = false;

				return;
			}

			if ((bool)colliderInTrigger.gameObject.GetComponent<CharacterSensor>())
			{
				Debug.Log("Here2");
				TakePickUp();
				return;
			}
			VehicleStatus componentInParent = colliderInTrigger.gameObject.GetComponentInParent<VehicleStatus>();
			if ((bool)componentInParent && componentInParent.Faction == Faction.Player)
			{
				Debug.Log("Here3");
				TakePickUp();

			}
		}
	}
}
