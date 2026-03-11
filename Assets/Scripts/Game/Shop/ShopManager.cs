using Common.Analytics;
using Game.Character;
using Game.Character.Superpowers;
using Game.GlobalComponent.Qwest;
using Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Shop
{
	public class ShopManager : MonoBehaviour
	{
		public delegate void ShopOpened();

		public delegate void ShopClosed();

		private const string BIKeysArrayName = "BoughtItemsKeys";

		private const string BIValuesArrayName = "BoughtItemsValues";

		private const string GemsPrefix = "Gems";

		private static ShopManager instance;

		public bool ShowDebug;

		[Space(10f)]
		public ShopLinks Links;

		[Space(10f)]
		public ShopIcons ShopIcons;

		[Space(10f)]
		public GameObject GameItemsHierarhy;

		[Space(10f)]
		public GameObject BlankElement;

		public GameObject BlankCategory;

		public GameObject BlankContainer;

		[Space(10f)]
		public GameObject BuyGemsPanel;
		public GameObject BuyCashPanel;

		[Space(10f)]
		public ShopCategory activeCategory;

		public ShopItem currentItem;

		public ShopOpened ShopOpeningEvent;

		public ShopClosed ShopCloseningEvent;

		private bool inited;

		private bool selected;

		private ShopDialogPanel currDialogPanel;

		private Dictionary<ItemsTypes, Dictionary<ShopCategory, List<ShopItem>>> ShopStuff = new Dictionary<ItemsTypes, Dictionary<ShopCategory, List<ShopItem>>>();

		public static ShopManager Instance => instance ?? (instance = UnityEngine.Object.FindObjectOfType<ShopManager>());

		public static bool IsOpen => instance.Links.Categories.activeInHierarchy;

		public static Dictionary<int, int> BoughtItemsCoins
		{
			get;
			private set;
		}

		public static Dictionary<int, int> BoughtItemsGems
		{
			get;
			private set;
		}

		[Header("Unlock All Items")]
		public GameItemWeapon[] weapons;
		public GameItemVehicle[] Vehicles;
		public GameItemClothes[] Skins;


		private void Awake()
		{
			Init();
			PlayerInfoManager.Gems = PlayerPrefs.GetInt("Gems");
            //PlayerInfoManager.Gems = 100000;

            //Debug.Log("UnlockEverything :: " + PlayerPrefs.GetString("UnlockEveryThing", "False"));

            if (PlayerPrefs.GetString ("UnlockEveryThing", "False") == "true")
			{

				UnlockEverthing();
			}
		}
		public void UnlockEverthing()
		{
			for (int i = 0; i < weapons.Length; i++)
			{
				weapons[i].ShopVariables.price = 0;
			}

			for (int i = 0; i < Vehicles.Length; i++)
			{
				Vehicles[i].ShopVariables.price = 0;
			}

			for (int i = 0; i < Skins.Length; i++)
			{
				Skins[i].ShopVariables.price = 0;
			}
		}


		public void UnlockEverythingInApp()
		{
			//MyIAPManager_IronBolt.Instance.UnlockEverything();
		}
        private void Init()
		{
			if (!inited)
			{
				instance = this;
				StartCoroutine("LoadPreviewRoom");
				ItemsManager.Instance.Init();
				StuffManager.Instance.Init();
				PlayerAbilityManager.LoadAbilities();
				PlayerAbilityManager.EnableEbilities();
				Links.InfoPanelManager.Init();
				LoadBI();
				SalesManager.Instance.Init();
				DailyBonusesManager.Instance.Init();
				inited = true;
				FillShopStuffDictionary();
			}
		}

		public T GetShopItemByType<T>(ItemsTypes itemType, object[] parametrs) where T : GameItem
		{
			ShopCategory category;
			ShopItem item;
			return GetShopItemByType<T>(itemType, parametrs, out category, out item);
		}

		public T GetShopItemByType<T>(ItemsTypes itemType, object[] parametrs, out ShopCategory category, out ShopItem item) where T : GameItem
		{
			category = null;
			item = null;
			foreach (KeyValuePair<ShopCategory, List<ShopItem>> item2 in ShopStuff[itemType])
			{
				foreach (ShopItem item3 in item2.Value)
				{
					T val = item3.GameItem as T;
					if ((bool)(UnityEngine.Object)val && item3.GameItem.SameParametrWithOther(parametrs))
					{
						category = item2.Key;
						item = item3;
						return val;
					}
				}
			}
			return (T)null;
		}

		public List<ShopCategory> GetShopCategores()
		{
			List<ShopCategory> list = new List<ShopCategory>();
			foreach (KeyValuePair<ItemsTypes, Dictionary<ShopCategory, List<ShopItem>>> item in ShopStuff)
			{
				foreach (KeyValuePair<ShopCategory, List<ShopItem>> item2 in item.Value)
				{
					list.Add(item2.Key);
				}
			}
			return list;
		}

		public bool GetShopItem(int id, out ShopItem item, out ShopCategory category)
		{
			category = null;
			item = null;
			foreach (KeyValuePair<ItemsTypes, Dictionary<ShopCategory, List<ShopItem>>> item2 in ShopStuff)
			{
				foreach (KeyValuePair<ShopCategory, List<ShopItem>> item3 in item2.Value)
				{
					foreach (ShopItem item4 in item3.Value)
					{
						if (item4.GameItem.ID == id)
						{
							item = item4;
							category = item3.Key;
							return true;
						}
					}
				}
			}
			return false;
		}

		public static void ClearBI(bool coinsOnly = true)
		{
			BaseProfile.ClearArray<int>("BoughtItemsKeys");
			if (!coinsOnly)
			{
				BaseProfile.ClearArray<int>("GemsBoughtItemsKeys");
			}
		}

		public void Enable()
		{
			if (ShopOpeningEvent != null)
			{
				ShopOpeningEvent();
			}
			ChangeCategory(GetFirstCategory());
		}

		public void Disable()
		{
			if (ShopCloseningEvent != null)
			{
				ShopCloseningEvent();
			}
		}

		public bool BoughtAlredy(GameItem gameItem)
		{
			Dictionary<int, int> dictionary = (!gameItem.ShopVariables.gemPrice) ? BoughtItemsCoins : BoughtItemsGems;
			if (dictionary.ContainsKey(gameItem.ID))
			{
				return true;
			}
			return false;
		}

		public bool BoughtAlredy(int gameItemID)
		{
			return BoughtAlredy(ItemsManager.Instance.GetItem(gameItemID));
		}

		public void ChangeCategory(ShopCategory category)
		{
			if (activeCategory != null)
			{
				activeCategory.Container.SetActive(value: false);
				activeCategory.Back.sprite = ShopIcons.ShopButtonOff;
			}
			category.Container.SetActive(value: true);
			activeCategory = category;
			if (activeCategory != null)
			{
				activeCategory.Back.sprite = ShopIcons.ShopCategoryOn;
			}
			SelectItem(GetFirstItemInCategory(activeCategory));
		}

		public void SelectItem(ShopItem item)
		{
			bool flag = currentItem == item;
			if (currentItem != null)
			{
				currentItem.Back.sprite = ShopIcons.ShopButtonOff;
			}
			currentItem = item;
			if (currentItem != null)
			{
				currentItem.Back.sprite = ShopIcons.ShopItemOn;
				currentItem.GameItem.UpdateItem();
			}
			if (selected && flag && item.GameItem is GameItemSkin)
			{
				//PreviewManager.Instance.ShowItem(item, showOrigin: true);
				selected = false;
			}
			else
			{
				PreviewManager.Instance.ShowItem(item);
				selected = true;
			}
			if (ShowDebug)
			{
				UnityEngine.Debug.LogFormat(currentItem, "item selected {0}", currentItem.name);
			}
			if (currentItem.GameItem.ShopVariables.price == 0 && ItemAvailableForBuy(currentItem.GameItem))
			{
				Give(currentItem.GameItem);
			}
			else
			{
				UpdateInfo();
			}
		}

		public void Buy()
		{
			Buy(null);
		}

		public void Buy(GameItem item)
		{
			if (item == null)
			{
				item = currentItem.GameItem;
			}
			if (ShowDebug)
			{
				UnityEngine.Debug.LogFormat(item, "try buy item {0}", item.name);
			}
			float num = SalesManager.GetSale(item.ID) / 100f;
			int num2 = Mathf.RoundToInt((float)item.ShopVariables.price - (float)item.ShopVariables.price * num);
			if (item.ShopVariables.gemPrice)
			{
				PlayerInfoManager.Gems -= num2;
			}
			else
			{
				PlayerInfoManager.Money -= num2;
				PlayerInfoManager.Instance.AddSpendMoney(-num2);
			}
			GameEventManager.Instance.Event.GetShopEvent();
			GameEventManager.Instance.Event.BuyItemEvent(item);
			Give(item, onBuy: true);
		}

		public void Give()
        {
			Give(currentItem.GameItem, true);
        }

		public void Give(GameItem item, bool onBuy = false)
		{
			Dictionary<int, int> dictionary = (!item.ShopVariables.gemPrice) ? BoughtItemsCoins : BoughtItemsGems;
			if (dictionary.ContainsKey(item.ID))
			{
				if (item.ShopVariables.MaxAmount == 1)
				{
					return;
				}
				Dictionary<int, int> dictionary2;
				int iD;
				(dictionary2 = dictionary)[iD = item.ID] = dictionary2[iD] + item.ShopVariables.PerStackAmount;
			}
			else
			{
				dictionary.Add(item.ID, item.ShopVariables.PerStackAmount);
			}
			if (item.ShopVariables.InstantEquip || StuffManager.Instance.CanEquipInstantly(item, onBuy))
			{
				Equip(item, equipOnly: true);
			}
			item.OnBuy();
			SavePlayerInfo();
			UpdateInfo();
		}

		public void Equip()
		{
			Equip(null);
		}

		public void Equip(GameItem item, bool equipOnly = false)
		{
			if (item == null)
			{
				item = currentItem.GameItem;
			}
			StuffManager.Instance.EquipItem(item, equipOnly);
			UpdateInfo();
		}

		public void OpenDialogPanel(GameItem item)
		{
			GameObject gameObject = null;
			ShopDialogPanel[] dialogPanelPrefabs = Links.DialogPanelPrefabs;
			foreach (ShopDialogPanel shopDialogPanel in dialogPanelPrefabs)
			{
				bool flag = false;
				ItemsTypes[] dialogPanelTypes = shopDialogPanel.DialogPanelTypes;
				foreach (ItemsTypes itemsTypes in dialogPanelTypes)
				{
					if (itemsTypes == item.Type)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					gameObject = shopDialogPanel.gameObject;
					break;
				}
			}
			if (gameObject != null)
			{
				Links.DialogPanelPlaceholder.gameObject.SetActive(value: false);
				Links.DialogPanelPlaceholder.gameObject.SetActive(value: true);
				currDialogPanel = gameObject.GetComponent<ShopDialogPanel>();
				gameObject.SetActive(value: true);
				UpdateDialogPanel(item);
			}
		}

		public void CloseDialogPanel()
		{
			currDialogPanel.gameObject.SetActive(value: false);
			Links.DialogPanelPlaceholder.gameObject.SetActive(value: false);
		}

		public void UpdateDialogPanel(GameItem item = null)
		{
			if (currDialogPanel != null)
			{
				currDialogPanel.UpdatePanel(item);
			}
		}

		public void OpenGemsPanel()
		{
			Links.DialogPanelPlaceholder.gameObject.SetActive(value: false);
			Links.DialogPanelPlaceholder.gameObject.SetActive(value: true);
			currDialogPanel = BuyGemsPanel.GetComponent<ShopDialogPanel>();
			BuyGemsPanel.SetActive(value: true);
			UpdateDialogPanel(currentItem.GameItem);
		}

		public void OpenCashPanel()
		{
			Links.DialogPanelPlaceholder.gameObject.SetActive(value: false);
			Links.DialogPanelPlaceholder.gameObject.SetActive(value: true);
			currDialogPanel = BuyCashPanel.GetComponent<ShopDialogPanel>();
			BuyCashPanel.SetActive(value: true);
			UpdateDialogPanel(currentItem.GameItem);
		}

		public void CloseGemsPanel()
		{
			CloseDialogPanel();
		}

		private void FixPanelRect(Transform targetTransform)
		{
			RectTransform rectTransform = targetTransform as RectTransform;
			if (!(rectTransform == null))
			{
				rectTransform.localScale = Vector3.one;
				rectTransform.pivot = new Vector2(0.5f, 0.5f);
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = Vector2.one;
				Vector2 vector2 = rectTransform.offsetMin = (rectTransform.offsetMax = Vector2.zero);
			}
		}

		public void DeleteFromBI(int ID, bool fromGems = false)
		{
			if (fromGems)
			{
				BoughtItemsGems.Remove(ID);
			}
			else
			{
				BoughtItemsCoins.Remove(ID);
			}
			SaveBI();
		}

		public int GetBIValue(int ID, bool inGems = false)
		{
			if (!inited)
			{
				LoadBI();
			}
			int value;
			if (inGems)
			{
				BoughtItemsGems.TryGetValue(ID, out value);
			}
			else
			{
				BoughtItemsCoins.TryGetValue(ID, out value);
			}
			return value;
		}

		public void SetBIValue(int ID, int value)
		{
			if (BoughtItemsCoins.ContainsKey(ID))
			{
				BoughtItemsCoins[ID] = value;
			}
			else
			{
				BoughtItemsCoins.Add(ID, value);
			}
			SaveBI();
		}

		public void GenerateUI()
		{
			ClearCategories();
			ClearElements();
			ItemsManager.Instance.AssembleGameitems();
			foreach (int key in ItemsManager.Instance.Items.Keys)
			{
				if (!ItemsManager.Instance.Items[key].ShopVariables.HideInShop && ItemsManager.Instance.Items[key].ShopVariables.isDivision)
				{
					ShopCategory shopCategory = CreateShopCategory(ItemsManager.Instance.Items[key]);
					GameItem[] componentsInChildren = ItemsManager.Instance.Items[key].GetComponentsInChildren<GameItem>();
					foreach (GameItem gameItem in componentsInChildren)
					{
						if (!gameItem.ShopVariables.isDivision && !gameItem.ShopVariables.HideInShop)
						{
							CreateShopItem(gameItem, shopCategory.Container);
						}
					}
				}
			}
			UnityEngine.Debug.Log("Shop UI is generated");
		}

		public void UpdateInfo()
		{
			Links.ResetVehicleButton.SetActive(value: false);
			if (!(currentItem == null))
			{
				bool flag = ItemAvailableForBuy(currentItem.GameItem);
				bool flag2 = StuffManager.AlredyEquiped(currentItem.GameItem);
				ManageBuyPanel(flag, EnoughMoneyToBuyItem(currentItem.GameItem));
				if (currentItem.GameItem.Type == ItemsTypes.Vehicle)
				{
					ManageEquipButton((!flag & ItemAvailableForEquip(currentItem.GameItem)) && !flag2, alreadyEquiped: false);
					Links.ResetVehicleButton.SetActive(flag2 && GarageManager.Instance.MainRespawner.GetControlledObject() == null);
				}
				else
				{
					ManageEquipButton(!flag & ItemAvailableForEquip(currentItem.GameItem), flag2);
				}
				Links.InfoPanelManager.ShowItemInfo(currentItem.GameItem, BoughtAlredy(currentItem.GameItem));
			}
		}

		public bool ItemAvailableForBuy(GameItem item)
		{
			if (!BoughtAlredy(item))
			{
				if (item.ShopVariables.playerLvl > PlayerInfoManager.Level || item.ShopVariables.VipLvl > PlayerInfoManager.VipLevel)
				{
					return false;
				}
				return item.CanBeBought;
			}
			if (item.ShopVariables.MaxAmount == 0 || ((item.ShopVariables.MaxAmount > 1) & (GetBIValue(item.ID) + item.ShopVariables.PerStackAmount < item.ShopVariables.MaxAmount)))
			{
				return item.CanBeBought;
			}
			return false;
		}

		public bool EnoughMoneyToBuyItem(GameItem item)
		{
			float num = SalesManager.GetSale(item.ID) / 100f;
			int num2 = (int)((float)item.ShopVariables.price - (float)item.ShopVariables.price * num);
			if (item.ShopVariables.gemPrice)
			{
				if (PlayerInfoManager.Gems < num2)
				{
					return false;
				}
			}
			else if (PlayerInfoManager.Money < num2)
			{
				return false;
			}
			return true;
		}

		public bool ItemAvailableForEquip(GameItem item)
		{
			return (!item.ShopVariables.InstantEquip & BoughtAlredy(item)) && item.CanBeEquiped;
		}

		public void JumpToMoneyCategory()
		{
			ShopCategory category;
			ShopItem item;
			GameItemBonus shopItemByType = GetShopItemByType<GameItemBonus>(ItemsTypes.Money, new object[1]
			{
				BonusTypes.Money
			}, out category, out item);
			ChangeCategory(category);
			SelectItem(item);
		}

		public void SavePlayerInfo()
		{
			if (ShowDebug)
			{
				UnityEngine.Debug.Log("Saving player info");
			}
			SaveBI();
		}

		private void SaveBI()
		{
			BaseProfile.StoreArray(BoughtItemsCoins.Keys.ToArray(), "BoughtItemsKeys");
			BaseProfile.StoreArray(BoughtItemsCoins.Values.ToArray(), "BoughtItemsValues");
			BaseProfile.StoreArray(BoughtItemsGems.Keys.ToArray(), "GemsBoughtItemsKeys");
			BaseProfile.StoreArray(BoughtItemsGems.Values.ToArray(), "GemsBoughtItemsValues");
		}

		private void LoadBI()
		{
			int[] array = BaseProfile.ResolveArray<int>("BoughtItemsKeys");
			int[] array2 = BaseProfile.ResolveArray<int>("BoughtItemsValues");
			int[] array3 = BaseProfile.ResolveArray<int>("GemsBoughtItemsKeys");
			int[] array4 = BaseProfile.ResolveArray<int>("GemsBoughtItemsValues");
			BoughtItemsCoins = new Dictionary<int, int>();
			BoughtItemsGems = new Dictionary<int, int>();
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					BoughtItemsCoins.Add(array[i], array2[i]);
				}
			}
			if (array3 != null && array3.Length > 0)
			{
				for (int j = 0; j < array3.Length; j++)
				{
					BoughtItemsGems.Add(array3[j], array4[j]);
				}
			}
		}

		private IEnumerator LoadPreviewRoom()
		{
			yield return SceneManager.LoadSceneAsync("ShopRoom", LoadSceneMode.Additive);
		}

		private ShopCategory GetFirstCategory()
		{
			return Links.Categories.GetComponentInChildren<ShopCategory>();
		}

		private void ClearPlaceholder(Transform placeholder)
		{
			if (!(placeholder == null))
			{
				for (int i = 0; i < placeholder.childCount; i++)
				{
					UnityEngine.Object.Destroy(placeholder.GetChild(i).gameObject);
				}
			}
		}

		private void ClearCategories()
		{
			int childCount = Links.Categories.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityEngine.Object.Destroy(Links.Categories.transform.GetChild(i).gameObject);
			}
		}

		private void ClearElements()
		{
			int childCount = Links.Elements.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityEngine.Object.Destroy(Links.Elements.transform.GetChild(i).gameObject);
			}
		}

		private ShopItem GetFirstItemInCategory(ShopCategory category)
		{
			return category.Container.GetComponentInChildren<ShopItem>();
		}

		private ShopCategory CreateShopCategory(GameItem item)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(BlankCategory, Links.Categories.transform);
			gameObject.name = item.name;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.localScale = Vector3.one;
			GameObject gameObject2 = UnityEngine.Object.Instantiate(BlankContainer, Links.Elements.transform);
			RectTransform component2 = gameObject2.GetComponent<RectTransform>();
			RectTransform component3 = gameObject2.transform.parent.GetComponent<RectTransform>();
			gameObject2.name = item.name;
			component2.anchoredPosition = component3.anchoredPosition;
			component2.sizeDelta = component3.sizeDelta;
			component2.eulerAngles = component3.eulerAngles;
			component2.localScale = Vector3.one;
			ShopCategory component4 = gameObject.GetComponent<ShopCategory>();
			component4.GameItem = item;
			component4.Container = gameObject2;
			component4.SetUP();
			SetUpAnalyticEventLabel(gameObject2, item.Type);
			return component4;
		}

		private void SetUpAnalyticEventLabel(GameObject container, ItemsTypes type)
		{
			AnalyticsEventPerformer analyticsEventPerformer = container.GetComponent<AnalyticsEventPerformer>();
			if (analyticsEventPerformer == null)
			{
				analyticsEventPerformer = container.AddComponent<AnalyticsEventPerformer>();
				analyticsEventPerformer.ActionType = EventsActionsTypes.AS;
				analyticsEventPerformer.SendEventOnEnable = true;
			}
			switch (type)
			{
			case ItemsTypes.Weapon:
				analyticsEventPerformer.Label = EventsLabels.Weapon;
				break;
			case ItemsTypes.Clothes:
				analyticsEventPerformer.Label = EventsLabels.Skins;
				break;
			case ItemsTypes.Bonus:
				analyticsEventPerformer.Label = EventsLabels.Bonuses;
				break;
			case ItemsTypes.Money:
				analyticsEventPerformer.Label = EventsLabels.Money;
				break;
			case ItemsTypes.PatronContainer:
				analyticsEventPerformer.Label = EventsLabels.Patrons;
				break;
			case ItemsTypes.Ability:
				analyticsEventPerformer.Label = EventsLabels.Superpowers;
				break;
			case ItemsTypes.Vehicle:
				analyticsEventPerformer.Label = EventsLabels.Vehicles;
				break;
			default:
				throw new ArgumentOutOfRangeException("ItemsTypes", type, null);
			}
		}

		private ShopItem CreateShopItem(GameItem item, GameObject container)
		{
			Transform parent = container.transform.Find("Viewport/Content");
			GameObject gameObject = UnityEngine.Object.Instantiate(BlankElement, parent);
			gameObject.name = item.name;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.localScale = Vector3.one;
			ShopItem component2 = gameObject.GetComponent<ShopItem>();
			component2.GameItem = item;
			component2.SetUP();
			return component2;
		}

		private void ManageEquipButton(bool interactable, bool alreadyEquiped)
		{
			Links.EquipButton.GetComponent<Image>().sprite = ((!alreadyEquiped) ? ShopIcons.Equip : ShopIcons.Unequip);
			Links.EquipButton.SetActive(interactable);
		}

		private void ManageBuyPanel(bool itemIsAvailableForBuy, bool enoughtMoney)
		{
			Links.BuyPanel.SetActive(itemIsAvailableForBuy);
			Links.BuyButton.SetActive(enoughtMoney);
			Links.watchVideoBtn.SetActive(itemIsAvailableForBuy);
			Links.Price.color = ((!enoughtMoney) ? ShopIcons.NotAvailablePriceColor : ShopIcons.AvailablePriceColor);
			float num = (float)currentItem.GameItem.ShopVariables.price * SalesManager.GetSale(currentItem.GameItem.ID) / 100f;
			Links.Price.text = ((int)((float)currentItem.GameItem.ShopVariables.price - num)).ToString();
			Links.PriceIcon.sprite = ((!currentItem.GameItem.ShopVariables.gemPrice) ? ShopIcons.Money : ShopIcons.Gems);
			if (Links.GoToGemButton != null)
			{
				Links.GoToGemButton.SetActive(!enoughtMoney && currentItem.GameItem.ShopVariables.gemPrice);
			}
			if (Links.GoToMoneyButton != null)
			{
				Links.GoToMoneyButton.SetActive(!enoughtMoney && !currentItem.GameItem.ShopVariables.gemPrice);
			}
		}

		public void WatchVideoAdToBuy()
        {
			if (RewardedAdsController.Instance)
			{
				GlobalContants.shopItem = true;
				RewardedAdsController.Instance.ShowRewarded("ShopItem");
			}
		}

		private void ApplyPrefab(GameObject go)
		{
		}

		private Transform getProtoParent(Transform incTransform)
		{
			while (incTransform.parent != null)
			{
				incTransform = incTransform.parent;
			}
			return incTransform;
		}

		private void FillShopStuffDictionary()
		{
			for (int i = 0; i < Links.Categories.transform.childCount; i++)
			{
				Transform child = Links.Categories.transform.GetChild(i);
				ShopCategory component = child.GetComponent<ShopCategory>();
				if (!ShopStuff.ContainsKey(component.GameItem.Type))
				{
					ShopStuff.Add(component.GameItem.Type, new Dictionary<ShopCategory, List<ShopItem>>());
				}
				if (!ShopStuff[component.GameItem.Type].ContainsKey(component))
				{
					ShopStuff[component.GameItem.Type].Add(component, new List<ShopItem>());
				}
				Transform child2 = component.Container.transform.GetChild(0).GetChild(0);
				for (int j = 0; j < child2.childCount; j++)
				{
					child = child2.GetChild(j);
					ShopItem component2 = child.GetComponent<ShopItem>();
					ShopStuff[component.GameItem.Type][component].Add(component2);
				}
			}
		}
	}
}
