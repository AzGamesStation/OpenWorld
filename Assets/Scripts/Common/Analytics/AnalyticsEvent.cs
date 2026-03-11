using System;

namespace Common.Analytics
{
	[Serializable]
	public class AnalyticsEvent
	{
		public string Name;

		public EventsActionsTypes ActionType;

		public EventsLabels EventLabel;

		public string ValueName;

		public string Value;
	}
}
