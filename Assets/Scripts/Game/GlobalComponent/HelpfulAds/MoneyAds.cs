using Game.Character;
using UnityEngine;

namespace Game.GlobalComponent.HelpfulAds
{
	public class MoneyAds : HelpfulAds
	{
		public bool ByGems;

		public int AddedMoney = 300;

		public HelpfullAdsType AdsType = HelpfullAdsType.Money;

		public override HelpfullAdsType HelpType()
		{
			return AdsType;
		}

		public override void HelpAccepted()
		{
			if (ByGems)
			{
				PlayerInfoManager.Gems += AddedMoney;
				return;
			}
			PlayerInfoManager.Money += AddedMoney;
			PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
			InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, AddedMoney.ToString());
		}
	}
}
