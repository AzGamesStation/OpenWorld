using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.MiniMap
{
	public class TouchPadForUserMark : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEventSystemHandler
	{
		public RectTransform MainRect;

		private MiniMap miniMap;

		private Vector2 resolutionIdeal = new Vector2(1920f, 1080f);

		private bool isDrag;

		private void Start()
		{
			miniMap = MiniMap.Instance;
		}

		private Vector3 PositionAddiction(PointerEventData eventData)
		{
			float num = (float)Screen.width / resolutionIdeal.x;
			float num2 = (float)Screen.height / resolutionIdeal.y;
			Vector2 position = eventData.position;
			float x = position.x;
			Vector2 position2 = eventData.position;
			Vector3 a = new Vector3(x, 0f, position2.y);
			Vector3 position3 = MainRect.position;
			float x2 = position3.x;
			Vector3 position4 = MainRect.position;
			Vector3 b = new Vector3(x2, 0f, position4.y);
			Vector3 vector = a - b;
			float num3 = miniMap.MiniMapCamera.orthographicSize * 2f;
			float num4 = num3 / MainRect.rect.width / num;
			float num5 = num3 / MainRect.rect.height / num2;
			return new Vector3(vector.x * num4, 0f, vector.z * num5);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			isDrag = false;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (!isDrag)
			{
				miniMap.LocateUserMark(PositionAddiction(eventData));
			}
			isDrag = false;
			miniMap.MarkOnClick(PositionAddiction(eventData));
		}

		public void OnDrag(PointerEventData eventData)
		{
			isDrag = true;
		}
	}
}
