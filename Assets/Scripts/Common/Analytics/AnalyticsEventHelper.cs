using System.Collections.Generic;
using UnityEngine;

namespace Common.Analytics
{
	public class AnalyticsEventHelper : MonoBehaviour
	{
		public AnalyticsEvent[] Events;

		private static readonly Dictionary<EventsLabels, AnalyticsEvent> eventDictionary = new Dictionary<EventsLabels, AnalyticsEvent>();

		private static bool inited;

		private void Awake()
		{
			if (!inited)
			{
				AnalyticsEvent[] events = Events;
				foreach (AnalyticsEvent analyticsEvent in events)
				{
					eventDictionary.Add(analyticsEvent.EventLabel, analyticsEvent);
				}
				inited = true;
			}
		}

		public static void SendAnalyticsEvent(EventsActionsTypes actionType, EventsLabels type)
		{
			if (type != 0)
			{
				AnalyticsEvent analyticsEvent = eventDictionary[type];
				if (analyticsEvent != null)
				{
					BaseAnalyticsManager.Instance.SendEvent(actionType, analyticsEvent.ValueName, analyticsEvent.Value);
				}
			}
		}
	}
}
