using Game.Character;
using Game.GlobalComponent;
using Game.Shop;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusesManager : MonoBehaviour
{
	private const string bonusReceivingTimeKey = "BonusReceiving";

	private const string currentBonusIndexKey = "BonusIndex";

	private static DailyBonusesManager instance;

	public DailyBonus[] Bonuses;

	[Space(10f)]
	public ScrollRect BonusListRect;

	public GameObject EmptyBonus;

	public GameObject InfoPrimitivePrefab;

	public GameObject GetBonusButton;

	public GameObject ContentContainer;

	private int currentBonusIndex;

	private int todayBonusIndex;

	private long bonusReceivingTime;

	private DailyBonusUIButton currentSelected;

	private bool inited;

	public static DailyBonusesManager Instance => instance ?? (instance = UnityEngine.Object.FindObjectOfType<DailyBonusesManager>());

	public bool SomeBonusAvailable => TimeManager.AnotherDay(bonusReceivingTime);

	private void Awake()
	{
		Init();
	}

	private void Start()
	{
		if (inited && TimeManager.AnotherDay(bonusReceivingTime))
		{
			ShowBonusesPanel();
		}

	}

	public void Init()
	{
		if (!inited)
		{
			currentBonusIndex = BaseProfile.ResolveValue("BonusIndex", 0);
			todayBonusIndex = currentBonusIndex;
			bonusReceivingTime = BaseProfile.ResolveValue("BonusReceiving", 0L);
			inited = true;
		}
	}

	private void ShowBonusInfo(int bonusID)
	{
		Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();
		if (Bonuses[bonusID].Gems != 0)
		{
			dictionary.Add("Gems: " + Bonuses[bonusID].Gems, ShopManager.Instance.ShopIcons.Gems);
		}
		if (Bonuses[bonusID].Money != 0)
		{
			dictionary.Add("Money: " + Bonuses[bonusID].Money, ShopManager.Instance.ShopIcons.Money);
		}
		if (Bonuses[bonusID].Item != null)
		{
			dictionary.Add(Bonuses[bonusID].Item.ShopVariables.Name, Bonuses[bonusID].Item.ShopVariables.ItemIcon);
		}
		ShowBonusReward(dictionary, bonusID == currentBonusIndex);
	}

	public DailyBonus GetTodayBonus()
	{
		return Bonuses[todayBonusIndex];
	}

	public void ProceedCurrentBonus()
	{
		ProceedBonus(GetTodayBonus());
		currentBonusIndex = todayBonusIndex + 1;
		if (currentBonusIndex >= Bonuses.Length)
		{
			currentBonusIndex = 0;
		}
		bonusReceivingTime = DateTime.Today.ToFileTime();
		BaseProfile.StoreValue(currentBonusIndex, "BonusIndex");
		BaseProfile.StoreValue(bonusReceivingTime, "BonusReceiving");
		HideBonusesPanel();
	}

	private void ProceedBonus(DailyBonus bonus)
	{
		PlayerInfoManager.Money += bonus.Money;
		PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
		PlayerInfoManager.Gems += bonus.Gems;
		if (bonus.Item != null)
		{
			ShopManager.Instance.Give(bonus.Item);
		}
	}

	private void ShowBonusesPanel()
	{
		BonusListRect.transform.parent.gameObject.SetActive(value: true);
		GenerateBonusList();
	}

	private void HideBonusesPanel()
	{
		BonusListRect.transform.parent.gameObject.SetActive(value: false);
	}

	private void GenerateBonusList()
	{
		for (int i = 0; i < Bonuses.Length; i++)
		{
			DailyBonusUIButton component = UnityEngine.Object.Instantiate(EmptyBonus, BonusListRect.content.transform).GetComponent<DailyBonusUIButton>();
			component.transform.localScale = Vector3.one;
			component.BonusID = i;
			if (i >= currentBonusIndex)
			{
				component.Image.sprite = Bonuses[i].Icon;
				component.BonusViewState(gained: false);
			}
			else
			{
				component.Image.sprite = Bonuses[i].ReceivedIcon;
				component.BonusViewState(gained: true);
			}
		}
		SelectBonusUIButton(BonusButtonByIndex(currentBonusIndex));
	}

	public void SelectBonusUIButton(DailyBonusUIButton bonusButton)
	{
		if (currentSelected != null)
		{
			currentSelected.transform.localScale = Vector3.one;
		}
		currentSelected = bonusButton;
		currentSelected.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
		ShowBonusInfo(bonusButton.BonusID);
	}

	private DailyBonusUIButton BonusButtonByIndex(int index)
	{
		return BonusListRect.content.GetChild(index).GetComponent<DailyBonusUIButton>();
	}

	private void ShowBonusReward(Dictionary<string, Sprite> output, bool isAvailable)
	{
		ClearRewardContainer();
		foreach (KeyValuePair<string, Sprite> item in output)
		{
			GameObject fromPool = PoolManager.Instance.GetFromPool(InfoPrimitivePrefab);
			fromPool.transform.SetParent(ContentContainer.transform, worldPositionStays: false);
			BonusInfoPrimitive component = fromPool.GetComponent<BonusInfoPrimitive>();
			component.transform.localScale = Vector3.one;
			component.InfoText.text = item.Key;
			component.IconImage.sprite = item.Value;
		}
	}

	private void ClearRewardContainer()
	{
		int childCount = ContentContainer.transform.childCount;
		GameObject[] array = new GameObject[childCount];
		for (int i = 0; i < childCount; i++)
		{
			array[i] = ContentContainer.transform.GetChild(i).gameObject;
		}
		GameObject[] array2 = array;
		foreach (GameObject o in array2)
		{
			PoolManager.Instance.ReturnToPool(o);
		}
	}

	public void WatchVideoAd()
	{
		GlobalContants.gemsPack5 = true;
		RewardedAdsController.Instance.ShowRewarded("DailyBonus");
	}
}
