using UnityEngine;

namespace Common.Analytics
{
	public class AnalyticsManager : BaseAnalyticsManager
	{
		private delegate void Action(BaseAnalyticsAdapter adapter);

		private const string GoogleAnalyticStateKey = "EnableGoogleAnalytic";

		private const int UsersPercentWithGoogleAnalytics = 5;

		private static BaseAnalyticsAdapter[] adapters;

		private bool sendEventsInGoogle;

		protected override void Awake()
		{
			base.Awake();
			if (BaseAnalyticsManager.Instance == null || adapters == null)
			{
				adapters = GetComponents<BaseAnalyticsAdapter>();
				sendEventsInGoogle = GoogleAnalyticIsEnable();
			}
		}

		private void Start()
		{
			SendInitEvent();
		}

		public bool GoogleAnalyticIsEnable()
		{
			if (BaseProfile.HasKey("EnableGoogleAnalytic"))
			{
				return BaseProfile.ResolveValueWitoutDefault<bool>("EnableGoogleAnalytic");
			}
			bool flag = EnableGoogleAnalyticForThisUser();
			BaseProfile.StoreValue(flag, "EnableGoogleAnalytic");
			return flag;
		}

		private bool EnableGoogleAnalyticForThisUser()
		{
			return Random.Range(1, 100) <= 5;
		}

		public override void SendEvent(string eventName, string valueName, string value)
		{
			base.SendEvent(eventName, valueName, value);
			AdaptersBypass(delegate(BaseAnalyticsAdapter adapter)
			{
				adapter.SendEvent(eventName, valueName, value);
			});
		}

		public override void SendEvent(string eventName, string valueName, int value)
		{
			base.SendEvent(eventName, valueName, value);
			AdaptersBypass(delegate(BaseAnalyticsAdapter adapter)
			{
				adapter.SendEvent(eventName, valueName, value);
			});
		}

		public override void SendEvent(string eventName)
		{
			base.SendEvent(eventName);
			AdaptersBypass(delegate(BaseAnalyticsAdapter adapter)
			{
				adapter.SendEvent(eventName);
			});
		}

		private void AdaptersBypass(Action action)
		{
			BaseAnalyticsAdapter[] array = adapters;
			foreach (BaseAnalyticsAdapter baseAnalyticsAdapter in array)
			{
				if (sendEventsInGoogle || !(baseAnalyticsAdapter is GoogleAnalyticsAdapter))
				{
					action(baseAnalyticsAdapter);
				}
			}
		}

		private void SendInitEvent()
		{
			SendEvent(EventsActionsTypes.U, "GoogleAnal", (!sendEventsInGoogle) ? "disabled" : "enabled");
			SendEvent(EventsActionsTypes.T, "Session", "start");
		}
	}
}
