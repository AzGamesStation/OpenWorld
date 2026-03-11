using Game.Character;
using Game.Character.CharacterController;
using UnityEngine;

namespace Game.Items
{
	public class GameItemSuperKick : GameItemAbility
	{
		public GameObject KickButton;

		public override void Enable()
		{
			PlayerManager.Instance.Player.GetComponentInChildren<SuperKick>().enabled = true;
			KickButton.SetActive(value: true);
		}

		public override void Disable()
		{
			PlayerManager.Instance.Player.GetComponentInChildren<SuperKick>().enabled = false;
			KickButton.SetActive(value: false);
		}
	}
}
