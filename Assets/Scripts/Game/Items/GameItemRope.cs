using Game.Character.CharacterController;
using UnityEngine;

namespace Game.Items
{
	public class GameItemRope : GameItemAbility
	{
		public GameObject ShotRopeButton;

		public bool UseInFly;

		public override void Enable()
		{
			if (UseInFly)
			{
				PlayerManager.Instance.AnimationController.UseRopeWhileFlying = true;
				return;
			}
			PlayerManager.Instance.AnimationController.useRope = true;
			ShotRopeButton.SetActive(value: true);
		}

		public override void Disable()
		{
			if (UseInFly)
			{
				PlayerManager.Instance.AnimationController.UseRopeWhileFlying = false;
				return;
			}
			PlayerManager.Instance.AnimationController.useRope = false;
			ShotRopeButton.SetActive(value: false);
		}
	}
}
