using Game.Managers;
using UnityEngine;

namespace Game.Character.Stats
{
	public class UpgradeManager : MonoBehaviour
	{
		public UpgradePanel[] Panels;

		public int[] LevelPerStatLevel;

		private static UpgradeManager instance;

		public static UpgradeManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = UnityEngine.Object.FindObjectOfType<UpgradeManager>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
		}

		public void SwitchBackground(PanelsList panel)
		{
			UpgradePanel[] panels = Panels;
			foreach (UpgradePanel upgradePanel in panels)
			{
				if (upgradePanel.type == panel)
				{
					upgradePanel.OnState.SetActive(value: true);
					upgradePanel.OffState.SetActive(value: false);
				}
				else
				{
					upgradePanel.OnState.SetActive(value: false);
					upgradePanel.OffState.SetActive(value: true);
				}
			}
		}

		public void UpgradeStat(UpgradeElement element)
		{
			Upgrade(element);
		}

		private void Upgrade(UpgradeElement element)
		{
			if (PlayerInfoManager.UpgradePoints >= 1 && EnoughLevelForStatUping(element))
			{
				int stat = StatsManager.GetStat(element.stat);
				if (stat < 5)
				{
					stat++;
					PlayerInfoManager.UpgradePoints--;
					StatsManager.SaveStat(element.stat, stat);
					element.progressBar.value = stat;
					PlayerInteractionsManager.Instance.Player.UpdateStats();
				}
				else if (GameManager.ShowDebugs)
				{
					UnityEngine.Debug.Log("max lvl for this stat");
				}
			}
			else if (GameManager.ShowDebugs)
			{
				UnityEngine.Debug.Log("Not enught upgrade points or not Enough Level For Stat Uping");
			}
		}

		public bool EnoughLevelForStatUping(UpgradeElement element)
		{
			if (LevelPerStatLevel.Length == 0)
			{
				return true;
			}
			if (PlayerInfoManager.Level >= LevelPerStatLevel[LevelPerStatLevel.Length - 1])
			{
				return true;
			}
			if (LevelPerStatLevel[StatsManager.GetStat(element.stat)] <= PlayerInfoManager.Level)
			{
				return true;
			}
			return false;
		}
	}
}
