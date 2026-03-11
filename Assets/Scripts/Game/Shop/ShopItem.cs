using Game.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Shop
{
	public class ShopItem : ShopElement
	{
		public Image SaleImage;

		private void Awake()
		{
			CheckSale();
			
		}

		private void OnEnable()
		{
			ShopManager.Instance.SelectItem(this);
		}

		public override void OnClick()
		{
			ShopManager.Instance.SelectItem(this);
		}

		private void CheckSale()
		{
			float num= 3;
			if (num > 0f)
			{
				SaleImage.gameObject.SetActive(value: true);
			}
			else
			{
				SaleImage.gameObject.SetActive(value: false);
			}
		}
	}
}
