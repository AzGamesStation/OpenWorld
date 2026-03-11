using UnityEngine.UI;

public class InAppFullscreen : OfflineAdsFullscreen
{
	//public IAPController.Item IAPItem;

	public Text PriceOutput;

	public override void Click()
	{
		//IAPController.Buy(IAPItem);
	}

	public void Start()
	{
		//PriceOutput.text = IAPController.Items[IAPItem].FormattedPrice;
	}
}
