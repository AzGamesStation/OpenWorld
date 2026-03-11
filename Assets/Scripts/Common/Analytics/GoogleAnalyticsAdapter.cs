namespace Common.Analytics
{
	public class GoogleAnalyticsAdapter : BaseAnalyticsAdapter
	{
		public override void SendEvent(string eventName, string valueName, string value)
		{
			if (global::Analytics.gua != null)
			{
				global::Analytics.gua.sendEventHit("d-category", eventName, $"{valueName}.{value}");
			}
		}

		public override void SendEvent(string eventName, string valueName, int value)
		{
			if (global::Analytics.gua != null)
			{
				global::Analytics.gua.sendEventHit("d-category", eventName, valueName, value);
			}
		}

		public override void SendEvent(string eventName)
		{
			if (global::Analytics.gua != null)
			{
				global::Analytics.gua.sendEventHit("d-category", eventName);
			}
		}
	}
}
