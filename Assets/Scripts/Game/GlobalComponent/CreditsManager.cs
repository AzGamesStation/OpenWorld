using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GlobalComponent
{
	public class CreditsManager : MonoBehaviour
	{
		private const float WaitTimeAfterFinishedLines = 3f;

		public List<string> CreditsLines = new List<string>();

		public float ScrollSpeed;

		public RectTransform TextSample;

		public RectTransform StartTextPosition;

		public RectTransform EndTextPosition;

		public GameObject CreditsPanel;

		public RadioManager RadioManagerPrefub;

		private float textLifeTime;

		private RectTransform lastInitedText;

		private int currentLineIndex;

		private float waitTimer;

		private readonly IDictionary<Text, float> initedTexts = new Dictionary<Text, float>();

		private void Awake()
		{
			AddMusicName();
			float num = ScrollSpeed / Time.deltaTime;
			textLifeTime = Vector3.Distance(StartTextPosition.transform.position, EndTextPosition.transform.position) / num;
		}

		private void AddMusicName()
		{
			CreditsLines.Add(" ");
			CreditsLines.Add("Used music:");
			BackgroundMusic backgroundMusic = UnityEngine.Object.FindObjectOfType<BackgroundMusic>();
			string name = backgroundMusic.GetComponent<AudioSource>().clip.name;
			CreditsLines.Add(name);
			AudioClip[] clips = backgroundMusic.Clips;
			foreach (AudioClip audioClip in clips)
			{
				if (!audioClip.name.Equals(name))
				{
					CreditsLines.Add(audioClip.name);
				}
			}
			if ((bool)RadioManagerPrefub)
			{
				foreach (RadioManager.RadioStation station in RadioManagerPrefub.Stations)
				{
					AudioClip[] audioClips = station.AudioClips;
					foreach (AudioClip audioClip2 in audioClips)
					{
						if (!audioClip2.name.Equals(name))
						{
							CreditsLines.Add(audioClip2.name);
						}
					}
				}
			}
			CreditsLines.Add(" ");
		}

		private void Update()
		{
			if (waitTimer > 0f)
			{
				waitTimer -= Time.deltaTime;
			}
			else if (Vector3.Distance(lastInitedText.anchoredPosition, StartTextPosition.anchoredPosition) > TextSample.rect.height)
			{
				CreateNewStringLine(CreditsLines[currentLineIndex]);
				currentLineIndex++;
				if (currentLineIndex > CreditsLines.Count - 1)
				{
					currentLineIndex = 0;
					waitTimer = 3f;
				}
			}
			foreach (KeyValuePair<Text, float> initedText in initedTexts)
			{
				initedText.Key.gameObject.transform.Translate(Vector3.up * ScrollSpeed);
				Color color = initedText.Key.color;
				float num = 1f - (Time.time - initedText.Value) / textLifeTime;
				initedText.Key.color = new Color(color.r, color.g, color.b, num);
				if (num < 0.1f)
				{
					UnityEngine.Object.Destroy(initedText.Key.gameObject);
					initedTexts.Remove(initedText);
					break;
				}
			}
		}

		private void OnEnable()
		{
			currentLineIndex = 0;
			lastInitedText = null;
			waitTimer = 0f;
			CreateNewStringLine(CreditsLines[currentLineIndex]);
			currentLineIndex++;
		}

		private void OnDisable()
		{
			foreach (KeyValuePair<Text, float> initedText in initedTexts)
			{
				UnityEngine.Object.Destroy(initedText.Key.gameObject);
			}
			initedTexts.Clear();
		}

		private void CreateNewStringLine(string newString)
		{
			lastInitedText = UnityEngine.Object.Instantiate(TextSample);
			RectTransform rectTransform = lastInitedText.transform as RectTransform;
			if (rectTransform != null)
			{
				rectTransform.SetParent(CreditsPanel.transform, worldPositionStays: false);
			}
			else
			{
				lastInitedText.transform.parent = CreditsPanel.transform;
			}
			lastInitedText.transform.localScale = Vector3.one;
			lastInitedText.anchoredPosition = StartTextPosition.anchoredPosition;
			Text component = lastInitedText.GetComponent<Text>();
			component.text = newString;
			initedTexts.Add(component, Time.time);
		}
	}
}
