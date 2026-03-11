using UnityEngine;

namespace Common.Analytics
{
	public class BaseAnalyticsManager : MonoBehaviour, IAnalyticsManager
	{
		public static IAnalyticsManager Instance;

		public bool EnableDebug;

		protected virtual void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}

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
			if (EnableDebug)
			{
				UnityEngine.Debug.LogFormat("Analytics: Dummy event hit. '{0}.{1} = {2}'", eventName, valueName, value);
			}
		}

		public virtual void SendEvent(string eventName, string valueName, int value)
		{
			if (EnableDebug)
			{
				UnityEngine.Debug.LogFormat("Analytics: Dummy event hit. '{0}.{1} = {2}'", eventName, valueName, value);
			}
		}

		public virtual void SendEvent(string eventName)
		{
			if (EnableDebug)
			{
				UnityEngine.Debug.LogFormat("Analytics: Dummy event hit. '{0}'", eventName);
			}
		}

		public virtual void SendIntEvent(string eventName, string valueName, int value)
		{
			if (EnableDebug)
			{
				UnityEngine.Debug.LogFormat("Analytics: Dummy event hit. '{0}.{1} = {2}'", eventName, valueName, value);
			}
		}
	}
}
