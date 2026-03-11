using Game.Weapons;
using UnityEngine;

namespace Game.Items
{
	public class GameItemAmmo : GameItem
	{
		public AmmoTypes AmmoType;

		public GameObject ammoPrefab;

		public override void Init()
		{
			base.Init();
			AmmoManager.Instance.AddContainer(this, this);
			AmmoManager.Instance.CreateContainer(this);
		}

		public override bool SameParametrWithOther(object[] parametrs)
		{
			return AmmoType == (AmmoTypes)parametrs[0];
		}
	}
}
