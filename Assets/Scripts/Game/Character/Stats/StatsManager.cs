using System;

namespace Game.Character.Stats
{
	[Serializable]
	public class StatsManager
	{
		public static StatsManager Instance;

		public int TimeForFullStaminaRegeneration = 60;

		public CharacterStat stamina = new CharacterStat();

		public UpgradeList upgradeValues;

		public static void SaveStat(StatsList name, int value)
		{
			BaseProfile.StoreValue(value, name.ToString());
			if (Instance != null)
			{
				Instance.Init();
			}
		}

		public static int GetStat(StatsList name)
		{
			return BaseProfile.ResolveValue(name.ToString(), 0);
		}

		public void Init()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			UpdateSpentPoints();
			UpdateStats();
		}

		public float GetPlayerStat(StatsList stat)
		{
			float num = 0f;
			return upgradeValues.GetStatMas(stat)?.ActualValue ?? num;
		}

		public void UpdateStats(bool resetCurrent = true)
		{
			float playerStat = GetPlayerStat(StatsList.Stamina);
			float regenPerSecond = playerStat / (float)TimeForFullStaminaRegeneration;
			if (resetCurrent)
			{
				stamina.Setup(playerStat, playerStat);
			}
			else
			{
				stamina.Setup(stamina.Current, playerStat);
			}
			stamina.RegenPerSecond = regenPerSecond;
		}

		private void UpdateSpentPoints()
		{
			int count = upgradeValues.Count;
			for (int i = 0; i < count; i++)
			{
				StatsMas statsMas = upgradeValues[i];
				statsMas.SpentPoints = GetStat(statsMas.stat);
			}
		}
	}
}
