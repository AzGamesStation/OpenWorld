using UnityEngine;

namespace Common.Analytics
{
	public class BaseAnalyticsAdapter : MonoBehaviour, IAnalyticsManager
	{
		public virtual void SendEvent(EventsActionsTypes actionType, string valueName, string value)
		{
			SendEvent(actionType.ToString(), valueName, value);
		}

		public virtual void SendEvent(EventsActionsTypes actionType, string valueName, int value)
		{
			SendEvent(actionType.ToString(), valueName, value);
		}

		public virtual void SendEvent(string eventName, string valueName, string value)
		{
		}

		public virtual void SendEvent(string eventName, string valueName, int value)
		{
		}

		public virtual void SendEvent(string eventName)
		{
		}
	}
}
