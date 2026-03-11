using Game.Character;
using Game.Character.CharacterController;
using Game.Character.Extras;
using Game.Factions;
using Game.GlobalComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
	public class RagdollStatus : HitEntity
	{
		private const float CanNotWakeUpSpeedPlayer = 0.3f;

		private const float CanNotWakeUpSpeedNpc = 0.1f;

		private const float BeginCheckWakeUpAbilityTime = 1f;

		private const float CheckWakeUpAbilityPeriod = 1f;

		private const float HeadDamageMultiplier = 5f;

		private const float DefaultDamageMultiplier = 1f;

		private const string HeadName = "mixamorig:Head";

		private const string ChestName = "mixamorig:Spine1";

		private const float ToSpecificBodyForceCounter = 1.5f;

		private static readonly List<string> SourcedBonesNames = new List<string>
		{
			"mixamorig:Hips",
			"mixamorig:Head",
			"mixamorig:Spine1",
			"mixamorig:LeftArm",
			"mixamorig:RightArm",
			"mixamorig:LeftLeg",
			"mixamorig:RightLeg"
		};

		[HideInInspector]
		public RagdollWakeUper wakeUper;

		public GameObject BoneSource;

		public CharacterWaterSensor WaterSensor;

		private List<RagdollDamageReciever> damageRecievers = new List<RagdollDamageReciever>();

		private float canNotWakeUpSpeed;

		private GameObject mainRootObject;

		private Rigidbody[] rigidbodies;

		protected override void Start()
		{
		}

		public override void Drowning(float waterDepth, float drowningDamageCounter = 1f)
		{
			wakeUper.Drowning(waterDepth);
			if (Dead)
			{
				return;
			}
			OnDie();
			if ((bool)mainRootObject)
			{
				Rigidbody[] componentsInChildren = mainRootObject.GetComponentsInChildren<Rigidbody>();
				Rigidbody[] array = componentsInChildren;
				foreach (Rigidbody rigidbody in array)
				{
					rigidbody.linearVelocity = Vector3.zero;
				}
			}
		}

		public void Init(float maxHp, float currentHp, Defence newDefence, GameObject rootObject, Faction newFaction)
		{
			mainRootObject = rootObject;
			EntityManager.Instance.RegisterLivingRagdoll(this);
			wakeUper = GetComponent<RagdollWakeUper>();
			Health.Max = maxHp;
			Health.Current = currentHp;
			Defence = newDefence;
			Dead = false;
			Faction = newFaction;
			canNotWakeUpSpeed = ((!wakeUper.IsPlayer()) ? 0.1f : 0.3f);
			if (rigidbodies == null)
			{
				rigidbodies = rootObject.GetComponentsInChildren<Rigidbody>();
			}
			if ((bool)WaterSensor)
			{
				WaterSensor.Init(this);
			}
			Rigidbody[] array = rigidbodies;
			foreach (Rigidbody rigidbody in array)
			{
				if (rigidbody == null || !SourcedBonesNames.Contains(rigidbody.name))
				{
					continue;
				}
				RagdollDamageReciever ragdollDamageReciever = rigidbody.GetComponent<RagdollDamageReciever>();
				if (ragdollDamageReciever == null)
				{
					ragdollDamageReciever = rigidbody.gameObject.AddComponent<RagdollDamageReciever>();
				}
				damageRecievers.Add(ragdollDamageReciever);
				ragdollDamageReciever.RdStatus = this;
				ragdollDamageReciever.Faction = newFaction;
				ragdollDamageReciever.NPCShootVectorOffset = Vector3.zero;
				ragdollDamageReciever.rootParent = rootObject.transform;
				if (rigidbody.name.Equals("mixamorig:Head"))
				{
					ragdollDamageReciever.DamageMultiplier = 5f;
				}
				else
				{
					ragdollDamageReciever.DamageMultiplier = 1f;
				}
				if (rigidbody.name.Equals("mixamorig:Spine1"))
				{
					GameObject fromPool = PoolManager.Instance.GetFromPool(BoneSource);
					if (fromPool == null)
					{
						break;
					}
					fromPool.transform.parent = rigidbody.transform;
					fromPool.transform.localPosition = Vector3.zero;
					fromPool.transform.localEulerAngles = Vector3.zero;
					ragdollDamageReciever.RecieverSensor = fromPool;
				}
			}
		}

		public void CheckWakeUpAbility()
		{
			if (base.gameObject.activeSelf)
			{
				StartCoroutine(CheckWakeUpAbilityCoroutine());
			}
		}

		public void ApplyForce(Rigidbody appliedBodyPart, Vector3 force)
		{
			if (rigidbodies == null)
			{
				rigidbodies = mainRootObject.GetComponentsInChildren<Rigidbody>();
			}
			Rigidbody[] array = rigidbodies;
			foreach (Rigidbody rigidbody in array)
			{
				float d = 1f;
				if (rigidbody == appliedBodyPart)
				{
					d = 1.5f;
				}
				rigidbody.AddForce(force * d, ForceMode.VelocityChange);
			}
		}

		private IEnumerator CheckWakeUpAbilityCoroutine()
		{
			yield return new WaitForSeconds(2f);
			WaitForSeconds checkWakeUpAbilityCoroutine = new WaitForSeconds(1f);
			while (true)
			{
				bool canWakeUp = true;
				foreach (RagdollDamageReciever damageReciever in damageRecievers)
				{
					if (damageReciever.Magnitude > canNotWakeUpSpeed)
					{
						canWakeUp = false;
						break;
					}
				}
				if (canWakeUp)
				{
					break;
				}
				wakeUper.TryWakeup();
				yield return checkWakeUpAbilityCoroutine;
			}
			wakeUper.SetRagdollWakeUpStatus(wakeUp: true);
		}

		public void DeInit()
		{
			foreach (RagdollDamageReciever damageReciever in damageRecievers)
			{
				damageReciever.DeInit();
				UnityEngine.Object.Destroy(damageReciever);
			}
			damageRecievers.Clear();
			rigidbodies = null;
			EntityManager.Instance.UnregisterRagdoll(this);
		}

		public override void OnHit(DamageType damageType, HitEntity owner, float damage, Vector3 hitPos, Vector3 hitVector, float defenceReduction = 0f)
		{
			if ((bool)wakeUper.OriginHitEntity)
			{
				wakeUper.OriginHitEntity.KilledByAbillity = KilledByAbillity;
			}
			base.OnHit(damageType, owner, damage, hitPos, hitVector, defenceReduction);
			wakeUper.OnHealthChange(damage);
		}

		protected override void OnDie(DamageType damageType = DamageType.Bullet)
		{
			Dead = true;
			if ((bool)wakeUper.OriginHitEntity)
			{
				wakeUper.OriginHitEntity.KilledByAbillity = KilledByAbillity;
				wakeUper.OriginHitEntity.Die(LastHitOwner);
			}
			if (!(wakeUper.OriginHitEntity is Player))
			{
				wakeUper.DeInitRagdoll(mainObjectDead: true);
			}
		}
	}
}
