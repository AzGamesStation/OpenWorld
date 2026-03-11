using UnityEngine;

namespace Game.Items
{
	public class GameItemAccessory : GameItemSkin
	{
		[Space(10f)]
		public GameObject ModelPrefab;

		public override bool SameParametrWithOther(object[] parametrs)
		{
			return ModelPrefab == (GameObject)parametrs[0];
		}
	}
}
