using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Analytics
{
	public class AnalyticsEventPerformer : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public EventsActionsTypes ActionType;

		public EventsLabels Label;

		public bool SendEventOnEnable;

		public bool SendEventOnClick;

		public void SendAnalyticsEvent()
		{
			AnalyticsEventHelper.SendAnalyticsEvent(ActionType, Label);
		}

		private void OnEnable()
		{
			if (SendEventOnEnable)
			{
				SendAnalyticsEvent();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (SendEventOnClick)
			{
				SendAnalyticsEvent();
			}
		}
	}
}
