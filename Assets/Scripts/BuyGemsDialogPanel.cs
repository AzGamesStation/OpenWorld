using Game.GlobalComponent.HelpfulAds;
using Game.Items;
using Game.Weapons;
using UnityEngine;

public class BuyGemsDialogPanel : ShopDialogPanel
{
	//[Space(20f)]
	//public IAPMiamiManager InappsManager;

	public override void ProceedSlot(DialogSlotHelper helper)
	{
		DialogBuyGemsSlotHelper dialogBuyGemsSlotHelper = helper as DialogBuyGemsSlotHelper;
		if (!(dialogBuyGemsSlotHelper == null))
		{
			if (dialogBuyGemsSlotHelper.ForFree)
			{
				HelpfullAdsManager.Instance.OfferAssistance(HelpfullAdsType.FreeGems, Refresh);
				dialogBuyGemsSlotHelper.UpdateSlot(IsAvailable: false, GetImage(helper), CheckHighlighted(dialogBuyGemsSlotHelper, currItem));
			}
			else
			{
				//IAPController.Buy(InappsManager.GemPacks[dialogBuyGemsSlotHelper.SlotIndex].Item);
			}
		}
	}

	public void Refresh(bool any)
	{
	}

	public override bool CheckAvailable(DialogSlotHelper helper, GameItem item)
	{
		DialogBuyGemsSlotHelper dialogBuyGemsSlotHelper = helper as DialogBuyGemsSlotHelper;
		if (dialogBuyGemsSlotHelper == null)
		{
			return false;
		}
		if (dialogBuyGemsSlotHelper.ForFree)
		{
			//return HelpfullAdsManager.Instance.IsReady;
		}
		return true;
	}

	public override Sprite GetImage(DialogSlotHelper helper)
	{
		DialogBuyGemsSlotHelper dialogBuyGemsSlotHelper = helper as DialogBuyGemsSlotHelper;
		if (dialogBuyGemsSlotHelper == null)
		{
			return null;
		}
		if (dialogBuyGemsSlotHelper.PriceText != null)
		{
			//dialogBuyGemsSlotHelper.PriceText.text = ((!dialogBuyGemsSlotHelper.ForFree) ? IAPController.Items[InappsManager.GemPacks[dialogBuyGemsSlotHelper.SlotIndex].Item].FormattedPrice : "FREE!");
		}
		if (dialogBuyGemsSlotHelper.ValueText != null)
		{
			//dialogBuyGemsSlotHelper.ValueText.text = ((!dialogBuyGemsSlotHelper.ForFree) ? ("X" + InappsManager.GemPacks[dialogBuyGemsSlotHelper.SlotIndex].GemValue) : ("X" + (HelpfullAdsManager.Instance.GetAdsByType(HelpfullAdsType.FreeGems) as MoneyAds).AddedMoney));
		}
		//return (!dialogBuyGemsSlotHelper.ForFree) ? InappsManager.GemPacks[dialogBuyGemsSlotHelper.SlotIndex].Icon : InappsManager.FreeGemsIcon;
		return null;
	}
}
