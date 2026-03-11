using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class UIDescriptor : MonoBehaviour
	{
		public static UIDescriptor Instance;

		public RectTransform Container;

		public Text DescriptionText;

		private RectTransform myRectTransform;

		public void ShowInfo(RectTransform showedRectTransform, string description, float showedTime)
		{
			Container.gameObject.SetActive(value: true);
			base.transform.parent = showedRectTransform;
			base.transform.localPosition = Vector3.zero;
			Vector3 position = base.transform.position;
			Vector3 a = (!(position.y > (float)Screen.height / 2f)) ? Vector3.up : Vector3.down;
			Vector3 position2 = base.transform.position;
			Vector3 a2 = (!(position2.x > (float)Screen.width / 2f)) ? Vector3.right : Vector3.left;
			base.transform.localPosition += a * (myRectTransform.rect.height / 2f + showedRectTransform.rect.height / 2f);
			base.transform.localPosition += a2 * (myRectTransform.rect.width / 2f + showedRectTransform.rect.width / 2f);
			base.transform.localScale = Vector3.one;
			DescriptionText.text = description;
			StopAllCoroutines();
			StartCoroutine(Timer(showedTime, HideInfo));
		}

		public void HideInfo()
		{
			Container.gameObject.SetActive(value: false);
			StopAllCoroutines();
		}

		private void Awake()
		{
			Instance = this;
			myRectTransform = (base.transform as RectTransform);
		}

		private void OnDisable()
		{
			HideInfo();
		}

		private IEnumerator Timer(float time, Action afterAction)
		{
			yield return new WaitForSecondsRealtime(time);
			afterAction?.Invoke();
		}
	}
}
