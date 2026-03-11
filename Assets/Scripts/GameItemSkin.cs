using Game.Character.Stats;
using Game.Items;
using UnityEngine;

public class GameItemSkin : GameItem
{
	[Space(10f)]
	public SkinSlot[] OccupiedSlots;

	public GameItemAbility[] RelatedAbilitys;

	public StatAttribute[] StatAttributes;
}
