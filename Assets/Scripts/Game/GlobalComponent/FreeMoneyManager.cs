using Game.GlobalComponent.HelpfulAds;
using UnityEngine;

namespace Game.GlobalComponent
{
	public class FreeMoneyManager : MonoBehaviour
	{
		public bool ByGems;

		public GameObject MoneyButton;

		protected SlowUpdateProc slowUpdateProc;

		public float UpdateTime => HelpfullAdsManager.Instance.HelpTimerLength;

		protected virtual void Awake()
		{
			slowUpdateProc = new SlowUpdateProc(SlowUpdate, 1f);
		}

		protected void FixedUpdate()
		{
			slowUpdateProc.ProceedOnFixedUpdate();
		}

		public virtual void ButtonClick()
		{
			if (ByGems)
			{
				HelpfullAdsManager.Instance.OfferAssistance(HelpfullAdsType.FreeGems, null);
			}
			else
			{
				HelpfullAdsManager.Instance.OfferAssistance(HelpfullAdsType.FreeMoney, null);
			}
		}

		protected virtual void SlowUpdate()
		{
			if (MoneyButton != null)
			{
				MoneyButton.SetActive(HelpfullAdsManager.Instance.IsReady);
			}
		}
	}
}
