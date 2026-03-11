using UnityEngine;

namespace Game.Shop
{
	public class ShopCategory : ShopElement
	{
		public GameObject Container;

		public override void OnClick()
		{
			ShopManager.Instance.ChangeCategory(this);
		}

		public override void SetUP()
		{
			base.SetUP();
			Container.SetActive(value: false);
		}
	}
}
