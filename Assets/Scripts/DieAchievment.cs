public class DieAchievment : Achievement
{
	private const int ACHIEVTARGERT = 10;

	public override void Init()
	{
		achiveParams = new SaveLoadAchievmentStruct(complite: false, 0, 10);
	}

	public override void PlayerDeadEvent(SuicideAchievment.DethType i = SuicideAchievment.DethType.None)
	{
		if (achiveParams.achiveCounter < achiveParams.achiveTarget)
		{
			achiveParams.achiveCounter++;
		}
		else
		{
			AchievComplite();
		}
	}
}
