using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class UniversalYesNoPanel : MonoBehaviour
	{
		public static UniversalYesNoPanel Instance;

		public RectTransform Content;

		public RectTransform HeaderContent;

		public Text HeaderText;

		public Text MessageText;

		public Button YesButton;

		private Action currentYesAction;

		private Action currentNoAction;

		private bool timeWasFrozen;

		public void DisplayOffer(string message, Action onYesAction)
		{
			DisplayOffer(null, message, onYesAction);
		}

		public void DisplayOffer(string header, string message, Action onYesAction, Action onNoAction = null, bool disableYesBitton = false)
		{
			Content.gameObject.SetActive(value: true);
			HeaderContent.gameObject.SetActive(header != null);
			if (header != null)
			{
				HeaderText.text = header;
			}
			MessageText.text = message;
			currentYesAction = onYesAction;
			currentNoAction = onNoAction;
			YesButton.interactable = !disableYesBitton;
			if (!GameplayUtils.OnPause)
			{
				GameplayUtils.PauseGame();
				timeWasFrozen = true;
			}
		}

		public void YesClick()
		{
			if (currentYesAction != null)
			{
				currentYesAction();
			}
			HidePanel();
		}

		public void NoClick()
		{
			if (currentNoAction != null)
			{
				currentNoAction();
			}
			HidePanel();
		}

		private void Awake()
		{
			Instance = this;
		}

		private void HidePanel()
		{
			if (timeWasFrozen)
			{
				GameplayUtils.ResumeGame(false);
			}
			Content.gameObject.SetActive(value: false);
			currentYesAction = null;
			currentNoAction = null;
			timeWasFrozen = false;
		}
	}
}
