using Game.UI;
using System;
using UnityEngine;

namespace Game.GlobalComponent.HelpfulAds
{
	public class HelpfullAdsManager : MonoBehaviour
	{
		private static HelpfullAdsManager instance;

		public float HelpTimerLength;

		private HelpfulAds[] helps;

		private float lastHelpTime;

		private Action<bool> lastCallback;

		private HelpfulAds lastHelpfulAds;

		public static HelpfullAdsManager Instance
		{
			get
			{
				if (instance == null)
				{

				}
				return instance;
			}
		}
		//public bool IsReady;
		public bool IsReady= false;

		public HelpfulAds GetAdsByType(HelpfullAdsType helpType)
		{
			if (helps == null || helps.Length == 0)
			{
				return null;
			}
			HelpfulAds[] array = helps;
			foreach (HelpfulAds helpfulAds in array)
			{
				if (helpfulAds.HelpType() == helpType)
				{
					return helpfulAds;
				}
			}
			return null;
		}

		public void OfferAssistance(HelpfullAdsType helpType, Action<bool> helpCallback)
		{
			if (!IsReady)
			{
				helpCallback?.Invoke(obj: false);
				return;
			}
			lastHelpfulAds = null;
			HelpfulAds[] array = helps;
			foreach (HelpfulAds helpfulAds in array)
			{
				if (helpfulAds.HelpType() == helpType)
				{
					lastHelpfulAds = helpfulAds;
					break;
				}
			}
			if (lastHelpfulAds == null)
			{
				throw new Exception("HelpfullAds for " + helpType + " type not found!");
			}
			lastCallback = helpCallback;
			UniversalYesNoPanel.Instance.DisplayOffer(null, lastHelpfulAds.Message, delegate
			{
				SelectionChoosed(accepted: true);
			}, delegate
			{
				SelectionChoosed(accepted: false);
			});
		}

		public void SelectionChoosed(bool accepted)
		{
			lastHelpTime = Time.time;
			if (!accepted)
			{
				if (lastCallback != null)
				{
					lastCallback(obj: false);
				}
			}
			else
			{
				RewardedAdsController.Instance.ShowRewarded("FreeHelp");
			}
		}

		private void Callback(AdsResult result)
		{
			MainThreadExecuter.Instance.Run(delegate
			{
				CallbackResolver(result);
			});
		}

		private void CallbackResolver(AdsResult result)
		{
			if (result != AdsResult.Finished)
			{
				if (lastCallback != null)
				{
					lastCallback(obj: false);
				}
				return;
			}
			lastHelpfulAds.HelpAccepted();
			if (lastCallback != null)
			{
				lastCallback(obj: true);
			}
		}

		private void Awake()
		{
			instance = this;
			helps = GetComponentsInChildren<HelpfulAds>();
			lastHelpTime = Time.time - HelpTimerLength;
		}
	}
}
