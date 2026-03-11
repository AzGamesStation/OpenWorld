using Game.Character.Stats;
using Game.Items;
using UnityEngine;

namespace Game.Shop
{
	public class ShopInfoPanelSkin : ShopInfoPanel
	{
		[SerializeField]
		private StatView m_StatViewPrefab;

		[SerializeField]
		private RectTransform m_StatViewHolder;

		[SerializeField]
		private StatIconList m_StatDefenitions;

		public override void ShowInfo(GameItem incItem)
		{
			base.ShowInfo(incItem);
			m_StatViewHolder.DestroyChildrens();
			GameItemSkin gameItemSkin = incItem as GameItemSkin;
			if (gameItemSkin == null)
			{
				UnityEngine.Debug.LogWarning("Пытался показать инфо о скине для неизвестного типа предмета.");
				return;
			}
			StatAttribute[] statAttributes = gameItemSkin.StatAttributes;
			for (int i = 0; i < statAttributes.Length; i++)
			{
				StatAttribute statAttribute = statAttributes[i];
				StatView statView = Object.Instantiate(m_StatViewPrefab, m_StatViewHolder, worldPositionStays: false);
				StatIcon definition = m_StatDefenitions.GetDefinition(statAttribute.StatType);
				statView.SetIcon(definition.Icon);
				statView.SetNameStat(definition.ShowedName);
				statView.SetValue(statAttribute.GetStatValue);
			}
		}
	}
}
