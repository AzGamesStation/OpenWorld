namespace Common.Analytics
{
	public interface IAnalyticsManager
	{
		void SendEvent(EventsActionsTypes actionType, string valueName, string value);

		void SendEvent(EventsActionsTypes actionType, string valueName, int value);

		void SendEvent(string eventName, string valueName, string value);

		void SendEvent(string eventName, string valueName, int value);

		void SendEvent(string eventName);
	}
}
