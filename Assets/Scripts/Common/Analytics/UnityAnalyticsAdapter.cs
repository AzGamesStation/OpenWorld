using System.Collections.Generic;
using UnityEngine.Analytics;

namespace Common.Analytics
{
	public class UnityAnalyticsAdapter : BaseAnalyticsAdapter
	{
		private const string Separator = "_";

		public override void SendEvent(string eventName, string valueName, string value)
		{
			UnityEngine.Analytics.Analytics.CustomEvent(eventName + "_" + valueName + "_" + value, new Dictionary<string, object>());
		}

		public override void SendEvent(string eventName, string valueName, int value)
		{
			UnityEngine.Analytics.Analytics.CustomEvent(eventName + "_" + valueName + "_" + value, new Dictionary<string, object>());
		}

		public override void SendEvent(string eventName)
		{
			UnityEngine.Analytics.Analytics.CustomEvent(eventName, new Dictionary<string, object>());
		}
	}
}
