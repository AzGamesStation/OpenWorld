using UnityEngine;
using UnityEngine.UI;

namespace Game.Character.Stats
{
	public class UpgradeElement : MonoBehaviour
	{
		public PanelsList panel;

		public StatsList stat;

		public Image ButtonImage;

		public Slider progressBar;

		private bool IsCanRaise => PlayerInfoManager.UpgradePoints >= 1 && UpgradeManager.Instance.EnoughLevelForStatUping(this);

		private void Start()
		{
			progressBar.value = StatsManager.GetStat(stat);
			PlayerInfoManager.Instance.AddOnValueChangedEvent(PlayerInfoType.UpgradePoints, OnUpgradePointsChangeHandler);
		}

		private void OnUpgradePointsChangeHandler(int upgradePoints)
		{
			UpdateButtonImage();
		}

		public void Upgrade()
		{
			UpgradeManager.Instance.UpgradeStat(this);
			UpdateButtonImage();
		}

		public void SwitchButton()
		{
			UpgradeManager.Instance.SwitchBackground(panel);
		}

		public void UpdateButtonImage()
		{
			ButtonImage.color = ((!IsCanRaise) ? new Color(1f, 1f, 1f, 0.3f) : Color.white);
		}

		private void OnEnable()
		{
			UpdateButtonImage();
		}
	}
}
