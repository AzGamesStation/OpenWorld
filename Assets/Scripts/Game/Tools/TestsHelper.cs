using Game.Character;
using Game.Character.CharacterController;
using Game.GlobalComponent.HelpfulAds;
using System;
using UnityEngine;

namespace Game.Tools
{
	public class TestsHelper : MonoBehaviour
	{
		public HitEntity CurrentHitEntity;

		public float dmg = 100f;

		[Space(6f)]
		[InspectorButton("SetDamage")]
		public bool damage;

		[Space(6f)]
		public bool CanWakeUp = true;

		[Space(6f)]
		[InspectorButton("ChangeOnRagdoll")]
		public bool ragdoll;

		[Space(6f)]
		[InspectorButton("HelpfulAds")]
		public bool adsReset;

		private void Awake()
		{
			if (!CurrentHitEntity)
			{
				CurrentHitEntity = PlayerInteractionsManager.Instance.Player;
			}
		}

		public void SetDamage()
		{
			if (!CurrentHitEntity)
			{
				throw new Exception("Don't have hit entity for set damage");
			}
			CurrentHitEntity.OnHit(DamageType.Instant, null, dmg, Vector3.zero, Vector3.zero);
		}

		public void ChangeOnRagdoll()
		{
			if (!CurrentHitEntity)
			{
				throw new Exception("Don't have hit entity for change on ragdoll");
			}
			Human human = CurrentHitEntity as Human;
			if (!human)
			{
				throw new Exception("Can't change on ragdoll");
			}
			human.ReplaceOnRagdoll(CanWakeUp);
		}

		public void HelpfulAds()
		{
			HelpfullAdsManager.Instance.HelpTimerLength = 0f;
		}
	}
}
