using Game.Items;

public class GameItemPack : GameItem
{
	public GameItem[] PackedItems;

	public override bool SameParametrWithOther(object[] parametrs)
	{
		return PackedItems == (GameItem[])parametrs[0];
	}
}
