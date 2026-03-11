using System;

namespace Game.Factions
{
	[Serializable]
	public class NpcRelations
	{
		public Faction FirstFaction;

		public Faction SecondFaction;

		public Relations TheirRelations = Relations.Neutral;
	}
}
