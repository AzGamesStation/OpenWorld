using UnityEngine;

public class RewardedAds : MonoBehaviour
{
	public void Click()
	{
		//AdsManager.ShowRewardAd(Callback);
		if (RewardedAdsController.Instance)
		{
			RewardedAdsController.Instance.ShowRewarded("FreeGems");
		}
	}

	private void Callback(AdsResult showResult)
	{
		if (showResult.Equals(AdsResult.Finished))
		{
		}
	}
}
