using Game.Character.Extras;
using Game.Character.Stats;
using Game.Factions;
using Game.GlobalComponent;
using Game.GlobalComponent.Qwest;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;
using Game.Character.CharacterController;

namespace Game.Character.CharacterController
{
	public class PlayerDieManager : MonoBehaviour
	{
		[Serializable]
		public class RagdolChanger
		{
			public DamageType LastHitDamageType;

			public GameObject ChangedRagdoll;
		}

		[Serializable]
		public class UILinks
		{
			public MenuPanelManager MenuManager;

			public Animator DeadPanel;

			public GameObject revivePanel;

			public Image BlackScreen;

			public Text DeadMessageText;
		}

		public delegate void PlayerDied(float timeOfDeath);

		public delegate void PlayerResurrect(float resurrectionTime);

		private const float DeadEventDelay = 2f;

		private const int ClearAroundRadius = 160;

		private static PlayerDieManager instance;

		public UILinks Links;

		[Range(0.1f, 1f)]
		public float BlackScreenLevel;

		public float FadeSpeed = 0.1f;

		public string DeadMessage;

		public float TextTypingDelay = 0.2f;

		public float WaitingTime = 1f;

		public bool LostWeaponAfterDead = true;

		public int HospitalRessurectCost = 500;

		public GameObject HospitalRessurectPoint;

		public int PoliceRessurectCost = 1000;

		public GameObject PoliceRessurectPoint;

		public GameObject[] Ports;

		public bool dieInCar;

		[Separator("Ragdoll Changers")]
		public RagdolChanger[] RagdolChangers;

		public PlayerDied PlayerDiedEvent;

		public PlayerResurrect PlayerResurrectEvent;

		private bool deadEventTriggered;

		public Joystick JStick;

		public static PlayerDieManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = UnityEngine.Object.FindObjectOfType<PlayerDieManager>();
				}
				return instance;
			}
		}

		private Player player => PlayerManager.Instance.Player;

		private void Awake()
		{
			instance = this;
		}

		public void OnPlayerDie()
		{
			print("died");
			if (!deadEventTriggered)
			{
				deadEventTriggered = true;
				ResetPanel();
				if (PlayerDiedEvent != null)
				{
					PlayerDiedEvent(Time.time);
				}
				PlayerInteractionsManager.Instance.SwitchInOutVehicleButtons(vehicleIn: false, vehicleOut: false);
				FactionsManager.Instance.ChangePlayerRelations(Faction.Police, Relations.Neutral);
				FactionsManager.Instance.ChangeFriendlyFactionsRelation(Faction.Police, Relations.Neutral);
				CharacterPropsController.instance.PropHandles(false);
				PlayerManager.Instance.AnimationController.JetWing.SetActive(false);
				StartCoroutine(OnPlayerDieCoroutine());
				//JStick.StopDance();
			}
		}

		public GameObject GetSpecificRagdoll(DamageType lastDamageType)
		{
			RagdolChanger[] ragdolChangers = RagdolChangers;
			foreach (RagdolChanger ragdolChanger in ragdolChangers)
			{
				if (ragdolChanger.LastHitDamageType == lastDamageType)
				{
					return ragdolChanger.ChangedRagdoll;
				}
			}
			return null;
		}

		private void ResetPanel()
		{
			Links.BlackScreen.color = new Color(0f, 0f, 0f, 0f);
			Links.DeadMessageText.text = string.Empty;
		}

		private IEnumerator OnPlayerDieCoroutine()
		{
			Animator prevPanel = Links.MenuManager.GetCurrentPanel();
			Links.MenuManager.OpenPanel(Links.DeadPanel);
			while (true)
			{
				Color color = Links.BlackScreen.color;
				if (!(color.a < BlackScreenLevel))
				{
					break;
				}
				Image blackScreen = Links.BlackScreen;
				Color color2 = Links.BlackScreen.color;
				blackScreen.color = new Color(0f, 0f, 0f, color2.a + FadeSpeed);
				yield return new WaitForEndOfFrame();
			}
			EntityManager.Instance.ReturnToPoolAllEnemiesAroundPoint(player.transform.position, 160f);
			RessurectPlayer();
			for (int j = 0; j < DeadMessage.Length; j++)
			{
				Links.DeadMessageText.text += DeadMessage[j];
				yield return new WaitForSecondsRealtime(TextTypingDelay);
			}
			yield return new WaitForSecondsRealtime(WaitingTime);
			for (int i = Links.DeadMessageText.text.Length; i > 0; i--)
			{
				Links.DeadMessageText.text = Links.DeadMessageText.text.Remove(i - 1);
				yield return new WaitForSecondsRealtime(TextTypingDelay / 2f);
			}
			//AdsManager.instance.ShowInterstitial("PlayerDie");

			deadEventTriggered = false;
			while (true)
			{
				Color color3 = Links.BlackScreen.color;
				if (!(color3.a > 0f))
				{
					break;
				}
				Image blackScreen2 = Links.BlackScreen;
				Color color4 = Links.BlackScreen.color;
				blackScreen2.color = new Color(0f, 0f, 0f, color4.a - FadeSpeed * 2f);
				yield return new WaitForEndOfFrame();
			}
			Links.MenuManager.OpenPanel(prevPanel);
			Controls.SetControlsSubPanel(ControlsType.Character);
			yield return new WaitForSeconds(2f);
			Data_Ironbolt.SendGameOver (PlayerInfoManager.Level);
			//GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, " Level " + PlayerInfoManager.Level);
            AnalyticsManager.instance.ProgressionEvent(AnalyticsManager.eventType.LevelFail, GlobalConstant.openWorldMode, PlayerInfoManager.Level);
            //firebasecall1.Instance.Event("Player_Died_At_level= "+PlayerInfoManager.Level);
			if (dieInCar)
			{
				dieInCar = false;
				//GameEventManager.Instance.Event.PlayerDeadEvent(SuicideAchievment.DethType.CarAccident);
				Data_Ironbolt.SendDeathReason(SuicideAchievment.DethType.CarAccident);
			}
			else if (PlayerInteractionsManager.Instance.Player.LastDamageType == DamageType.Water)
			{
				//GameEventManager.Instance.Event.PlayerDeadEvent(SuicideAchievment.DethType.Drowing);
				Data_Ironbolt.SendDeathReason(SuicideAchievment.DethType.Drowing);
			}
			else if (PlayerInteractionsManager.Instance.Player.LastDamageType == DamageType.Explosion)
			{
				//GameEventManager.Instance.Event.PlayerDeadEvent(SuicideAchievment.DethType.Explosion);
				Data_Ironbolt.SendDeathReason(SuicideAchievment.DethType.Explosion);
			}
			else if (PlayerInteractionsManager.Instance.Player.LastDamageType == DamageType.Collision)
			{
				//GameEventManager.Instance.Event.PlayerDeadEvent(SuicideAchievment.DethType.Falling);
				Data_Ironbolt.SendDeathReason(SuicideAchievment.DethType.Falling);
			}
			else if (PlayerInteractionsManager.Instance.Player.LastDamageType == DamageType.Bullet)
			{
				//GameEventManager.Instance.Event.PlayerDeadEvent(SuicideAchievment.DethType.Shooting);
				Data_Ironbolt.SendDeathReason(SuicideAchievment.DethType.Shooting);
			}
			else
			{
				GameEventManager.Instance.Event.PlayerDeadEvent();
			}
		}

		private void RessurectPlayer()
		{
			player.Resurrect();
			int num = HospitalRessurectCost;
			Transform transform;
			if (player.LastDamageType == DamageType.Water)
			{
				if (LostWeaponAfterDead)
				{
					player.LostCurrentWeapon();
				}
				transform = Ports[0].transform;
				GameObject[] ports = Ports;
				foreach (GameObject gameObject in ports)
				{
					if (Vector3.Distance(player.transform.position, gameObject.transform.position) < Vector3.Distance(player.transform.position, transform.position))
					{
						transform = gameObject.transform;
					}
				}
			}
			else if (player.LastHitOwner != null && player.LastHitOwner.Faction == Faction.Police)
			{
				if (LostWeaponAfterDead)
				{
					player.LostCurrentWeapon();
				}
				transform = PoliceRessurectPoint.transform;
				num = PoliceRessurectCost;
			}
			else
			{
				transform = HospitalRessurectPoint.transform;
				num = HospitalRessurectCost;
			}
			player.GetComponent<DontGoThroughThings>().SetPrevPostion(transform.position);
			player.transform.position = transform.position;
			player.transform.rotation = transform.rotation;
			if (!player.IsTransformer && PlayerInfoManager.Money > 0 && PlayerInfoManager.Money >= num)
			{
				InGameLogManager.Instance.RegisterNewMessage(MessageType.NegativeMoney, "-" + num.ToString());
				PlayerInfoManager.Money -= num;
				PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
			}
			if (PlayerResurrectEvent != null)
			{
				PlayerResurrectEvent(Time.time);
			}
		}
	}
}
