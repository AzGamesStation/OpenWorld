using UnityEngine;
using UnityEngine.UI;
using Game.Character;
public class DialogSlotHelper : MonoBehaviour
{
	public ShopDialogPanel DialogPanel;

	public bool BuyFirst;

	public int SlotIndex;

	[Space(10f)]
	public Button Button;

	public Image ButtonIcon;

	public Image ItemIcon;

	public Sprite EmptySlotIcon;

	[Space(10f)]
	public Color AvailavleColor;

	public Color NotAvailavleColor;

	public Color HighlightedColor;
	public bool isWeapons;

	private void Start()
	{
		if (Button == null)
		{
			Button = GetComponent<Button>();
		}
		if (ButtonIcon == null)
		{
			ButtonIcon = GetComponent<Image>();
		}
	}

	public void FreeGemsRewardedVideo()
	{
		if (RewardedAdsController.Instance)
		{
			GlobalContants.freeGems = true;
			RewardedAdsController.Instance.ShowRewarded("FreeGems");
		}
	}

	public void Watch2RewardedAds()
    {
		if (RewardedAdsController.Instance)
		{
			GlobalContants.freeGems = true;
			RewardedAdsController.Instance.ShowRewarded("FreeGems");
		}
	}

	public void Watch3RewardedAds()
	{
		if (RewardedAdsController.Instance)
		{
			GlobalContants.freeGems = true;
			RewardedAdsController.Instance.ShowRewarded("FreeGems");
		}
	}

	public void Watch4RewardedAds()
	{
		if (RewardedAdsController.Instance)
		{
			GlobalContants.freeGems = true;
			RewardedAdsController.Instance.ShowRewarded("FreeGems");
		}
	}

	public void Watch5RewardedAds()
	{
		if (RewardedAdsController.Instance)
		{
			GlobalContants.freeGems = true;
			RewardedAdsController.Instance.ShowRewarded("FreeGems");
		}
	}

    public void pack1Purchase()
    {
		if(PlayerInfoManager.Money>=10000)
        {
			PlayerInfoManager.Gems += 500;
		}
        //if (MyIAPManager_IronBolt.Instance)
        //{
        //    MyIAPManager_IronBolt.Instance.GemsPack1();
        //}
    }

    public void pack2Purchase()
    {
		if (PlayerInfoManager.Money >= 15000)
		{
			PlayerInfoManager.Gems += 500;
		}
		//if (MyIAPManager_IronBolt.Instance)
		//{
		//    MyIAPManager_IronBolt.Instance.GemsPack2();
		//}
	}


    public void pack3Purchase()
    {
		if (PlayerInfoManager.Money >= 25000)
		{
			PlayerInfoManager.Gems += 5000;
		}
		//if (MyIAPManager_IronBolt.Instance)
		//{
		//    MyIAPManager_IronBolt.Instance.GemsPack3();
		//}
	}


    public void pack4Purchase()
    {
		if (PlayerInfoManager.Money >= 40000)
		{
			PlayerInfoManager.Gems += 10000;
		}
		//if (MyIAPManager_IronBolt.Instance)
		//{
		//    MyIAPManager_IronBolt.Instance.GemsPack4();
		//}
	}


    public void OnClick()
	{
		if (!BuyFirst)
		{
			DialogPanel.ProceedSlot(this);
		}
		else
		{
			DialogPanel.BuySlot(this);
		}
	}

	public virtual void UpdateSlot(bool IsAvailable, Sprite sprite, bool highlighted)
	{
		if (IsAvailable)
		{
			Button.interactable = true;
			ButtonIcon.color = AvailavleColor;
		}
		else
		{
			Button.interactable = false;
			ButtonIcon.color = NotAvailavleColor;
		}
		if (highlighted)
		{
			ButtonIcon.color = HighlightedColor;
		}
		if (isWeapons)
		{
			if ((bool)sprite)
			{
				ItemIcon.sprite = sprite;
				ItemIcon.gameObject.SetActive(value: true);
			}
			else
			{
				ItemIcon.gameObject.SetActive(value: false);
			}
		}
	}
}