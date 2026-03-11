using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Shop
{
	[Serializable]
	public class ShopLinks
	{
		public GameObject Categories;

		public GameObject Elements;

		public ShopInfoPanelManager InfoPanelManager;

		public Image PriceIcon;

		public Text Price;

		public GameObject BuyPanel;

		public GameObject EquipButton;

		public GameObject BuyButton;

		public GameObject GoToMoneyButton;

		public GameObject GoToGemButton;

		public GameObject watchVideoBtn;

		public GameObject cashCollectPanel;

		public Transform DialogPanelPlaceholder;

		public ShopDialogPanel[] DialogPanelPrefabs;

		public Image Background;

		public GameObject ResetVehicleButton;
	}
}
