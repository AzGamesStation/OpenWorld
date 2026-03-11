using Game.Items;
using Game.Shop;
using System;
using UnityEngine;

namespace Game.Weapons
{
	[Serializable]
	public class WeaponSlot
	{
		public WeaponSlotTypes WeaponSlotType;

		public Weapon WeaponPrefab;

		public Weapon WeaponInstance;

		public GameObject Placeholder;

		public GameItem BuyToUnlock;

		public bool Available => BuyToUnlock == null || ShopManager.Instance.BoughtAlredy(BuyToUnlock);
	}
}
