using System.Collections.Generic;
using UnityEngine;

namespace Game.Factions
{
	[CreateAssetMenu(fileName = "RelationManager", menuName = "Managers/Create RelationManager", order = 1)]
	public class RelationManager : ScriptableObject
	{
		[SerializeField]
		private PlayerRelationsList m_DefaultPlayerRaltions;

		[SerializeField]
		private PlayerRelationsList m_PlayerRelationsListVariable;

		[Separator]
		[SerializeField]
		private NpcRelationsList m_DefaultNPCRelations;

		[SerializeField]
		private NpcRelationsList m_NPCRelationsListVariable;

		[Separator]
		[SerializeField]
		private List<Faction> ignoredFactionsToSave = new List<Faction>
		{
			Faction.Police,
			Faction.Civilian
		};

		public IList<Faction> IgnoredFactionToSave => ignoredFactionsToSave.AsReadOnly();

		public int CountNPCRelations => m_NPCRelationsListVariable.Count;

		public int CountPlayerRelations => m_PlayerRelationsListVariable.Count;

		private void OnEnable()
		{
			LoadDefaultPlayerRelationValues();
			LoadDefaultNPCRelationValues();
		}

		private void OnDisable()
		{
			LoadDefaultPlayerRelationValues();
			LoadDefaultNPCRelationValues();
		}

		public void LoadPlayerRalationVariables(int[] factions, float[] values)
		{
			if (factions == null || factions.Length == 0)
			{
				return;
			}
			LoadDefaultPlayerRelationValues();
			for (int i = 0; i < factions.Length; i++)
			{
				Faction faction = (Faction)factions[i];
				if (!ignoredFactionsToSave.Contains(faction))
				{
					PlayerRelations playerRelations = GetPlayerRelations(faction);
					playerRelations.RelationValue = values[i];
				}
			}
		}

		public void SavePlayerRelations(List<int> factions, List<float> values)
		{
			int count = m_PlayerRelationsListVariable.Count;
			for (int i = 0; i < count; i++)
			{
				PlayerRelations playerRelations = m_PlayerRelationsListVariable[i];
				if (playerRelations != null && !ignoredFactionsToSave.Contains(playerRelations.NpcFaction))
				{
					factions.Add((int)playerRelations.NpcFaction);
					values.Add(playerRelations.RelationValue);
				}
			}
		}

		private void LoadDefaultPlayerRelationValues()
		{
			m_PlayerRelationsListVariable.Clear();
			int count = m_DefaultPlayerRaltions.Count;
			for (int i = 0; i < count; i++)
			{
				PlayerRelations playerRelations = m_DefaultPlayerRaltions[i];
				if (playerRelations != null)
				{
					m_PlayerRelationsListVariable.Add(new PlayerRelations
					{
						NpcFaction = playerRelations.NpcFaction,
						RelationValue = playerRelations.RelationValue
					});
				}
			}
		}

		private void LoadDefaultNPCRelationValues()
		{
			m_NPCRelationsListVariable.Clear();
			int count = m_DefaultNPCRelations.Count;
			for (int i = 0; i < count; i++)
			{
				NpcRelations npcRelations = m_DefaultNPCRelations[i];
				if (npcRelations != null)
				{
					m_NPCRelationsListVariable.Add(new NpcRelations
					{
						FirstFaction = npcRelations.FirstFaction,
						SecondFaction = npcRelations.SecondFaction,
						TheirRelations = npcRelations.TheirRelations
					});
				}
			}
		}

		public PlayerRelations GetPlayerRelations(Faction faction)
		{
			PlayerRelations playerRelations = null;
			int count = m_PlayerRelationsListVariable.Count;
			for (int i = 0; i < count; i++)
			{
				PlayerRelations playerRelations2 = m_PlayerRelationsListVariable[i];
				if (playerRelations2.NpcFaction == faction)
				{
					playerRelations = playerRelations2;
					break;
				}
			}
			if (playerRelations == null)
			{
				PlayerRelations playerRelations3 = new PlayerRelations();
				playerRelations3.NpcFaction = faction;
				playerRelations = playerRelations3;
				m_PlayerRelationsListVariable.Add(playerRelations);
			}
			return playerRelations;
		}

		public Relations GetNpcRelations(Faction firstFac, Faction secondFac)
		{
			NpcRelations npcRelations = null;
			for (int i = 0; i < m_NPCRelationsListVariable.Count; i++)
			{
				NpcRelations npcRelations2 = m_NPCRelationsListVariable[i];
				if ((npcRelations2.FirstFaction == firstFac && npcRelations2.SecondFaction == secondFac) || (npcRelations2.FirstFaction == secondFac && npcRelations2.SecondFaction == firstFac))
				{
					npcRelations = npcRelations2;
					break;
				}
			}
			if (npcRelations == null)
			{
				NpcRelations npcRelations3 = new NpcRelations();
				npcRelations3.FirstFaction = firstFac;
				npcRelations3.SecondFaction = secondFac;
				npcRelations = npcRelations3;
				m_NPCRelationsListVariable.Add(npcRelations);
			}
			return npcRelations.TheirRelations;
		}

		public NpcRelations GetNPCRelation(int index)
		{
			return m_NPCRelationsListVariable[index];
		}

		public PlayerRelations GetPlayerRelation(int index)
		{
			return m_PlayerRelationsListVariable[index];
		}
	}
}
