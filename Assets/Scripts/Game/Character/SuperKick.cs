using Game.Character.CharacterController;
using Game.Enemy;
using Game.GlobalComponent;
using Game.Shop;
using Game.Vehicle;
using UnityEngine;

namespace Game.Character
{
	public class SuperKick : MonoBehaviour
	{
		private const string SuperKickAxisName = "SuperKick";

		private const float MaxKickDistance = 5f;

		public static bool isInKickState;

		public GameObject SuperKickButton, SuperSlapButton;

		public Rigidbody MainRigidbody;

		public LayerMask GroundLayerMask;

		public float TimeOffsetForAnimation = 0.5f;

		public float kickDamage = 100f;

		public float HorizontalPushForce = 700f;

		public float VerticalPushForce = 250f;

		public bool IgnoreMass = true;

		public int staminaForKick = 50;

		public ForceMultipliers multipliers;

		public bool debug;

		private GameObject lastTarget;

		private Vector3 hitPosition;

		private float distance;

		private float currentMultipler;

		private float kickTimer;

		private bool isAbleToKick;

		private bool isGrounded;

		private bool isEnoughStamina;

		private bool isEnoughClose;

		private AnimationController animationController;

		private Player player;

		private bool KickConditions => isAbleToKick && isGrounded && isEnoughStamina && isEnoughClose && !player.MoveToCar && player.isActiveAndEnabled && kickTimer < 0f && (!player.IsTransformer || !player.Transformer.transformating);

		private void Start()
		{
			animationController = base.transform.GetComponentInParent<AnimationController>();
			player = PlayerInteractionsManager.Instance.Player;
		}

		private void OnTriggerStay(Collider other)
		{
			if (!isAbleToKick)
			{
				isAbleToKick = true;
				lastTarget = other.gameObject;
				hitPosition = other.transform.position;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject == lastTarget)
			{
				isAbleToKick = false;
				isInKickState = false;
			}
		}

		public void Reset()
		{
			isAbleToKick = false;
			isInKickState = false;
			SuperKickButton.SetActive(value: false);
			SuperSlapButton.SetActive(false);
		}

		private void Update()
		{
			EnableButton();
			KickProcessing();
			StaminaProcessing();
		}

		private void FixedUpdate()
		{
			GroundCheck();
			DistanceCheck();
			kickTimer -= Time.deltaTime;
		}

		private void KickProcessing()
		{
			if (Controls.GetButtonDown("SuperKick") && KickConditions)
			{
				kickTimer = 3f;
				isInKickState = true;
				StartAnim();
				Invoke("Kick", TimeOffsetForAnimation);
				StaminaProcessing(spendStamina: true);
			}

			if (Controls.GetButtonDown("SuperSlap") && KickConditions)
			{
				kickTimer = 3f;
				isInKickState = true;
				SlapAnim();
				Invoke("Kick", TimeOffsetForAnimation);
				StaminaProcessing(spendStamina: true);
			}
		}

		private void StartAnim()
		{
			animationController.MainAnimator.SetTrigger("DoAbility");
		}

		private void SlapAnim()
		{
			animationController.MainAnimator.SetTrigger("DoSlap");
		}

		private void EnableButton()
		{
			if (KickConditions && !CharacterPropsController.instance.isSkating)
			{
				SuperKickButton.SetActive(value: true);
				SuperSlapButton.SetActive(value: true);
			}
			else
			{
				SuperKickButton.SetActive(value: false);
				SuperSlapButton.SetActive(value: false);
			}
		}

		private void DistanceCheck()
		{
			if ((bool)lastTarget)
			{
				distance = Vector3.Distance(lastTarget.transform.position, player.transform.position);
				isEnoughClose = (distance <= 5f);
				if (!isEnoughClose)
				{
					lastTarget = null;
					isAbleToKick = false;
				}
			}
		}

		private void GroundCheck()
		{
			isGrounded = (animationController.AnimOnGround && !player.IsSwiming);
		}

		private void Push(Rigidbody r, float multiplier)
		{
			Vector3 a = base.transform.forward * HorizontalPushForce + base.transform.up * VerticalPushForce;
			Vector3 torque = -base.transform.up;
			float d = (!IgnoreMass) ? 1f : r.mass;
			r.AddForceAtPosition(a * d * multiplier, base.transform.position + Vector3.up);
			r.AddTorque(torque);
			isInKickState = false;
		}

		private void Kick()
		{
			if (!lastTarget)
			{
				isInKickState = false;
				return;
			}
			hitPosition = lastTarget.transform.position;
			HitEntity component = lastTarget.GetComponent<HitEntity>();
			if (component != null && component.DeadByDamage(kickDamage))
			{
				component.KilledByAbillity = WeaponNameList.SuperKick;
			}
			Human component2 = lastTarget.GetComponent<Human>();
			Rigidbody componentInChildren;
			if ((bool)component2)
			{
				currentMultipler = multipliers.human;
				component2.ReplaceOnRagdoll(!component2.DeadByDamage(kickDamage), out GameObject initRagdoll);
				componentInChildren = initRagdoll.GetComponentInChildren<Rigidbody>();
				component2.OnHit(DamageType.MeleeHit, player, kickDamage, hitPosition, player.transform.forward);
				Push(componentInChildren, currentMultipler);
				PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickHumen);
				return;
			}
			BodyPartDamageReciever component3 = lastTarget.GetComponent<BodyPartDamageReciever>();
			if ((bool)component3)
			{
				HumanoidStatusNPC humanoidStatusNPC = component3.RerouteEntity as HumanoidStatusNPC;
				if ((bool)humanoidStatusNPC)
				{
					humanoidStatusNPC.BaseNPC.ChangeController(BaseNPC.NPCControllerType.Smart, out BaseControllerNPC controller);
					SmartHumanoidController smartHumanoidController = controller as SmartHumanoidController;
					if (smartHumanoidController != null)
					{
						smartHumanoidController.AddTarget(player);
						smartHumanoidController.InitBackToDummyLogic();
					}
					if (humanoidStatusNPC.DeadByDamage(kickDamage))
					{
						humanoidStatusNPC.KilledByAbillity = WeaponNameList.Ability;
					}
					if (humanoidStatusNPC.Ragdollable)
					{
						humanoidStatusNPC.ReplaceOnRagdoll(humanoidStatusNPC.Health.Current - kickDamage, out GameObject _);
						componentInChildren = humanoidStatusNPC.GetRagdollHips().GetComponent<Rigidbody>();
						Push(componentInChildren, multipliers.human);
					}
					humanoidStatusNPC.OnHit(DamageType.MeleeHit, player, kickDamage, hitPosition, player.transform.forward);
					PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickHumen);
					return;
				}
			}
			componentInChildren = lastTarget.GetComponent<Rigidbody>();
			if ((bool)componentInChildren)
			{
				RagdollDamageReciever component4 = componentInChildren.transform.GetComponent<RagdollDamageReciever>();
				if ((bool)component4)
				{
					RagdollWakeUper component5 = component4.rootParent.GetComponent<RagdollWakeUper>();
					if ((bool)component5 && component5.CurrentState != RagdollState.Ragdolled)
					{
						component5.SetRagdollWakeUpStatus(wakeUp: false);
					}
					component4.OnHit(DamageType.MeleeHit, player, 1000f, hitPosition, player.transform.forward);
					PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickHumen);
					isInKickState = false;
					return;
				}
				Rigidbody[] componentsInParent = componentInChildren.GetComponentsInParent<Rigidbody>();
				Rigidbody[] array = componentsInParent;
				foreach (Rigidbody rigidbody in array)
				{
					if (rigidbody.name == "hips")
					{
						componentInChildren = rigidbody;
						RagdollWakeUper componentInChildren2 = componentInChildren.gameObject.GetComponentInChildren<RagdollWakeUper>();
						if (componentInChildren2 != null)
						{
							componentInChildren2.DeInitRagdoll(mainObjectDead: true);
						}
						PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickHumen);
						break;
					}
				}
				Push(componentInChildren, multipliers.ragdoll);
				return;
			}
			componentInChildren = lastTarget.GetComponentInParent<Rigidbody>();
			if ((bool)componentInChildren)
			{
				DrivableVehicle component6 = componentInChildren.transform.GetComponent<DrivableVehicle>();
				DrivableMotorcycle component7 = componentInChildren.GetComponent<DrivableMotorcycle>();
				if ((bool)component6)
				{
					DrivableCar drivableCar = component6 as DrivableCar;
					if ((bool)drivableCar)
					{
						WheelCollider[] wheels = drivableCar.wheels;
						foreach (WheelCollider wheelCollider in wheels)
						{
							wheelCollider.brakeTorque = 0f;
						}
					}
					PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickCar);
					currentMultipler = multipliers.car;
				}
				if ((bool)component7)
				{
					if ((bool)component7.DummyDriver)
					{
						component7.MainRigidbody.constraints = RigidbodyConstraints.None;
						component7.DummyDriver.DropRagdoll(player, component7.transform.up, canWakeUp: false);
					}
					currentMultipler = multipliers.motorcycle;
				}
				PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickCar);
				Push(componentInChildren, currentMultipler);
			}
			else
			{
				PseudoDynamicObject component8 = lastTarget.GetComponent<PseudoDynamicObject>();
				if ((bool)component8)
				{
					component8.ReplaceOnDynamic();
					componentInChildren = component8.GetComponent<Rigidbody>();
					PointSoundManager.Instance.PlaySoundAtPoint(base.transform.position, TypeOfSound.KickObj);
					Push(componentInChildren, multipliers.PDO);
				}
				else
				{
					isInKickState = false;
				}
			}
		}

		private void StaminaProcessing(bool spendStamina = false)
		{
			if (player.stats.stamina.Current >= (float)staminaForKick)
			{
				isEnoughStamina = true;
				if (spendStamina)
				{
					player.stats.stamina.SetAmount(-staminaForKick);
				}
			}
			else
			{
				isEnoughStamina = false;
			}
		}
	}
}
