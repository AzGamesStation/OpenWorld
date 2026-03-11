using Game.Character;
using Game.Items;
using Game.Shop;
using UnityEngine.UI;

namespace Game.UI
{
	public class PlayerVipLevelDisplay : PlayerInfoDisplayBase
	{
		public Image ImageLink;

		protected override PlayerInfoType GetInfoType()
		{
			return PlayerInfoType.VipLvL;
		}

		protected override void Display()
		{
			if (PlayerInfoManager.VipLevel > 0)
			{
				GameItem shopItemByType = ShopManager.Instance.GetShopItemByType<GameItemBonus>(ItemsTypes.Bonus, new object[2]
				{
					BonusTypes.VIP,
					PlayerInfoManager.VipLevel
				});
				if(shopItemByType)
				ImageLink.sprite = shopItemByType.ShopVariables.ItemIcon;
			}
		}
	}
}
