using System;
using UnityEngine;

public class OfflineAdsFullscreen : MonoBehaviour
{
	private static Action<AdsResult> callback;

	public GameObject CloseButton;

	private float timeToEnableCoseButton;

	public virtual void Click()
	{
	}

	public void ShowAd(Action<AdsResult> adsCallback)
	{
		callback = adsCallback;
		//AdsManager.PauseByAds(pause: true);
		//if (AdsManager.instance)
		//{
		//	AdsManager.instance.AdmobInterstitail();
		//}

		base.transform.parent.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
		CloseButton.SetActive(value: false);
		timeToEnableCoseButton = Time.realtimeSinceStartup + 5f;
	}

	public void CloseButtonClick()
	{
		//AdsManager.PauseByAds(pause: false);
		//if (AdsManager.instance)
		//{
		//	AdsManager.instance.AdmobInterstitail();
		//}

		CloseButton.SetActive(value: false);
		OfflineAdsFullscreen[] componentsInChildren = base.transform.parent.GetComponentsInChildren<OfflineAdsFullscreen>(includeInactive: true);
		if (componentsInChildren != null)
		{
			foreach (OfflineAdsFullscreen offlineAdsFullscreen in componentsInChildren)
			{
				offlineAdsFullscreen.gameObject.SetActive(value: false);
			}
		}
		if (callback != null)
		{
			callback(AdsResult.Skipped);
			callback = null;
		}
	}

	private void Update()
	{
		if (Time.realtimeSinceStartup > timeToEnableCoseButton)
		{
			CloseButton.SetActive(value: true);
		}
	}
}
