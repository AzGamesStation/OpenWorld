using System;
using System.Collections;
using UnityEngine;

namespace Game.GlobalComponent.Quality
{
	public class WaitingPanelController : MonoBehaviour
	{
		public GameObject PanelWaiting;

		private static WaitingPanelController instance;

		private float timer;

		public static WaitingPanelController Instance => instance ?? (instance = UnityEngine.Object.FindObjectOfType<WaitingPanelController>());

		private void Awake()
		{
			instance = this;
		}

		private void LateUpdate()
		{
			SwitchWaitingPanel();
		}

		public void StartWaiting(Action callback)
		{
			PanelWaiting.SetActive(value: true);
			timer = Time.frameCount + 10;
			StartCoroutine(Show(callback));
		}

		private IEnumerator Show(Action callback)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			callback();
		}

		private void SwitchWaitingPanel()
		{
			if (timer <= (float)Time.frameCount && timer != 0f)
			{
				PanelWaiting.SetActive(value: false);
				timer = 0f;
			}
		}
	}
}
