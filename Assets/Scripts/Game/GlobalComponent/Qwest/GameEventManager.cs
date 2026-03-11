using Game.Character.CharacterController;
using Game.Factions;
using Game.Items;
using Game.MiniMap;
using Game.PickUps;
using Game.UI;
using Game.Vehicle;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GlobalComponent.Qwest
{
	public class GameEventManager : MonoBehaviour
	{
		private class GameEvent : IEvent
		{
			private delegate void QwestAction(Qwest qwest);

			private delegate void AchievementAction(Achievement achievement);

			public void PlayerDeadEvent(SuicideAchievment.DethType i = SuicideAchievment.DethType.None)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().PlayerDeadEvent();
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.PlayerDeadEvent(i);
				});
			}

			public void NpcKilledEvent(Vector3 position, Faction npcFaction, HitEntity victim, HitEntity killer)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().NpcKilledEvent(position, npcFaction, victim, killer);
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.NpcKilledEvent(position, npcFaction, victim, killer);
				});
			}

			public void PickedQwestItemEvent(Vector3 position, QwestPickupType pickupType, BaseTask relatedTask)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().PickedQwestItemEvent(position, pickupType, relatedTask);
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.PickedQwestItemEvent(position, pickupType, relatedTask);
				});
			}

			public void PointReachedEvent(Vector3 position, BaseTask task)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().PointReachedEvent(position, task);
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.PointReachedEvent(position, task);
				});
			}

			public void PointReachedByVehicleEvent(Vector3 position, BaseTask task, DrivableVehicle vehicle)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().PointReachedByVehicleEvent(position, task, vehicle);
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.PointReachedByVehicleEvent(position, task, vehicle);
				});
			}

			public void GetIntoVehicleEvent(DrivableVehicle vehicle)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().GetIntoVehicleEvent(vehicle);
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.GetIntoVehicleEvent(vehicle);
				});
			}

			public void GetOutVehicleEvent(DrivableVehicle vehicle)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().GetOutVehicleEvent(vehicle);
				});
				ByByPass(delegate(Achievement achievement)
				{
					achievement.GetOutVehicleEvent(vehicle);
				});
			}

			public void PickUpCollectionEvent(string CollectionName)
			{
				ByByPass(delegate(Achievement achievement)
				{
					achievement.PickUpCollectionEvent(CollectionName);
				});
			}

			public void GetLevelEvent(int level)
			{
				ByByPass(delegate(Achievement achievement)
				{
					achievement.GetLevelEvent(level);
				});
			}

			public void GetShopEvent()
			{
				ByByPass(delegate(Achievement achievement)
				{
					achievement.GetShopEvent();
				});
			}

			public void VehicleDrawingEvent(DrivableVehicle vehicle)
			{
				ByByPass(delegate(Achievement achievement)
				{
					achievement.VehicleDrawingEvent(vehicle);
				});
			}

			public void BuyItemEvent(GameItem item)
			{
				ByPass(delegate(Qwest qwest)
				{
					qwest.GetCurrentTask().BuyItemEvent(item);
				});
			}

			private void ByPass(QwestAction action)
			{
				Qwest[] array = Instance.ActiveQwests.ToArray();
				foreach (Qwest qwest in array)
				{
					if (!Instance.TimeQwestActive || Instance.CurrentTimeQwest.Equals(qwest))
					{
						action(qwest);
					}
				}
			}

			private void ByByPass(AchievementAction action)
			{
				Achievement[] array = Instance.activeAchievements.ToArray();
				foreach (Achievement achievement in array)
				{
					action(achievement);
				}
			}
		}

		private static GameEventManager instance;

		public readonly IEvent Event = new GameEvent();

        [Separator("Qwest Data")]
        [HideInInspector]
        public string QwestData;
		public TextAsset SerializedQwests;
		//public NewLevel LevelData;

		[Separator("Mini Map")]
		public MarkForMiniMap MMMark;

		public Transform MapMarksListTransform;

		[Separator("Prefabs")]
		public QuestPickUp[] questPickUps;

		public QwestStart QwestStartPrefab;

		public QwestPoint QwestPointPrefab;

		public QwestVehiclePoint QwestVehiclePointPrefab;

		public Qwest MarkedQwest;

		[HideInInspector]
		public Qwest CurrentTimeQwest;

		public bool MassacreTaskActive;

		[Separator("Achievments")]
		public bool AchievmentsReset;

		public List<Achievement> activeAchievements = new List<Achievement>();

		public List<Achievement> allAchievements = new List<Achievement>();

		public readonly List<Qwest> ActiveQwests = new List<Qwest>();

		private readonly List<Qwest> availableQwests = new List<Qwest>();

		public List<Qwest> allQwests = new List<Qwest>();

		private readonly List<Qwest> nextQuests = new List<Qwest>();

		public GameObject QwestStartPointObjectsParent;
		public GameObject CallerStartPointObjectsParent;

		public static GameEventManager Instance
		{
			get
			{
				if (instance == null)
				{
                    instance = GameObject.FindObjectOfType<GameEventManager>();
                }
				return instance;
			}
		}

		public bool TaskSelectionAvailable => !MassacreTaskActive;

		public bool TimeQwestActive => CurrentTimeQwest != null;

		private List<GetJsonFunReturn> allQwest = new List<GetJsonFunReturn>();
		[ContextMenu ("JsonDeserielised")]
		private void GenerateLevels()
		{
			string strJson = "List<Qwest> lstNewQwests = new List<Qwest>();\n";
			strJson += "Vector3 tempV3 = new Vector3();\n\n\n";
			int totalQwestCount = 0;
			foreach (Qwest qwest in this.allQwests)
			{
				++totalQwestCount;
				strJson += "\n\n//----------" + totalQwestCount + "-----------\n\n";
				GetJsonFunReturn objRetMain = GetQwest(qwest);
				strJson += objRetMain.strJson;

				if (qwest.ParentQwest == null)
				{
					strJson += "\n" + objRetMain.objName + ".ParentQwest = null;\n";
				}
				else
				{
					GetJsonFunReturn objRet = GetQwest(qwest.ParentQwest);
					strJson += objRet.strJson;
					strJson += "\n" + objRetMain.objName + ".ParentQwest = " + objRet.objName + ";\n";
				}

				strJson += "\nlstNewQwests.Add(" + objRetMain.objName + ");";
				strJson += "\n\n\n";
			}
			WriteString(strJson);
		}
		int qwestObjIndex = 0;
		private GetJsonFunReturn GetQwest(Qwest qwest)
		{
			foreach (GetJsonFunReturn obj in allQwest)
			{
				if (obj != null && obj.qwest != null && obj.qwest.Name == qwest.Name
					&& obj.qwest.QwestTitle == qwest.QwestTitle && obj.qwest.StartDialog == qwest.StartDialog
					&& obj.qwest.EndDialog == qwest.EndDialog && obj.qwest.TasksList == qwest.TasksList
					&& obj.qwest.QwestTree == qwest.QwestTree && obj.qwest.ParentQwest == qwest.ParentQwest
					)
				{
					return obj;
				}
			}

			GetJsonFunReturn objRet = new GetJsonFunReturn();
			string qwestObjName = "objQwest" + qwestObjIndex;
			objRet.objName = qwestObjName;

			string strJson = "";
			GetJsonFunReturn tempGetJsonFunReturn = new GetJsonFunReturn();
			tempGetJsonFunReturn.strJson = "\n\n";
			tempGetJsonFunReturn.objName = qwestObjName;
			tempGetJsonFunReturn.qwest = qwest;
			allQwest.Add(tempGetJsonFunReturn);
			qwestObjIndex++;

			strJson += "Qwest " + qwestObjName + " = new Qwest();\n";
			strJson += qwestObjName + ".Name = \"" + qwest.Name + "\";\n";
			strJson += qwestObjName + ".QwestTitle = \"" + qwest.QwestTitle + "\";\n";

			strJson += "\n" + qwestObjName + ".Rewards = new UniversalReward();\n";
			strJson += qwestObjName + ".Rewards.ExperienceReward = " + qwest.Rewards.ExperienceReward + ";\n";
			strJson += qwestObjName + ".Rewards.MoneyReward = " + qwest.Rewards.MoneyReward + ";\n";
			strJson += qwestObjName + ".Rewards.RewardInGems = " + qwest.Rewards.RewardInGems.ToString().ToLower() + ";\n";
			strJson += qwestObjName + ".Rewards.ItemRewardID = " + qwest.Rewards.ItemRewardID + ";\n";
			strJson += qwestObjName + ".Rewards.RelationRewards = new FactionRelationReward[0];\n";
			int countIndex = 0;
			//foreach (FactionRelationReward relationReward in qwest.Rewards.RelationRewards)
			//{
			//    strJson += qwestObjName + ".Rewards.RelationRewards.SetValue("+qwest.Rewards.RelationRewards.GetValue(countIndex)+", "+countIndex+");\n";

			//        countIndex++;
			//}

			strJson += "\n" + qwestObjName + ".ShowQwestCompletePanel = " + qwest.ShowQwestCompletePanel.ToString().ToLower() + ";\n";
			strJson += qwestObjName + ".TimerValue = " + qwest.TimerValue + ";\n";
			strJson += qwestObjName + ".RepeatableQuest = " + qwest.RepeatableQuest.ToString().ToLower() + ";\n";
			strJson += qwestObjName + ".MMMarkId = " + qwest.MMMarkId + ";\n";

			strJson += "\n" + qwestObjName + ".MarkForMiniMap = null;\n";

			strJson += qwestObjName + ".AdditionalStartPointRadius = " + qwest.AdditionalStartPointRadius + ";\n";
			strJson += qwestObjName + ".StartDialog = \"" + qwest.StartDialog.Replace("\"", "\\\"") + "\";\n";
			strJson += qwestObjName + ".EndDialog = \"" + qwest.EndDialog.Replace("\"", "\\\"") + "\";\n\n";

			strJson += "\n\ntempV3 = new Vector3(" + qwest.StartPosition.x + "f," + qwest.StartPosition.y + "f, " + qwest.StartPosition.z + "f);\n";
			strJson += qwestObjName + ".StartPosition = tempV3;";


			countIndex = 0;
			strJson += "\n" + qwestObjName + ".TasksList = new BaseTask[" + qwest.TasksList.Length + "];\n";
			foreach (BaseTask baseTask in qwest.TasksList)
			{
				GetJsonFunReturn objBaseRet = GetBaseTask(baseTask);
				if (objBaseRet != null)
				{
					strJson += objBaseRet.strJson;
					strJson += qwestObjName + ".TasksList.SetValue(" + objBaseRet.objName + ", " + countIndex + ");\n";
					countIndex++;
				}
			}


			countIndex = 0;
			strJson += "\n" + qwestObjName + ".QwestTree = new List<Qwest>();\n";
			foreach (Qwest objQwestLoop in qwest.QwestTree)
			{
				GetJsonFunReturn objBaseRet = GetQwest(objQwestLoop);
				if (objBaseRet != null)
				{
					strJson += objBaseRet.strJson;
					strJson += qwestObjName + ".QwestTree.Add(" + objBaseRet.objName + ");\n";
					countIndex++;
				}
			}

			strJson += "\n";

			objRet.strJson = strJson;
			return objRet;
		}
		private void WriteString(string text)
		{
			string path = "Assets/test.txt";

			System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true);
			writer.WriteLine(text);
			writer.Close();
		}
		public class GetJsonFunReturn
		{
			public string objName;
			public string strJson;

			public Qwest qwest;
			public BaseTask baseTask;
		}
		private int basetTaskObjCount = 0;
		private List<GetJsonFunReturn> allBaseTask = new List<GetJsonFunReturn>();
		private GetJsonFunReturn GetBaseTask(BaseTask baseTask)
		{
			foreach (GetJsonFunReturn obj in allBaseTask)
			{
				if (obj != null && obj.baseTask != null
					&& obj.baseTask.TaskText == baseTask.TaskText && obj.baseTask.AdditionalTimer == baseTask.AdditionalTimer
					&& obj.baseTask.DialogData == baseTask.DialogData && obj.baseTask.EndDialogData == baseTask.EndDialogData
					&& obj.baseTask.NextTask == baseTask.NextTask && obj.baseTask.PrevTask == baseTask.PrevTask
					)
				{
					return obj;
				}
			}

			GetJsonFunReturn objRet = new GetJsonFunReturn();
			objRet.objName = "objBaseTask" + basetTaskObjCount;

			GetJsonFunReturn tempGetJsonFunReturn = new GetJsonFunReturn();
			tempGetJsonFunReturn.strJson = "\n\n";
			tempGetJsonFunReturn.objName = objRet.objName;
			tempGetJsonFunReturn.baseTask = baseTask;
			allBaseTask.Add(tempGetJsonFunReturn);
			basetTaskObjCount++;

			string strJson = "";

			if (baseTask.GetType() == typeof(ReachPointTask))
			{
				ReachPointTask obj = (ReachPointTask)baseTask;
				strJson += "\n\nReachPointTask " + objRet.objName + " = new ReachPointTask();\n";
				strJson += objRet.objName + ".PointPosition = new Vector3(" + obj.PointPosition.x + "f," + obj.PointPosition.y + "f," + obj.PointPosition.z + "f);\n";
				strJson += objRet.objName + ".AdditionalPointRadius = " + obj.AdditionalPointRadius + ";\n\n";
			}
			//else if (baseTask.GetType() == typeof(RaceTask))
			//{
			//	RaceTask obj = (RaceTask)baseTask;
			//	strJson += "\n\nRaceTask " + objRet.objName + " = new RaceTask();\n";
			//	strJson += objRet.objName + ".RaceNumber = " + obj.RaceNumber + ";\n\n";
			//}
			//else if (baseTask.GetType() == typeof(ArenaTutorialTask))
			//{
			//	ArenaTutorialTask obj = (ArenaTutorialTask)baseTask;
			//	strJson += "\n\nArenaTutorialTask " + objRet.objName + " = new ArenaTutorialTask();\n";
			//	strJson += objRet.objName + ".State = ArenaTutorial.TutorialState." + obj.State + ";\n\n";
			//}
			else if (baseTask.GetType() == typeof(BuyGameItemTask))
			{
				BuyGameItemTask obj = (BuyGameItemTask)baseTask;
				strJson += "\n\nBuyGameItemTask " + objRet.objName + " = new BuyGameItemTask();\n";
				strJson += objRet.objName + ".ItemID = " + obj.ItemID + ";\n";
				strJson += objRet.objName + ".AddMoneyBeforeStartTask = " + obj.AddMoneyBeforeStartTask + ";\n";
				strJson += objRet.objName + ".InGems = " + obj.InGems.ToString().ToLower() + ";\n\n";
			}
			else if (baseTask.GetType() == typeof(CollectItemsTask))
			{
				CollectItemsTask obj = (CollectItemsTask)baseTask;
				strJson += "\n\nCollectItemsTask " + objRet.objName + " = new CollectItemsTask();\n";
				strJson += objRet.objName + ".InitialCountToCollect = " + obj.InitialCountToCollect + ";\n";
				strJson += objRet.objName + ".PickupType = QwestPickupType." + obj.PickupType + ";\n";
				strJson += objRet.objName + ".TargetFaction = Faction." + obj.TargetFaction + ";\n";
				strJson += objRet.objName + ".MarksCount = " + obj.MarksCount + ";\n";
				strJson += objRet.objName + ".MarksTypeNPC = \"" + obj.MarksTypeNPC + "\";\n";
				strJson += objRet.objName + ".MarksTypePickUp = \"" + obj.MarksTypePickUp + "\";\n\n";
			}
			else if (baseTask.GetType() == typeof(ComboTask))
			{
				ComboTask obj = (ComboTask)baseTask;
				strJson += "\n\nComboTask " + objRet.objName + " = new ComboTask();\n";
				strJson += objRet.objName + ".WeaponDependent = " + obj.WeaponDependent.ToString().ToLower() + ";\n";
				strJson += objRet.objName + ".RequiredWeapon = \"" + obj.RequiredWeapon + "\";\n";
				strJson += objRet.objName + ".RequiredComboCount = " + obj.RequiredComboCount + ";\n\n";
			}
			else if (baseTask.GetType() == typeof(CounterTask))
			{
				CounterTask obj = (CounterTask)baseTask;
				strJson += "\n\nCounterTask " + objRet.objName + " = new CounterTask();\n";
				strJson += objRet.objName + ".TaskChecksCount = " + obj.TaskChecksCount + ";\n\n";

				GetJsonFunReturn objJsonRet = GetBaseTask(obj.ReturnTask);
				if (objJsonRet == null)
				{
					strJson += objRet.objName + ".ReturnTask = null;\n\n";
				}
				else
				{
					strJson += objJsonRet.strJson;
					strJson += objRet.objName + ".ReturnTask = \"" + objJsonRet.objName + "\";\n\n";
				}
			}
			else if (baseTask.GetType() == typeof(DriveToPointTask))
			{
				DriveToPointTask obj = (DriveToPointTask)baseTask;
				strJson += "\n\nDriveToPointTask " + objRet.objName + " = new DriveToPointTask();\n";
				strJson += objRet.objName + ".PointPosition = new Vector3(" + obj.PointPosition.x + "f," + obj.PointPosition.y + "f," + obj.PointPosition.z + "f);\n";
				strJson += objRet.objName + ".SpecificVehicleName = VehicleList." + obj.SpecificVehicleName + ";\n";
				strJson += objRet.objName + ".PointRadius = " + obj.PointRadius + ";\n";
				strJson += objRet.objName + ".VehicleType = VehicleType." + obj.VehicleType + ";\n\n";
			}
			//else if (baseTask.GetType() == typeof(EnterArenaTask))
			//{
			//	EnterArenaTask obj = (EnterArenaTask)baseTask;
			//	strJson += "\n\nEnterArenaTask " + objRet.objName + " = new EnterArenaTask();\n";
			//	strJson += objRet.objName + ".HighlightPoint = new Vector3(" + obj.HighlightPoint.x + "f," + obj.HighlightPoint.y + "f," + obj.HighlightPoint.z + "f);\n";
			//	strJson += objRet.objName + ".AdditionalPointRadius = " + obj.AdditionalPointRadius + ";\n\n";
			//}
			else if (baseTask.GetType() == typeof(LeaveACarAtPointTask))
			{
				LeaveACarAtPointTask obj = (LeaveACarAtPointTask)baseTask;
				strJson += "\n\nLeaveACarAtPointTask " + objRet.objName + " = new LeaveACarAtPointTask();\n";
				strJson += objRet.objName + ".PointPosition = new Vector3(" + obj.PointPosition.x + "f," + obj.PointPosition.y + "f," + obj.PointPosition.z + "f);\n";
				strJson += objRet.objName + ".SpecificVehicleName = VehicleList." + obj.SpecificVehicleName + ";\n";
				strJson += objRet.objName + ".VehicleType = VehicleType." + obj.VehicleType + ";\n";
				strJson += objRet.objName + ".Range = " + obj.Range + ";\n";
				strJson += objRet.objName + ".PointRadius = " + obj.PointRadius + ";\n";
				strJson += objRet.objName + ".AtPointDialog = \"" + obj.AtPointDialog.Replace("\"", "\\\"") + "\";\n\n";
			}
			else if (baseTask.GetType() == typeof(MassacreTask))
			{
				MassacreTask obj = (MassacreTask)baseTask;
				strJson += "\n\nMassacreTask " + objRet.objName + " = new MassacreTask();\n";
				strJson += objRet.objName + ".WeaponItemID = " + obj.WeaponItemID + ";\n";
				strJson += objRet.objName + ".RequiredVictimsCount = " + obj.RequiredVictimsCount + ";\n";
				strJson += objRet.objName + ".MarksTypeNPC = \"" + obj.MarksTypeNPC + "\";\n";
				strJson += objRet.objName + ".MarksCount = " + obj.MarksCount + ";\n\n";
			}
			else if (baseTask.GetType() == typeof(StealAVehicleTask))
			{
				StealAVehicleTask obj = (StealAVehicleTask)baseTask;
				strJson += "\n\nStealAVehicleTask " + objRet.objName + " = new StealAVehicleTask();\n";
				strJson += objRet.objName + ".SpecificVehicleName = VehicleList." + obj.SpecificVehicleName + ";\n";
				strJson += objRet.objName + ".VehicleType = VehicleType." + obj.VehicleType + ";\n";
				strJson += objRet.objName + ".countVisualMarks = " + obj.countVisualMarks + ";\n";
				strJson += objRet.objName + ".markVisualType = \"" + obj.markVisualType + "\";\n\n";
			}
			else if (baseTask.GetType() == typeof(TeleportPlayerToPositionTask))
			{
				TeleportPlayerToPositionTask obj = (TeleportPlayerToPositionTask)baseTask;
				strJson += "\n\nTeleportPlayerToPositionTask " + objRet.objName + " = new TeleportPlayerToPositionTask();\n";
				strJson += objRet.objName + ".targetPosition = new Vector3(" + obj.targetPosition.x + "f," + obj.targetPosition.y + "f," + obj.targetPosition.z + "f);\n\n";
			}
			else
			{
				strJson += "\n\nBaseTask " + objRet.objName + " = new BaseTask();\n";
			}


			strJson += objRet.objName + ".TaskText = \"" + baseTask.TaskText + "\";\n";
			strJson += objRet.objName + ".AdditionalTimer = " + baseTask.AdditionalTimer + ";\n";
			strJson += objRet.objName + ".DialogData = \"" + baseTask.DialogData.Replace("\"", "\\\"") + "\";\n";
			strJson += objRet.objName + ".EndDialogData = \"" + baseTask.EndDialogData.Replace("\"", "\\\"") + "\";\n";

			if (baseTask.NextTask == null)
			{
				strJson += objRet.objName + ".NextTask = null;\n";
			}
			else
			{
				GetJsonFunReturn objBaseRet = GetBaseTask(baseTask.NextTask);
				if (objBaseRet == null)
				{
					strJson += objRet.objName + ".NextTask = null;\n";
				}
				else
				{
					strJson += objBaseRet.strJson;
					strJson += objRet.objName + ".NextTask = " + objBaseRet.objName + ";\n";
				}
			}

			if (baseTask.PrevTask == null)
			{
				strJson += objRet.objName + ".PrevTask = null;\n";
			}
			else
			{
				GetJsonFunReturn objBaseRet = GetBaseTask(baseTask.PrevTask);
				if (objBaseRet == null)
				{
					strJson += objRet.objName + ".PrevTask = null;\n";
				}
				else
				{
					strJson += objBaseRet.strJson;
					strJson += objRet.objName + ".PrevTask = " + objBaseRet.objName + ";\n";
				}
			}

			objRet.strJson = strJson;
			return objRet;
		}


		public void StartQwest(Qwest qwest)
		{
			if (!TimeQwestActive && availableQwests.Contains(qwest))
			{
				Debug.Log("startQwest");
				ActiveQwests.Add(qwest);
				qwest.Init();
				MarkedQwest = qwest;
				RefreshQwestArrow();
				availableQwests.Remove(qwest);
				ToggleQwestMark(qwest, toggle: false);
				if (qwest.IsTimeQwest)
				{
					CurrentTimeQwest = qwest;
					MarkedQwest = qwest;
					BackgroundMusic.instance.PlayTimeQuestClip();
				}

			}
		}

		public void QwestFailed(Qwest qwest)
		{
			if (ActiveQwests.Contains(qwest))
			{
				qwest.GetCurrentTask()?.Finished();
				ActiveQwests.Remove(qwest);
				if (qwest.Equals(MarkedQwest))
				{
					MarkedQwest = ((ActiveQwests.Count <= 0) ? null : ActiveQwests[0]);
					RefreshQwestArrow();
				}
				PlaceQuestOnMap(qwest);
				InGameLogManager.Instance.RegisterNewMessage(MessageType.QuestFailed, qwest.QwestTitle);
				PointSoundManager.Instance.PlaySoundAtPoint(Vector3.zero, "QwestFailed");
				if (qwest.Equals(CurrentTimeQwest))
				{
					CurrentTimeQwest = null;
					BackgroundMusic.instance.StopTimeQuestClip();
				}
			}
		}

		public void QwestResolved(Qwest qwest)
		{
			if (TimeQwestActive && !qwest.Equals(CurrentTimeQwest))
			{
				return;
			}
			if (TimeQwestActive && qwest.Equals(CurrentTimeQwest))
			{
				CurrentTimeQwest = null;
				BackgroundMusic.instance.StopTimeQuestClip();
			}
			nextQuests.Clear();
			Debug.Log("RepeatableQuest :: " + qwest.RepeatableQuest);
			ActiveQwests.Remove(qwest);
			if (qwest.RepeatableQuest)
			{
				nextQuests.Add(qwest);
			}
			else
			{
				Dictionary<string, bool> qwestStatus = QwestProfile.QwestStatus;
				if (!qwestStatus.ContainsKey(qwest.Name))
				{
					qwestStatus.Add(qwest.Name, value: true);
					QwestProfile.QwestStatus = qwestStatus;
				}

				for (int i = 0; i < qwest.QwestTree.Count; i++)
				{
					Qwest item = qwest.QwestTree[i];
					nextQuests.Add(item);
				}
			}

			for (int j = 0; j < nextQuests.Count; j++)
			{

				Qwest quest = nextQuests[j];
				if (!quest.isCallerLevel)
				{
					PlaceQuestOnMap(quest);
					if (nextQuests[j].Name == "Steal a car 2")
					{
						BaseProfile.ClearBaseDataAtlastLevel();
					}
                }
                else
                {
					//CallController.instance.ActiveNextCall();
					if (nextQuests[j].Name == "CallerLevel (2)")
					{
						BaseProfile.ClearBaseDataAtlastLevel();
					}


				}
			}
			if (qwest.Equals(MarkedQwest))
			{
				MarkedQwest = ((ActiveQwests.Count <= 0) ? null : ActiveQwests[0]);
				RefreshQwestArrow();
			}
			QwestStartPointObjectsParent.SetActive(true);

		}

		public void RefreshQwestArrow()
		{
			if (UIMarkManager.InstanceExist)
			{
				if (MarkedQwest != null && MarkedQwest.GetQwestTarget() != null && QwestProfile.QwestArrow)
				{
					UIMarkManager.Instance.TargetStaticMark = MarkedQwest.GetQwestTarget();
					UIMarkManager.Instance.ActivateStaticMark(value: true);
				}
				else
				{
					UIMarkManager.Instance.ActivateStaticMark(value: false);
				}
			}
		}

		private void GenerateQwestStartPoint(Qwest qwest)
		{
			QwestStart qwestStart = PoolManager.Instance.GetFromPool(QwestStartPrefab);
			PoolManager.Instance.AddBeforeReturnEvent(qwestStart, delegate
			{
				qwestStart.Qwest = null;
			});
			qwestStart.Qwest = qwest;
			//qwestStart.transform.parent = base.transform;
			qwestStart.transform.localPosition = qwest.StartPosition;
			qwestStart.transform.localScale = new Vector3(1f + qwest.AdditionalStartPointRadius, 1f + qwest.AdditionalStartPointRadius, 1f + qwest.AdditionalStartPointRadius);
			ToggleQwestMark(qwest, toggle: true);
            if (!qwest.isCallerLevel)
            {
				qwestStart.gameObject.transform.parent = QwestStartPointObjectsParent.transform;
            }
            else
            {
				qwestStart.gameObject.transform.parent = CallerStartPointObjectsParent.transform;
			}
			
		}

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				UIGame uIGame = UIGame.Instance;
				uIGame.OnExitInMenu = (Action)Delegate.Combine(uIGame.OnExitInMenu, new Action(OnExitInMenu));
				UIGame uIGame2 = UIGame.Instance;
				uIGame2.OnPausePanelOpen = (Action)Delegate.Combine(uIGame2.OnPausePanelOpen, new Action(OnPausePanelOpen));
			}
			if (MapMarksListTransform != null)
			{
				MarkForMiniMap[] componentsInChildren = MapMarksListTransform.GetComponentsInChildren<MarkForMiniMap>();
				if (componentsInChildren != null)
				{
					MarkForMiniMap[] array = componentsInChildren;
					foreach (MarkForMiniMap markForMiniMap in array)
					{
						markForMiniMap.HideIcon();
					}
				}
			}
            //allQwests.AddRange(MiamiSerializier.JSONDeserialize<List<Qwest>>(SerializedQwests.text));
            //allQwests.AddRange(NewLevel.GetNewLevels ());
            allQwests.AddRange(MiamiSerializier.JSONDeserialize<List<Qwest>>(QwestData));

            Dictionary<string, bool> qwestStatus = QwestProfile.QwestStatus;
			foreach (Qwest allQwest in allQwests)
			{
				if (!allQwest.isCallerLevel && !qwestStatus.ContainsKey(allQwest.Name) && (allQwest.ParentQwest == null || (allQwest.ParentQwest != null && qwestStatus.ContainsKey(allQwest.ParentQwest.Name))))
				{
					PlaceQuestOnMap(allQwest);
                }
                else if (!qwestStatus.ContainsKey(allQwest.Name) && allQwest.isCallerLevel)
                {
					Debug.Log("Awake Active call");
					//CallController.instance.ActiveNextCall();
				}
			}
			allAchievements.RemoveAll((Achievement elem) => elem != null);
			activeAchievements.RemoveAll((Achievement elem) => elem != null);
			Achievement[] componentsInChildren2 = GetComponentsInChildren<Achievement>();
			foreach (Achievement achievement in componentsInChildren2)
			{
				achievement.Init();
				allAchievements.Add(achievement);
			}
			if (AchievmentsReset)
			{
				SaveAchievements();
			}
			LoadAchievements();
			foreach (Achievement allAchievement in allAchievements)
			{
				if (!allAchievement.achiveParams.isDone)
				{
					activeAchievements.Add(allAchievement);
				}
			}
		}

		int index;
		public void RecieveCall()
        {
			allQwests.AddRange(MiamiSerializier.JSONDeserialize<List<Qwest>>(QwestData));
			QwestStartPointObjectsParent.SetActive(false);
			Dictionary<string, bool> qwestStatus = QwestProfile.QwestStatus;
			index = PlayerPrefs.GetInt("CallerIndex", 0);
			index++;
			PlayerPrefs.SetInt("CallerIndex", index);

			//allQwests.Count = allQwests.Count - allQwests.Count / 2;
			foreach (Qwest allQwest in allQwests)
			{
				if (!qwestStatus.ContainsKey(allQwest.Name) && allQwest.isCallerLevel && allQwest.index == index)
				{
                    if (CallController.instance.isCallerLevelGet)
                    {
						return;
                    }
					Debug.Log("Caller Level Generated :: " + allQwest.Name);
					PlaceQuestOnMap(allQwest);
					CallController.instance.isCallerLevelGet = true;
				}
			}

		}

		private void PlaceQuestOnMap(Qwest quest)
		{
			availableQwests.Add(quest);
			GenerateQwestStartPoint(quest);
		}

		private void SaveAchievements()
		{
			foreach (Achievement allAchievement in allAchievements)
			{
				allAchievement.SaveAchiev();
			}
			CollectionPickUpsManager.Instance.SaveCollections();
		}

		private void LoadAchievements()
		{
			foreach (Achievement allAchievement in allAchievements)
			{
				allAchievement.LoadAchiev();
			}
		}

		private void Update()
		{
			if (MMMark != null)
			{
				if (!MMMark.isActiveAndEnabled)
				{
					MMMark.gameObject.SetActive(value: true);
				}
				if (MarkedQwest != null && MarkedQwest.GetQwestTarget() != null)
				{
					MMMark.transform.position = MarkedQwest.GetQwestTarget().position;
					MMMark.ShowIcon();
				}
				else
				{
					MMMark.HideIcon();
				}
			}
		}

		private void ToggleQwestMark(Qwest qwest, bool toggle)
		{
			if (qwest.MMMarkId != -1)
			{
				MarkForMiniMap markForMiniMap = qwest.MarkForMiniMap;
				if (markForMiniMap == null)
				{
					markForMiniMap = (qwest.MarkForMiniMap = MapMarksListTransform.GetChild(qwest.MMMarkId).GetComponent<MarkForMiniMap>());
				}
				if (toggle)
				{
					markForMiniMap.transform.position = qwest.StartPosition;
					markForMiniMap.gameObject.SetActive(value: true);
					markForMiniMap.ShowIcon();
				}
				else
				{
					markForMiniMap.HideIcon();
					markForMiniMap.gameObject.SetActive(value: false);
				}
			}
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				SaveAchievements();
			}
		}

		private void OnApplicationQuit()
		{
			SaveAchievements();
		}

		private void OnExitInMenu()
		{
			SaveAchievements();
		}

		private void OnPausePanelOpen()
		{
			SaveAchievements();
		}
	}
}
