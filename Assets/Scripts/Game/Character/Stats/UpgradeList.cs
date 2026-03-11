using UnityEngine;

namespace Game.Character.Stats
{
	[CreateAssetMenu(fileName = "UpgradeList", menuName = "Library/Player/Create Upgrade List", order = 1)]
	public class UpgradeList : BaseListScriptable<StatsMas>
	{
		public StatsMas GetStatMas(StatsList typeStat)
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				if (base[i].stat == typeStat)
				{
					return base[i];
				}
			}
			return null;
		}

		public void ResetBonusValues()
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].bonusvalue = 0f;
			}
		}
	}
}
