using Game.Character;
using Game.GlobalComponent.Training;
using System;
using System.Collections;
using UnityEngine;

namespace Common.Analytics
{
	public class AnalyticsController : MonoBehaviour
	{
		private const float TimeThresholdToStartSendingEvents = 20f;

		private const float TimePeriodToRepeatSendingEvents = 300f;

		private const string NormalFPSHash = "normalFPS";

		private const string SpikeFPSHash = "spikeFPS";

		private const string SpikePercentHash = "spikePercent";

		public int[] ReceivedMoneyEventsValues;

		public int[] SpentMoneyEventsValues;

		[Tooltip("In minutes")]
		public int[] TimeInGameEventsValues;

		public int[] NormalFPSRanges;

		public int[] SpikeFPSRanges;

		public int[] SpikePercentageRanges;

		public int[] SkipTrainingRanges;

		private int frameCount;

		private float movingAverageMs;

		private float timer;

		private float alreadyConsideredTime;

		private bool firstEventIsSent;

		private bool countFPS;

		private FPSCountersController fpsCountersController = new FPSCountersController();

		private IEnumerator Start()
		{
			TrainingManager.SkipTrainingEvent = (TrainingManager.SkipTrainingDelegate)Delegate.Combine(TrainingManager.SkipTrainingEvent, new TrainingManager.SkipTrainingDelegate(SendSkipedTraining));
			yield return new WaitForSeconds(20f);
			SendStartEvents();
			if (!CheckAndSendFPS())
			{
				StartCoroutine(fpsCountersController.StartCount(SaveAndSendFPSStats));
			}
		}

		private void FixedUpdate()
		{
			TrackTimeInGame();
			if (TimerEnded())
			{
				SendEvents();
			}
		}

		private void OnDestroy()
		{
			TrainingManager.SkipTrainingEvent = (TrainingManager.SkipTrainingDelegate)Delegate.Remove(TrainingManager.SkipTrainingEvent, new TrainingManager.SkipTrainingDelegate(SendSkipedTraining));
		}

		private bool TimerEnded()
		{
			if (!firstEventIsSent)
			{
				return false;
			}
			if (timer >= 300f)
			{
				timer = 0f;
				return true;
			}
			timer += Time.deltaTime;
			return false;
		}

		private bool CheckAndSendFPS()
		{
			int num = BaseProfile.ResolveValue("normalFPS", -1000);
			int num2 = BaseProfile.ResolveValue("spikeFPS", -1000);
			int num3 = BaseProfile.ResolveValue("spikePercent", -1000);
			if (num != -1000 && num2 != -1000 && num3 != -1000)
			{
				SendFPSStats(num, num2, num3);
				return true;
			}
			return false;
		}

		private void SendEvents()
		{
			SendReceivedMoney();
			SendSpentMoney();
			SendTimeInGame();
		}

		private void TrackTimeInGame()
		{
			if ((Time.timeSinceLevelLoad - alreadyConsideredTime) / 60f > 1f)
			{
				alreadyConsideredTime = Time.timeSinceLevelLoad;
				PlayerInfoManager.TotalTimeInGame++;
			}
		}

		private void SendStartEvents()
		{
			firstEventIsSent = true;
			BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.T, "TInGame", "20sec");
			SendEvents();
		}

		private void SendReceivedMoney()
		{
			int totalReceivedMoney = PlayerInfoManager.TotalReceivedMoney;
			int[] receivedMoneyEventsValues = ReceivedMoneyEventsValues;
			foreach (int num in receivedMoneyEventsValues)
			{
				if (num <= totalReceivedMoney)
				{
					BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.M, "MReceived", GetShortenedNumber(num));
				}
			}
		}

		private void SendSpentMoney()
		{
			int num = Mathf.Abs(PlayerInfoManager.TotalSpentMoney);
			int[] spentMoneyEventsValues = SpentMoneyEventsValues;
			foreach (int num2 in spentMoneyEventsValues)
			{
				if (num2 <= num)
				{
					BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.M, "MSpent", GetShortenedNumber(num2));
				}
			}
		}

		private void SendTimeInGame()
		{
			int totalTimeInGame = PlayerInfoManager.TotalTimeInGame;
			int[] timeInGameEventsValues = TimeInGameEventsValues;
			foreach (int num in timeInGameEventsValues)
			{
				if (num <= totalTimeInGame)
				{
					string value;
					if (num > 60)
					{
						int num2 = num / 60;
						value = num2 + "H";
					}
					else
					{
						int num2 = num;
						value = num2 + "M";
					}
					BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.T, "TInGame", value);
					if (totalTimeInGame < 30 && (PlayerInfoManager.Money > 99998 || PlayerInfoManager.Gems > 9998))
					{
						BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.U, "cheater", "true");
					}
				}
			}
		}

		private void SendSkipedTraining(int skipedTrainingCount)
		{
			string value = (skipedTrainingCount <= 3) ? skipedTrainingCount.ToString() : GetRangeFromArray(skipedTrainingCount, SkipTrainingRanges);
			BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.AM, "SkipTrain", value);
		}

		private string GetShortenedNumber(int value)
		{
			if (value < 1000)
			{
				return value.ToString();
			}
			return value / 1000 + "k";
		}

		private void SaveAndSendFPSStats()
		{
			BaseProfile.StoreValue(fpsCountersController.NormalFPS.GetFPS(), "normalFPS");
			BaseProfile.StoreValue(fpsCountersController.SpikeFPS.GetFPS(), "spikeFPS");
			BaseProfile.StoreValue(fpsCountersController.GetPercentageFPSAtUpperBound(), "spikePercent");
			SendFPSStats(fpsCountersController.NormalFPS.GetFPS(), fpsCountersController.SpikeFPS.GetFPS(), fpsCountersController.GetPercentageFPSAtUpperBound());
		}

		private void SendFPSStats(int normalFPS, int spikeFPS, int spikePercent)
		{
			BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.P, "FNormal", GetRangeFromArray(normalFPS, NormalFPSRanges));
			BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.P, "FSpike", GetRangeFromArray(spikeFPS, SpikeFPSRanges));
			BaseAnalyticsManager.Instance.SendEvent(EventsActionsTypes.P, "FPercent", GetRangeFromArray(spikePercent, SpikePercentageRanges));
		}

		private string GetRangeFromArray(int value, int[] array)
		{
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				if (i == array.Length - 1)
				{
					text = text + array[i] + "+";
				}
				else if (value >= array[i] && array[i + 1] >= value)
				{
					string text2 = text;
					text = text2 + array[i] + "-" + array[i + 1];
					break;
				}
			}
			return text;
		}
	}
}
