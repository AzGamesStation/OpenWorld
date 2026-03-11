using Game.Character.CharacterController;
using Game.Events;
using Game.GlobalComponent;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Factions
{
	public class FactionsManager : MonoBehaviour
	{
		private const string PlayerRelationsFactionsArrayName = "PlayerRelationsFactions";

		private const string PlayerRelationsValuesArrayName = "PlayerRelationsValues";

		private const float PolliceAttentionTime = 20f;

		private const float PoliceRelationWarmingValue = 0.5f;

		private static FactionsManager instance;

		[SerializeField]
		[Header("Ralation manager")]
		private RelationManager m_RelationManager;

		[SerializeField]
		private GameEvent m_RelationChangeEvent;

		private readonly List<HitEntity> victimsList = new List<HitEntity>();

		private SlowUpdateProc slowUpdateProc;

		private float lastCrimeTime;

		public static FactionsManager Instance
		{
			get
			{
				if (instance == null)
				{
					throw new Exception("FactionsManager is not initialized");
				}
				return instance;
			}
		}

		public static void ClearPlayerRelations()
		{
			BaseProfile.ClearArray<string>("PlayerRelationsFactions");
			BaseProfile.ClearArray<string>("PlayerRelationsValues");
		}

		public void SavePlayerRelations()
		{
			List<int> list = new List<int>();
			List<float> list2 = new List<float>();
			m_RelationManager.SavePlayerRelations(list, list2);
			BaseProfile.StoreArray(list.ToArray(), "PlayerRelationsFactions");
			BaseProfile.StoreArray(list2.ToArray(), "PlayerRelationsValues");
		}

		public Relations GetRelations(Faction entityFaction, Faction targetFaction)
		{
			if (entityFaction == Faction.NoneFaction || targetFaction == Faction.NoneFaction)
			{
				return Relations.Neutral;
			}
			if (entityFaction == targetFaction)
			{
				return Relations.Friendly;
			}
			if (entityFaction == Faction.Player)
			{
				return GetPlayerRelations(targetFaction);
			}
			if (targetFaction == Faction.Player)
			{
				return GetPlayerRelations(entityFaction);
			}
			return GetNPCRelations(entityFaction, targetFaction);
		}

		public void ChangePlayerRelations(Faction faction, float value)
		{
			m_RelationManager.GetPlayerRelations(faction).ChangeRelationValue(value);
			RelationChanged();
		}

		public void ChangePlayerRelations(Faction faction, Relations newRelations)
		{
			m_RelationManager.GetPlayerRelations(faction).CurrentRelations = newRelations;
			RelationChanged();
		}

		public void ChangeFriendlyFactionsRelation(Faction rootFaction, float amount)
		{
			int countNPCRelations = m_RelationManager.CountNPCRelations;
			for (int i = 0; i < countNPCRelations; i++)
			{
				NpcRelations nPCRelation = m_RelationManager.GetNPCRelation(i);
				if (nPCRelation != null && nPCRelation.TheirRelations == Relations.Friendly && nPCRelation.FirstFaction != nPCRelation.SecondFaction)
				{
					Faction faction = Faction.NoneFaction;
					if (nPCRelation.FirstFaction == rootFaction)
					{
						faction = nPCRelation.SecondFaction;
					}
					else if (nPCRelation.SecondFaction == rootFaction)
					{
						faction = nPCRelation.FirstFaction;
					}
					if (faction != 0)
					{
						ChangePlayerRelations(faction, amount);
					}
				}
			}
		}

		public void ChangeFriendlyFactionsRelation(Faction rootFaction, Relations newRelations)
		{
			int countNPCRelations = m_RelationManager.CountNPCRelations;
			for (int i = 0; i < countNPCRelations; i++)
			{
				NpcRelations nPCRelation = m_RelationManager.GetNPCRelation(i);
				if (nPCRelation != null && nPCRelation.TheirRelations == Relations.Friendly && nPCRelation.FirstFaction != nPCRelation.SecondFaction)
				{
					Faction faction = Faction.NoneFaction;
					if (nPCRelation.FirstFaction == rootFaction)
					{
						faction = nPCRelation.SecondFaction;
					}
					else if (nPCRelation.SecondFaction == rootFaction)
					{
						faction = nPCRelation.FirstFaction;
					}
					if (faction != 0)
					{
						ChangePlayerRelations(faction, newRelations);
					}
				}
			}
		}

		public void CommitedACrime()
		{
			if (GetPlayerRelations(Faction.Police) != Relations.Hostile)
			{
				ChangePlayerRelations(Faction.Police, -1f);
				ChangeFriendlyFactionsRelation(Faction.Police, -1f);
			}
			lastCrimeTime = Time.time;
		}

		public void PlayerAttackHuman(HitEntity victim)
		{
			if (!victimsList.Contains(victim) && m_RelationManager.GetNpcRelations(victim.Faction, Faction.Police) == Relations.Friendly)
			{
				victimsList.Add(victim);
				CommitedACrime();
				PoolManager.Instance.AddBeforeReturnEvent(victim, delegate
				{
					victimsList.Remove(victim);
				});
			}
		}

		public Relations GetPlayerRelations(Faction faction)
		{
			return m_RelationManager.GetPlayerRelations(faction).CurrentRelations;
		}

		public Relations GetNPCRelations(Faction firstFac, Faction secondFac)
		{
			return m_RelationManager.GetNpcRelations(firstFac, secondFac);
		}

		public float GetPlayerRelationNormalized(Faction faction)
		{
			float playerRelationsValue = GetPlayerRelationsValue(faction);
			if (playerRelationsValue >= 0f)
			{
				return playerRelationsValue / 10f;
			}
			return (0f - playerRelationsValue) / -10f;
		}

		public float GetPlayerRelationsValue(Faction faction)
		{
			return m_RelationManager.GetPlayerRelations(faction).RelationValue;
		}

		private void Awake()
		{
			instance = this;
			slowUpdateProc = new SlowUpdateProc(SlowUpdate, 1f);
			LoadPlayerRelations();
		}

		private void SlowUpdate()
		{
			if (Time.time > lastCrimeTime + 20f && GetPlayerRelationsValue(Faction.Police) < 0f)
			{
				ChangePlayerRelations(Faction.Police, 0.5f);
				ChangeFriendlyFactionsRelation(Faction.Police, 0.5f);
			}
		}

		private void FixedUpdate()
		{
			slowUpdateProc.ProceedOnFixedUpdate();
		}

		private void LoadPlayerRelations()
		{
			int[] factions = BaseProfile.ResolveArray<int>("PlayerRelationsFactions");
			float[] values = BaseProfile.ResolveArray<float>("PlayerRelationsValues");
			m_RelationManager.LoadPlayerRalationVariables(factions, values);
		}

		private void RelationChanged()
		{
			if (m_RelationChangeEvent != null)
			{
				m_RelationChangeEvent.Raise();
			}
		}
	}
}
