using Game.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Game.FollowUs
{
	public class FollowUs : MonoBehaviour
	{
		public int bonus = 2000;

		public Text bonusText;

		public static bool BonusUsed
		{
			get
			{
				return BaseProfile.ResolveValue("SocialBonus", defaultValue: false);
			}
			set
			{
				BaseProfile.StoreValue(value, "SocialBonus");
			}
		}

		private void Start()
		{
			ChangeText();
		}

		public void openVkPage()
		{
			Application.OpenURL("http://vk.com/free.games.studio");
			if (!BonusUsed)
			{
				BonusUsed = true;
				PlayerInfoManager.Money += bonus;
				PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
			}
			ChangeText();
		}

		public void openFBPage()
		{
			Application.OpenURL("https://www.facebook.com/FreeGamesInc");
			if (!BonusUsed)
			{
				BonusUsed = true;
				PlayerInfoManager.Money += bonus; 
				PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
			}
			ChangeText();
		}

		private void ChangeText()
		{
			bonusText.text = ((!BonusUsed) ? "Follow us to get bonuses 2000" : "Follow us");
		}
	}
}
