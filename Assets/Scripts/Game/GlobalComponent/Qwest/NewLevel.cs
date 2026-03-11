using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.GlobalComponent.Qwest;
using Game.Vehicle;
using Game.Factions;
public class NewLevel : MonoBehaviour
{
 public static List<Qwest> GetNewLevels()
    {
        List<Qwest> lstNewQwests = new List<Qwest>();
        Vector3 tempV3 = new Vector3();




        //----------Qwest#1-----------

        Qwest objQwest0 = new Qwest();
        objQwest0.Name = "Tasko";
        objQwest0.QwestTitle = "Get to Work";

        objQwest0.Rewards = new UniversalReward();
        objQwest0.Rewards.ExperienceReward = 1100;
        objQwest0.Rewards.MoneyReward = 0;
        objQwest0.Rewards.RewardInGems = false;
        objQwest0.Rewards.ItemRewardID = -192958;
        objQwest0.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest0.ShowQwestCompletePanel = true;
        objQwest0.TimerValue = 0;
        objQwest0.RepeatableQuest = false;
        objQwest0.MMMarkId = 2;

        objQwest0.MarkForMiniMap = null;
        objQwest0.AdditionalStartPointRadius = 0;
        objQwest0.StartDialog = "{\"DialogName\":\"Start_11\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"'sms message' – Be Here ASAP!\"},{\"Actor\":\"You\",\"Replica\":\"'texting' – On it!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest0.EndDialog = "";



        tempV3 = new Vector3(-376.91f, 1.917877f, 217.26f);
        objQwest0.StartPosition = tempV3;
        objQwest0.TasksList = new BaseTask[2];


        ReachPointTask objBaseTask0 = new ReachPointTask();
        objBaseTask0.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask0.AdditionalPointRadius = 0;

        objBaseTask0.TaskText = "Go to bro";
        objBaseTask0.AdditionalTimer = 0;
        objBaseTask0.DialogData = "{\"DialogName\":\"987435\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Find Bro Man!.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask0.EndDialogData = "{\"DialogName\":\"Start_11\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"Hey! You here, Blake! So this City is a nice place mate? But here at hotel and seaside, the place is quite frustrating!\"},{\"Actor\":\"You\",\"Replica\":\"- Big time, that's lit.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- At first I'll give you the small remedy. I've heard you're a good cold-blooded shooter...\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Of course, if you're the veteran of Syria, Iraq, Afghanistan and Vietnam, which hating our government now.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Such as we need here! There is the war that we're losing now! The mayor sell our island, our land for a penny! \nSame time other bands don't want to talk, just kill each other!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        ReachPointTask objBaseTask1 = new ReachPointTask();
        objBaseTask1.PointPosition = new Vector3(-216.4f, 2.31f, -23.1f);
        objBaseTask1.AdditionalPointRadius = 0;

        objBaseTask1.TaskText = "Talk with Winslow";
        objBaseTask1.AdditionalTimer = 0;
        objBaseTask1.DialogData = "";
        objBaseTask1.EndDialogData = "{\"DialogName\":\"321454\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Buy the Ammo mate and leave conversation for later.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask1.NextTask = null;


        objBaseTask1.PrevTask = objBaseTask0;
        objBaseTask0.NextTask = objBaseTask1;
        objBaseTask0.PrevTask = null;
        objQwest0.TasksList.SetValue(objBaseTask0, 0);


        objQwest0.TasksList.SetValue(objBaseTask1, 1);

        objQwest0.QwestTree = new List<Qwest>();

        //----------Qwest#2-----------

        Qwest objQwest1 = new Qwest();
        objQwest1.Name = "Buy item";
        objQwest1.QwestTitle = "Buy ammo";

        objQwest1.Rewards = new UniversalReward();
        objQwest1.Rewards.ExperienceReward = 1210;
        objQwest1.Rewards.MoneyReward = 4000;
        objQwest1.Rewards.RewardInGems = false;
        objQwest1.Rewards.ItemRewardID = 0;
        objQwest1.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest1.ShowQwestCompletePanel = true;
        objQwest1.TimerValue = 0;
        objQwest1.RepeatableQuest = false;
        objQwest1.MMMarkId = 2;

        objQwest1.MarkForMiniMap = null;
        objQwest1.AdditionalStartPointRadius = 0;
        objQwest1.StartDialog = "{\"DialogName\":\"krekerrtek\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Here is how we can buy Ammo Mate.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest1.EndDialog = "";



        tempV3 = new Vector3(-174.29f, 2.31f, -80.55f);
        objQwest1.StartPosition = tempV3;
        objQwest1.TasksList = new BaseTask[1];


        BuyGameItemTask objBaseTask2 = new BuyGameItemTask();
        objBaseTask2.ItemID = -2720466;
        objBaseTask2.AddMoneyBeforeStartTask = 500;
        objBaseTask2.InGems = false;

        objBaseTask2.TaskText = "Buy the Ammo";
        objBaseTask2.AdditionalTimer = 0;
        objBaseTask2.DialogData = "{\"DialogName\":\"buy9mm\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"Purchase Ammo in Shop\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask2.EndDialogData = "{\"DialogName\":\"endbuyitem9mm\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Jakson\",\"Replica\":\"- Awesome Work mate!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask2.NextTask = null;
        objBaseTask2.PrevTask = null;
        objQwest1.TasksList.SetValue(objBaseTask2, 0);

        objQwest1.QwestTree = new List<Qwest>();



        Qwest objQwest2 = new Qwest();
        objQwest2.Name = "Transfer";
        objQwest2.QwestTitle = "Transfer";

        objQwest2.Rewards = new UniversalReward();
        objQwest2.Rewards.ExperienceReward = 1331;
        objQwest2.Rewards.MoneyReward = 0;
        objQwest2.Rewards.RewardInGems = false;
        objQwest2.Rewards.ItemRewardID = -899488;
        objQwest2.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest2.ShowQwestCompletePanel = true;
        objQwest2.TimerValue = 0;
        objQwest2.RepeatableQuest = false;
        objQwest2.MMMarkId = 2;

        objQwest2.MarkForMiniMap = null;
        objQwest2.AdditionalStartPointRadius = 0;
        objQwest2.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Go to Carlos and get yourself hired! Make sure you help him the way he wants. Do not make me regret the first task!\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Get the car at garage. Or any other car, just get here. I'll drop the luggage to you and you'll need to drive it to Carlos. Then back, ok? It's clear?\"},{\"Actor\":\"You\",\"Replica\":\"- Easy\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest2.EndDialog = "{\"DialogName\":\"Kek\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- It is Wonderful Mate! Keep the payment as gift! \"},{\"Actor\":\"Winslow\",\"Replica\":\"There are some Bros racing across the street… Wanna Join?.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-174.29f, 2.31f, -80.55f);
        objQwest2.StartPosition = tempV3;
        objQwest2.TasksList = new BaseTask[11];


        ReachPointTask objBaseTask3 = new ReachPointTask();
        objBaseTask3.PointPosition = new Vector3(-314.58f, 2.39f, -146.92f);
        objBaseTask3.AdditionalPointRadius = 0;

        objBaseTask3.TaskText = "Move to Garage";
        objBaseTask3.AdditionalTimer = 0;
        objBaseTask3.DialogData = "{\"DialogName\":\"dsas\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Go to the garage.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask3.EndDialogData = "{\"DialogName\":\"as\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"The Car Showcase is here! Whatever moto you buy is gonna be here and so is your purchased car nigga!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        StealAVehicleTask objBaseTask4 = new StealAVehicleTask();
        objBaseTask4.SpecificVehicleName = VehicleList.None;
        objBaseTask4.VehicleType = VehicleType.Car;
        objBaseTask4.countVisualMarks = 2;
        objBaseTask4.markVisualType = "Enter";

        objBaseTask4.TaskText = "Get a car";
        objBaseTask4.AdditionalTimer = 0;
        objBaseTask4.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get the car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask4.EndDialogData = "";


        DriveToPointTask objBaseTask5 = new DriveToPointTask();
        objBaseTask5.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask5.SpecificVehicleName = VehicleList.None;
        objBaseTask5.PointRadius = 6;
        objBaseTask5.VehicleType = VehicleType.Car;

        objBaseTask5.TaskText = "Drive to Winslow";
        objBaseTask5.AdditionalTimer = 45;
        objBaseTask5.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to Winslow's point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask5.EndDialogData = "{\"DialogName\":\"--\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- All ready, I'll be waiting here. Enjoy the ride, see the city!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask6 = new DriveToPointTask();
        objBaseTask6.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask6.SpecificVehicleName = VehicleList.None;
        objBaseTask6.PointRadius = 6;
        objBaseTask6.VehicleType = VehicleType.Car;

        objBaseTask6.TaskText = "Drive to Carlos";
        objBaseTask6.AdditionalTimer = 45;
        objBaseTask6.DialogData = "";
        objBaseTask6.EndDialogData = "";


        DriveToPointTask objBaseTask7 = new DriveToPointTask();
        objBaseTask7.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask7.SpecificVehicleName = VehicleList.None;
        objBaseTask7.PointRadius = 6;
        objBaseTask7.VehicleType = VehicleType.Car;

        objBaseTask7.TaskText = "Drive to Carlos";
        objBaseTask7.AdditionalTimer = 45;
        objBaseTask7.DialogData = "";
        objBaseTask7.EndDialogData = "";


        DriveToPointTask objBaseTask8 = new DriveToPointTask();
        objBaseTask8.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask8.SpecificVehicleName = VehicleList.None;
        objBaseTask8.PointRadius = 6;
        objBaseTask8.VehicleType = VehicleType.Car;

        objBaseTask8.TaskText = "Drive to Carlos";
        objBaseTask8.AdditionalTimer = 45;
        objBaseTask8.DialogData = "";
        objBaseTask8.EndDialogData = "";


        DriveToPointTask objBaseTask9 = new DriveToPointTask();
        objBaseTask9.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask9.SpecificVehicleName = VehicleList.None;
        objBaseTask9.PointRadius = 6;
        objBaseTask9.VehicleType = VehicleType.Car;

        objBaseTask9.TaskText = "Drive to Carlos";
        objBaseTask9.AdditionalTimer = 45;
        objBaseTask9.DialogData = "";
        objBaseTask9.EndDialogData = "";


        DriveToPointTask objBaseTask10 = new DriveToPointTask();
        objBaseTask10.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask10.SpecificVehicleName = VehicleList.None;
        objBaseTask10.PointRadius = 6;
        objBaseTask10.VehicleType = VehicleType.Car;

        objBaseTask10.TaskText = "Drive to Carlos";
        objBaseTask10.AdditionalTimer = 45;
        objBaseTask10.DialogData = "";
        objBaseTask10.EndDialogData = "";


        DriveToPointTask objBaseTask11 = new DriveToPointTask();
        objBaseTask11.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask11.SpecificVehicleName = VehicleList.None;
        objBaseTask11.PointRadius = 6;
        objBaseTask11.VehicleType = VehicleType.Car;

        objBaseTask11.TaskText = "Drive to Carlos";
        objBaseTask11.AdditionalTimer = 45;
        objBaseTask11.DialogData = "";
        objBaseTask11.EndDialogData = "";


        DriveToPointTask objBaseTask12 = new DriveToPointTask();
        objBaseTask12.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask12.SpecificVehicleName = VehicleList.None;
        objBaseTask12.PointRadius = 6;
        objBaseTask12.VehicleType = VehicleType.Car;

        objBaseTask12.TaskText = "Drive to Carlos";
        objBaseTask12.AdditionalTimer = 90;
        objBaseTask12.DialogData = "{\"DialogName\":\"4352467\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Ride the car to find Carlos down the street.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask12.EndDialogData = "{\"DialogName\":\"8814555\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Wassup, I'm from Winslow\"},{\"Actor\":\"Carlos\",\"Replica\":\"- Oh, yeah, Mumba, I know! We da plug! You've bring my breakfast, yeah?\"},{\"Actor\":\"You\",\"Replica\":\"- Here. Maybe you need help with something, ha?\"},{\"Actor\":\"Carlos\",\"Replica\":\"- Not now, but have got some unsolved deeds. Come back a little later, I will be grateful. Many of our people died on this streets recently, you know.\"},{\"Actor\":\"Carlos\",\"Replica\":\"- Gang need to get by together. Thanks for transfer. See ya later, dude!\"},{\"Actor\":\"You\",\"Replica\":\"- Deal, bye!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask13 = new DriveToPointTask();
        //objBaseTask13.PointPosition = new Vector3(-565.03f, 2.31f, -221.13f);
        objBaseTask13.PointPosition = new Vector3(-305f, 2.31f, 77.9f);
        objBaseTask13.SpecificVehicleName = VehicleList.None;
        objBaseTask13.PointRadius = 6;
        objBaseTask13.VehicleType = VehicleType.Car;

        objBaseTask13.TaskText = "Drive to Winslow";
        objBaseTask13.AdditionalTimer = 0;
        objBaseTask13.DialogData = "{\"DialogName\":\"\u0443\u043a\u0435455\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steer back to Winslow!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask13.EndDialogData = "";
        objBaseTask13.NextTask = null;


        objBaseTask13.PrevTask = objBaseTask12;
        objBaseTask12.NextTask = objBaseTask13;


        objBaseTask12.PrevTask = objBaseTask5;
        objBaseTask11.NextTask = objBaseTask12;


        objBaseTask11.PrevTask = objBaseTask10;
        objBaseTask10.NextTask = objBaseTask11;


        objBaseTask10.PrevTask = objBaseTask9;
        objBaseTask9.NextTask = objBaseTask10;


        objBaseTask9.PrevTask = objBaseTask8;
        objBaseTask8.NextTask = objBaseTask9;


        objBaseTask8.PrevTask = objBaseTask7;
        objBaseTask7.NextTask = objBaseTask8;


        objBaseTask7.PrevTask = objBaseTask6;
        objBaseTask6.NextTask = objBaseTask7;


        objBaseTask6.PrevTask = objBaseTask5;
        objBaseTask5.NextTask = objBaseTask6;


        objBaseTask5.PrevTask = objBaseTask4;
        objBaseTask4.NextTask = objBaseTask5;


        objBaseTask4.PrevTask = objBaseTask3;
        objBaseTask3.NextTask = objBaseTask4;
        objBaseTask3.PrevTask = null;
        objQwest2.TasksList.SetValue(objBaseTask3, 0);


        objQwest2.TasksList.SetValue(objBaseTask4, 1);


        objQwest2.TasksList.SetValue(objBaseTask5, 2);


        objQwest2.TasksList.SetValue(objBaseTask6, 3);


        objQwest2.TasksList.SetValue(objBaseTask7, 4);


        objQwest2.TasksList.SetValue(objBaseTask8, 5);


        objQwest2.TasksList.SetValue(objBaseTask9, 6);


        objQwest2.TasksList.SetValue(objBaseTask10, 7);


        objQwest2.TasksList.SetValue(objBaseTask11, 8);


        objQwest2.TasksList.SetValue(objBaseTask12, 9);


        objQwest2.TasksList.SetValue(objBaseTask13, 10);

        objQwest2.QwestTree = new List<Qwest>();

        //----------Qwest#3-----------

        Qwest objQwest3 = new Qwest();
        objQwest3.Name = "Street racing";
        objQwest3.QwestTitle = "Ilicit Trial";

        objQwest3.Rewards = new UniversalReward();
        objQwest3.Rewards.ExperienceReward = 1645;
        objQwest3.Rewards.MoneyReward = 100;
        objQwest3.Rewards.RewardInGems = true;
        objQwest3.Rewards.ItemRewardID = 0;
        objQwest3.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest3.ShowQwestCompletePanel = true;
        objQwest3.TimerValue = 30;
        objQwest3.RepeatableQuest = false;
        objQwest3.MMMarkId = 4;

        objQwest3.MarkForMiniMap = null;
        objQwest3.AdditionalStartPointRadius = 0;
        objQwest3.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"It is James. Want to put your name in the racing chapter? Was a Joke mate! Just show your driving skills. \"},{\"Actor\":\"James\",\"Replica\":\"- So, to join us, you need to pay 5000$.\"},{\"Actor\":\"James\",\"Replica\":\"- You are a B** A**! Here is the reward! Welcome Street Racer mania! Be furious and enjoy your time here mate…\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest3.EndDialog = "{\"DialogName\":\"Kek\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- The payment is something good too! So enjoy your time boi!\"},{\"Actor\":\"James\",\"Replica\":\"- Good to be a part of racing pack. Come by later for next mania.\"},{\"Actor\":\"James\",\"Replica\":\"- There is down-sider out there! Tresta! He has no vids but knows motos like babes.\"},{\"Actor\":\"James\",\"Replica\":\"- Oh, yeah, see...There is one crazy asian at my back, his name is Pedro. He's about cars and nice job too, but without videos.\"},{\"Actor\":\"James\",\"Replica\":\"- Hope you get what I say.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-565.03f, 2.31f, -221.13f);
        objQwest3.StartPosition = tempV3;
        objQwest3.TasksList = new BaseTask[11];


        StealAVehicleTask objBaseTask14 = new StealAVehicleTask();
        objBaseTask14.SpecificVehicleName = VehicleList.None;
        objBaseTask14.VehicleType = VehicleType.Car;
        objBaseTask14.countVisualMarks = 2;
        objBaseTask14.markVisualType = "Enter";

        objBaseTask14.TaskText = "Get a car";
        objBaseTask14.AdditionalTimer = 0;
        objBaseTask14.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask14.EndDialogData = "";


        DriveToPointTask objBaseTask15 = new DriveToPointTask();
        objBaseTask15.PointPosition = new Vector3(-590.88f, 2.31f, -220.31f);
        objBaseTask15.SpecificVehicleName = VehicleList.None;
        objBaseTask15.PointRadius = 6;
        objBaseTask15.VehicleType = VehicleType.Car;

        objBaseTask15.TaskText = "Drive to start";
        objBaseTask15.AdditionalTimer = 90;
        objBaseTask15.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the start\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask15.EndDialogData = "{\"DialogName\":\"--\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- Ready...Set...GO!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask16 = new DriveToPointTask();
        objBaseTask16.PointPosition = new Vector3(-586.27f, 2.31f, 22.3f);
        objBaseTask16.SpecificVehicleName = VehicleList.None;
        objBaseTask16.PointRadius = 6;
        objBaseTask16.VehicleType = VehicleType.Car;

        objBaseTask16.TaskText = "Drive to the point";
        objBaseTask16.AdditionalTimer = 90;
        objBaseTask16.DialogData = "{\"DialogName\":\"\u0443\u043a\u0435455\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"To complete quest you need to drive through all points before time runs out.\"},{\"Actor\":\"--\",\"Replica\":\"Now get to the next point and etc, until finish.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask16.EndDialogData = "";


        DriveToPointTask objBaseTask17 = new DriveToPointTask();
        objBaseTask17.PointPosition = new Vector3(-586.27f, 2.31f, 193.3f);
        objBaseTask17.SpecificVehicleName = VehicleList.None;
        objBaseTask17.PointRadius = 6;
        objBaseTask17.VehicleType = VehicleType.Car;

        objBaseTask17.TaskText = "Drive to point";
        objBaseTask17.AdditionalTimer = 30;
        objBaseTask17.DialogData = "{\"DialogName\":\"\u0443\u043a\u0435455\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the next checkpoint.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask17.EndDialogData = "";


        DriveToPointTask objBaseTask18 = new DriveToPointTask();
        objBaseTask18.PointPosition = new Vector3(-586.27f, 2.31f, 453.6f);
        objBaseTask18.SpecificVehicleName = VehicleList.None;
        objBaseTask18.PointRadius = 6;
        objBaseTask18.VehicleType = VehicleType.Car;

        objBaseTask18.TaskText = "Drive to point";
        objBaseTask18.AdditionalTimer = 30;
        objBaseTask18.DialogData = "{\"DialogName\":\"3334445\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"So you understand\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask18.EndDialogData = "";


        DriveToPointTask objBaseTask19 = new DriveToPointTask();
        objBaseTask19.PointPosition = new Vector3(-587.9f, 2.31f, 708.3f);
        objBaseTask19.SpecificVehicleName = VehicleList.None;
        objBaseTask19.PointRadius = 6;
        objBaseTask19.VehicleType = VehicleType.Car;

        objBaseTask19.TaskText = "Drive to point";
        objBaseTask19.AdditionalTimer = 30;
        objBaseTask19.DialogData = "";
        objBaseTask19.EndDialogData = "";


        DriveToPointTask objBaseTask20 = new DriveToPointTask();
        objBaseTask20.PointPosition = new Vector3(-726.1f, 2.31f, 865f);
        objBaseTask20.SpecificVehicleName = VehicleList.None;
        objBaseTask20.PointRadius = 6;
        objBaseTask20.VehicleType = VehicleType.Car;

        objBaseTask20.TaskText = "Drive to point";
        objBaseTask20.AdditionalTimer = 30;
        objBaseTask20.DialogData = "";
        objBaseTask20.EndDialogData = "";


        DriveToPointTask objBaseTask21 = new DriveToPointTask();
        objBaseTask21.PointPosition = new Vector3(-559.3f, 2.31f, 952f);
        objBaseTask21.SpecificVehicleName = VehicleList.None;
        objBaseTask21.PointRadius = 6;
        objBaseTask21.VehicleType = VehicleType.Car;

        objBaseTask21.TaskText = "Drive to point";
        objBaseTask21.AdditionalTimer = 30;
        objBaseTask21.DialogData = "";
        objBaseTask21.EndDialogData = "";


        DriveToPointTask objBaseTask22 = new DriveToPointTask();
        objBaseTask22.PointPosition = new Vector3(-558.9f, 2.31f, 710.7f);
        objBaseTask22.SpecificVehicleName = VehicleList.None;
        objBaseTask22.PointRadius = 6;
        objBaseTask22.VehicleType = VehicleType.Car;

        objBaseTask22.TaskText = "Drive to point";
        objBaseTask22.AdditionalTimer = 30;
        objBaseTask22.DialogData = "";
        objBaseTask22.EndDialogData = "{\"DialogName\":\"333555\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Now drive back!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask23 = new DriveToPointTask();
        objBaseTask23.PointPosition = new Vector3(-390.4f, 2.31f, 632.1f);
        objBaseTask23.SpecificVehicleName = VehicleList.None;
        objBaseTask23.PointRadius = 6;
        objBaseTask23.VehicleType = VehicleType.Car;

        objBaseTask23.TaskText = "Drive to point";
        objBaseTask23.AdditionalTimer = 30;
        objBaseTask23.DialogData = "";
        objBaseTask23.EndDialogData = "";


        DriveToPointTask objBaseTask24 = new DriveToPointTask();
        objBaseTask24.PointPosition = new Vector3(-590.88f, 2.31f, -220.31f);
        objBaseTask24.SpecificVehicleName = VehicleList.None;
        objBaseTask24.PointRadius = 6;
        objBaseTask24.VehicleType = VehicleType.Car;

        objBaseTask24.TaskText = "Drive back to James";
        objBaseTask24.AdditionalTimer = 30;
        objBaseTask24.DialogData = "{\"DialogName\":\"11038\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Finish it!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask24.EndDialogData = "";
        objBaseTask24.NextTask = null;


        objBaseTask24.PrevTask = objBaseTask23;
        objBaseTask23.NextTask = objBaseTask24;


        objBaseTask23.PrevTask = objBaseTask22;
        objBaseTask22.NextTask = objBaseTask23;


        objBaseTask22.PrevTask = objBaseTask21;
        objBaseTask21.NextTask = objBaseTask22;


        objBaseTask21.PrevTask = objBaseTask20;
        objBaseTask20.NextTask = objBaseTask21;


        objBaseTask20.PrevTask = objBaseTask19;
        objBaseTask19.NextTask = objBaseTask20;


        objBaseTask19.PrevTask = objBaseTask18;
        objBaseTask18.NextTask = objBaseTask19;


        objBaseTask18.PrevTask = objBaseTask17;
        objBaseTask17.NextTask = objBaseTask18;


        objBaseTask17.PrevTask = objBaseTask16;
        objBaseTask16.NextTask = objBaseTask17;


        objBaseTask16.PrevTask = objBaseTask15;
        objBaseTask15.NextTask = objBaseTask16;


        objBaseTask15.PrevTask = objBaseTask14;
        objBaseTask14.NextTask = objBaseTask15;
        objBaseTask14.PrevTask = null;
        objQwest3.TasksList.SetValue(objBaseTask14, 0);


        objQwest3.TasksList.SetValue(objBaseTask15, 1);


        objQwest3.TasksList.SetValue(objBaseTask16, 2);


        objQwest3.TasksList.SetValue(objBaseTask17, 3);


        objQwest3.TasksList.SetValue(objBaseTask18, 4);


        objQwest3.TasksList.SetValue(objBaseTask19, 5);


        objQwest3.TasksList.SetValue(objBaseTask20, 6);


        objQwest3.TasksList.SetValue(objBaseTask21, 7);


        objQwest3.TasksList.SetValue(objBaseTask22, 8);


        objQwest3.TasksList.SetValue(objBaseTask23, 9);


        objQwest3.TasksList.SetValue(objBaseTask24, 10);

        objQwest3.QwestTree = new List<Qwest>();

        //----------Qwest#4-----------

        Qwest objQwest4 = new Qwest();
        objQwest4.Name = "Race 2";
        objQwest4.QwestTitle = "Super race";

        objQwest4.Rewards = new UniversalReward();
        objQwest4.Rewards.ExperienceReward = 2377;
        objQwest4.Rewards.MoneyReward = 0;
        objQwest4.Rewards.RewardInGems = false;
        objQwest4.Rewards.ItemRewardID = -967628;
        objQwest4.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest4.ShowQwestCompletePanel = true;
        objQwest4.TimerValue = 20;
        objQwest4.RepeatableQuest = false;
        objQwest4.MMMarkId = 4;

        objQwest4.MarkForMiniMap = null;
        objQwest4.AdditionalStartPointRadius = 0;
        objQwest4.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Sup, shawty!\"},{\"Actor\":\"Trisha\",\"Replica\":\"It’s time to shut up and drive on the straight-line! Show your skills now!\"},{\"Actor\":\"Trisha\",\"Replica\":\"-We will send you some money! Go back to James for next quest.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest4.EndDialog = "";



        tempV3 = new Vector3(-565.03f, 2.31f, -221.13f);
        objQwest4.StartPosition = tempV3;
        objQwest4.TasksList = new BaseTask[5];


        StealAVehicleTask objBaseTask25 = new StealAVehicleTask();
        objBaseTask25.SpecificVehicleName = VehicleList.None;
        objBaseTask25.VehicleType = VehicleType.Car;
        objBaseTask25.countVisualMarks = 2;
        objBaseTask25.markVisualType = "Enter";

        objBaseTask25.TaskText = "Get a car";
        objBaseTask25.AdditionalTimer = 0;
        objBaseTask25.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a fast car\"},{\"Actor\":\"--\",\"Replica\":\"- Nick of time! Start the race..\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask25.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"-Finish the drive\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask26 = new DriveToPointTask();
        objBaseTask26.PointPosition = new Vector3(-590.88f, 2.31f, -220.31f);
        objBaseTask26.SpecificVehicleName = VehicleList.None;
        objBaseTask26.PointRadius = 6;
        objBaseTask26.VehicleType = VehicleType.Car;

        objBaseTask26.TaskText = "Drive to start";
        objBaseTask26.AdditionalTimer = 30;
        objBaseTask26.DialogData = "";
        objBaseTask26.EndDialogData = "{\"DialogName\":\"--\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- 3...2...1...GO!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask27 = new DriveToPointTask();
        objBaseTask27.PointPosition = new Vector3(-439.4f, 2.31f, -142.5f);
        objBaseTask27.SpecificVehicleName = VehicleList.None;
        objBaseTask27.PointRadius = 6;
        objBaseTask27.VehicleType = VehicleType.Car;

        objBaseTask27.TaskText = "Drive to the point";
        objBaseTask27.AdditionalTimer = 90;
        objBaseTask27.DialogData = "";
        objBaseTask27.EndDialogData = "";


DriveToPointTask objBaseTask28 = new DriveToPointTask();
        objBaseTask28.PointPosition = new Vector3(-442.8f, 2.31f, 194.7f);
        objBaseTask28.SpecificVehicleName = VehicleList.None;
        objBaseTask28.PointRadius = 6;
        objBaseTask28.VehicleType = VehicleType.Car;

        objBaseTask28.TaskText = "Drive to point";
        objBaseTask28.AdditionalTimer = 30;
        objBaseTask28.DialogData = "";
        objBaseTask28.EndDialogData = "";


        DriveToPointTask objBaseTask29 = new DriveToPointTask();
        objBaseTask29.PointPosition = new Vector3(-389.61f, 2.31f, 456.23f);
        objBaseTask29.SpecificVehicleName = VehicleList.None;
        objBaseTask29.PointRadius = 6;
        objBaseTask29.VehicleType = VehicleType.Car;

        objBaseTask29.TaskText = "Drive to point";
        objBaseTask29.AdditionalTimer = 0;
        objBaseTask29.DialogData = "";
        objBaseTask29.EndDialogData = "";
        objBaseTask29.NextTask = null;


        objBaseTask29.PrevTask = objBaseTask28;
        objBaseTask28.NextTask = objBaseTask29;


        objBaseTask28.PrevTask = objBaseTask27;
        objBaseTask27.NextTask = objBaseTask28;


        objBaseTask27.PrevTask = objBaseTask26;
        objBaseTask26.NextTask = objBaseTask27;


        objBaseTask26.PrevTask = objBaseTask25;
        objBaseTask25.NextTask = objBaseTask26;
        objBaseTask25.PrevTask = null;
        objQwest4.TasksList.SetValue(objBaseTask25, 0);


        objQwest4.TasksList.SetValue(objBaseTask26, 1);


        objQwest4.TasksList.SetValue(objBaseTask27, 2);


        objQwest4.TasksList.SetValue(objBaseTask28, 3);


        objQwest4.TasksList.SetValue(objBaseTask29, 4);

        objQwest4.QwestTree = new List<Qwest>();

        //----------Qwest#5-----------

        Qwest objQwest5 = new Qwest();
        objQwest5.Name = "Race 3";
        objQwest5.QwestTitle = "Drifting Mania";

        objQwest5.Rewards = new UniversalReward();
        objQwest5.Rewards.ExperienceReward = 3637;
        objQwest5.Rewards.MoneyReward = 0;
        objQwest5.Rewards.RewardInGems = false;
        objQwest5.Rewards.ItemRewardID = -192768;
        objQwest5.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest5.ShowQwestCompletePanel = true;
        objQwest5.TimerValue = 30;
        objQwest5.RepeatableQuest = false;
        objQwest5.MMMarkId = 4;

        objQwest5.MarkForMiniMap = null;
        objQwest5.AdditionalStartPointRadius = 0;
        objQwest5.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- Good Job! Keep Racing man\"},{\"Actor\":\"You\",\"Replica\":\"- Not difficult.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest5.EndDialog = "{\"DialogName\":\"opa\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- Ooo! Skrrt-skrrt!\"},{\"Actor\":\"You\",\"Replica\":\"-  Was Easy Peasy.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-565.03f, 2.31f, -221.13f);
        objQwest5.StartPosition = tempV3;
        objQwest5.TasksList = new BaseTask[22];


        StealAVehicleTask objBaseTask30 = new StealAVehicleTask();
        objBaseTask30.SpecificVehicleName = VehicleList.None;
        objBaseTask30.VehicleType = VehicleType.Car;
        objBaseTask30.countVisualMarks = 2;
        objBaseTask30.markVisualType = "Enter";

        objBaseTask30.TaskText = "Get a car";
        objBaseTask30.AdditionalTimer = 0;
        objBaseTask30.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a fast car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask30.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the start\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask31 = new DriveToPointTask();
        objBaseTask31.PointPosition = new Vector3(-588.5f, 2.31f, -154.4f);
        objBaseTask31.SpecificVehicleName = VehicleList.None;
        objBaseTask31.PointRadius = 6;
        objBaseTask31.VehicleType = VehicleType.Car;

        objBaseTask31.TaskText = "Drive to start";
        objBaseTask31.AdditionalTimer = 120;
        objBaseTask31.DialogData = "";
        objBaseTask31.EndDialogData = "{\"DialogName\":\"--\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- START! Pew-pew-pew!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask32 = new DriveToPointTask();
        objBaseTask32.PointPosition = new Vector3(-590.88f, 2.31f, -220.31f);
        objBaseTask32.SpecificVehicleName = VehicleList.None;
        objBaseTask32.PointRadius = 6;
        objBaseTask32.VehicleType = VehicleType.Car;

        objBaseTask32.TaskText = "Drive to point";
        objBaseTask32.AdditionalTimer = 120;
        objBaseTask32.DialogData = "";
        objBaseTask32.EndDialogData = "";


DriveToPointTask objBaseTask33 = new DriveToPointTask();
        objBaseTask33.PointPosition = new Vector3(-586.27f, 2.31f, 22.3f);
        objBaseTask33.SpecificVehicleName = VehicleList.None;
        objBaseTask33.PointRadius = 6;
        objBaseTask33.VehicleType = VehicleType.Car;

        objBaseTask33.TaskText = "Drive to point";
        objBaseTask33.AdditionalTimer = 120;
        objBaseTask33.DialogData = "";
        objBaseTask33.EndDialogData = "";


        DriveToPointTask objBaseTask34 = new DriveToPointTask();
        objBaseTask34.PointPosition = new Vector3(-586.27f, 2.31f, 193.3f);
        objBaseTask34.SpecificVehicleName = VehicleList.None;
        objBaseTask34.PointRadius = 6;
        objBaseTask34.VehicleType = VehicleType.Car;

        objBaseTask34.TaskText = "Drive to point";
        objBaseTask34.AdditionalTimer = 30;
        objBaseTask34.DialogData = "";
        objBaseTask34.EndDialogData = "";


        DriveToPointTask objBaseTask35 = new DriveToPointTask();
        objBaseTask35.PointPosition = new Vector3(-586.27f, 2.31f, 453.6f);
        objBaseTask35.SpecificVehicleName = VehicleList.None;
        objBaseTask35.PointRadius = 6;
        objBaseTask35.VehicleType = VehicleType.Car;

        objBaseTask35.TaskText = "Drive to point";
        objBaseTask35.AdditionalTimer = 120;
        objBaseTask35.DialogData = "";
        objBaseTask35.EndDialogData = "";


        DriveToPointTask objBaseTask36 = new DriveToPointTask();
        objBaseTask36.PointPosition = new Vector3(-587.9f, 2.31f, 708.3f);
        objBaseTask36.SpecificVehicleName = VehicleList.None;
        objBaseTask36.PointRadius = 6;
        objBaseTask36.VehicleType = VehicleType.Car;

        objBaseTask36.TaskText = "Drive to point";
        objBaseTask36.AdditionalTimer = 0;
        objBaseTask36.DialogData = "";
        objBaseTask36.EndDialogData = "";


        DriveToPointTask objBaseTask37 = new DriveToPointTask();
        objBaseTask37.PointPosition = new Vector3(-726.1f, 2.31f, 865f);
        objBaseTask37.SpecificVehicleName = VehicleList.None;
        objBaseTask37.PointRadius = 6;
        objBaseTask37.VehicleType = VehicleType.Car;

        objBaseTask37.TaskText = "Drive to point";
        objBaseTask37.AdditionalTimer = 120;
        objBaseTask37.DialogData = "";
        objBaseTask37.EndDialogData = "";


        DriveToPointTask objBaseTask38 = new DriveToPointTask();
        objBaseTask38.PointPosition = new Vector3(-559.3f, 2.31f, 952f);
        objBaseTask38.SpecificVehicleName = VehicleList.None;
        objBaseTask38.PointRadius = 6;
        objBaseTask38.VehicleType = VehicleType.Car;

        objBaseTask38.TaskText = "Drive to point";
        objBaseTask38.AdditionalTimer = 0;
        objBaseTask38.DialogData = "";
        objBaseTask38.EndDialogData = "";


        DriveToPointTask objBaseTask39 = new DriveToPointTask();
        objBaseTask39.PointPosition = new Vector3(-558.9f, 2.31f, 710.7f);
        objBaseTask39.SpecificVehicleName = VehicleList.None;
        objBaseTask39.PointRadius = 6;
        objBaseTask39.VehicleType = VehicleType.Car;

        objBaseTask39.TaskText = "Drive to point";
        objBaseTask39.AdditionalTimer = 30;
        objBaseTask39.DialogData = "";
        objBaseTask39.EndDialogData = "";


        DriveToPointTask objBaseTask40 = new DriveToPointTask();
        objBaseTask40.PointPosition = new Vector3(-390.4f, 2.31f, 632.1f);
        objBaseTask40.SpecificVehicleName = VehicleList.None;
        objBaseTask40.PointRadius = 6;
        objBaseTask40.VehicleType = VehicleType.Car;

        objBaseTask40.TaskText = "Drive to point";
        objBaseTask40.AdditionalTimer = 0;
        objBaseTask40.DialogData = "";
        objBaseTask40.EndDialogData = "";


        DriveToPointTask objBaseTask41 = new DriveToPointTask();
        objBaseTask41.PointPosition = new Vector3(-425.6f, 2.31f, 323.2f);
        objBaseTask41.SpecificVehicleName = VehicleList.None;
        objBaseTask41.PointRadius = 6;
        objBaseTask41.VehicleType = VehicleType.Car;

        objBaseTask41.TaskText = "Drive to point";
        objBaseTask41.AdditionalTimer = 30;
        objBaseTask41.DialogData = "";
        objBaseTask41.EndDialogData = "";


        DriveToPointTask objBaseTask42 = new DriveToPointTask();
        objBaseTask42.PointPosition = new Vector3(-438.4f, 2.31f, -145.2f);
        objBaseTask42.SpecificVehicleName = VehicleList.None;
        objBaseTask42.PointRadius = 6;
        objBaseTask42.VehicleType = VehicleType.Car;

        objBaseTask42.TaskText = "Drive to point";
        objBaseTask42.AdditionalTimer = 0;
        objBaseTask42.DialogData = "";
        objBaseTask42.EndDialogData = "";


        DriveToPointTask objBaseTask43 = new DriveToPointTask();
        objBaseTask43.PointPosition = new Vector3(-348.9f, 2.31f, -145f);
        objBaseTask43.SpecificVehicleName = VehicleList.None;
        objBaseTask43.PointRadius = 6;
        objBaseTask43.VehicleType = VehicleType.Car;

        objBaseTask43.TaskText = "Drive to point";
        objBaseTask43.AdditionalTimer = 30;
        objBaseTask43.DialogData = "";
        objBaseTask43.EndDialogData = "";


        DriveToPointTask objBaseTask44 = new DriveToPointTask();
        objBaseTask44.PointPosition = new Vector3(-348f, 2.31f, -392.4f);
        objBaseTask44.SpecificVehicleName = VehicleList.None;
        objBaseTask44.PointRadius = 6;
        objBaseTask44.VehicleType = VehicleType.Car;

        objBaseTask44.TaskText = "Drive to point";
        objBaseTask44.AdditionalTimer = 0;
        objBaseTask44.DialogData = "";
        objBaseTask44.EndDialogData = "";


        DriveToPointTask objBaseTask45 = new DriveToPointTask();
        objBaseTask45.PointPosition = new Vector3(-107.77f, 2.31f, -261.5f);
        objBaseTask45.SpecificVehicleName = VehicleList.None;
        objBaseTask45.PointRadius = 6;
        objBaseTask45.VehicleType = VehicleType.Car;

        objBaseTask45.TaskText = "Drive to point";
        objBaseTask45.AdditionalTimer = 30;
        objBaseTask45.DialogData = "";
        objBaseTask45.EndDialogData = "";


        DriveToPointTask objBaseTask46 = new DriveToPointTask();
        objBaseTask46.PointPosition = new Vector3(-186.6f, 2.31f, -82.4f);
        objBaseTask46.SpecificVehicleName = VehicleList.None;
        objBaseTask46.PointRadius = 6;
        objBaseTask46.VehicleType = VehicleType.Car;

        objBaseTask46.TaskText = "Drive to point";
        objBaseTask46.AdditionalTimer = 0;
        objBaseTask46.DialogData = "";
        objBaseTask46.EndDialogData = "";


        DriveToPointTask objBaseTask47 = new DriveToPointTask();
        objBaseTask47.PointPosition = new Vector3(-188.2f, 2.31f, 455.92f);
        objBaseTask47.SpecificVehicleName = VehicleList.None;
        objBaseTask47.PointRadius = 6;
        objBaseTask47.VehicleType = VehicleType.Car;

        objBaseTask47.TaskText = "Drive to point";
        objBaseTask47.AdditionalTimer = 30;
        objBaseTask47.DialogData = "";
        objBaseTask47.EndDialogData = "";


        DriveToPointTask objBaseTask48 = new DriveToPointTask();
        objBaseTask48.PointPosition = new Vector3(-358.65f, 2.31f, 626.86f);
        objBaseTask48.SpecificVehicleName = VehicleList.None;
        objBaseTask48.PointRadius = 6;
        objBaseTask48.VehicleType = VehicleType.Car;

        objBaseTask48.TaskText = "Drive to point";
        objBaseTask48.AdditionalTimer = 0;
        objBaseTask48.DialogData = "";
        objBaseTask48.EndDialogData = "";


        DriveToPointTask objBaseTask49 = new DriveToPointTask();
        objBaseTask49.PointPosition = new Vector3(-555.4f, 2.31f, 711.3f);
        objBaseTask49.SpecificVehicleName = VehicleList.None;
        objBaseTask49.PointRadius = 6;
        objBaseTask49.VehicleType = VehicleType.Car;

        objBaseTask49.TaskText = "Drive to point";
        objBaseTask49.AdditionalTimer = 30;
        objBaseTask49.DialogData = "";
        objBaseTask49.EndDialogData = "";


        DriveToPointTask objBaseTask50 = new DriveToPointTask();
        objBaseTask50.PointPosition = new Vector3(-559f, 2.31f, 264.43f);
        objBaseTask50.SpecificVehicleName = VehicleList.None;
        objBaseTask50.PointRadius = 6;
        objBaseTask50.VehicleType = VehicleType.Car;

        objBaseTask50.TaskText = "Drive to point";
        objBaseTask50.AdditionalTimer = 0;
        objBaseTask50.DialogData = "";
        objBaseTask50.EndDialogData = "";


        DriveToPointTask objBaseTask51 = new DriveToPointTask();
        objBaseTask51.PointPosition = new Vector3(-585.8f, 2.31f, 21f);
        objBaseTask51.SpecificVehicleName = VehicleList.None;
        objBaseTask51.PointRadius = 6;
        objBaseTask51.VehicleType = VehicleType.Car;

        objBaseTask51.TaskText = "Drive to finish";
        objBaseTask51.AdditionalTimer = 0;
        objBaseTask51.DialogData = "{\"DialogName\":\"2345456\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Finish it!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask51.EndDialogData = "";
        objBaseTask51.NextTask = null;


        objBaseTask51.PrevTask = objBaseTask50;
        objBaseTask50.NextTask = objBaseTask51;


        objBaseTask50.PrevTask = objBaseTask49;
        objBaseTask49.NextTask = objBaseTask50;


        objBaseTask49.PrevTask = objBaseTask48;
        objBaseTask48.NextTask = objBaseTask49;


        objBaseTask48.PrevTask = objBaseTask47;
        objBaseTask47.NextTask = objBaseTask48;


        objBaseTask47.PrevTask = objBaseTask46;
        objBaseTask46.NextTask = objBaseTask47;


        objBaseTask46.PrevTask = objBaseTask45;
        objBaseTask45.NextTask = objBaseTask46;


        objBaseTask45.PrevTask = objBaseTask44;
        objBaseTask44.NextTask = objBaseTask45;


        objBaseTask44.PrevTask = objBaseTask43;
        objBaseTask43.NextTask = objBaseTask44;


        objBaseTask43.PrevTask = objBaseTask42;
        objBaseTask42.NextTask = objBaseTask43;


        objBaseTask42.PrevTask = objBaseTask41;
        objBaseTask41.NextTask = objBaseTask42;


        objBaseTask41.PrevTask = objBaseTask40;
        objBaseTask40.NextTask = objBaseTask41;


        objBaseTask40.PrevTask = objBaseTask39;
        objBaseTask39.NextTask = objBaseTask40;


        objBaseTask39.PrevTask = objBaseTask38;
        objBaseTask38.NextTask = objBaseTask39;


        objBaseTask38.PrevTask = objBaseTask37;
        objBaseTask37.NextTask = objBaseTask38;


        objBaseTask37.PrevTask = objBaseTask36;
        objBaseTask36.NextTask = objBaseTask37;


        objBaseTask36.PrevTask = objBaseTask35;
        objBaseTask35.NextTask = objBaseTask36;


        objBaseTask35.PrevTask = objBaseTask34;
        objBaseTask34.NextTask = objBaseTask35;


        objBaseTask34.PrevTask = objBaseTask33;
        objBaseTask33.NextTask = objBaseTask34;


        objBaseTask33.PrevTask = objBaseTask32;
        objBaseTask32.NextTask = objBaseTask33;


        objBaseTask32.PrevTask = objBaseTask31;
        objBaseTask31.NextTask = objBaseTask32;


        objBaseTask31.PrevTask = objBaseTask30;
        objBaseTask30.NextTask = objBaseTask31;
        objBaseTask30.PrevTask = null;
        objQwest5.TasksList.SetValue(objBaseTask30, 0);


        objQwest5.TasksList.SetValue(objBaseTask31, 1);


        objQwest5.TasksList.SetValue(objBaseTask32, 2);


        objQwest5.TasksList.SetValue(objBaseTask33, 3);


        objQwest5.TasksList.SetValue(objBaseTask34, 4);


        objQwest5.TasksList.SetValue(objBaseTask35, 5);


        objQwest5.TasksList.SetValue(objBaseTask36, 6);


        objQwest5.TasksList.SetValue(objBaseTask37, 7);


        objQwest5.TasksList.SetValue(objBaseTask38, 8);


        objQwest5.TasksList.SetValue(objBaseTask39, 9);


        objQwest5.TasksList.SetValue(objBaseTask40, 10);


        objQwest5.TasksList.SetValue(objBaseTask41, 11);


        objQwest5.TasksList.SetValue(objBaseTask42, 12);


        objQwest5.TasksList.SetValue(objBaseTask43, 13);


        objQwest5.TasksList.SetValue(objBaseTask44, 14);


        objQwest5.TasksList.SetValue(objBaseTask45, 15);


        objQwest5.TasksList.SetValue(objBaseTask46, 16);


        objQwest5.TasksList.SetValue(objBaseTask47, 17);


        objQwest5.TasksList.SetValue(objBaseTask48, 18);


        objQwest5.TasksList.SetValue(objBaseTask49, 19);


        objQwest5.TasksList.SetValue(objBaseTask50, 20);


        objQwest5.TasksList.SetValue(objBaseTask51, 21);

        objQwest5.QwestTree = new List<Qwest>();
        
        //----------Qwest#6-----------


        Qwest objQwest6 = new Qwest();
        objQwest6.Name = "Race 4";
        objQwest6.QwestTitle = "Racing Mania Season 2";

        objQwest6.Rewards = new UniversalReward();
        objQwest6.Rewards.ExperienceReward = 5601;
        objQwest6.Rewards.MoneyReward = 0;
        objQwest6.Rewards.RewardInGems = false;
        objQwest6.Rewards.ItemRewardID = -521134;
        objQwest6.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest6.ShowQwestCompletePanel = true;
        objQwest6.TimerValue = 0;
        objQwest6.RepeatableQuest = false;
        objQwest6.MMMarkId = 4;

        objQwest6.MarkForMiniMap = null;
        objQwest6.AdditionalStartPointRadius = 0;
        objQwest6.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- The level has raised up. Buckle up to the Seat.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest6.EndDialog = "{\"DialogName\":\"dsfeee\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"-  Vella is looking for you! Find her to get some tricks. \"},{\"Actor\":\"James\",\"Replica\":\"- So, if you like to jump on springboards, you could find Vella, she takes video of car tricks.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-565.03f, 2.31f, -221.13f);
        objQwest6.StartPosition = tempV3;
        objQwest6.TasksList = new BaseTask[14];


        StealAVehicleTask objBaseTask52 = new StealAVehicleTask();
        objBaseTask52.SpecificVehicleName = VehicleList.None;
        objBaseTask52.VehicleType = VehicleType.Car;
        objBaseTask52.countVisualMarks = 2;
        objBaseTask52.markVisualType = "Enter";

        objBaseTask52.TaskText = "Get a car";
        objBaseTask52.AdditionalTimer = 0;
        objBaseTask52.DialogData = "{\"DialogName\":\"324d\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a fast car!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask52.EndDialogData = "{\"DialogName\":\"fdgfgdt\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to start!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask53 = new DriveToPointTask();
        objBaseTask53.PointPosition = new Vector3(-590.88f, 2.31f, -220.31f);
        objBaseTask53.SpecificVehicleName = VehicleList.None;
        objBaseTask53.PointRadius = 6;
        objBaseTask53.VehicleType = VehicleType.Car;

        objBaseTask53.TaskText = "Drive to start point";
        objBaseTask53.AdditionalTimer = 120;
        objBaseTask53.DialogData = "";
        objBaseTask53.EndDialogData = "{\"DialogName\":\"4333221\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- 3...2...1...START!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask54 = new DriveToPointTask();
        objBaseTask54.PointPosition = new Vector3(-439.4f, 2.31f, -142.5f);
        objBaseTask54.SpecificVehicleName = VehicleList.None;
        objBaseTask54.PointRadius = 6;
        objBaseTask54.VehicleType = VehicleType.Car;

        objBaseTask54.TaskText = "Drive to point";
        objBaseTask54.AdditionalTimer = 0;
        objBaseTask54.DialogData = "";
        objBaseTask54.EndDialogData = "";


        DriveToPointTask objBaseTask55 = new DriveToPointTask();
        objBaseTask55.PointPosition = new Vector3(-442.8f, 2.31f, 194.7f);
        objBaseTask55.SpecificVehicleName = VehicleList.None;
        objBaseTask55.PointRadius = 6;
        objBaseTask55.VehicleType = VehicleType.Car;

        objBaseTask55.TaskText = "Drive to point";
        objBaseTask55.AdditionalTimer = 30;
        objBaseTask55.DialogData = "";
        objBaseTask55.EndDialogData = "";


        DriveToPointTask objBaseTask56 = new DriveToPointTask();
        objBaseTask56.PointPosition = new Vector3(-389.61f, 2.31f, 456.23f);
        objBaseTask56.SpecificVehicleName = VehicleList.None;
        objBaseTask56.PointRadius = 6;
        objBaseTask56.VehicleType = VehicleType.Car;

        objBaseTask56.TaskText = "Drive to point";
        objBaseTask56.AdditionalTimer = 30;
        objBaseTask56.DialogData = "";
        objBaseTask56.EndDialogData = "";


        DriveToPointTask objBaseTask57 = new DriveToPointTask();
        objBaseTask57.PointPosition = new Vector3(-284.3f, 2.31f, 456.23f);
        objBaseTask57.SpecificVehicleName = VehicleList.None;
        objBaseTask57.PointRadius = 6;
        objBaseTask57.VehicleType = VehicleType.Car;

        objBaseTask57.TaskText = "Drive to point";
        objBaseTask57.AdditionalTimer = 0;
        objBaseTask57.DialogData = "";
        objBaseTask57.EndDialogData = "";


        DriveToPointTask objBaseTask58 = new DriveToPointTask();
        objBaseTask58.PointPosition = new Vector3(-286f, 2.31f, 660.9f);
        objBaseTask58.SpecificVehicleName = VehicleList.None;
        objBaseTask58.PointRadius = 6;
        objBaseTask58.VehicleType = VehicleType.Car;

        objBaseTask58.TaskText = "Drive to point";
        objBaseTask58.AdditionalTimer = 30;
        objBaseTask58.DialogData = "";
        objBaseTask58.EndDialogData = "";


        DriveToPointTask objBaseTask59 = new DriveToPointTask();
        objBaseTask59.PointPosition = new Vector3(-287.25f, 2.31f, 836.6f);
        objBaseTask59.SpecificVehicleName = VehicleList.None;
        objBaseTask59.PointRadius = 6;
        objBaseTask59.VehicleType = VehicleType.Car;

        objBaseTask59.TaskText = "Drive to point";
        objBaseTask59.AdditionalTimer = 0;
        objBaseTask59.DialogData = "";
        objBaseTask59.EndDialogData = "";


        DriveToPointTask objBaseTask60 = new DriveToPointTask();
        objBaseTask60.PointPosition = new Vector3(-287.25f, 2.31f, 1038.9f);
        objBaseTask60.SpecificVehicleName = VehicleList.None;
        objBaseTask60.PointRadius = 6;
        objBaseTask60.VehicleType = VehicleType.Car;

        objBaseTask60.TaskText = "Drive to point";
        objBaseTask60.AdditionalTimer = 30;
        objBaseTask60.DialogData = "";
        objBaseTask60.EndDialogData = "";


        DriveToPointTask objBaseTask61 = new DriveToPointTask();
        objBaseTask61.PointPosition = new Vector3(-495.47f, 2.31f, 934.6f);
        objBaseTask61.SpecificVehicleName = VehicleList.None;
        objBaseTask61.PointRadius = 6;
        objBaseTask61.VehicleType = VehicleType.Car;

        objBaseTask61.TaskText = "Drive to point";
        objBaseTask61.AdditionalTimer = 0;
        objBaseTask61.DialogData = "";
        objBaseTask61.EndDialogData = "";


        DriveToPointTask objBaseTask62 = new DriveToPointTask();
        objBaseTask62.PointPosition = new Vector3(-460.4f, 2.31f, 840.3f);
        objBaseTask62.SpecificVehicleName = VehicleList.None;
        objBaseTask62.PointRadius = 6;
        objBaseTask62.VehicleType = VehicleType.Car;

        objBaseTask62.TaskText = "Drive to point";
        objBaseTask62.AdditionalTimer = 30;
        objBaseTask62.DialogData = "";
        objBaseTask62.EndDialogData = "";


        DriveToPointTask objBaseTask63 = new DriveToPointTask();
        objBaseTask63.PointPosition = new Vector3(-558.9f, 2.31f, 839f);
        objBaseTask63.SpecificVehicleName = VehicleList.None;
        objBaseTask63.PointRadius = 6;
        objBaseTask63.VehicleType = VehicleType.Car;

        objBaseTask63.TaskText = "Drive to point";
        objBaseTask63.AdditionalTimer = 30;
        objBaseTask63.DialogData = "";
        objBaseTask63.EndDialogData = "";


        DriveToPointTask objBaseTask64 = new DriveToPointTask();
        objBaseTask64.PointPosition = new Vector3(-558.9f, 2.31f, 22.5f);
        objBaseTask64.SpecificVehicleName = VehicleList.None;
        objBaseTask64.PointRadius = 6;
        objBaseTask64.VehicleType = VehicleType.Car;

        objBaseTask64.TaskText = "Drive to point";
        objBaseTask64.AdditionalTimer = 30;
        objBaseTask64.DialogData = "";
        objBaseTask64.EndDialogData = "";


        DriveToPointTask objBaseTask65 = new DriveToPointTask();
        objBaseTask65.PointPosition = new Vector3(-584.61f, 2.31f, -210.38f);
        objBaseTask65.SpecificVehicleName = VehicleList.None;
        objBaseTask65.PointRadius = 6;
        objBaseTask65.VehicleType = VehicleType.Car;

        objBaseTask65.TaskText = "Drive to point";
        objBaseTask65.AdditionalTimer = 0;
        objBaseTask65.DialogData = "";
        objBaseTask65.EndDialogData = "";
        objBaseTask65.NextTask = null;


        objBaseTask65.PrevTask = objBaseTask64;
        objBaseTask64.NextTask = objBaseTask65;


        objBaseTask64.PrevTask = objBaseTask63;
        objBaseTask63.NextTask = objBaseTask64;


        objBaseTask63.PrevTask = objBaseTask62;
        objBaseTask62.NextTask = objBaseTask63;


        objBaseTask62.PrevTask = objBaseTask61;
        objBaseTask61.NextTask = objBaseTask62;


        objBaseTask61.PrevTask = objBaseTask60;
        objBaseTask60.NextTask = objBaseTask61;


        objBaseTask60.PrevTask = objBaseTask59;
        objBaseTask59.NextTask = objBaseTask60;


        objBaseTask59.PrevTask = objBaseTask58;
        objBaseTask58.NextTask = objBaseTask59;


        objBaseTask58.PrevTask = objBaseTask57;
        objBaseTask57.NextTask = objBaseTask58;


        objBaseTask57.PrevTask = objBaseTask56;
        objBaseTask56.NextTask = objBaseTask57;


        objBaseTask56.PrevTask = objBaseTask55;
        objBaseTask55.NextTask = objBaseTask56;


        objBaseTask55.PrevTask = objBaseTask54;
        objBaseTask54.NextTask = objBaseTask55;


        objBaseTask54.PrevTask = objBaseTask53;
        objBaseTask53.NextTask = objBaseTask54;


        objBaseTask53.PrevTask = objBaseTask52;
        objBaseTask52.NextTask = objBaseTask53;
        objBaseTask52.PrevTask = null;
        objQwest6.TasksList.SetValue(objBaseTask52, 0);


        objQwest6.TasksList.SetValue(objBaseTask53, 1);


        objQwest6.TasksList.SetValue(objBaseTask54, 2);


        objQwest6.TasksList.SetValue(objBaseTask55, 3);


        objQwest6.TasksList.SetValue(objBaseTask56, 4);


        objQwest6.TasksList.SetValue(objBaseTask57, 5);


        objQwest6.TasksList.SetValue(objBaseTask58, 6);


        objQwest6.TasksList.SetValue(objBaseTask59, 7);


        objQwest6.TasksList.SetValue(objBaseTask60, 8);


        objQwest6.TasksList.SetValue(objBaseTask61, 9);


        objQwest6.TasksList.SetValue(objBaseTask62, 10);


        objQwest6.TasksList.SetValue(objBaseTask63, 11);


        objQwest6.TasksList.SetValue(objBaseTask64, 12);


        objQwest6.TasksList.SetValue(objBaseTask65, 13);

        objQwest6.QwestTree = new List<Qwest>();

        //----------Qwest#7-----------

        Qwest objQwest7 = new Qwest();
        objQwest7.Name = "Race 5";
        objQwest7.QwestTitle = "Rush Man ";

        objQwest7.Rewards = new UniversalReward();
        objQwest7.Rewards.ExperienceReward = 4748;
        objQwest7.Rewards.MoneyReward = 100;
        objQwest7.Rewards.RewardInGems = true;
        objQwest7.Rewards.ItemRewardID = 0;
        objQwest7.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest7.ShowQwestCompletePanel = true;
        objQwest7.TimerValue = 30;
        objQwest7.RepeatableQuest = false;
        objQwest7.MMMarkId = 4;

        objQwest7.MarkForMiniMap = null;
        objQwest7.AdditionalStartPointRadius = 0;
        objQwest7.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- Rush to race! On the big island. Do it now!\"},{\"Actor\":\"You\",\"Replica\":\"- Let's do it!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest7.EndDialog = "{\"DialogName\":\"opa\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- This was great! You need to be paid well.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-565.03f, 2.31f, -221.13f);
        objQwest7.StartPosition = tempV3;
        objQwest7.TasksList = new BaseTask[22];


        StealAVehicleTask objBaseTask66 = new StealAVehicleTask();
        objBaseTask66.SpecificVehicleName = VehicleList.None;
        objBaseTask66.VehicleType = VehicleType.Car;
        objBaseTask66.countVisualMarks = 2;
        objBaseTask66.markVisualType = "Enter";

        objBaseTask66.TaskText = "Get a car";
        objBaseTask66.AdditionalTimer = 0;
        objBaseTask66.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a fast car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask66.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the start\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask67 = new DriveToPointTask();
        objBaseTask67.PointPosition = new Vector3(-590.88f, 2.31f, -220.31f);
        objBaseTask67.SpecificVehicleName = VehicleList.None;
        objBaseTask67.PointRadius = 6;
        objBaseTask67.VehicleType = VehicleType.Car;

        objBaseTask67.TaskText = "Drive to start";
        objBaseTask67.AdditionalTimer = 90;
        objBaseTask67.DialogData = "";
        objBaseTask67.EndDialogData = "{\"DialogName\":\"--\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"James\",\"Replica\":\"- Ready...Set...GO!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask68 = new DriveToPointTask();
        objBaseTask68.PointPosition = new Vector3(-588.5f, 2.31f, -154.4f); 
        objBaseTask68.SpecificVehicleName = VehicleList.None;
        objBaseTask68.PointRadius = 6;
        objBaseTask68.VehicleType = VehicleType.Car;

        objBaseTask68.TaskText = "Drive to point";
        objBaseTask68.AdditionalTimer = 90;
        objBaseTask68.DialogData = "";
        objBaseTask68.EndDialogData = "";


DriveToPointTask objBaseTask69 = new DriveToPointTask();
        objBaseTask69.PointPosition = new Vector3(-586.27f, 2.31f, 22.3f);
        objBaseTask69.SpecificVehicleName = VehicleList.None;
        objBaseTask69.PointRadius = 6;
        objBaseTask69.VehicleType = VehicleType.Car;

        objBaseTask69.TaskText = "Drive to point";
        objBaseTask69.AdditionalTimer = 0;
        objBaseTask69.DialogData = "";
        objBaseTask69.EndDialogData = "";


        DriveToPointTask objBaseTask70 = new DriveToPointTask();
        objBaseTask70.PointPosition = new Vector3(-586.27f, 2.31f, 193.3f);
        objBaseTask70.SpecificVehicleName = VehicleList.None;
        objBaseTask70.PointRadius = 6;
        objBaseTask70.VehicleType = VehicleType.Car;

        objBaseTask70.TaskText = "Drive to point";
        objBaseTask70.AdditionalTimer = 30;
        objBaseTask70.DialogData = "";
        objBaseTask70.EndDialogData = "";


        DriveToPointTask objBaseTask71 = new DriveToPointTask();
        objBaseTask71.PointPosition = new Vector3(-586.27f, 2.31f, 453.6f);
        objBaseTask71.SpecificVehicleName = VehicleList.None;
        objBaseTask71.PointRadius = 6;
        objBaseTask71.VehicleType = VehicleType.Car;

        objBaseTask71.TaskText = "Drive to point";
        objBaseTask71.AdditionalTimer = 0;
        objBaseTask71.DialogData = "";
        objBaseTask71.EndDialogData = "";


        DriveToPointTask objBaseTask72 = new DriveToPointTask();
        objBaseTask72.PointPosition = new Vector3(-587.9f, 2.31f, 708.3f);
        objBaseTask72.SpecificVehicleName = VehicleList.None;
        objBaseTask72.PointRadius = 6;
        objBaseTask72.VehicleType = VehicleType.Car;

        objBaseTask72.TaskText = "Drive to point";
        objBaseTask72.AdditionalTimer = 30;
        objBaseTask72.DialogData = "";
        objBaseTask72.EndDialogData = "";


        DriveToPointTask objBaseTask73 = new DriveToPointTask();
        objBaseTask73.PointPosition = new Vector3(-726.1f, 2.31f, 865f);
        objBaseTask73.SpecificVehicleName = VehicleList.None;
        objBaseTask73.PointRadius = 6;
        objBaseTask73.VehicleType = VehicleType.Car;

        objBaseTask73.TaskText = "Drive to point";
        objBaseTask73.AdditionalTimer = 0;
        objBaseTask73.DialogData = "";
        objBaseTask73.EndDialogData = "";


        DriveToPointTask objBaseTask74 = new DriveToPointTask();
        objBaseTask74.PointPosition = new Vector3(-559.3f, 2.31f, 952f);
        objBaseTask74.SpecificVehicleName = VehicleList.None;
        objBaseTask74.PointRadius = 6;
        objBaseTask74.VehicleType = VehicleType.Car;

        objBaseTask74.TaskText = "Drive to point";
        objBaseTask74.AdditionalTimer = 30;
        objBaseTask74.DialogData = "";
        objBaseTask74.EndDialogData = "";


        DriveToPointTask objBaseTask75 = new DriveToPointTask();
        objBaseTask75.PointPosition = new Vector3(-558.9f, 2.31f, 710.7f);
        objBaseTask75.SpecificVehicleName = VehicleList.None;
        objBaseTask75.PointRadius = 6;
        objBaseTask75.VehicleType = VehicleType.Car;

        objBaseTask75.TaskText = "Drive to point";
        objBaseTask75.AdditionalTimer = 0;
        objBaseTask75.DialogData = "";
        objBaseTask75.EndDialogData = "";


        DriveToPointTask objBaseTask76 = new DriveToPointTask();
        objBaseTask76.PointPosition = new Vector3(-390.4f, 2.31f, 632.1f);
        objBaseTask76.SpecificVehicleName = VehicleList.None;
        objBaseTask76.PointRadius = 6;
        objBaseTask76.VehicleType = VehicleType.Car;

        objBaseTask76.TaskText = "Drive to point";
        objBaseTask76.AdditionalTimer = 30;
        objBaseTask76.DialogData = "";
        objBaseTask76.EndDialogData = "";


        DriveToPointTask objBaseTask77 = new DriveToPointTask();
        objBaseTask77.PointPosition = new Vector3(-425.6f, 2.31f, 323.2f);
        objBaseTask77.SpecificVehicleName = VehicleList.None;
        objBaseTask77.PointRadius = 6;
        objBaseTask77.VehicleType = VehicleType.Car;

        objBaseTask77.TaskText = "Drive to point";
        objBaseTask77.AdditionalTimer = 0;
        objBaseTask77.DialogData = "";
        objBaseTask77.EndDialogData = "";


        DriveToPointTask objBaseTask78 = new DriveToPointTask();
        objBaseTask78.PointPosition = new Vector3(-438.4f, 2.31f, -145.2f);
        objBaseTask78.SpecificVehicleName = VehicleList.None;
        objBaseTask78.PointRadius = 6;
        objBaseTask78.VehicleType = VehicleType.Car;

        objBaseTask78.TaskText = "Drive to point";
        objBaseTask78.AdditionalTimer = 30;
        objBaseTask78.DialogData = "";
        objBaseTask78.EndDialogData = "";


        DriveToPointTask objBaseTask79 = new DriveToPointTask();
        objBaseTask79.PointPosition = new Vector3(-348.9f, 2.31f, -145f);
        objBaseTask79.SpecificVehicleName = VehicleList.None;
        objBaseTask79.PointRadius = 6;
        objBaseTask79.VehicleType = VehicleType.Car;

        objBaseTask79.TaskText = "Drive to point";
        objBaseTask79.AdditionalTimer = 0;
        objBaseTask79.DialogData = "";
        objBaseTask79.EndDialogData = "";


        DriveToPointTask objBaseTask80 = new DriveToPointTask();
        objBaseTask80.PointPosition = new Vector3(-348f, 2.31f, -392.4f);
        objBaseTask80.SpecificVehicleName = VehicleList.None;
        objBaseTask80.PointRadius = 6;
        objBaseTask80.VehicleType = VehicleType.Car;

        objBaseTask80.TaskText = "Drive to point";
        objBaseTask80.AdditionalTimer = 30;
        objBaseTask80.DialogData = "";
        objBaseTask80.EndDialogData = "";


        DriveToPointTask objBaseTask81 = new DriveToPointTask();
        objBaseTask81.PointPosition = new Vector3(-107.77f, 2.31f, -261.5f);
        objBaseTask81.SpecificVehicleName = VehicleList.None;
        objBaseTask81.PointRadius = 6;
        objBaseTask81.VehicleType = VehicleType.Car;

        objBaseTask81.TaskText = "Drive to point";
        objBaseTask81.AdditionalTimer = 0;
        objBaseTask81.DialogData = "";
        objBaseTask81.EndDialogData = "";


        DriveToPointTask objBaseTask82 = new DriveToPointTask();
        objBaseTask82.PointPosition = new Vector3(-186.6f, 2.31f, -82.4f);
        objBaseTask82.SpecificVehicleName = VehicleList.None;
        objBaseTask82.PointRadius = 6;
        objBaseTask82.VehicleType = VehicleType.Car;

        objBaseTask82.TaskText = "Drive to point";
        objBaseTask82.AdditionalTimer = 30;
        objBaseTask82.DialogData = "";
        objBaseTask82.EndDialogData = "";


        DriveToPointTask objBaseTask83 = new DriveToPointTask();
        objBaseTask83.PointPosition = new Vector3(-188.2f, 2.31f, 455.92f);
        objBaseTask83.SpecificVehicleName = VehicleList.None;
        objBaseTask83.PointRadius = 6;
        objBaseTask83.VehicleType = VehicleType.Car;

        objBaseTask83.TaskText = "Drive to point";
        objBaseTask83.AdditionalTimer = 0;
        objBaseTask83.DialogData = "";
        objBaseTask83.EndDialogData = "";


        DriveToPointTask objBaseTask84 = new DriveToPointTask();
        objBaseTask84.PointPosition = new Vector3(-358.65f, 2.31f, 626.86f);
        objBaseTask84.SpecificVehicleName = VehicleList.None;
        objBaseTask84.PointRadius = 6;
        objBaseTask84.VehicleType = VehicleType.Car;

        objBaseTask84.TaskText = "Drive to point";
        objBaseTask84.AdditionalTimer = 30;
        objBaseTask84.DialogData = "";
        objBaseTask84.EndDialogData = "";


        DriveToPointTask objBaseTask85 = new DriveToPointTask();
        objBaseTask85.PointPosition = new Vector3(-555.4f, 2.31f, 711.3f);
        objBaseTask85.SpecificVehicleName = VehicleList.None;
        objBaseTask85.PointRadius = 6;
        objBaseTask85.VehicleType = VehicleType.Car;

        objBaseTask85.TaskText = "Drive to point";
        objBaseTask85.AdditionalTimer = 0;
        objBaseTask85.DialogData = "";
        objBaseTask85.EndDialogData = "";


        DriveToPointTask objBaseTask86 = new DriveToPointTask();
        objBaseTask86.PointPosition = new Vector3(-559f, 2.31f, 264.43f);
        objBaseTask86.SpecificVehicleName = VehicleList.None;
        objBaseTask86.PointRadius = 6;
        objBaseTask86.VehicleType = VehicleType.Car;

        objBaseTask86.TaskText = "Drive to point";
        objBaseTask86.AdditionalTimer = 30;
        objBaseTask86.DialogData = "";
        objBaseTask86.EndDialogData = "";


        DriveToPointTask objBaseTask87 = new DriveToPointTask();
        objBaseTask87.PointPosition = new Vector3(-585.8f, 2.31f, 21f);
        objBaseTask87.SpecificVehicleName = VehicleList.None;
        objBaseTask87.PointRadius = 6;
        objBaseTask87.VehicleType = VehicleType.Car;

        objBaseTask87.TaskText = "Drive to finish";
        objBaseTask87.AdditionalTimer = 0;
        objBaseTask87.DialogData = "{\"DialogName\":\"2345456\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Finish it!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask87.EndDialogData = "";
        objBaseTask87.NextTask = null;


        objBaseTask87.PrevTask = objBaseTask86;
        objBaseTask86.NextTask = objBaseTask87;


        objBaseTask86.PrevTask = objBaseTask85;
        objBaseTask85.NextTask = objBaseTask86;


        objBaseTask85.PrevTask = objBaseTask84;
        objBaseTask84.NextTask = objBaseTask85;


        objBaseTask84.PrevTask = objBaseTask83;
        objBaseTask83.NextTask = objBaseTask84;


        objBaseTask83.PrevTask = objBaseTask82;
        objBaseTask82.NextTask = objBaseTask83;


        objBaseTask82.PrevTask = objBaseTask81;
        objBaseTask81.NextTask = objBaseTask82;


        objBaseTask81.PrevTask = objBaseTask80;
        objBaseTask80.NextTask = objBaseTask81;


        objBaseTask80.PrevTask = objBaseTask79;
        objBaseTask79.NextTask = objBaseTask80;


        objBaseTask79.PrevTask = objBaseTask78;
        objBaseTask78.NextTask = objBaseTask79;


        objBaseTask78.PrevTask = objBaseTask77;
        objBaseTask77.NextTask = objBaseTask78;


        objBaseTask77.PrevTask = objBaseTask76;
        objBaseTask76.NextTask = objBaseTask77;


        objBaseTask76.PrevTask = objBaseTask75;
        objBaseTask75.NextTask = objBaseTask76;


        objBaseTask75.PrevTask = objBaseTask74;
        objBaseTask74.NextTask = objBaseTask75;


        objBaseTask74.PrevTask = objBaseTask73;
        objBaseTask73.NextTask = objBaseTask74;


        objBaseTask73.PrevTask = objBaseTask72;
        objBaseTask72.NextTask = objBaseTask73;


        objBaseTask72.PrevTask = objBaseTask71;
        objBaseTask71.NextTask = objBaseTask72;


        objBaseTask71.PrevTask = objBaseTask70;
        objBaseTask70.NextTask = objBaseTask71;


        objBaseTask70.PrevTask = objBaseTask69;
        objBaseTask69.NextTask = objBaseTask70;


        objBaseTask69.PrevTask = objBaseTask68;
        objBaseTask68.NextTask = objBaseTask69;


        objBaseTask68.PrevTask = objBaseTask67;
        objBaseTask67.NextTask = objBaseTask68;


        objBaseTask67.PrevTask = objBaseTask66;
        objBaseTask66.NextTask = objBaseTask67;
        objBaseTask66.PrevTask = null;
        objQwest7.TasksList.SetValue(objBaseTask66, 0);


        objQwest7.TasksList.SetValue(objBaseTask67, 1);


        objQwest7.TasksList.SetValue(objBaseTask68, 2);


        objQwest7.TasksList.SetValue(objBaseTask69, 3);


        objQwest7.TasksList.SetValue(objBaseTask70, 4);


        objQwest7.TasksList.SetValue(objBaseTask71, 5);


        objQwest7.TasksList.SetValue(objBaseTask72, 6);


        objQwest7.TasksList.SetValue(objBaseTask73, 7);


        objQwest7.TasksList.SetValue(objBaseTask74, 8);


        objQwest7.TasksList.SetValue(objBaseTask75, 9);


        objQwest7.TasksList.SetValue(objBaseTask76, 10);


        objQwest7.TasksList.SetValue(objBaseTask77, 11);


        objQwest7.TasksList.SetValue(objBaseTask78, 12);


        objQwest7.TasksList.SetValue(objBaseTask79, 13);


        objQwest7.TasksList.SetValue(objBaseTask80, 14);


        objQwest7.TasksList.SetValue(objBaseTask81, 15);


        objQwest7.TasksList.SetValue(objBaseTask82, 16);


        objQwest7.TasksList.SetValue(objBaseTask83, 17);


        objQwest7.TasksList.SetValue(objBaseTask84, 18);


        objQwest7.TasksList.SetValue(objBaseTask85, 19);


        objQwest7.TasksList.SetValue(objBaseTask86, 20);


        objQwest7.TasksList.SetValue(objBaseTask87, 21);

        objQwest7.QwestTree = new List<Qwest>();

        objQwest6.QwestTree.Add(objQwest7);

        //----------Qwest#8-----------

        Qwest objQwest8 = new Qwest();
        objQwest8.Name = "Jumping";
        objQwest8.QwestTitle = "Hop up";

        objQwest8.Rewards = new UniversalReward();
        objQwest8.Rewards.ExperienceReward = 9496;
        objQwest8.Rewards.MoneyReward = 0;
        objQwest8.Rewards.RewardInGems = false;
        objQwest8.Rewards.ItemRewardID = 0;
        objQwest8.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest8.ShowQwestCompletePanel = true;
        objQwest8.TimerValue = 20;
        objQwest8.RepeatableQuest = false;
        objQwest8.MMMarkId = 4;

        objQwest8.MarkForMiniMap = null;
        objQwest8.AdditionalStartPointRadius = 0;
        objQwest8.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Sup, shawty!\"},{\"Actor\":\"Vella\",\"Replica\":\"- Hello there! So, you're the trickster, yes? At first, I need you to jump on the springboard over the skate park fence.\"},{\"Actor\":\"Vella\",\"Replica\":\" For Earnings.. Come back here yo boi!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest8.EndDialog = "{\"DialogName\":\"67458333\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Vella\",\"Replica\":\"- This is Awesome!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(650.2f, 2.31f, 31f);
        objQwest8.StartPosition = tempV3;
        objQwest8.TasksList = new BaseTask[6];


        StealAVehicleTask objBaseTask88 = new StealAVehicleTask();
        objBaseTask88.SpecificVehicleName = VehicleList.None;
        objBaseTask88.VehicleType = VehicleType.Car;
        objBaseTask88.countVisualMarks = 2;
        objBaseTask88.markVisualType = "Enter";

        objBaseTask88.TaskText = "Get a car";
        objBaseTask88.AdditionalTimer = 0;
        objBaseTask88.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask88.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Go the the board pavilion\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask89 = new DriveToPointTask();
        objBaseTask89.PointPosition = new Vector3(498.08f, 2.4f, 18.43f);
        objBaseTask89.SpecificVehicleName = VehicleList.None;
        objBaseTask89.PointRadius = 10;
        objBaseTask89.VehicleType = VehicleType.Car;

        objBaseTask89.TaskText = "Drive to start";
        objBaseTask89.AdditionalTimer = 30;
        objBaseTask89.DialogData = "";
        objBaseTask89.EndDialogData = "";


        DriveToPointTask objBaseTask90 = new DriveToPointTask();
        objBaseTask90.PointPosition = new Vector3(480.34f, 8.04f, 25f);
        objBaseTask90.SpecificVehicleName = VehicleList.None;
        objBaseTask90.PointRadius = 10;
        objBaseTask90.VehicleType = VehicleType.Car;

        objBaseTask90.TaskText = "Drive to the point";
        objBaseTask90.AdditionalTimer = 120;
        objBaseTask90.DialogData = "";
        objBaseTask90.EndDialogData = "";


DriveToPointTask objBaseTask91 = new DriveToPointTask();
        objBaseTask91.PointPosition = new Vector3(468.51f, 8.22f, 28.67f);
        objBaseTask91.SpecificVehicleName = VehicleList.None;
        objBaseTask91.PointRadius = 10;
        objBaseTask91.VehicleType = VehicleType.Car;

        objBaseTask91.TaskText = "Drive to point";
        objBaseTask91.AdditionalTimer = 0;
        objBaseTask91.DialogData = "";
        objBaseTask91.EndDialogData = "";


        DriveToPointTask objBaseTask92 = new DriveToPointTask();
        objBaseTask92.PointPosition = new Vector3(450.42f, 3.68f, 36f);
        objBaseTask92.SpecificVehicleName = VehicleList.None;
        objBaseTask92.PointRadius = 10;
        objBaseTask92.VehicleType = VehicleType.Car;

        objBaseTask92.TaskText = "Land here";
        objBaseTask92.AdditionalTimer = 0;
        objBaseTask92.DialogData = "";
        objBaseTask92.EndDialogData = "";


        ReachPointTask objBaseTask93 = new ReachPointTask();
        objBaseTask93.PointPosition = new Vector3(432.8f, 2.31f, 47.5f);
        objBaseTask93.AdditionalPointRadius = 0;

        objBaseTask93.TaskText = "Go to the point to trash cans";
        objBaseTask93.AdditionalTimer = 0;
        objBaseTask93.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Go back to Vella\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask93.EndDialogData = "";
        objBaseTask93.NextTask = null;


        objBaseTask93.PrevTask = objBaseTask92;
        objBaseTask92.NextTask = objBaseTask93;


        objBaseTask92.PrevTask = objBaseTask91;
        objBaseTask91.NextTask = objBaseTask92;


        objBaseTask91.PrevTask = objBaseTask90;
        objBaseTask90.NextTask = objBaseTask91;


        objBaseTask90.PrevTask = objBaseTask89;
        objBaseTask89.NextTask = objBaseTask90;


        objBaseTask89.PrevTask = objBaseTask88;
        objBaseTask88.NextTask = objBaseTask89;
        objBaseTask88.PrevTask = null;
        objQwest8.TasksList.SetValue(objBaseTask88, 0);


        objQwest8.TasksList.SetValue(objBaseTask89, 1);


        objQwest8.TasksList.SetValue(objBaseTask90, 2);


        objQwest8.TasksList.SetValue(objBaseTask91, 3);


        objQwest8.TasksList.SetValue(objBaseTask92, 4);


        objQwest8.TasksList.SetValue(objBaseTask93, 5);

        objQwest8.QwestTree = new List<Qwest>();

        //----------Qwest#9-----------

        Qwest objQwest9 = new Qwest();
        objQwest9.Name = "Jumping 2";
        objQwest9.QwestTitle = "Hop up Season 2";

        objQwest9.Rewards = new UniversalReward();
        objQwest9.Rewards.ExperienceReward = 15177;
        objQwest9.Rewards.MoneyReward = 0;
        objQwest9.Rewards.RewardInGems = false;
        objQwest9.Rewards.ItemRewardID = 0;
        objQwest9.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest9.ShowQwestCompletePanel = true;
        objQwest9.TimerValue = 20;
        objQwest9.RepeatableQuest = false;
        objQwest9.MMMarkId = 4;

        objQwest9.MarkForMiniMap = null;
        objQwest9.AdditionalStartPointRadius = 0;
        objQwest9.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Vella\",\"Replica\":\"- Jump through the channel! I am shooting your video.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest9.EndDialog = "{\"DialogName\":\"67458333\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Vella\",\"Replica\":\"'Screaming'\n- Cash is sent! Go back to pavilion\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(650.2f, 2.31f, 31f);
        objQwest9.StartPosition = tempV3;
        objQwest9.TasksList = new BaseTask[5];


        StealAVehicleTask objBaseTask94 = new StealAVehicleTask();
        objBaseTask94.SpecificVehicleName = VehicleList.None;
        objBaseTask94.VehicleType = VehicleType.Car;
        objBaseTask94.countVisualMarks = 2;
        objBaseTask94.markVisualType = "Enter";

        objBaseTask94.TaskText = "Get a car";
        objBaseTask94.AdditionalTimer = 0;
        objBaseTask94.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask94.EndDialogData = "";


        DriveToPointTask objBaseTask95 = new DriveToPointTask();
        objBaseTask95.PointPosition = new Vector3(498.23f, 2.4f, 85.63f);
        objBaseTask95.SpecificVehicleName = VehicleList.None;
        objBaseTask95.PointRadius = 10;
        objBaseTask95.VehicleType = VehicleType.Car;

        objBaseTask95.TaskText = "Drive to start";
        objBaseTask95.AdditionalTimer = 30;
        objBaseTask95.DialogData = "";
        objBaseTask95.EndDialogData = "";


        DriveToPointTask objBaseTask96 = new DriveToPointTask();
        objBaseTask96.PointPosition = new Vector3(480.34f, 8.04f, 78.8f);
        objBaseTask96.SpecificVehicleName = VehicleList.None;
        objBaseTask96.PointRadius = 10;
        objBaseTask96.VehicleType = VehicleType.Car;

        objBaseTask96.TaskText = "Drive to the point";
        objBaseTask96.AdditionalTimer = 120;
        objBaseTask96.DialogData = "";
        objBaseTask96.EndDialogData = "";


DriveToPointTask objBaseTask97 = new DriveToPointTask();
        objBaseTask97.PointPosition = new Vector3(468.51f, 8.22f, 74.6f);
        objBaseTask97.SpecificVehicleName = VehicleList.None;
        objBaseTask97.PointRadius = 10;
        objBaseTask97.VehicleType = VehicleType.Car;

        objBaseTask97.TaskText = "Get the point";
        objBaseTask97.AdditionalTimer = 0;
        objBaseTask97.DialogData = "";
        objBaseTask97.EndDialogData = "";


        DriveToPointTask objBaseTask98 = new DriveToPointTask();
        objBaseTask98.PointPosition = new Vector3(450.42f, 3.68f, 67.7f);
        objBaseTask98.SpecificVehicleName = VehicleList.None;
        objBaseTask98.PointRadius = 10;
        objBaseTask98.VehicleType = VehicleType.Car;

        objBaseTask98.TaskText = "Land here";
        objBaseTask98.AdditionalTimer = 0;
        objBaseTask98.DialogData = "";
        objBaseTask98.EndDialogData = "";
        objBaseTask98.NextTask = null;


        objBaseTask98.PrevTask = objBaseTask97;
        objBaseTask97.NextTask = objBaseTask98;


        objBaseTask97.PrevTask = objBaseTask96;
        objBaseTask96.NextTask = objBaseTask97;


        objBaseTask96.PrevTask = objBaseTask95;
        objBaseTask95.NextTask = objBaseTask96;


        objBaseTask95.PrevTask = objBaseTask94;
        objBaseTask94.NextTask = objBaseTask95;
        objBaseTask94.PrevTask = null;
        objQwest9.TasksList.SetValue(objBaseTask94, 0);


        objQwest9.TasksList.SetValue(objBaseTask95, 1);


        objQwest9.TasksList.SetValue(objBaseTask96, 2);


        objQwest9.TasksList.SetValue(objBaseTask97, 3);


        objQwest9.TasksList.SetValue(objBaseTask98, 4);

        objQwest9.QwestTree = new List<Qwest>();
        Qwest objQwest10 = new Qwest();

        //----------Qwest#10-----------

        objQwest10.Name = "Jumping 3";
        objQwest10.QwestTitle = "Hop up Season 3";

        objQwest10.Rewards = new UniversalReward();
        objQwest10.Rewards.ExperienceReward = 11690;
        objQwest10.Rewards.MoneyReward = 10000;
        objQwest10.Rewards.RewardInGems = false;
        objQwest10.Rewards.ItemRewardID = 0;
        objQwest10.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest10.ShowQwestCompletePanel = true;
        objQwest10.TimerValue = 20;
        objQwest10.RepeatableQuest = false;
        objQwest10.MMMarkId = 4;

        objQwest10.MarkForMiniMap = null;
        objQwest10.AdditionalStartPointRadius = 0;
        objQwest10.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Vella\",\"Replica\":\"- Dare yourself as next two jumps need to be over the channel. Send me a message video and I’ll make sure your work is accepted by boss\"},{\"Actor\":\"Vella\",\"Replica\":\"- Will send you some funds!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest10.EndDialog = "{\"DialogName\":\"67458333\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Vella\",\"Replica\":\"'message'\n- SWAAAG xD\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(650.2f, 2.31f, 31f);
        objQwest10.StartPosition = tempV3;
        objQwest10.TasksList = new BaseTask[5];


        StealAVehicleTask objBaseTask99 = new StealAVehicleTask();
        objBaseTask99.SpecificVehicleName = VehicleList.None;
        objBaseTask99.VehicleType = VehicleType.Car;
        objBaseTask99.countVisualMarks = 2;
        objBaseTask99.markVisualType = "Enter";

        objBaseTask99.TaskText = "Get a car";
        objBaseTask99.AdditionalTimer = 0;
        objBaseTask99.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask99.EndDialogData = "";


        DriveToPointTask objBaseTask100 = new DriveToPointTask();
        objBaseTask100.PointPosition = new Vector3(191.1f, 2.4f, -131.1f);
        objBaseTask100.SpecificVehicleName = VehicleList.None;
        objBaseTask100.PointRadius = 10;
        objBaseTask100.VehicleType = VehicleType.Car;

        objBaseTask100.TaskText = "Drive to start";
        objBaseTask100.AdditionalTimer = 30;
        objBaseTask100.DialogData = "";
        objBaseTask100.EndDialogData = "";


        DriveToPointTask objBaseTask101 = new DriveToPointTask();
        objBaseTask101.PointPosition = new Vector3(79.9f, 13.17f, -139.51f);
        objBaseTask101.SpecificVehicleName = VehicleList.None;
        objBaseTask101.PointRadius = 10;
        objBaseTask101.VehicleType = VehicleType.Car;

        objBaseTask101.TaskText = "Drive to the point";
        objBaseTask101.AdditionalTimer = 120;
        objBaseTask101.DialogData = "";
        objBaseTask101.EndDialogData = "";


        DriveToPointTask objBaseTask102 = new DriveToPointTask();
        objBaseTask102.PointPosition = new Vector3(45.3f, 15.3f, -141.44f);
        objBaseTask102.SpecificVehicleName = VehicleList.None;
        objBaseTask102.PointRadius = 10;
        objBaseTask102.VehicleType = VehicleType.Car;

        objBaseTask102.TaskText = "Get the point";
        objBaseTask102.AdditionalTimer = 0;
        objBaseTask102.DialogData = "";
        objBaseTask102.EndDialogData = "";


        DriveToPointTask objBaseTask103 = new DriveToPointTask();
        objBaseTask103.PointPosition = new Vector3(-25f, 2.6f, -143.77f);
        objBaseTask103.SpecificVehicleName = VehicleList.None;
        objBaseTask103.PointRadius = 10;
        objBaseTask103.VehicleType = VehicleType.Car;

        objBaseTask103.TaskText = "Land here";
        objBaseTask103.AdditionalTimer = 0;
        objBaseTask103.DialogData = "";
        objBaseTask103.EndDialogData = "";
        objBaseTask103.NextTask = null;


        objBaseTask103.PrevTask = objBaseTask102;
        objBaseTask102.NextTask = objBaseTask103;


        objBaseTask102.PrevTask = objBaseTask101;
        objBaseTask101.NextTask = objBaseTask102;


        objBaseTask101.PrevTask = objBaseTask100;
        objBaseTask100.NextTask = objBaseTask101;


        objBaseTask100.PrevTask = objBaseTask99;
        objBaseTask99.NextTask = objBaseTask100;
        objBaseTask99.PrevTask = null;
        objQwest10.TasksList.SetValue(objBaseTask99, 0);


        objQwest10.TasksList.SetValue(objBaseTask100, 1);


        objQwest10.TasksList.SetValue(objBaseTask101, 2);


        objQwest10.TasksList.SetValue(objBaseTask102, 3);


        objQwest10.TasksList.SetValue(objBaseTask103, 4);

        objQwest10.QwestTree = new List<Qwest>();

        objQwest9.QwestTree.Add(objQwest10);
        Qwest objQwest11 = new Qwest();
        objQwest11.Name = "Jumping 4";
        objQwest11.QwestTitle = "Hop up Season 4";

        objQwest11.Rewards = new UniversalReward();
        objQwest11.Rewards.ExperienceReward = 11690;
        objQwest11.Rewards.MoneyReward = 125;
        objQwest11.Rewards.RewardInGems = true;
        objQwest11.Rewards.ItemRewardID = 0;
        objQwest11.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest11.ShowQwestCompletePanel = true;
        objQwest11.TimerValue = 20;
        objQwest11.RepeatableQuest = false;
        objQwest11.MMMarkId = 4;

        objQwest11.MarkForMiniMap = null;
        objQwest11.AdditionalStartPointRadius = 0;
        objQwest11.StartDialog = "";
        objQwest11.EndDialog = "{\"DialogName\":\"67458333\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Vella\",\"Replica\":\"'Message'\n- Thanks!))\"},{\"Actor\":\"You\",\"Replica\":\"'Message'\n- - Wouldn’t it be a reward if I go out with you today?\"},{\"Actor\":\"Vella\",\"Replica\":\"'Message'\n- Rush on the gas gear and reach next job!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(650.2f, 2.31f, 31f);
        objQwest11.StartPosition = tempV3;
        objQwest11.TasksList = new BaseTask[5];


        StealAVehicleTask objBaseTask104 = new StealAVehicleTask();
        objBaseTask104.SpecificVehicleName = VehicleList.None;
        objBaseTask104.VehicleType = VehicleType.Car;
        objBaseTask104.countVisualMarks = 2;
        objBaseTask104.markVisualType = "Enter";

        objBaseTask104.TaskText = "Get a car";
        objBaseTask104.AdditionalTimer = 0;
        objBaseTask104.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask104.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Take the distance for the disperse and press the gas pedal!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        DriveToPointTask objBaseTask105 = new DriveToPointTask();
        objBaseTask105.PointPosition = new Vector3(498.08f, 2.4f, 18.43f);
        objBaseTask105.SpecificVehicleName = VehicleList.None;
        objBaseTask105.PointRadius = 10;
        objBaseTask105.VehicleType = VehicleType.Car;

        objBaseTask105.TaskText = "Drive to start";
        objBaseTask105.AdditionalTimer = 30;
        objBaseTask105.DialogData = "";
        objBaseTask105.EndDialogData = "";


        DriveToPointTask objBaseTask106 = new DriveToPointTask();
        objBaseTask106.PointPosition = new Vector3(480.34f, 8.04f, 25f);
        objBaseTask106.SpecificVehicleName = VehicleList.None;
        objBaseTask106.PointRadius = 10;
        objBaseTask106.VehicleType = VehicleType.Car;

        objBaseTask106.TaskText = "Drive to the point";
        objBaseTask106.AdditionalTimer = 120;
        objBaseTask106.DialogData = "";
        objBaseTask106.EndDialogData = "";


DriveToPointTask objBaseTask107 = new DriveToPointTask();
        objBaseTask107.PointPosition = new Vector3(468.51f, 8.22f, 28.67f);
        objBaseTask107.SpecificVehicleName = VehicleList.None;
        objBaseTask107.PointRadius = 10;
        objBaseTask107.VehicleType = VehicleType.Car;

        objBaseTask107.TaskText = "Get the point";
        objBaseTask107.AdditionalTimer = 0;
        objBaseTask107.DialogData = "";
        objBaseTask107.EndDialogData = "";


        DriveToPointTask objBaseTask108 = new DriveToPointTask();
        objBaseTask108.PointPosition = new Vector3(450.42f, 3.68f, 36f);
        objBaseTask108.SpecificVehicleName = VehicleList.None;
        objBaseTask108.PointRadius = 10;
        objBaseTask108.VehicleType = VehicleType.Car;

        objBaseTask108.TaskText = "Land here";
        objBaseTask108.AdditionalTimer = 0;
        objBaseTask108.DialogData = "";
        objBaseTask108.EndDialogData = "";
        objBaseTask108.NextTask = null;


        objBaseTask108.PrevTask = objBaseTask107;
        objBaseTask107.NextTask = objBaseTask108;


        objBaseTask107.PrevTask = objBaseTask106;
        objBaseTask106.NextTask = objBaseTask107;


        objBaseTask106.PrevTask = objBaseTask105;
        objBaseTask105.NextTask = objBaseTask106;


        objBaseTask105.PrevTask = objBaseTask104;
        objBaseTask104.NextTask = objBaseTask105;
        objBaseTask104.PrevTask = null;
        objQwest11.TasksList.SetValue(objBaseTask104, 0);


        objQwest11.TasksList.SetValue(objBaseTask105, 1);


        objQwest11.TasksList.SetValue(objBaseTask106, 2);


        objQwest11.TasksList.SetValue(objBaseTask107, 3);


        objQwest11.TasksList.SetValue(objBaseTask108, 4);

        objQwest11.QwestTree = new List<Qwest>();

        objQwest10.QwestTree.Add(objQwest11);

        objQwest8.QwestTree.Add(objQwest9);

        objQwest7.QwestTree.Add(objQwest8);

        objQwest5.QwestTree.Add(objQwest6);

        objQwest4.QwestTree.Add(objQwest5);

        objQwest3.QwestTree.Add(objQwest4);
        Qwest objQwest12 = new Qwest();
        objQwest12.Name = "Car business";
        objQwest12.QwestTitle = "Moto business";

        objQwest12.Rewards = new UniversalReward();
        objQwest12.Rewards.ExperienceReward = 2377;
        objQwest12.Rewards.MoneyReward = 0;
        objQwest12.Rewards.RewardInGems = false;
        objQwest12.Rewards.ItemRewardID = -496484;
        objQwest12.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest12.ShowQwestCompletePanel = true;
        objQwest12.TimerValue = 0;
        objQwest12.RepeatableQuest = false;
        objQwest12.MMMarkId = 6;

        objQwest12.MarkForMiniMap = null;
        objQwest12.AdditionalStartPointRadius = 0;
        objQwest12.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- You wanna sell vehicles?\"},{\"Actor\":\"You\",\"Replica\":\"- Chikohawa… We are here to help ya!\"},{\"Actor\":\"Pedro\",\"Replica\":\"- Take this oldie to the point round the corner of the streer!\"},{\"Actor\":\"You\",\"Replica\":\"- Understand, thanks.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest12.EndDialog = "{\"DialogName\":\"blya\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- Here is your liquid fund! We like your tough way of management!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-393.39f, 2.31f, 303.6f);
        objQwest12.StartPosition = tempV3;
        objQwest12.TasksList = new BaseTask[4];


        ReachPointTask objBaseTask109 = new ReachPointTask();
        objBaseTask109.PointPosition = new Vector3(-292.76f, 2.21f, -1.62f);
        objBaseTask109.AdditionalPointRadius = 0;

        objBaseTask109.TaskText = "Go find the Car";
        objBaseTask109.AdditionalTimer = 0;
        objBaseTask109.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask109.EndDialogData = "";


        StealAVehicleTask objBaseTask110 = new StealAVehicleTask();
        objBaseTask110.SpecificVehicleName = VehicleList.None;
        objBaseTask110.VehicleType = VehicleType.Car;
        objBaseTask110.countVisualMarks = 2;
        objBaseTask110.markVisualType = "Enter";

        objBaseTask110.TaskText = "Get this Car";
        objBaseTask110.AdditionalTimer = 0;
        objBaseTask110.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal the Car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask110.EndDialogData = "";


        DriveToPointTask objBaseTask111 = new DriveToPointTask();
        objBaseTask111.PointPosition = new Vector3(-393.39f, 2.31f, 303.6f);
        objBaseTask111.SpecificVehicleName = VehicleList.None;
        objBaseTask111.PointRadius = 3;
        objBaseTask111.VehicleType = VehicleType.Car;

        objBaseTask111.TaskText = "Drive back to Pedro";
        objBaseTask111.AdditionalTimer = 0;
        objBaseTask111.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive it to the Pedro's point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask111.EndDialogData = "";


        LeaveACarAtPointTask objBaseTask112 = new LeaveACarAtPointTask();
        objBaseTask112.PointPosition = new Vector3(-393.39f, 2.31f, 303.6f);
        objBaseTask112.SpecificVehicleName = VehicleList.None;
        objBaseTask112.VehicleType = VehicleType.Car;
        objBaseTask112.Range = 10;
        objBaseTask112.PointRadius = 3;
        objBaseTask112.AtPointDialog = "";

        objBaseTask112.TaskText = "Leave the Car";
        objBaseTask112.AdditionalTimer = 0;
        objBaseTask112.DialogData = "{\"DialogName\":\"32q54\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the Car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask112.EndDialogData = "";
        objBaseTask112.NextTask = null;


        objBaseTask112.PrevTask = objBaseTask111;
        objBaseTask111.NextTask = objBaseTask112;


        objBaseTask111.PrevTask = objBaseTask110;
        objBaseTask110.NextTask = objBaseTask111;


        objBaseTask110.PrevTask = objBaseTask109;
        objBaseTask109.NextTask = objBaseTask110;
        objBaseTask109.PrevTask = null;
        objQwest12.TasksList.SetValue(objBaseTask109, 0);


        objQwest12.TasksList.SetValue(objBaseTask110, 1);


        objQwest12.TasksList.SetValue(objBaseTask111, 2);


        objQwest12.TasksList.SetValue(objBaseTask112, 3);

        objQwest12.QwestTree = new List<Qwest>();
        Qwest objQwest13 = new Qwest();
        objQwest13.Name = "Steal a car 1";
        objQwest13.QwestTitle = "Loot the Moto 2";

        objQwest13.Rewards = new UniversalReward();
        objQwest13.Rewards.ExperienceReward = 3637;
        objQwest13.Rewards.MoneyReward = 12000;
        objQwest13.Rewards.RewardInGems = false;
        objQwest13.Rewards.ItemRewardID = 0;
        objQwest13.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest13.ShowQwestCompletePanel = true;
        objQwest13.TimerValue = 0;
        objQwest13.RepeatableQuest = false;
        objQwest13.MMMarkId = 6;

        objQwest13.MarkForMiniMap = null;
        objQwest13.AdditionalStartPointRadius = 0;
        objQwest13.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- The hot moto is near the southside in dale. Go and bring mama here!\"},{\"Actor\":\"Pedro\",\"Replica\":\"- Don’t let it rust down! Drive moto here.\"},{\"Actor\":\"You\",\"Replica\":\"- No problems\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest13.EndDialog = "{\"DialogName\":\"iiirrerwe\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"-  You know some guns? We liked your driving skills so, as baba salsa says.. We would like to test your aim at target.\"},{\"Actor\":\"You\",\"Replica\":\"- Hm, thanks.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-393.39f, 2.31f, 303.6f);
        objQwest13.StartPosition = tempV3;
        objQwest13.TasksList = new BaseTask[4];


        ReachPointTask objBaseTask113 = new ReachPointTask();
        objBaseTask113.PointPosition = new Vector3(-292.76f, 2.21f, -26.15f);
        objBaseTask113.AdditionalPointRadius = 0;

        objBaseTask113.TaskText = "Go find the car";
        objBaseTask113.AdditionalTimer = 0;
        objBaseTask113.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point to find the car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask113.EndDialogData = "";


        StealAVehicleTask objBaseTask114 = new StealAVehicleTask();
        objBaseTask114.SpecificVehicleName = VehicleList.Universal;
        objBaseTask114.VehicleType = VehicleType.Car;
        objBaseTask114.countVisualMarks = 2;
        objBaseTask114.markVisualType = "Enter";

        objBaseTask114.TaskText = "Get this car";
        objBaseTask114.AdditionalTimer = 0;
        objBaseTask114.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal the car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask114.EndDialogData = "";


        DriveToPointTask objBaseTask115 = new DriveToPointTask();
        objBaseTask115.PointPosition = new Vector3(-393.39f, 2.31f, 303.6f);
        objBaseTask115.SpecificVehicleName = VehicleList.Universal;
        objBaseTask115.PointRadius = 4;
        objBaseTask115.VehicleType = VehicleType.Car;

        objBaseTask115.TaskText = "Drive to point";
        objBaseTask115.AdditionalTimer = 0;
        objBaseTask115.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask115.EndDialogData = "";


        LeaveACarAtPointTask objBaseTask116 = new LeaveACarAtPointTask();
        objBaseTask116.PointPosition = new Vector3(-393.39f, 2.31f, 303.6f);
        objBaseTask116.SpecificVehicleName = VehicleList.Universal;
        objBaseTask116.VehicleType = VehicleType.Car;
        objBaseTask116.Range = 10;
        objBaseTask116.PointRadius = 4;
        objBaseTask116.AtPointDialog = "";

        objBaseTask116.TaskText = "Leave car";
        objBaseTask116.AdditionalTimer = 0;
        objBaseTask116.DialogData = "{\"DialogName\":\"32q54\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask116.EndDialogData = "";
        objBaseTask116.NextTask = null;


        objBaseTask116.PrevTask = objBaseTask115;
        objBaseTask115.NextTask = objBaseTask116;


        objBaseTask115.PrevTask = objBaseTask114;
        objBaseTask114.NextTask = objBaseTask115;


        objBaseTask114.PrevTask = objBaseTask113;
        objBaseTask113.NextTask = objBaseTask114;
        objBaseTask113.PrevTask = null;
        objQwest13.TasksList.SetValue(objBaseTask113, 0);


        objQwest13.TasksList.SetValue(objBaseTask114, 1);


        objQwest13.TasksList.SetValue(objBaseTask115, 2);


        objQwest13.TasksList.SetValue(objBaseTask116, 3);

        objQwest13.QwestTree = new List<Qwest>();
        Qwest objQwest14 = new Qwest();
        objQwest14.Name = "Steal a car 2";
        objQwest14.QwestTitle = "Loot Prado";

        objQwest14.Rewards = new UniversalReward();
        objQwest14.Rewards.ExperienceReward = 5601;
        objQwest14.Rewards.MoneyReward = 0;
        objQwest14.Rewards.RewardInGems = false;
        objQwest14.Rewards.ItemRewardID = -31098;
        objQwest14.Rewards.RelationRewards = new FactionRelationReward[0];

        objQwest14.ShowQwestCompletePanel = true;
        objQwest14.TimerValue = 0;
        objQwest14.RepeatableQuest = false;
        objQwest14.MMMarkId = 6;

        objQwest14.MarkForMiniMap = null;
        objQwest14.AdditionalStartPointRadius = 0;
        objQwest14.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- The two Prados are there out of the science lab. Loot them and bring beauties over here!\"},{\"Actor\":\"You\",\"Replica\":\"- Ok.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objQwest14.EndDialog = "{\"DialogName\":\"ggg\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Lively Lavida Man! Your awesome…\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        tempV3 = new Vector3(-393.39f, 2.31f, 303.6f);
        objQwest14.StartPosition = tempV3;
        objQwest14.TasksList = new BaseTask[4];


        ReachPointTask objBaseTask117 = new ReachPointTask();
        objBaseTask117.PointPosition = new Vector3(-292.76f, 2.21f, -26.15f);
        objBaseTask117.AdditionalPointRadius = 5;

        objBaseTask117.TaskText = "Go find the Jeep";
        objBaseTask117.AdditionalTimer = 0;
        objBaseTask117.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask117.EndDialogData = "";


        StealAVehicleTask objBaseTask118 = new StealAVehicleTask();
        objBaseTask118.SpecificVehicleName = VehicleList.Jeep;
        objBaseTask118.VehicleType = VehicleType.Car;
        objBaseTask118.countVisualMarks = 2;
        objBaseTask118.markVisualType = "Enter";

        objBaseTask118.TaskText = "Choose one Jeep";
        objBaseTask118.AdditionalTimer = 0;
        objBaseTask118.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal the Jeep\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask118.EndDialogData = "";


        DriveToPointTask objBaseTask119 = new DriveToPointTask();
        objBaseTask119.PointPosition = new Vector3(-393.39f, 2.31f, 303.6f);
        objBaseTask119.SpecificVehicleName = VehicleList.Jeep;
        objBaseTask119.PointRadius = 4;
        objBaseTask119.VehicleType = VehicleType.Car;

        objBaseTask119.TaskText = "Drive to point";
        objBaseTask119.AdditionalTimer = 0;
        objBaseTask119.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive back to Pedro\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask119.EndDialogData = "";


        LeaveACarAtPointTask objBaseTask120 = new LeaveACarAtPointTask();
        objBaseTask120.PointPosition = new Vector3(-393.39f, 2.31f, 303.6f);
        objBaseTask120.SpecificVehicleName = VehicleList.Jeep;
        objBaseTask120.VehicleType = VehicleType.Car;
        objBaseTask120.Range = 10;
        objBaseTask120.PointRadius = 4;
        objBaseTask120.AtPointDialog = "";

        objBaseTask120.TaskText = "Leave car";
        objBaseTask120.AdditionalTimer = 0;
        objBaseTask120.DialogData = "{\"DialogName\":\"32q54\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        objBaseTask120.EndDialogData = "";
        objBaseTask120.NextTask = null;


        objBaseTask120.PrevTask = objBaseTask119;
        objBaseTask119.NextTask = objBaseTask120;


        objBaseTask119.PrevTask = objBaseTask118;
        objBaseTask118.NextTask = objBaseTask119;


        objBaseTask118.PrevTask = objBaseTask117;
        objBaseTask117.NextTask = objBaseTask118;
        objBaseTask117.PrevTask = null;
        objQwest14.TasksList.SetValue(objBaseTask117, 0);


        objQwest14.TasksList.SetValue(objBaseTask118, 1);


        objQwest14.TasksList.SetValue(objBaseTask119, 2);


        objQwest14.TasksList.SetValue(objBaseTask120, 3);

        objQwest14.QwestTree = new List<Qwest>();
        //Qwest objQwest15 = new Qwest();
        //objQwest15.Name = "Steal a car 3";
        //objQwest15.QwestTitle = "Stealing Limo";

        //objQwest15.Rewards = new UniversalReward();
        //objQwest15.Rewards.ExperienceReward = 11690;
        //objQwest15.Rewards.MoneyReward = 10000;
        //objQwest15.Rewards.RewardInGems = false;
        //objQwest15.Rewards.ItemRewardID = 0;
        //objQwest15.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest15.ShowQwestCompletePanel = true;
        //objQwest15.TimerValue = 0;
        //objQwest15.RepeatableQuest = true;
        //objQwest15.MMMarkId = 6;

        //objQwest15.MarkForMiniMap = null;
        //objQwest15.AdditionalStartPointRadius = 0;
        //objQwest15.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- Hey, now I need a Limousine. Yeah, really long car. Without any specification, just get it.\"},{\"Actor\":\"Pedro\",\"Replica\":\"- For example, you could find some near the mafia's mansion or green tea farm.\"},{\"Actor\":\"You\",\"Replica\":\"- Hmmm, it's interesting.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest15.EndDialog = "";



        //tempV3 = new Vector3(-506.1292f, 1.639862f, -254.34f);
        //objQwest15.StartPosition = tempV3;
        //objQwest15.TasksList = new BaseTask[3];


        //StealAVehicleTask objBaseTask121 = new StealAVehicleTask();
        //objBaseTask121.SpecificVehicleName = VehicleList.Longcarr;
        //objBaseTask121.VehicleType = VehicleType.Car;
        //objBaseTask121.countVisualMarks = 2;
        //objBaseTask121.markVisualType = "Enter";

        //objBaseTask121.TaskText = "Get any Limo on the streets";
        //objBaseTask121.AdditionalTimer = 0;
        //objBaseTask121.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal a Limousine\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask121.EndDialogData = "";


        //DriveToPointTask objBaseTask122 = new DriveToPointTask();
        //objBaseTask122.PointPosition = new Vector3(-508.2692f, 1.737854f, -250.18f);
        //objBaseTask122.SpecificVehicleName = VehicleList.Longcarr;
        //objBaseTask122.PointRadius = 3;
        //objBaseTask122.VehicleType = VehicleType.Car;

        //objBaseTask122.TaskText = "Drive to the point";
        //objBaseTask122.AdditionalTimer = 0;
        //objBaseTask122.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive back to Pedro\n\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask122.EndDialogData = "";


        //LeaveACarAtPointTask objBaseTask123 = new LeaveACarAtPointTask();
        //objBaseTask123.PointPosition = new Vector3(-508.2692f, 1.737854f, -250.18f);
        //objBaseTask123.SpecificVehicleName = VehicleList.Longcarr;
        //objBaseTask123.VehicleType = VehicleType.Car;
        //objBaseTask123.Range = 10;
        //objBaseTask123.PointRadius = 4;
        //objBaseTask123.AtPointDialog = "";

        //objBaseTask123.TaskText = "Leave car";
        //objBaseTask123.AdditionalTimer = 0;
        //objBaseTask123.DialogData = "{\"DialogName\":\"32q54\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get out\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask123.EndDialogData = "{\"DialogName\":\"assad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- Yeah, that's what I wanted, here your cash.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask123.NextTask = null;


        //objBaseTask123.PrevTask = objBaseTask122;
        //objBaseTask122.NextTask = objBaseTask123;


        //objBaseTask122.PrevTask = objBaseTask121;
        //objBaseTask121.NextTask = objBaseTask122;
        //objBaseTask121.PrevTask = null;
        //objQwest15.TasksList.SetValue(objBaseTask121, 0);


        //objQwest15.TasksList.SetValue(objBaseTask122, 1);


        //objQwest15.TasksList.SetValue(objBaseTask123, 2);

        //objQwest15.QwestTree = new List<Qwest>();
        //Qwest objQwest16 = new Qwest();
        //objQwest16.Name = "Steal a car 4";
        //objQwest16.QwestTitle = "Stealing musclecar";

        //objQwest16.Rewards = new UniversalReward();
        //objQwest16.Rewards.ExperienceReward = 2000;
        //objQwest16.Rewards.MoneyReward = 15000;
        //objQwest16.Rewards.RewardInGems = false;
        //objQwest16.Rewards.ItemRewardID = 0;
        //objQwest16.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest16.ShowQwestCompletePanel = true;
        //objQwest16.TimerValue = 0;
        //objQwest16.RepeatableQuest = false;
        //objQwest16.MMMarkId = 6;

        //objQwest16.MarkForMiniMap = null;
        //objQwest16.AdditionalStartPointRadius = 0;
        //objQwest16.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- My garage needs a really good Z-bird. Could you drive me one for good sum, please?\"},{\"Actor\":\"You\",\"Replica\":\"- Stupid question)))))))))))))\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest16.EndDialog = "";



        //tempV3 = new Vector3(-506.1292f, 1.639862f, -254.34f);
        //objQwest16.StartPosition = tempV3;
        //objQwest16.TasksList = new BaseTask[3];


        //StealAVehicleTask objBaseTask124 = new StealAVehicleTask();
        //objBaseTask124.SpecificVehicleName = VehicleList.ZBird;
        //objBaseTask124.VehicleType = VehicleType.Car;
        //objBaseTask124.countVisualMarks = 2;
        //objBaseTask124.markVisualType = "Enter";

        //objBaseTask124.TaskText = "Get the car anywhere";
        //objBaseTask124.AdditionalTimer = 0;
        //objBaseTask124.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal a Z Bird (musclecar)\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask124.EndDialogData = "";


        //DriveToPointTask objBaseTask125 = new DriveToPointTask();
        //objBaseTask125.PointPosition = new Vector3(-508.2692f, 1.737854f, -250.18f);
        //objBaseTask125.SpecificVehicleName = VehicleList.ZBird;
        //objBaseTask125.PointRadius = 4;
        //objBaseTask125.VehicleType = VehicleType.Car;

        //objBaseTask125.TaskText = "Drive to point";
        //objBaseTask125.AdditionalTimer = 0;
        //objBaseTask125.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive back to Pedro\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask125.EndDialogData = "";


        //LeaveACarAtPointTask objBaseTask126 = new LeaveACarAtPointTask();
        //objBaseTask126.PointPosition = new Vector3(-508.2692f, 1.737854f, -250.18f);
        //objBaseTask126.SpecificVehicleName = VehicleList.ZBird;
        //objBaseTask126.VehicleType = VehicleType.Car;
        //objBaseTask126.Range = 10;
        //objBaseTask126.PointRadius = 4;
        //objBaseTask126.AtPointDialog = "";

        //objBaseTask126.TaskText = "Leave car";
        //objBaseTask126.AdditionalTimer = 0;
        //objBaseTask126.DialogData = "";
        //objBaseTask126.EndDialogData = "{\"DialogName\":\"assad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- That's all I needed. I gift you this bike cause you're my best employee! It was nice working with you, Oleg!\"},{\"Actor\":\"Pedro\",\"Replica\":\"- It was nice working with you, Oleg!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask126.NextTask = null;


        //objBaseTask126.PrevTask = objBaseTask125;
        //objBaseTask125.NextTask = objBaseTask126;


        //objBaseTask125.PrevTask = objBaseTask124;
        //objBaseTask124.NextTask = objBaseTask125;
        //objBaseTask124.PrevTask = null;
        //objQwest16.TasksList.SetValue(objBaseTask124, 0);


        //objQwest16.TasksList.SetValue(objBaseTask125, 1);


        //objQwest16.TasksList.SetValue(objBaseTask126, 2);

        //objQwest16.QwestTree = new List<Qwest>();
        //Qwest objQwest17 = new Qwest();
        //objQwest17.Name = "Steal a car 3";
        //objQwest17.QwestTitle = "Stealing tank";

        //objQwest17.Rewards = new UniversalReward();
        //objQwest17.Rewards.ExperienceReward = 3000;
        //objQwest17.Rewards.MoneyReward = 18000;
        //objQwest17.Rewards.RewardInGems = false;
        //objQwest17.Rewards.ItemRewardID = 0;
        //objQwest17.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest17.ShowQwestCompletePanel = true;
        //objQwest17.TimerValue = 0;
        //objQwest17.RepeatableQuest = false;
        //objQwest17.MMMarkId = 6;

        //objQwest17.MarkForMiniMap = null;
        //objQwest17.AdditionalStartPointRadius = 0;
        //objQwest17.StartDialog = "{\"DialogName\":\"Convey\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- The last order for you, man: I need you to steal the tank from the poligon.\"},{\"Actor\":\"You\",\"Replica\":\"- I guess I will.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest17.EndDialog = "{\"DialogName\":\"6675\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- Wow! Great job, here is your prize, thank you!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(-506.1292f, 1.639862f, -254.34f);
        //objQwest17.StartPosition = tempV3;
        //objQwest17.TasksList = new BaseTask[4];


        //ReachPointTask objBaseTask127 = new ReachPointTask();
        //objBaseTask127.PointPosition = new Vector3(503.4608f, 1.717865f, -983.66f);
        //objBaseTask127.AdditionalPointRadius = 2;

        //objBaseTask127.TaskText = "Go to the base";
        //objBaseTask127.AdditionalTimer = 0;
        //objBaseTask127.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point on the poligon. Watch your back.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask127.EndDialogData = "";


        //StealAVehicleTask objBaseTask128 = new StealAVehicleTask();
        //objBaseTask128.SpecificVehicleName = VehicleList.None;
        //objBaseTask128.VehicleType = VehicleType.Tank;
        //objBaseTask128.countVisualMarks = 2;
        //objBaseTask128.markVisualType = "Enter";

        //objBaseTask128.TaskText = "Get the tank";
        //objBaseTask128.AdditionalTimer = 0;
        //objBaseTask128.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal TANK!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask128.EndDialogData = "";


        //DriveToPointTask objBaseTask129 = new DriveToPointTask();
        //objBaseTask129.PointPosition = new Vector3(-508.2692f, 1.737854f, -250.18f);
        //objBaseTask129.SpecificVehicleName = VehicleList.None;
        //objBaseTask129.PointRadius = 4;
        //objBaseTask129.VehicleType = VehicleType.Tank;

        //objBaseTask129.TaskText = "Drive to the point";
        //objBaseTask129.AdditionalTimer = 0;
        //objBaseTask129.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive it to Pedro. Be careful.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask129.EndDialogData = "";


        //LeaveACarAtPointTask objBaseTask130 = new LeaveACarAtPointTask();
        //objBaseTask130.PointPosition = new Vector3(-508.2692f, 1.737854f, -250.18f);
        //objBaseTask130.SpecificVehicleName = VehicleList.None;
        //objBaseTask130.VehicleType = VehicleType.Tank;
        //objBaseTask130.Range = 10;
        //objBaseTask130.PointRadius = 5;
        //objBaseTask130.AtPointDialog = "";

        //objBaseTask130.TaskText = "Leave car";
        //objBaseTask130.AdditionalTimer = 0;
        //objBaseTask130.DialogData = "{\"DialogName\":\"32q54\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get out\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask130.EndDialogData = "{\"DialogName\":\"assad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Pedro\",\"Replica\":\"- Yeah, that's what I wanted, here your cash.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask130.NextTask = null;


        //objBaseTask130.PrevTask = objBaseTask129;
        //objBaseTask129.NextTask = objBaseTask130;


        //objBaseTask129.PrevTask = objBaseTask128;
        //objBaseTask128.NextTask = objBaseTask129;


        //objBaseTask128.PrevTask = objBaseTask127;
        //objBaseTask127.NextTask = objBaseTask128;
        //objBaseTask127.PrevTask = null;
        //objQwest17.TasksList.SetValue(objBaseTask127, 0);


        //objQwest17.TasksList.SetValue(objBaseTask128, 1);


        //objQwest17.TasksList.SetValue(objBaseTask129, 2);


        //objQwest17.TasksList.SetValue(objBaseTask130, 3);

        //objQwest17.QwestTree = new List<Qwest>();

        //objQwest16.QwestTree.Add(objQwest17);

        //objQwest15.QwestTree.Add(objQwest16);

        //objQwest14.QwestTree.Add(objQwest15);

        //objQwest13.QwestTree.Add(objQwest14);
        //Qwest objQwest18 = new Qwest();
        //objQwest18.Name = "Killer contract 1";
        //objQwest18.QwestTitle = "Kill fatso";

        //objQwest18.Rewards = new UniversalReward();
        //objQwest18.Rewards.ExperienceReward = 5601;
        //objQwest18.Rewards.MoneyReward = 0;
        //objQwest18.Rewards.RewardInGems = false;
        //objQwest18.Rewards.ItemRewardID = -1389870;
        //objQwest18.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest18.ShowQwestCompletePanel = true;
        //objQwest18.TimerValue = 0;
        //objQwest18.RepeatableQuest = false;
        //objQwest18.MMMarkId = 7;

        //objQwest18.MarkForMiniMap = null;
        //objQwest18.AdditionalStartPointRadius = 0;
        //objQwest18.StartDialog = "{\"DialogName\":\"Phone_11\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- Hello, I'm Mr Chan and there is my small agency of mercenaries. You are Mumba as I know, yes? \"},{\"Actor\":\"You\",\"Replica\":\"- Nice to meet you, mr Chan.\"},{\"Actor\":\"Chan\",\"Replica\":\"- So, are you ready for work?\"},{\"Actor\":\"You\",\"Replica\":\"- Yap.\"},{\"Actor\":\"Chan\",\"Replica\":\"- The tasks are to kill some people. Every head is paid in full. The first victim is stupid fatty, that often creeps out of his business.\"},{\"Actor\":\"Chan\",\"Replica\":\"- That's his address. You can find him here, he thinks he safe. I'll give you 3000$ for proofs of his death.\"},{\"Actor\":\"You\",\"Replica\":\"- I'll be back soon.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest18.EndDialog = "";



        //tempV3 = new Vector3(-290.7492f, 2.257843f, -797.98f);
        //objQwest18.StartPosition = tempV3;
        //objQwest18.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask131 = new ReachPointTask();
        //objBaseTask131.PointPosition = new Vector3(-713.1692f, 1.617859f, -321.6f);
        //objBaseTask131.AdditionalPointRadius = 2;

        //objBaseTask131.TaskText = "Find the fat bastard";
        //objBaseTask131.AdditionalTimer = 0;
        //objBaseTask131.DialogData = "{\"DialogName\":\"212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point to find house of the victim.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask131.EndDialogData = "";


        //CollectItemsTask objBaseTask132 = new CollectItemsTask();
        //objBaseTask132.InitialCountToCollect = 1;
        //objBaseTask132.PickupType = QwestPickupType.DocumentsFolder;
        //objBaseTask132.TargetFaction = Faction.Civilian;
        //objBaseTask132.MarksCount = 2;
        //objBaseTask132.MarksTypeNPC = "Kill";
        //objBaseTask132.MarksTypePickUp = "Pickup";

        //objBaseTask132.TaskText = "Kill the target";
        //objBaseTask132.AdditionalTimer = 0;
        //objBaseTask132.DialogData = "{\"DialogName\":\"23\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Hit this fatso and loot his documents.\"},{\"Actor\":\"You\",\"Replica\":\"- Bonjour, monsieur!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask132.EndDialogData = "";


        //ReachPointTask objBaseTask133 = new ReachPointTask();
        //objBaseTask133.PointPosition = new Vector3(94.81729f, -0.08215332f, 222.4847f);
        //objBaseTask133.AdditionalPointRadius = 0;

        //objBaseTask133.TaskText = "Bring the stuff back for the reward";
        //objBaseTask133.AdditionalTimer = 0;
        //objBaseTask133.DialogData = "{\"DialogName\":\"333\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back to Chan's point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask133.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- That's what I needed!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask133.NextTask = null;


        //objBaseTask133.PrevTask = objBaseTask132;
        //objBaseTask132.NextTask = objBaseTask133;


        //objBaseTask132.PrevTask = objBaseTask131;
        //objBaseTask131.NextTask = objBaseTask132;
        //objBaseTask131.PrevTask = null;
        //objQwest18.TasksList.SetValue(objBaseTask131, 0);


        //objQwest18.TasksList.SetValue(objBaseTask132, 1);


        //objQwest18.TasksList.SetValue(objBaseTask133, 2);

        //objQwest18.QwestTree = new List<Qwest>();
        //Qwest objQwest19 = new Qwest();
        //objQwest19.Name = "Killer contract 2";
        //objQwest19.QwestTitle = "Grannies killer";

        //objQwest19.Rewards = new UniversalReward();
        //objQwest19.Rewards.ExperienceReward = 9496;
        //objQwest19.Rewards.MoneyReward = 0;
        //objQwest19.Rewards.RewardInGems = false;
        //objQwest19.Rewards.ItemRewardID = 0;
        //objQwest19.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest19.ShowQwestCompletePanel = true;
        //objQwest19.TimerValue = 0;
        //objQwest19.RepeatableQuest = false;
        //objQwest19.MMMarkId = 7;

        //objQwest19.MarkForMiniMap = null;
        //objQwest19.AdditionalStartPointRadius = 0;
        //objQwest19.StartDialog = "{\"DialogName\":\"Phone_11\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- Hey. Next task is to kill the granny, she's snithching much on different people.\"},{\"Actor\":\"Chan\",\"Replica\":\"- That's her address. 3000$ again, old lady all the same.\"},{\"Actor\":\"You\",\"Replica\":\"- So, if she's snitching...\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest19.EndDialog = "";



        //tempV3 = new Vector3(-290.7492f, 2.257843f, -797.98f);
        //objQwest19.StartPosition = tempV3;
        //objQwest19.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask134 = new ReachPointTask();
        //objBaseTask134.PointPosition = new Vector3(288.5208f, 1.697845f, -975.2599f);
        //objBaseTask134.AdditionalPointRadius = 0;

        //objBaseTask134.TaskText = "Find the address";
        //objBaseTask134.AdditionalTimer = 0;
        //objBaseTask134.DialogData = "{\"DialogName\":\"324dwr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point to find her house\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask134.EndDialogData = "";


        //CollectItemsTask objBaseTask135 = new CollectItemsTask();
        //objBaseTask135.InitialCountToCollect = 1;
        //objBaseTask135.PickupType = QwestPickupType.Book;
        //objBaseTask135.TargetFaction = Faction.Civilian;
        //objBaseTask135.MarksCount = 2;
        //objBaseTask135.MarksTypeNPC = "Kill";
        //objBaseTask135.MarksTypePickUp = "Pickup";

        //objBaseTask135.TaskText = "Hit granny and pick up her item";
        //objBaseTask135.AdditionalTimer = 0;
        //objBaseTask135.DialogData = "{\"DialogName\":\"23\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Kill this pesky old lady and pick up item\"},{\"Actor\":\"Granny\",\"Replica\":\"- Hey, you, whatcha looking? What the stupid nerd, look at him!\"},{\"Actor\":\"You\",\"Replica\":\"- Sorry, nothing personal!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask135.EndDialogData = "";


        //ReachPointTask objBaseTask136 = new ReachPointTask();
        //objBaseTask136.PointPosition = new Vector3(-290.7492f, 2.257843f, -797.98f);
        //objBaseTask136.AdditionalPointRadius = 0;

        //objBaseTask136.TaskText = "Get back for the price";
        //objBaseTask136.AdditionalTimer = 0;
        //objBaseTask136.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back to Chan\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask136.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- You're real maniac!\"},{\"Actor\":\"You\",\"Replica\":\"- Stop joking, I didn't like it. But she was really pesky.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask136.NextTask = null;


        //objBaseTask136.PrevTask = objBaseTask135;
        //objBaseTask135.NextTask = objBaseTask136;


        //objBaseTask135.PrevTask = objBaseTask134;
        //objBaseTask134.NextTask = objBaseTask135;
        //objBaseTask134.PrevTask = null;
        //objQwest19.TasksList.SetValue(objBaseTask134, 0);


        //objQwest19.TasksList.SetValue(objBaseTask135, 1);


        //objQwest19.TasksList.SetValue(objBaseTask136, 2);

        //objQwest19.QwestTree = new List<Qwest>();
        //Qwest objQwest20 = new Qwest();
        //objQwest20.Name = "Killer conract 3";
        //objQwest20.QwestTitle = "Kill the pervert";

        //objQwest20.Rewards = new UniversalReward();
        //objQwest20.Rewards.ExperienceReward = 15177;
        //objQwest20.Rewards.MoneyReward = 0;
        //objQwest20.Rewards.RewardInGems = false;
        //objQwest20.Rewards.ItemRewardID = 0;
        //objQwest20.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest20.ShowQwestCompletePanel = true;
        //objQwest20.TimerValue = 0;
        //objQwest20.RepeatableQuest = false;
        //objQwest20.MMMarkId = 7;

        //objQwest20.MarkForMiniMap = null;
        //objQwest20.AdditionalStartPointRadius = 0;
        //objQwest20.StartDialog = "{\"DialogName\":\"Phone_11\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- One bastard is importuning to young girls. Need to mortally teach him.\"},{\"Actor\":\"You\",\"Replica\":\"- Yes, of course.\"},{\"Actor\":\"Chan\",\"Replica\":\"- He is on the west end of the Long Beach now.\"},{\"Actor\":\"You\",\"Replica\":\"- Ok.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest20.EndDialog = "";



        //tempV3 = new Vector3(-290.7492f, 2.257843f, -797.98f);
        //objQwest20.StartPosition = tempV3;
        //objQwest20.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask137 = new ReachPointTask();
        //objBaseTask137.PointPosition = new Vector3(-940.9092f, -7.41214f, 3.299999f);
        //objBaseTask137.AdditionalPointRadius = 0;

        //objBaseTask137.TaskText = "Go to the Long Beach";
        //objBaseTask137.AdditionalTimer = 0;
        //objBaseTask137.DialogData = "";
        //objBaseTask137.EndDialogData = "{\"DialogName\":\"898\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Granny\",\"Replica\":\"- Hey, you, whatcha looking? What the stupid nerd, look at him!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //CollectItemsTask objBaseTask138 = new CollectItemsTask();
        //objBaseTask138.InitialCountToCollect = 1;
        //objBaseTask138.PickupType = QwestPickupType.DocumentsFolder;
        //objBaseTask138.TargetFaction = Faction.Civilian;
        //objBaseTask138.MarksCount = 2;
        //objBaseTask138.MarksTypeNPC = "Kill";
        //objBaseTask138.MarksTypePickUp = "Pickup";

        //objBaseTask138.TaskText = "Make murder";
        //objBaseTask138.AdditionalTimer = 0;
        //objBaseTask138.DialogData = "{\"DialogName\":\"23\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Kill this man and pick up his passport as proof\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask138.EndDialogData = "";


        //ReachPointTask objBaseTask139 = new ReachPointTask();
        //objBaseTask139.PointPosition = new Vector3(-290.7492f, 2.257843f, -797.98f);
        //objBaseTask139.AdditionalPointRadius = 0;

        //objBaseTask139.TaskText = "Bring proof for reward";
        //objBaseTask139.AdditionalTimer = 0;
        //objBaseTask139.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back to Chan\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask139.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- Business!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask139.NextTask = null;


        //objBaseTask139.PrevTask = objBaseTask138;
        //objBaseTask138.NextTask = objBaseTask139;


        //objBaseTask138.PrevTask = objBaseTask137;
        //objBaseTask137.NextTask = objBaseTask138;
        //objBaseTask137.PrevTask = null;
        //objQwest20.TasksList.SetValue(objBaseTask137, 0);


        //objQwest20.TasksList.SetValue(objBaseTask138, 1);


        //objQwest20.TasksList.SetValue(objBaseTask139, 2);

        //objQwest20.QwestTree = new List<Qwest>();
        //Qwest objQwest21 = new Qwest();
        //objQwest21.Name = "Killer contract 4";
        //objQwest21.QwestTitle = "Double agent";

        //objQwest21.Rewards = new UniversalReward();
        //objQwest21.Rewards.ExperienceReward = 11690;
        //objQwest21.Rewards.MoneyReward = 125;
        //objQwest21.Rewards.RewardInGems = true;
        //objQwest21.Rewards.ItemRewardID = 0;
        //objQwest21.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest21.ShowQwestCompletePanel = true;
        //objQwest21.TimerValue = 0;
        //objQwest21.RepeatableQuest = true;
        //objQwest21.MMMarkId = 7;

        //objQwest21.MarkForMiniMap = null;
        //objQwest21.AdditionalStartPointRadius = 0;
        //objQwest21.StartDialog = "{\"DialogName\":\"Phone_11\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- Now we have special target. One treacherous cop is working on two fronts. We need to eliminate him.\"},{\"Actor\":\"Chan\",\"Replica\":\"- Find him at the North Central Street.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest21.EndDialog = "";



        //tempV3 = new Vector3(-290.7492f, 2.257843f, -797.98f);
        //objQwest21.StartPosition = tempV3;
        //objQwest21.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask140 = new ReachPointTask();
        //objBaseTask140.PointPosition = new Vector3(-278.1692f, 1.617859f, -165.61f);
        //objBaseTask140.AdditionalPointRadius = 2;

        //objBaseTask140.TaskText = "Find this policeman";
        //objBaseTask140.AdditionalTimer = 0;
        //objBaseTask140.DialogData = "";
        //objBaseTask140.EndDialogData = "{\"DialogName\":\"333555\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Good morning, officer!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //CollectItemsTask objBaseTask141 = new CollectItemsTask();
        //objBaseTask141.InitialCountToCollect = 1;
        //objBaseTask141.PickupType = QwestPickupType.DocumentsFolder;
        //objBaseTask141.TargetFaction = Faction.Police;
        //objBaseTask141.MarksCount = 2;
        //objBaseTask141.MarksTypeNPC = "Kill";
        //objBaseTask141.MarksTypePickUp = "Pickup";

        //objBaseTask141.TaskText = "Shoot and loot";
        //objBaseTask141.AdditionalTimer = 0;
        //objBaseTask141.DialogData = "{\"DialogName\":\"23\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Kill the cop and get his police certificate as proof\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask141.EndDialogData = "";


        //ReachPointTask objBaseTask142 = new ReachPointTask();
        //objBaseTask142.PointPosition = new Vector3(94.81729f, -0.08215332f, 222.4847f);
        //objBaseTask142.AdditionalPointRadius = 0;

        //objBaseTask142.TaskText = "Go take the stuff";
        //objBaseTask142.AdditionalTimer = 0;
        //objBaseTask142.DialogData = "";
        //objBaseTask142.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Chan\",\"Replica\":\"- Oh, finally done! We did all my order list for this month, congratulations!\"},{\"Actor\":\"You\",\"Replica\":\"- Hah...\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask142.NextTask = null;


        //objBaseTask142.PrevTask = objBaseTask141;
        //objBaseTask141.NextTask = objBaseTask142;


        //objBaseTask141.PrevTask = objBaseTask140;
        //objBaseTask140.NextTask = objBaseTask141;
        //objBaseTask140.PrevTask = null;
        //objQwest21.TasksList.SetValue(objBaseTask140, 0);


        //objQwest21.TasksList.SetValue(objBaseTask141, 1);


        //objQwest21.TasksList.SetValue(objBaseTask142, 2);

        //objQwest21.QwestTree = new List<Qwest>();

        //objQwest20.QwestTree.Add(objQwest21);

        //objQwest19.QwestTree.Add(objQwest20);

        //objQwest18.QwestTree.Add(objQwest19);

        //objQwest13.QwestTree.Add(objQwest18);

        objQwest12.QwestTree.Add(objQwest13);

        objQwest11.QwestTree.Add(objQwest12);
        objQwest13.QwestTree.Add(objQwest14);
        objQwest14.QwestTree.Add(objQwest0);

        //objQwest3.QwestTree.Add(objQwest12);
        //Qwest objQwest22 = new Qwest();
        //objQwest22.Name = "Delivery man";
        //objQwest22.QwestTitle = "Special delivery";

        //objQwest22.Rewards = new UniversalReward();
        //objQwest22.Rewards.ExperienceReward = 2377;
        //objQwest22.Rewards.MoneyReward = 5000;
        //objQwest22.Rewards.RewardInGems = false;
        //objQwest22.Rewards.ItemRewardID = 0;
        //objQwest22.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest22.ShowQwestCompletePanel = true;
        //objQwest22.TimerValue = 30;
        //objQwest22.RepeatableQuest = true;
        //objQwest22.MMMarkId = 5;

        //objQwest22.MarkForMiniMap = null;
        //objQwest22.AdditionalStartPointRadius = 0;
        //objQwest22.StartDialog = "{\"DialogName\":\"13212\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Terry\",\"Replica\":\"- Hey, homie! Do you want to earn some money?\"},{\"Actor\":\"You\",\"Replica\":\"- What here you have?\"},{\"Actor\":\"Terry\",\"Replica\":\"- We have a small underground pizzeria in our garage. Just need a delivery man. I've heard that you're the good driver, a real racer!\"},{\"Actor\":\"You\",\"Replica\":\"- Yeah, I like it! \"},{\"Actor\":\"Terry\",\"Replica\":\"- Just take a car, and let's do it!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest22.EndDialog = "";



        //tempV3 = new Vector3(-545.6992f, 1.67984f, -259.41f);
        //objQwest22.StartPosition = tempV3;
        //objQwest22.TasksList = new BaseTask[13];


        //StealAVehicleTask objBaseTask143 = new StealAVehicleTask();
        //objBaseTask143.SpecificVehicleName = VehicleList.None;
        //objBaseTask143.VehicleType = VehicleType.Car;
        //objBaseTask143.countVisualMarks = 2;
        //objBaseTask143.markVisualType = "Enter";

        //objBaseTask143.TaskText = "Get a car";
        //objBaseTask143.AdditionalTimer = 0;
        //objBaseTask143.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask143.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the Terry's point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask144 = new DriveToPointTask();
        //objBaseTask144.PointPosition = new Vector3(462.7808f, 1.657867f, -969.93f);
        //objBaseTask144.SpecificVehicleName = VehicleList.None;
        //objBaseTask144.PointRadius = 3;
        //objBaseTask144.VehicleType = VehicleType.Car;

        //objBaseTask144.TaskText = "Drive to pizzeria";
        //objBaseTask144.AdditionalTimer = 270;
        //objBaseTask144.DialogData = "";
        //objBaseTask144.EndDialogData = "{\"DialogName\":\"--\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Terry\",\"Replica\":\"- Ok, that's the list of addresses with the right order. You haven't much time!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask145 = new DriveToPointTask();
        //objBaseTask145.PointPosition = new Vector3(-84.5892f, -4.972137f, -967.96f);
        //objBaseTask145.SpecificVehicleName = VehicleList.None;
        //objBaseTask145.PointRadius = 3;
        //objBaseTask145.VehicleType = VehicleType.Car;

        //objBaseTask145.TaskText = "Drive to point";
        //objBaseTask145.AdditionalTimer = 90;
        //objBaseTask145.DialogData = "{\"DialogName\":\"3322\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Drive to the first client\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask145.EndDialogData = "{\"DialogName\":\"7799\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Hi, guys! That's your pizza! Just give me 15 dollars for it!\"},{\"Actor\":\"Chinesa\",\"Replica\":\"- 15 dolla, here! Thank you!\"},{\"Actor\":\"You\",\"Replica\":\"- Have a good day!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask146 = new DriveToPointTask();
        //objBaseTask146.PointPosition = new Vector3(-550.1892f, 1.607849f, -615.19f);
        //objBaseTask146.SpecificVehicleName = VehicleList.None;
        //objBaseTask146.PointRadius = 3;
        //objBaseTask146.VehicleType = VehicleType.Car;

        //objBaseTask146.TaskText = "Drive to point";
        //objBaseTask146.AdditionalTimer = 0;
        //objBaseTask146.DialogData = "";
        //objBaseTask146.EndDialogData = "";


        //ReachPointTask objBaseTask147 = new ReachPointTask();
        //objBaseTask147.PointPosition = new Vector3(-545.0492f, 1.687866f, -617.77f);
        //objBaseTask147.AdditionalPointRadius = 0;

        //objBaseTask147.TaskText = "Go to the door";
        //objBaseTask147.AdditionalTimer = 0;
        //objBaseTask147.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point to give pizza to the client (leave the car)\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask147.EndDialogData = "{\"DialogName\":\"tryoijiokdty\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"'Knock-knock'\n- Hello, there is your pepperoni pizza! 8 dollars from you.\"},{\"Actor\":\"Anonymus\",\"Replica\":\"- Here your cash, leave the pizza under the door and get out!\"},{\"Actor\":\"You\",\"Replica\":\"- Don't matter!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //StealAVehicleTask objBaseTask148 = new StealAVehicleTask();
        //objBaseTask148.SpecificVehicleName = VehicleList.None;
        //objBaseTask148.VehicleType = VehicleType.Car;
        //objBaseTask148.countVisualMarks = 2;
        //objBaseTask148.markVisualType = "Enter";

        //objBaseTask148.TaskText = "Get a car";
        //objBaseTask148.AdditionalTimer = 0;
        //objBaseTask148.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back in your car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask148.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the next point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask149 = new DriveToPointTask();
        //objBaseTask149.PointPosition = new Vector3(-163.3892f, 5.557861f, -251.83f);
        //objBaseTask149.SpecificVehicleName = VehicleList.None;
        //objBaseTask149.PointRadius = 2;
        //objBaseTask149.VehicleType = VehicleType.Car;

        //objBaseTask149.TaskText = "Drive to point";
        //objBaseTask149.AdditionalTimer = 0;
        //objBaseTask149.DialogData = "";
        //objBaseTask149.EndDialogData = "{\"DialogName\":\"33321\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Hi! There is your Hawaiian pizza and I need 10 dollars from you\"},{\"Actor\":\"Fatso\",\"Replica\":\"- Thanks, here you are!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask150 = new DriveToPointTask();
        //objBaseTask150.PointPosition = new Vector3(517.9408f, 1.777863f, -151.57f);
        //objBaseTask150.SpecificVehicleName = VehicleList.None;
        //objBaseTask150.PointRadius = 3;
        //objBaseTask150.VehicleType = VehicleType.Car;

        //objBaseTask150.TaskText = "Drive to point";
        //objBaseTask150.AdditionalTimer = 0;
        //objBaseTask150.DialogData = "";
        //objBaseTask150.EndDialogData = "";


        //ReachPointTask objBaseTask151 = new ReachPointTask();
        //objBaseTask151.PointPosition = new Vector3(522.6407f, 1.857849f, -145.916f);
        //objBaseTask151.AdditionalPointRadius = 0;

        //objBaseTask151.TaskText = "Go to the door";
        //objBaseTask151.AdditionalTimer = 0;
        //objBaseTask151.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point to give pizza to the client\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask151.EndDialogData = "{\"DialogName\":\"tryoijiokdty\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"'Knock-knock'\n\"},{\"Actor\":\"The client\",\"Replica\":\"- Hello! Give it through the window, yeah, come here!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //ReachPointTask objBaseTask152 = new ReachPointTask();
        //objBaseTask152.PointPosition = new Vector3(512.6108f, 1.857849f, -145.916f);
        //objBaseTask152.AdditionalPointRadius = 0;

        //objBaseTask152.TaskText = "Go to the window";
        //objBaseTask152.AdditionalTimer = 0;
        //objBaseTask152.DialogData = "";
        //objBaseTask152.EndDialogData = "{\"DialogName\":\"tryoijiokdty\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- 13 dollars, please\"},{\"Actor\":\"The client\",\"Replica\":\"- Here...oh, yah, thank's, dude! Goodbye!\"},{\"Actor\":\"You\",\"Replica\":\"- Bye\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //StealAVehicleTask objBaseTask153 = new StealAVehicleTask();
        //objBaseTask153.SpecificVehicleName = VehicleList.None;
        //objBaseTask153.VehicleType = VehicleType.Car;
        //objBaseTask153.countVisualMarks = 2;
        //objBaseTask153.markVisualType = "Enter";

        //objBaseTask153.TaskText = "Get a car";
        //objBaseTask153.AdditionalTimer = 0;
        //objBaseTask153.DialogData = "{\"DialogName\":\"kkk\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back in your car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask153.EndDialogData = "{\"DialogName\":\"be\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the next client\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask154 = new DriveToPointTask();
        //objBaseTask154.PointPosition = new Vector3(44.0408f, 1.757843f, -245.19f);
        //objBaseTask154.SpecificVehicleName = VehicleList.None;
        //objBaseTask154.PointRadius = 3;
        //objBaseTask154.VehicleType = VehicleType.Car;

        //objBaseTask154.TaskText = "Drive to point";
        //objBaseTask154.AdditionalTimer = 0;
        //objBaseTask154.DialogData = "{\"DialogName\":\"775423\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Oof, damn! I missed the address! Although nothing, they will wait, it's the cops! Hah!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask154.EndDialogData = "{\"DialogName\":\"ert3442\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Nice day, officer! There is your dinner, you're welcome!\"},{\"Actor\":\"Officer\",\"Replica\":\"- Nice!\"},{\"Actor\":\"You\",\"Replica\":\"- And your 25 dollars...\"},{\"Actor\":\"Officer\",\"Replica\":\"- Oh, yeah, here!\"},{\"Actor\":\"You\",\"Replica\":\"- Chao!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask155 = new DriveToPointTask();
        //objBaseTask155.PointPosition = new Vector3(462.7308f, 1.537842f, -969.94f);
        //objBaseTask155.SpecificVehicleName = VehicleList.None;
        //objBaseTask155.PointRadius = 3;
        //objBaseTask155.VehicleType = VehicleType.Car;

        //objBaseTask155.TaskText = "Drive to pizzeria";
        //objBaseTask155.AdditionalTimer = 0;
        //objBaseTask155.DialogData = "{\"DialogName\":\"234 4\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive back to the pizzeria\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask155.EndDialogData = "{\"DialogName\":\"345234\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- So, nothing has cooled down, right?\"},{\"Actor\":\"Terry\",\"Replica\":\"- Yap! Nice job, that's your part! Thanks, man, our delivery man is ill today.\"},{\"Actor\":\"You\",\"Replica\":\"- Maybe, another day, you could call me for help, thrasher!\"},{\"Actor\":\"Terry\",\"Replica\":\"- Ha, okay!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask155.NextTask = null;


        //objBaseTask155.PrevTask = objBaseTask154;
        //objBaseTask154.NextTask = objBaseTask155;


        //objBaseTask154.PrevTask = objBaseTask153;
        //objBaseTask153.NextTask = objBaseTask154;


        //objBaseTask153.PrevTask = objBaseTask152;
        //objBaseTask152.NextTask = objBaseTask153;


        //objBaseTask152.PrevTask = objBaseTask151;
        //objBaseTask151.NextTask = objBaseTask152;


        //objBaseTask151.PrevTask = objBaseTask150;
        //objBaseTask150.NextTask = objBaseTask151;


        //objBaseTask150.PrevTask = objBaseTask149;
        //objBaseTask149.NextTask = objBaseTask150;


        //objBaseTask149.PrevTask = objBaseTask148;
        //objBaseTask148.NextTask = objBaseTask149;


        //objBaseTask148.PrevTask = objBaseTask147;
        //objBaseTask147.NextTask = objBaseTask148;


        //objBaseTask147.PrevTask = objBaseTask146;
        //objBaseTask146.NextTask = objBaseTask147;


        //objBaseTask146.PrevTask = objBaseTask145;
        //objBaseTask145.NextTask = objBaseTask146;


        //objBaseTask145.PrevTask = objBaseTask144;
        //objBaseTask144.NextTask = objBaseTask145;


        //objBaseTask144.PrevTask = objBaseTask143;
        //objBaseTask143.NextTask = objBaseTask144;
        //objBaseTask143.PrevTask = null;
        //objQwest22.TasksList.SetValue(objBaseTask143, 0);


        //objQwest22.TasksList.SetValue(objBaseTask144, 1);


        //objQwest22.TasksList.SetValue(objBaseTask145, 2);


        //objQwest22.TasksList.SetValue(objBaseTask146, 3);


        //objQwest22.TasksList.SetValue(objBaseTask147, 4);


        //objQwest22.TasksList.SetValue(objBaseTask148, 5);


        //objQwest22.TasksList.SetValue(objBaseTask149, 6);


        //objQwest22.TasksList.SetValue(objBaseTask150, 7);


        //objQwest22.TasksList.SetValue(objBaseTask151, 8);


        //objQwest22.TasksList.SetValue(objBaseTask152, 9);


        //objQwest22.TasksList.SetValue(objBaseTask153, 10);


        //objQwest22.TasksList.SetValue(objBaseTask154, 11);


        //objQwest22.TasksList.SetValue(objBaseTask155, 12);

        //objQwest22.QwestTree = new List<Qwest>();

        //objQwest3.QwestTree.Add(objQwest22);

        objQwest2.QwestTree.Add(objQwest3);
        //Qwest objQwest23 = new Qwest();
        //objQwest23.Name = "First Blood";
        //objQwest23.QwestTitle = "First shooting";

        //objQwest23.Rewards = new UniversalReward();
        //objQwest23.Rewards.ExperienceReward = 1615;
        //objQwest23.Rewards.MoneyReward = 0;
        //objQwest23.Rewards.RewardInGems = false;
        //objQwest23.Rewards.ItemRewardID = -1488574;
        //objQwest23.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest23.ShowQwestCompletePanel = true;
        //objQwest23.TimerValue = 0;
        //objQwest23.RepeatableQuest = false;
        //objQwest23.MMMarkId = 2;

        //objQwest23.MarkForMiniMap = null;
        //objQwest23.AdditionalStartPointRadius = 0;
        //objQwest23.StartDialog = "{\"DialogName\":\"ewwe\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Listen, stupid *ss gangstas are selling crack in the neigbor area. That's not right, to push cheap low-quality product. Need to teach them.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Bang'em, pick up their drugs and throw it into the trash. Back after.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest23.EndDialog = "";



        //tempV3 = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objQwest23.StartPosition = tempV3;
        //objQwest23.TasksList = new BaseTask[9];


        //StealAVehicleTask objBaseTask156 = new StealAVehicleTask();
        //objBaseTask156.SpecificVehicleName = VehicleList.None;
        //objBaseTask156.VehicleType = VehicleType.Car;
        //objBaseTask156.countVisualMarks = 2;
        //objBaseTask156.markVisualType = "Enter";

        //objBaseTask156.TaskText = "Get a car";
        //objBaseTask156.AdditionalTimer = 0;
        //objBaseTask156.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask156.EndDialogData = "";


        //DriveToPointTask objBaseTask157 = new DriveToPointTask();
        //objBaseTask157.PointPosition = new Vector3(-612.2328f, 1.377838f, -706.9753f);
        //objBaseTask157.SpecificVehicleName = VehicleList.None;
        //objBaseTask157.PointRadius = 6;
        //objBaseTask157.VehicleType = VehicleType.Car;

        //objBaseTask157.TaskText = "Drive to Winslow";
        //objBaseTask157.AdditionalTimer = 45;
        //objBaseTask157.DialogData = "{\"DialogName\":\"sd\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask157.EndDialogData = "";


        //DriveToPointTask objBaseTask158 = new DriveToPointTask();
        //objBaseTask158.PointPosition = new Vector3(-579.1492f, 1.697845f, -630.08f);
        //objBaseTask158.SpecificVehicleName = VehicleList.None;
        //objBaseTask158.PointRadius = 6;
        //objBaseTask158.VehicleType = VehicleType.Car;

        //objBaseTask158.TaskText = "Drive to Carlos";
        //objBaseTask158.AdditionalTimer = 45;
        //objBaseTask158.DialogData = "";
        //objBaseTask158.EndDialogData = "";


        //DriveToPointTask objBaseTask159 = new DriveToPointTask();
        //objBaseTask159.PointPosition = new Vector3(-499.4088f, 1.287842f, -608.9816f);
        //objBaseTask159.SpecificVehicleName = VehicleList.None;
        //objBaseTask159.PointRadius = 6;
        //objBaseTask159.VehicleType = VehicleType.Car;

        //objBaseTask159.TaskText = "Drive to Carlos";
        //objBaseTask159.AdditionalTimer = 45;
        //objBaseTask159.DialogData = "";
        //objBaseTask159.EndDialogData = "";


        //DriveToPointTask objBaseTask160 = new DriveToPointTask();
        //objBaseTask160.PointPosition = new Vector3(-445.5627f, 2.017853f, -839.4853f);
        //objBaseTask160.SpecificVehicleName = VehicleList.None;
        //objBaseTask160.PointRadius = 6;
        //objBaseTask160.VehicleType = VehicleType.Car;

        //objBaseTask160.TaskText = "Drive to Carlos";
        //objBaseTask160.AdditionalTimer = 45;
        //objBaseTask160.DialogData = "";
        //objBaseTask160.EndDialogData = "";


        //ReachPointTask objBaseTask161 = new ReachPointTask();
        //objBaseTask161.PointPosition = new Vector3(-399.997f, 1.657867f, -847.7583f);
        //objBaseTask161.AdditionalPointRadius = 0;

        //objBaseTask161.TaskText = "Go to the dealers' point";
        //objBaseTask161.AdditionalTimer = 0;
        //objBaseTask161.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the car and get to the point to find those gangstas.\"},{\"Actor\":\"--\",\"Replica\":\"|Remember, when you are carrying out the quests with gunfights, you need at first get to the checkpoint and then start a fight, \r\ndon't do it earlier without the need!|\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask161.EndDialogData = "{\"DialogName\":\"lisafik\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Kill two gangstas and pick up their crack now.\"},{\"Actor\":\"--\",\"Replica\":\"|Remember for this type of quests, if you don't see your targets, try to find them nearby in this zone.\r\nIf you don't succeed, close a quest and try back later|\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //CollectItemsTask objBaseTask162 = new CollectItemsTask();
        //objBaseTask162.InitialCountToCollect = 2;
        //objBaseTask162.PickupType = QwestPickupType.Drug;
        //objBaseTask162.TargetFaction = Faction.Gang;
        //objBaseTask162.MarksCount = 2;
        //objBaseTask162.MarksTypeNPC = "Kill";
        //objBaseTask162.MarksTypePickUp = "Pickup";

        //objBaseTask162.TaskText = "Shoot gangstas, pick up crack";
        //objBaseTask162.AdditionalTimer = 0;
        //objBaseTask162.DialogData = "";
        //objBaseTask162.EndDialogData = "";


        //ReachPointTask objBaseTask163 = new ReachPointTask();
        //objBaseTask163.PointPosition = new Vector3(-814.1227f, 1.707855f, -575.9253f);
        //objBaseTask163.AdditionalPointRadius = 0;

        //objBaseTask163.TaskText = "Go to the point to trash cans";
        //objBaseTask163.AdditionalTimer = 0;
        //objBaseTask163.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to the point to throw crack away\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask163.EndDialogData = "";


        //ReachPointTask objBaseTask164 = new ReachPointTask();
        //objBaseTask164.PointPosition = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objBaseTask164.AdditionalPointRadius = 0;

        //objBaseTask164.TaskText = "Go back to Winslow";
        //objBaseTask164.AdditionalTimer = 0;
        //objBaseTask164.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get to Winslow\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask164.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- All done, brotha.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Great!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask164.NextTask = null;


        //objBaseTask164.PrevTask = objBaseTask163;
        //objBaseTask163.NextTask = objBaseTask164;


        //objBaseTask163.PrevTask = objBaseTask162;
        //objBaseTask162.NextTask = objBaseTask163;


        //objBaseTask162.PrevTask = objBaseTask161;
        //objBaseTask161.NextTask = objBaseTask162;


        //objBaseTask161.PrevTask = objBaseTask160;
        //objBaseTask160.NextTask = objBaseTask161;


        //objBaseTask160.PrevTask = objBaseTask159;
        //objBaseTask159.NextTask = objBaseTask160;


        //objBaseTask159.PrevTask = objBaseTask158;
        //objBaseTask158.NextTask = objBaseTask159;


        //objBaseTask158.PrevTask = objBaseTask157;
        //objBaseTask157.NextTask = objBaseTask158;


        //objBaseTask157.PrevTask = objBaseTask156;
        //objBaseTask156.NextTask = objBaseTask157;
        //objBaseTask156.PrevTask = null;
        //objQwest23.TasksList.SetValue(objBaseTask156, 0);


        //objQwest23.TasksList.SetValue(objBaseTask157, 1);


        //objQwest23.TasksList.SetValue(objBaseTask158, 2);


        //objQwest23.TasksList.SetValue(objBaseTask159, 3);


        //objQwest23.TasksList.SetValue(objBaseTask160, 4);


        //objQwest23.TasksList.SetValue(objBaseTask161, 5);


        //objQwest23.TasksList.SetValue(objBaseTask162, 6);


        //objQwest23.TasksList.SetValue(objBaseTask163, 7);


        //objQwest23.TasksList.SetValue(objBaseTask164, 8);

        //objQwest23.QwestTree = new List<Qwest>();
        //Qwest objQwest24 = new Qwest();
        //objQwest24.Name = "Break down mafia";
        //objQwest24.QwestTitle = "Break down mafia";

        //objQwest24.Rewards = new UniversalReward();
        //objQwest24.Rewards.ExperienceReward = 2377;
        //objQwest24.Rewards.MoneyReward = 0;
        //objQwest24.Rewards.RewardInGems = false;
        //objQwest24.Rewards.ItemRewardID = -26134936;
        //objQwest24.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest24.ShowQwestCompletePanel = true;
        //objQwest24.TimerValue = 0;
        //objQwest24.RepeatableQuest = false;
        //objQwest24.MMMarkId = 2;

        //objQwest24.MarkForMiniMap = null;
        //objQwest24.AdditionalStartPointRadius = 0;
        //objQwest24.StartDialog = "{\"DialogName\":\"sad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Ok, next targets aren't so easy. I need you to kill some mafiosas. These bastards killed my brothas Chookie, Cookie and Wookiee.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Their Don's mansion is near the center of the city. Kill the boss, maybe all his people too. Bring here the item from the boss.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Be careful, the boss have a special armor.\"},{\"Actor\":\"You\",\"Replica\":\"- It's very dangerous, the task for a real ninja commando. I think you need to prepare! Guess you're ready for it?\"},{\"Actor\":null,\"Replica\":\"- I guess, that's easy peasy lemon squeezy!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest24.EndDialog = "{\"DialogName\":\"999\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- That's it!\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Hell yeah! Take the bank! See what I've got for you\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objQwest24.StartPosition = tempV3;
        //objQwest24.TasksList = new BaseTask[9];


        //StealAVehicleTask objBaseTask165 = new StealAVehicleTask();
        //objBaseTask165.SpecificVehicleName = VehicleList.None;
        //objBaseTask165.VehicleType = VehicleType.Car;
        //objBaseTask165.countVisualMarks = 2;
        //objBaseTask165.markVisualType = "Enter";

        //objBaseTask165.TaskText = "Get a car";
        //objBaseTask165.AdditionalTimer = 0;
        //objBaseTask165.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask165.EndDialogData = "";


        //DriveToPointTask objBaseTask166 = new DriveToPointTask();
        //objBaseTask166.PointPosition = new Vector3(-612.2328f, 1.377838f, -706.9753f);
        //objBaseTask166.SpecificVehicleName = VehicleList.None;
        //objBaseTask166.PointRadius = 6;
        //objBaseTask166.VehicleType = VehicleType.Car;

        //objBaseTask166.TaskText = "Drive to Winslow";
        //objBaseTask166.AdditionalTimer = 45;
        //objBaseTask166.DialogData = "{\"DialogName\":\"sd\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask166.EndDialogData = "";


        //DriveToPointTask objBaseTask167 = new DriveToPointTask();
        //objBaseTask167.PointPosition = new Vector3(-579.4127f, 1.767853f, -630.1153f);
        //objBaseTask167.SpecificVehicleName = VehicleList.None;
        //objBaseTask167.PointRadius = 6;
        //objBaseTask167.VehicleType = VehicleType.Car;

        //objBaseTask167.TaskText = "Drive to Carlos";
        //objBaseTask167.AdditionalTimer = 45;
        //objBaseTask167.DialogData = "";
        //objBaseTask167.EndDialogData = "";


        //DriveToPointTask objBaseTask168 = new DriveToPointTask();
        //objBaseTask168.PointPosition = new Vector3(-175.7027f, 1.697845f, -611.6353f);
        //objBaseTask168.SpecificVehicleName = VehicleList.None;
        //objBaseTask168.PointRadius = 6;
        //objBaseTask168.VehicleType = VehicleType.Car;

        //objBaseTask168.TaskText = "Drive to Carlos";
        //objBaseTask168.AdditionalTimer = 45;
        //objBaseTask168.DialogData = "";
        //objBaseTask168.EndDialogData = "";


        //DriveToPointTask objBaseTask169 = new DriveToPointTask();
        //objBaseTask169.PointPosition = new Vector3(-117.8027f, 1.617859f, -538.5453f);
        //objBaseTask169.SpecificVehicleName = VehicleList.None;
        //objBaseTask169.PointRadius = 6;
        //objBaseTask169.VehicleType = VehicleType.Car;

        //objBaseTask169.TaskText = "Drive to Carlos";
        //objBaseTask169.AdditionalTimer = 45;
        //objBaseTask169.DialogData = "";
        //objBaseTask169.EndDialogData = "";


        //DriveToPointTask objBaseTask170 = new DriveToPointTask();
        //objBaseTask170.PointPosition = new Vector3(14.80728f, 9.617859f, -467.3353f);
        //objBaseTask170.SpecificVehicleName = VehicleList.None;
        //objBaseTask170.PointRadius = 6;
        //objBaseTask170.VehicleType = VehicleType.Car;

        //objBaseTask170.TaskText = "Drive to Carlos";
        //objBaseTask170.AdditionalTimer = 45;
        //objBaseTask170.DialogData = "";
        //objBaseTask170.EndDialogData = "";


        //ReachPointTask objBaseTask171 = new ReachPointTask();
        //objBaseTask171.PointPosition = new Vector3(-31.19272f, 11.71786f, -408.3353f);
        //objBaseTask171.AdditionalPointRadius = 15;

        //objBaseTask171.TaskText = "Find mafia";
        //objBaseTask171.AdditionalTimer = 0;
        //objBaseTask171.DialogData = "{\"DialogName\":\"ololo\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the car and get to the point to the entrance in the mafia's mansion\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask171.EndDialogData = "{\"DialogName\":\"567895\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Hi, guys!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //CollectItemsTask objBaseTask172 = new CollectItemsTask();
        //objBaseTask172.InitialCountToCollect = 1;
        //objBaseTask172.PickupType = QwestPickupType.Case;
        //objBaseTask172.TargetFaction = Faction.BossMafia;
        //objBaseTask172.MarksCount = 2;
        //objBaseTask172.MarksTypeNPC = "Kill";
        //objBaseTask172.MarksTypePickUp = "Pickup";

        //objBaseTask172.TaskText = "Kill mafia and loot";
        //objBaseTask172.AdditionalTimer = 0;
        //objBaseTask172.DialogData = "{\"DialogName\":\"Start_33\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Destroy mainly the boss and get his case.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask172.EndDialogData = "";


        //ReachPointTask objBaseTask173 = new ReachPointTask();
        //objBaseTask173.PointPosition = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objBaseTask173.AdditionalPointRadius = 0;

        //objBaseTask173.TaskText = "Go back to Winslow";
        //objBaseTask173.AdditionalTimer = 0;
        //objBaseTask173.DialogData = "";
        //objBaseTask173.EndDialogData = "";
        //objBaseTask173.NextTask = null;


        //objBaseTask173.PrevTask = objBaseTask172;
        //objBaseTask172.NextTask = objBaseTask173;


        //objBaseTask172.PrevTask = objBaseTask171;
        //objBaseTask171.NextTask = objBaseTask172;


        //objBaseTask171.PrevTask = objBaseTask170;
        //objBaseTask170.NextTask = objBaseTask171;


        //objBaseTask170.PrevTask = objBaseTask169;
        //objBaseTask169.NextTask = objBaseTask170;


        //objBaseTask169.PrevTask = objBaseTask168;
        //objBaseTask168.NextTask = objBaseTask169;


        //objBaseTask168.PrevTask = objBaseTask167;
        //objBaseTask167.NextTask = objBaseTask168;


        //objBaseTask167.PrevTask = objBaseTask166;
        //objBaseTask166.NextTask = objBaseTask167;


        //objBaseTask166.PrevTask = objBaseTask165;
        //objBaseTask165.NextTask = objBaseTask166;
        //objBaseTask165.PrevTask = null;
        //objQwest24.TasksList.SetValue(objBaseTask165, 0);


        //objQwest24.TasksList.SetValue(objBaseTask166, 1);


        //objQwest24.TasksList.SetValue(objBaseTask167, 2);


        //objQwest24.TasksList.SetValue(objBaseTask168, 3);


        //objQwest24.TasksList.SetValue(objBaseTask169, 4);


        //objQwest24.TasksList.SetValue(objBaseTask170, 5);


        //objQwest24.TasksList.SetValue(objBaseTask171, 6);


        //objQwest24.TasksList.SetValue(objBaseTask172, 7);


        //objQwest24.TasksList.SetValue(objBaseTask173, 8);

        //objQwest24.QwestTree = new List<Qwest>();
        //Qwest objQwest25 = new Qwest();
        //objQwest25.Name = "Break down yakuza";
        //objQwest25.QwestTitle = "Break down yakuza";

        //objQwest25.Rewards = new UniversalReward();
        //objQwest25.Rewards.ExperienceReward = 3637;
        //objQwest25.Rewards.MoneyReward = 150;
        //objQwest25.Rewards.RewardInGems = true;
        //objQwest25.Rewards.ItemRewardID = 0;
        //objQwest25.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest25.ShowQwestCompletePanel = true;
        //objQwest25.TimerValue = 0;
        //objQwest25.RepeatableQuest = false;
        //objQwest25.MMMarkId = 2;

        //objQwest25.MarkForMiniMap = null;
        //objQwest25.AdditionalStartPointRadius = 0;
        //objQwest25.StartDialog = "{\"DialogName\":\"sad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- And another commando mission, butcher. Yakuzas play dirty. They give us the tea instead of marij*ana.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Their farm, where they are working with their hired rednecks, is near the south beach. Kill them and pick up their items to find dope.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- It's very dangerous, this crazy asian mafia is merciless. They all got UZI!\"},{\"Actor\":\"You\",\"Replica\":\"- Ooo, I'm so scared!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest25.EndDialog = "{\"DialogName\":\"7775\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Sh*t! They got only green tea, it was small misunderstanding! Damn, uneducated fermers!\"},{\"Actor\":\"You\",\"Replica\":\"- But they got Uzi too!\"},{\"Actor\":\"Winslow\",\"Replica\":\"- These Japanese still strange.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objQwest25.StartPosition = tempV3;
        //objQwest25.TasksList = new BaseTask[8];


        //StealAVehicleTask objBaseTask174 = new StealAVehicleTask();
        //objBaseTask174.SpecificVehicleName = VehicleList.None;
        //objBaseTask174.VehicleType = VehicleType.Car;
        //objBaseTask174.countVisualMarks = 2;
        //objBaseTask174.markVisualType = "Enter";

        //objBaseTask174.TaskText = "Get a car";
        //objBaseTask174.AdditionalTimer = 0;
        //objBaseTask174.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask174.EndDialogData = "";


        //DriveToPointTask objBaseTask175 = new DriveToPointTask();
        //objBaseTask175.PointPosition = new Vector3(-578.9728f, 1.937866f, -622.3353f);
        //objBaseTask175.SpecificVehicleName = VehicleList.None;
        //objBaseTask175.PointRadius = 6;
        //objBaseTask175.VehicleType = VehicleType.Car;

        //objBaseTask175.TaskText = "Drive to Winslow";
        //objBaseTask175.AdditionalTimer = 45;
        //objBaseTask175.DialogData = "{\"DialogName\":\"sd\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask175.EndDialogData = "";


        //DriveToPointTask objBaseTask176 = new DriveToPointTask();
        //objBaseTask176.PointPosition = new Vector3(-205.9427f, 1.997864f, -612.9053f);
        //objBaseTask176.SpecificVehicleName = VehicleList.None;
        //objBaseTask176.PointRadius = 6;
        //objBaseTask176.VehicleType = VehicleType.Car;

        //objBaseTask176.TaskText = "Drive to Carlos";
        //objBaseTask176.AdditionalTimer = 45;
        //objBaseTask176.DialogData = "";
        //objBaseTask176.EndDialogData = "";


        //DriveToPointTask objBaseTask177 = new DriveToPointTask();
        //objBaseTask177.PointPosition = new Vector3(-92.69272f, 1.57785f, -829.2453f);
        //objBaseTask177.SpecificVehicleName = VehicleList.None;
        //objBaseTask177.PointRadius = 6;
        //objBaseTask177.VehicleType = VehicleType.Car;

        //objBaseTask177.TaskText = "Drive to Carlos";
        //objBaseTask177.AdditionalTimer = 45;
        //objBaseTask177.DialogData = "";
        //objBaseTask177.EndDialogData = "";


        //DriveToPointTask objBaseTask178 = new DriveToPointTask();
        //objBaseTask178.PointPosition = new Vector3(-51.18271f, -2.482147f, -938.1453f);
        //objBaseTask178.SpecificVehicleName = VehicleList.None;
        //objBaseTask178.PointRadius = 6;
        //objBaseTask178.VehicleType = VehicleType.Car;

        //objBaseTask178.TaskText = "Drive to Carlos";
        //objBaseTask178.AdditionalTimer = 45;
        //objBaseTask178.DialogData = "";
        //objBaseTask178.EndDialogData = "";


        //ReachPointTask objBaseTask179 = new ReachPointTask();
        //objBaseTask179.PointPosition = new Vector3(-86.1127f, -4.962158f, -954.6875f);
        //objBaseTask179.AdditionalPointRadius = 7;

        //objBaseTask179.TaskText = "Find yakuzas' farm";
        //objBaseTask179.AdditionalTimer = 0;
        //objBaseTask179.DialogData = "{\"DialogName\":\"ololo\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the car and get to the point at the farm.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask179.EndDialogData = "{\"DialogName\":\"jojojojoi\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Hey, you! Whom did you want to deceive, hah? Where is my Mary Jane?\"},{\"Actor\":\"Jaki Chan\",\"Replica\":\"- 'speaks chinese' bla-bla-bla\"},{\"Actor\":\"You\",\"Replica\":\"- English, motherf*cka, do you speak it?\"},{\"Actor\":\"Jaki Chan\",\"Replica\":\"- 'speaks chinese'...growin green tea...'speaks chinese'...wat cha want? I don't understanda...\"},{\"Actor\":\"You\",\"Replica\":\"- I should explain...\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //CollectItemsTask objBaseTask180 = new CollectItemsTask();
        //objBaseTask180.InitialCountToCollect = 3;
        //objBaseTask180.PickupType = QwestPickupType.Case;
        //objBaseTask180.TargetFaction = Faction.Yakuza;
        //objBaseTask180.MarksCount = 2;
        //objBaseTask180.MarksTypeNPC = "Kill";
        //objBaseTask180.MarksTypePickUp = "Pickup";

        //objBaseTask180.TaskText = "Kill japs and loot";
        //objBaseTask180.AdditionalTimer = 0;
        //objBaseTask180.DialogData = "{\"DialogName\":\"Start_33\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Destroy 3 farmers or more and pick up their items.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask180.EndDialogData = "";


        //ReachPointTask objBaseTask181 = new ReachPointTask();
        //objBaseTask181.PointPosition = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objBaseTask181.AdditionalPointRadius = 0;

        //objBaseTask181.TaskText = "Go back to Winslow";
        //objBaseTask181.AdditionalTimer = 0;
        //objBaseTask181.DialogData = "";
        //objBaseTask181.EndDialogData = "";
        //objBaseTask181.NextTask = null;


        //objBaseTask181.PrevTask = objBaseTask180;
        //objBaseTask180.NextTask = objBaseTask181;


        //objBaseTask180.PrevTask = objBaseTask179;
        //objBaseTask179.NextTask = objBaseTask180;


        //objBaseTask179.PrevTask = objBaseTask178;
        //objBaseTask178.NextTask = objBaseTask179;


        //objBaseTask178.PrevTask = objBaseTask177;
        //objBaseTask177.NextTask = objBaseTask178;


        //objBaseTask177.PrevTask = objBaseTask176;
        //objBaseTask176.NextTask = objBaseTask177;


        //objBaseTask176.PrevTask = objBaseTask175;
        //objBaseTask175.NextTask = objBaseTask176;


        //objBaseTask175.PrevTask = objBaseTask174;
        //objBaseTask174.NextTask = objBaseTask175;
        //objBaseTask174.PrevTask = null;
        //objQwest25.TasksList.SetValue(objBaseTask174, 0);


        //objQwest25.TasksList.SetValue(objBaseTask175, 1);


        //objQwest25.TasksList.SetValue(objBaseTask176, 2);


        //objQwest25.TasksList.SetValue(objBaseTask177, 3);


        //objQwest25.TasksList.SetValue(objBaseTask178, 4);


        //objQwest25.TasksList.SetValue(objBaseTask179, 5);


        //objQwest25.TasksList.SetValue(objBaseTask180, 6);


        //objQwest25.TasksList.SetValue(objBaseTask181, 7);

        //objQwest25.QwestTree = new List<Qwest>();
        //Qwest objQwest26 = new Qwest();
        //objQwest26.Name = "Massacre 3";
        //objQwest26.QwestTitle = "SABOTAGE";

        //objQwest26.Rewards = new UniversalReward();
        //objQwest26.Rewards.ExperienceReward = 5601;
        //objQwest26.Rewards.MoneyReward = 0;
        //objQwest26.Rewards.RewardInGems = false;
        //objQwest26.Rewards.ItemRewardID = -1487544;
        //objQwest26.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest26.ShowQwestCompletePanel = true;
        //objQwest26.TimerValue = 0;
        //objQwest26.RepeatableQuest = false;
        //objQwest26.MMMarkId = 2;

        //objQwest26.MarkForMiniMap = null;
        //objQwest26.AdditionalStartPointRadius = 0;
        //objQwest26.StartDialog = "{\"DialogName\":\"Start_31\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Ok, you were born for this illegal mission.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- We must declare ourselves to the mayor.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Your task is to sabotage the military base. Slaughter the guards and steal the military helicopter. And we will sell it.\n\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Come back alive, but not immediately. I'll send you reward, come back later.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest26.EndDialog = "{\"DialogName\":\"88005555535\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"'texting a message'\n- it's ready.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objQwest26.StartPosition = tempV3;
        //objQwest26.TasksList = new BaseTask[6];


        //ReachPointTask objBaseTask182 = new ReachPointTask();
        //objBaseTask182.PointPosition = new Vector3(-784.8428f, 2.503845f, -665.4894f);
        //objBaseTask182.AdditionalPointRadius = 0;

        //objBaseTask182.TaskText = "Get to the military base";
        //objBaseTask182.AdditionalTimer = 0;
        //objBaseTask182.DialogData = "{\"DialogName\":\"bbe\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Go to the military point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask182.EndDialogData = "";


        //MassacreTask objBaseTask183 = new MassacreTask();
        //objBaseTask183.WeaponItemID = -168118;
        //objBaseTask183.RequiredVictimsCount = 3;
        //objBaseTask183.MarksTypeNPC = "Kill";
        //objBaseTask183.MarksCount = 5;

        //objBaseTask183.TaskText = "AK-74 massacre";
        //objBaseTask183.AdditionalTimer = 300;
        //objBaseTask183.DialogData = "{\"DialogName\":\"123\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Come into and kill all soldiers fast.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask183.EndDialogData = "";


        //StealAVehicleTask objBaseTask184 = new StealAVehicleTask();
        //objBaseTask184.SpecificVehicleName = VehicleList.None;
        //objBaseTask184.VehicleType = VehicleType.Copter;
        //objBaseTask184.countVisualMarks = 2;
        //objBaseTask184.markVisualType = "Enter";

        //objBaseTask184.TaskText = "Get the copter";
        //objBaseTask184.AdditionalTimer = 0;
        //objBaseTask184.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Steal the helicopter!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask184.EndDialogData = "";


        //DriveToPointTask objBaseTask185 = new DriveToPointTask();
        //objBaseTask185.PointPosition = new Vector3(-238.5227f, 217.8279f, -326.6053f);
        //objBaseTask185.SpecificVehicleName = VehicleList.None;
        //objBaseTask185.PointRadius = 12;
        //objBaseTask185.VehicleType = VehicleType.Copter;

        //objBaseTask185.TaskText = "Fly away to the roof";
        //objBaseTask185.AdditionalTimer = 0;
        //objBaseTask185.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Fly to the point\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask185.EndDialogData = "";


        //DriveToPointTask objBaseTask186 = new DriveToPointTask();
        //objBaseTask186.PointPosition = new Vector3(-237.3327f, 205.7579f, -325.7353f);
        //objBaseTask186.SpecificVehicleName = VehicleList.None;
        //objBaseTask186.PointRadius = 12;
        //objBaseTask186.VehicleType = VehicleType.Copter;

        //objBaseTask186.TaskText = "Just fly down to land it";
        //objBaseTask186.AdditionalTimer = 0;
        //objBaseTask186.DialogData = "";
        //objBaseTask186.EndDialogData = "";


        //LeaveACarAtPointTask objBaseTask187 = new LeaveACarAtPointTask();
        //objBaseTask187.PointPosition = new Vector3(-237.3327f, 205.7579f, -325.7353f);
        //objBaseTask187.SpecificVehicleName = VehicleList.None;
        //objBaseTask187.VehicleType = VehicleType.Copter;
        //objBaseTask187.Range = 10;
        //objBaseTask187.PointRadius = 8;
        //objBaseTask187.AtPointDialog = "";

        //objBaseTask187.TaskText = "Leave the copter";
        //objBaseTask187.AdditionalTimer = 0;
        //objBaseTask187.DialogData = "{\"DialogName\":\"32q54\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Leave the copter here.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask187.EndDialogData = "";
        //objBaseTask187.NextTask = null;


        //objBaseTask187.PrevTask = objBaseTask186;
        //objBaseTask186.NextTask = objBaseTask187;


        //objBaseTask186.PrevTask = objBaseTask185;
        //objBaseTask185.NextTask = objBaseTask186;


        //objBaseTask185.PrevTask = objBaseTask184;
        //objBaseTask184.NextTask = objBaseTask185;


        //objBaseTask184.PrevTask = objBaseTask183;
        //objBaseTask183.NextTask = objBaseTask184;


        //objBaseTask183.PrevTask = objBaseTask182;
        //objBaseTask182.NextTask = objBaseTask183;
        //objBaseTask182.PrevTask = null;
        //objQwest26.TasksList.SetValue(objBaseTask182, 0);


        //objQwest26.TasksList.SetValue(objBaseTask183, 1);


        //objQwest26.TasksList.SetValue(objBaseTask184, 2);


        //objQwest26.TasksList.SetValue(objBaseTask185, 3);


        //objQwest26.TasksList.SetValue(objBaseTask186, 4);


        //objQwest26.TasksList.SetValue(objBaseTask187, 5);

        //objQwest26.QwestTree = new List<Qwest>();
        //Qwest objQwest27 = new Qwest();
        //objQwest27.Name = "Massacre 2";
        //objQwest27.QwestTitle = "Serious Mumba";

        //objQwest27.Rewards = new UniversalReward();
        //objQwest27.Rewards.ExperienceReward = 4748;
        //objQwest27.Rewards.MoneyReward = 8000;
        //objQwest27.Rewards.RewardInGems = false;
        //objQwest27.Rewards.ItemRewardID = 0;
        //objQwest27.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest27.ShowQwestCompletePanel = true;
        //objQwest27.TimerValue = 300;
        //objQwest27.RepeatableQuest = true;
        //objQwest27.MMMarkId = 2;

        //objQwest27.MarkForMiniMap = null;
        //objQwest27.AdditionalStartPointRadius = 0;
        //objQwest27.StartDialog = "{\"DialogName\":\"Start_31\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Ok, now the last carnage. \"},{\"Actor\":\"Winslow\",\"Replica\":\"- Get to the police station and start provocation. You will revenge to these pigs for our people!\nThe mayor won't be able to sell our island so easy!\"},{\"Actor\":\"You\",\"Replica\":\"- Ok, brother.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- Kill 20 people, mainly policemen, and don't get caught!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest27.EndDialog = "";



        //tempV3 = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objQwest27.StartPosition = tempV3;
        //objQwest27.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask188 = new ReachPointTask();
        //objBaseTask188.PointPosition = new Vector3(49.21729f, 1.647858f, -276.6853f);
        //objBaseTask188.AdditionalPointRadius = 0;

        //objBaseTask188.TaskText = "Go to the police station";
        //objBaseTask188.AdditionalTimer = 0;
        //objBaseTask188.DialogData = "{\"DialogName\":\"32145\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Go to checkpoint on the police station.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask188.EndDialogData = "";


        //MassacreTask objBaseTask189 = new MassacreTask();
        //objBaseTask189.WeaponItemID = -168118;
        //objBaseTask189.RequiredVictimsCount = 20;
        //objBaseTask189.MarksTypeNPC = "Kill";
        //objBaseTask189.MarksCount = 5;

        //objBaseTask189.TaskText = "AK-74 massacre";
        //objBaseTask189.AdditionalTimer = 300;
        //objBaseTask189.DialogData = "{\"DialogName\":\"123\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"You got a few minutes to kill 20 targets.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask189.EndDialogData = "";


        //ReachPointTask objBaseTask190 = new ReachPointTask();
        //objBaseTask190.PointPosition = new Vector3(-670.1027f, 1.497864f, -681.5052f);
        //objBaseTask190.AdditionalPointRadius = 0;

        //objBaseTask190.TaskText = "Back for the price";
        //objBaseTask190.AdditionalTimer = 0;
        //objBaseTask190.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back. Run fast!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask190.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Winslow\",\"Replica\":\"- Man, that's all that I could offer to you now. You did the great job. There is my turn now, next phase.\"},{\"Actor\":\"Winslow\",\"Replica\":\"- I'll try to lynch this bitch!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask190.NextTask = null;


        //objBaseTask190.PrevTask = objBaseTask189;
        //objBaseTask189.NextTask = objBaseTask190;


        //objBaseTask189.PrevTask = objBaseTask188;
        //objBaseTask188.NextTask = objBaseTask189;
        //objBaseTask188.PrevTask = null;
        //objQwest27.TasksList.SetValue(objBaseTask188, 0);


        //objQwest27.TasksList.SetValue(objBaseTask189, 1);


        //objQwest27.TasksList.SetValue(objBaseTask190, 2);

        //objQwest27.QwestTree = new List<Qwest>();

        //objQwest26.QwestTree.Add(objQwest27);
        //Qwest objQwest28 = new Qwest();
        //objQwest28.Name = "Massacres from Mr Smith";
        //objQwest28.QwestTitle = "Massacre line 1";

        //objQwest28.Rewards = new UniversalReward();
        //objQwest28.Rewards.ExperienceReward = 9496;
        //objQwest28.Rewards.MoneyReward = 0;
        //objQwest28.Rewards.RewardInGems = false;
        //objQwest28.Rewards.ItemRewardID = 0;
        //objQwest28.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest28.ShowQwestCompletePanel = true;
        //objQwest28.TimerValue = 300;
        //objQwest28.RepeatableQuest = false;
        //objQwest28.MMMarkId = 3;

        //objQwest28.MarkForMiniMap = null;
        //objQwest28.AdditionalStartPointRadius = 0;
        //objQwest28.StartDialog = "{\"DialogName\":\"Start_31\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- Hello there, how are you doing? Ok, I've got something for you.\"},{\"Actor\":\"Mr Smith\",\"Replica\":\"- Not only in your gang's interests to sabotage tourism here. I offer you the job.\"},{\"Actor\":\"Mr Smith\",\"Replica\":\"- Arrange the small number of carnages on these beaches and I'll pay you. I've hear that you a real maniac.\"},{\"Actor\":\"Mr Smith\",\"Replica\":\"- You'll need to kill a large number of people. But do you understand that's this is just a videogame? Never try this at home, boy!\"},{\"Actor\":\"You\",\"Replica\":\"- I need more money, yeah! I understand!\"},{\"Actor\":\"Mr Smith\",\"Replica\":\"- The first target is the South Beach. 10 people.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest28.EndDialog = "";



        //tempV3 = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objQwest28.StartPosition = tempV3;
        //objQwest28.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask191 = new ReachPointTask();
        //objBaseTask191.PointPosition = new Vector3(-149.5927f, -9.942139f, -1062.935f);
        //objBaseTask191.AdditionalPointRadius = 0;

        //objBaseTask191.TaskText = "Go to the South beach";
        //objBaseTask191.AdditionalTimer = 0;
        //objBaseTask191.DialogData = "{\"DialogName\":\"32145\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Go to the point on the beach\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask191.EndDialogData = "";


        //MassacreTask objBaseTask192 = new MassacreTask();
        //objBaseTask192.WeaponItemID = -168118;
        //objBaseTask192.RequiredVictimsCount = 10;
        //objBaseTask192.MarksTypeNPC = "Kill";
        //objBaseTask192.MarksCount = 5;

        //objBaseTask192.TaskText = "AK-74 shooting";
        //objBaseTask192.AdditionalTimer = 300;
        //objBaseTask192.DialogData = "{\"DialogName\":\"123\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"You got a few minutes to kill 10 targets.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask192.EndDialogData = "";


        //ReachPointTask objBaseTask193 = new ReachPointTask();
        //objBaseTask193.PointPosition = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objBaseTask193.AdditionalPointRadius = 0;

        //objBaseTask193.TaskText = "Back for the price";
        //objBaseTask193.AdditionalTimer = 0;
        //objBaseTask193.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back. Run fast!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask193.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- You're professional.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask193.NextTask = null;


        //objBaseTask193.PrevTask = objBaseTask192;
        //objBaseTask192.NextTask = objBaseTask193;


        //objBaseTask192.PrevTask = objBaseTask191;
        //objBaseTask191.NextTask = objBaseTask192;
        //objBaseTask191.PrevTask = null;
        //objQwest28.TasksList.SetValue(objBaseTask191, 0);


        //objQwest28.TasksList.SetValue(objBaseTask192, 1);


        //objQwest28.TasksList.SetValue(objBaseTask193, 2);

        //objQwest28.QwestTree = new List<Qwest>();
        //Qwest objQwest29 = new Qwest();
        //objQwest29.Name = "Massacre line 2 (2)";
        //objQwest29.QwestTitle = "Massacre line 2";

        //objQwest29.Rewards = new UniversalReward();
        //objQwest29.Rewards.ExperienceReward = 15177;
        //objQwest29.Rewards.MoneyReward = 0;
        //objQwest29.Rewards.RewardInGems = false;
        //objQwest29.Rewards.ItemRewardID = 0;
        //objQwest29.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest29.ShowQwestCompletePanel = true;
        //objQwest29.TimerValue = 300;
        //objQwest29.RepeatableQuest = false;
        //objQwest29.MMMarkId = 3;

        //objQwest29.MarkForMiniMap = null;
        //objQwest29.AdditionalStartPointRadius = 0;
        //objQwest29.StartDialog = "{\"DialogName\":\"Start_31\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- The second taget is the Southwestern Beach. 10 people too.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest29.EndDialog = "";



        //tempV3 = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objQwest29.StartPosition = tempV3;
        //objQwest29.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask194 = new ReachPointTask();
        //objBaseTask194.PointPosition = new Vector3(-868.3428f, -4.142151f, -642.8053f);
        //objBaseTask194.AdditionalPointRadius = 0;

        //objBaseTask194.TaskText = "Go to the Southwestern beach";
        //objBaseTask194.AdditionalTimer = 0;
        //objBaseTask194.DialogData = "{\"DialogName\":\"32145\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Go to the point on the beach\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask194.EndDialogData = "";


        //MassacreTask objBaseTask195 = new MassacreTask();
        //objBaseTask195.WeaponItemID = -168118;
        //objBaseTask195.RequiredVictimsCount = 10;
        //objBaseTask195.MarksTypeNPC = "Kill";
        //objBaseTask195.MarksCount = 5;

        //objBaseTask195.TaskText = "AK-74 shooting";
        //objBaseTask195.AdditionalTimer = 300;
        //objBaseTask195.DialogData = "{\"DialogName\":\"123\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"You got a few minutes to kill 10 targets.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask195.EndDialogData = "";


        //ReachPointTask objBaseTask196 = new ReachPointTask();
        //objBaseTask196.PointPosition = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objBaseTask196.AdditionalPointRadius = 0;

        //objBaseTask196.TaskText = "Back for the price";
        //objBaseTask196.AdditionalTimer = 0;
        //objBaseTask196.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back. Run fast!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask196.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- Here\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask196.NextTask = null;


        //objBaseTask196.PrevTask = objBaseTask195;
        //objBaseTask195.NextTask = objBaseTask196;


        //objBaseTask195.PrevTask = objBaseTask194;
        //objBaseTask194.NextTask = objBaseTask195;
        //objBaseTask194.PrevTask = null;
        //objQwest29.TasksList.SetValue(objBaseTask194, 0);


        //objQwest29.TasksList.SetValue(objBaseTask195, 1);


        //objQwest29.TasksList.SetValue(objBaseTask196, 2);

        //objQwest29.QwestTree = new List<Qwest>();
        //Qwest objQwest30 = new Qwest();
        //objQwest30.Name = "Massacre line 2 (3)";
        //objQwest30.QwestTitle = "Massacre line 3";

        //objQwest30.Rewards = new UniversalReward();
        //objQwest30.Rewards.ExperienceReward = 23380;
        //objQwest30.Rewards.MoneyReward = 0;
        //objQwest30.Rewards.RewardInGems = false;
        //objQwest30.Rewards.ItemRewardID = 0;
        //objQwest30.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest30.ShowQwestCompletePanel = true;
        //objQwest30.TimerValue = 300;
        //objQwest30.RepeatableQuest = false;
        //objQwest30.MMMarkId = 3;

        //objQwest30.MarkForMiniMap = null;
        //objQwest30.AdditionalStartPointRadius = 0;
        //objQwest30.StartDialog = "{\"DialogName\":\"Start_31\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- The third target is the Eastern Beach. 15 civilians or anybody\n.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest30.EndDialog = "";



        //tempV3 = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objQwest30.StartPosition = tempV3;
        //objQwest30.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask197 = new ReachPointTask();
        //objBaseTask197.PointPosition = new Vector3(254.0073f, -6.192139f, -261.4353f);
        //objBaseTask197.AdditionalPointRadius = 0;

        //objBaseTask197.TaskText = "Go to the Eastern beach";
        //objBaseTask197.AdditionalTimer = 0;
        //objBaseTask197.DialogData = "{\"DialogName\":\"32145\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Go to the point on the beach\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask197.EndDialogData = "";


        //MassacreTask objBaseTask198 = new MassacreTask();
        //objBaseTask198.WeaponItemID = -168118;
        //objBaseTask198.RequiredVictimsCount = 15;
        //objBaseTask198.MarksTypeNPC = "Kill";
        //objBaseTask198.MarksCount = 5;

        //objBaseTask198.TaskText = "AK-74 shooting";
        //objBaseTask198.AdditionalTimer = 300;
        //objBaseTask198.DialogData = "{\"DialogName\":\"123\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"You got a few minutes to kill 15 targets.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask198.EndDialogData = "";


        //ReachPointTask objBaseTask199 = new ReachPointTask();
        //objBaseTask199.PointPosition = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objBaseTask199.AdditionalPointRadius = 0;

        //objBaseTask199.TaskText = "Back for the price";
        //objBaseTask199.AdditionalTimer = 0;
        //objBaseTask199.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back. Run fast!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask199.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- Blood money.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask199.NextTask = null;


        //objBaseTask199.PrevTask = objBaseTask198;
        //objBaseTask198.NextTask = objBaseTask199;


        //objBaseTask198.PrevTask = objBaseTask197;
        //objBaseTask197.NextTask = objBaseTask198;
        //objBaseTask197.PrevTask = null;
        //objQwest30.TasksList.SetValue(objBaseTask197, 0);


        //objQwest30.TasksList.SetValue(objBaseTask198, 1);


        //objQwest30.TasksList.SetValue(objBaseTask199, 2);

        //objQwest30.QwestTree = new List<Qwest>();
        //Qwest objQwest31 = new Qwest();
        //objQwest31.Name = "Massacre line 2 (4)";
        //objQwest31.QwestTitle = "Massacre line 4";

        //objQwest31.Rewards = new UniversalReward();
        //objQwest31.Rewards.ExperienceReward = 15418;
        //objQwest31.Rewards.MoneyReward = 138;
        //objQwest31.Rewards.RewardInGems = true;
        //objQwest31.Rewards.ItemRewardID = 0;
        //objQwest31.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest31.ShowQwestCompletePanel = true;
        //objQwest31.TimerValue = 300;
        //objQwest31.RepeatableQuest = true;
        //objQwest31.MMMarkId = 3;

        //objQwest31.MarkForMiniMap = null;
        //objQwest31.AdditionalStartPointRadius = 0;
        //objQwest31.StartDialog = "{\"DialogName\":\"Start_31\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- The last target is the Northern Longbeach. 20 bodies.\n.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest31.EndDialog = "";



        //tempV3 = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objQwest31.StartPosition = tempV3;
        //objQwest31.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask200 = new ReachPointTask();
        //objBaseTask200.PointPosition = new Vector3(-441.0183f, -7.592133f, 13.46471f);
        //objBaseTask200.AdditionalPointRadius = 0;

        //objBaseTask200.TaskText = "Go to the Eastern beach";
        //objBaseTask200.AdditionalTimer = 0;
        //objBaseTask200.DialogData = "{\"DialogName\":\"32145\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Go to the point on the beach\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask200.EndDialogData = "";


        //MassacreTask objBaseTask201 = new MassacreTask();
        //objBaseTask201.WeaponItemID = -1488988;
        //objBaseTask201.RequiredVictimsCount = 15;
        //objBaseTask201.MarksTypeNPC = "Kill";
        //objBaseTask201.MarksCount = 5;

        //objBaseTask201.TaskText = "Final manhunt with Lazergun";
        //objBaseTask201.AdditionalTimer = 300;
        //objBaseTask201.DialogData = "{\"DialogName\":\"123\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"You got a few minutes to kill 15 targets.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask201.EndDialogData = "";


        //ReachPointTask objBaseTask202 = new ReachPointTask();
        //objBaseTask202.PointPosition = new Vector3(-849.3627f, 1.707855f, -570.1853f);
        //objBaseTask202.AdditionalPointRadius = 0;

        //objBaseTask202.TaskText = "Back for the price";
        //objBaseTask202.AdditionalTimer = 0;
        //objBaseTask202.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get back. Run fast!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask202.EndDialogData = "{\"DialogName\":\"sdfewr\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Mr Smith\",\"Replica\":\"- We will burn in hell.\"},{\"Actor\":\"You\",\"Replica\":\"- I'm just hstlin', you know!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask202.NextTask = null;


        //objBaseTask202.PrevTask = objBaseTask201;
        //objBaseTask201.NextTask = objBaseTask202;


        //objBaseTask201.PrevTask = objBaseTask200;
        //objBaseTask200.NextTask = objBaseTask201;
        //objBaseTask200.PrevTask = null;
        //objQwest31.TasksList.SetValue(objBaseTask200, 0);


        //objQwest31.TasksList.SetValue(objBaseTask201, 1);


        //objQwest31.TasksList.SetValue(objBaseTask202, 2);

        //objQwest31.QwestTree = new List<Qwest>();

        //objQwest30.QwestTree.Add(objQwest31);

        //objQwest29.QwestTree.Add(objQwest30);

        //objQwest28.QwestTree.Add(objQwest29);

        //objQwest26.QwestTree.Add(objQwest28);

        //objQwest25.QwestTree.Add(objQwest26);

        //objQwest24.QwestTree.Add(objQwest25);

        //objQwest23.QwestTree.Add(objQwest24);

        //objQwest2.QwestTree.Add(objQwest23);
        //Qwest objQwest32 = new Qwest();
        //objQwest32.Name = "Help to Carlos";
        //objQwest32.QwestTitle = "Help to Carlos";

        //objQwest32.Rewards = new UniversalReward();
        //objQwest32.Rewards.ExperienceReward = 1615;
        //objQwest32.Rewards.MoneyReward = 0;
        //objQwest32.Rewards.RewardInGems = false;
        //objQwest32.Rewards.ItemRewardID = -3541834;
        //objQwest32.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest32.ShowQwestCompletePanel = true;
        //objQwest32.TimerValue = 0;
        //objQwest32.RepeatableQuest = false;
        //objQwest32.MMMarkId = 8;

        //objQwest32.MarkForMiniMap = null;
        //objQwest32.AdditionalStartPointRadius = 0;
        //objQwest32.StartDialog = "{\"DialogName\":\"ewwe\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- Wassup! I got a few requests for you, biggie!\"},{\"Actor\":\"You\",\"Replica\":\"- All good! So what?\"},{\"Actor\":\"Carlos\",\"Replica\":\"- Need to take away our arrived weapons. You should meet with our provider, get guns and ammo and drive it to me.\"},{\"Actor\":\"You\",\"Replica\":\"- Okay. Must the provider to stay alive?\"},{\"Actor\":\"Carlos\",\"Replica\":\"- It would be better for us, if he does. Be quiet.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest32.EndDialog = "{\"DialogName\":\"555\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- All good, yeah? Captain is our trusted person.\"},{\"Actor\":\"You\",\"Replica\":\"- He's corrupted bastard or psychopath, or both. I mean I was a lil bit scared...\"},{\"Actor\":\"Carlos\",\"Replica\":\"- Hey, you're the die-hard and scared of the corrupted soldier?\"},{\"Actor\":\"You\",\"Replica\":\"- Don't you remember that I'm the corrupted soldier too?\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objQwest32.StartPosition = tempV3;
        //objQwest32.TasksList = new BaseTask[3];


        //StealAVehicleTask objBaseTask203 = new StealAVehicleTask();
        //objBaseTask203.SpecificVehicleName = VehicleList.None;
        //objBaseTask203.VehicleType = VehicleType.Car;
        //objBaseTask203.countVisualMarks = 2;
        //objBaseTask203.markVisualType = "Enter";

        //objBaseTask203.TaskText = "Get wheels";
        //objBaseTask203.AdditionalTimer = 0;
        //objBaseTask203.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car to drive to the provider's point.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask203.EndDialogData = "";


        //DriveToPointTask objBaseTask204 = new DriveToPointTask();
        //objBaseTask204.PointPosition = new Vector3(-914.8228f, 1.58786f, -538.9653f);
        //objBaseTask204.SpecificVehicleName = VehicleList.None;
        //objBaseTask204.PointRadius = 3;
        //objBaseTask204.VehicleType = VehicleType.Car;

        //objBaseTask204.TaskText = "Drive to meet provider";
        //objBaseTask204.AdditionalTimer = 0;
        //objBaseTask204.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to provider's point.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask204.EndDialogData = "{\"DialogName\":\"fish or meat\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Good afternoon. I'm from Carlos, to take the lunch. Here are the ticket.\"},{\"Actor\":\"Captain Sam\",\"Replica\":\"- Oh, hello, my friend! So, here you are your lunch!\"},{\"Actor\":\"You\",\"Replica\":\"- Thanks!\"},{\"Actor\":\"Captain Sam\",\"Replica\":\"- You are welcome!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask205 = new DriveToPointTask();
        //objBaseTask205.PointPosition = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objBaseTask205.SpecificVehicleName = VehicleList.None;
        //objBaseTask205.PointRadius = 3;
        //objBaseTask205.VehicleType = VehicleType.Car;

        //objBaseTask205.TaskText = "Drive back to Carlos";
        //objBaseTask205.AdditionalTimer = 0;
        //objBaseTask205.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive back\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask205.EndDialogData = "";
        //objBaseTask205.NextTask = null;


        //objBaseTask205.PrevTask = objBaseTask204;
        //objBaseTask204.NextTask = objBaseTask205;


        //objBaseTask204.PrevTask = objBaseTask203;
        //objBaseTask203.NextTask = objBaseTask204;
        //objBaseTask203.PrevTask = null;
        //objQwest32.TasksList.SetValue(objBaseTask203, 0);


        //objQwest32.TasksList.SetValue(objBaseTask204, 1);


        //objQwest32.TasksList.SetValue(objBaseTask205, 2);

        //objQwest32.QwestTree = new List<Qwest>();
        //Qwest objQwest33 = new Qwest();
        //objQwest33.Name = "Break down dilla";
        //objQwest33.QwestTitle = "Break dilla";

        //objQwest33.Rewards = new UniversalReward();
        //objQwest33.Rewards.ExperienceReward = 2377;
        //objQwest33.Rewards.MoneyReward = 10000;
        //objQwest33.Rewards.RewardInGems = false;
        //objQwest33.Rewards.ItemRewardID = 0;
        //objQwest33.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest33.ShowQwestCompletePanel = true;
        //objQwest33.TimerValue = 0;
        //objQwest33.RepeatableQuest = false;
        //objQwest33.MMMarkId = 8;

        //objQwest33.MarkForMiniMap = null;
        //objQwest33.AdditionalStartPointRadius = 0;
        //objQwest33.StartDialog = "{\"DialogName\":\"sad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- One diller is working with mafiosos after our calm. Shoot him down and loot.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest33.EndDialog = "";



        //tempV3 = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objQwest33.StartPosition = tempV3;
        //objQwest33.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask206 = new ReachPointTask();
        //objBaseTask206.PointPosition = new Vector3(-374.8027f, 1.737854f, -535.7653f);
        //objBaseTask206.AdditionalPointRadius = 4;

        //objBaseTask206.TaskText = "Find the diller";
        //objBaseTask206.AdditionalTimer = 0;
        //objBaseTask206.DialogData = "{\"DialogName\":\"ololo\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Go find the diller\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask206.EndDialogData = "";


        //CollectItemsTask objBaseTask207 = new CollectItemsTask();
        //objBaseTask207.InitialCountToCollect = 1;
        //objBaseTask207.PickupType = QwestPickupType.Phone;
        //objBaseTask207.TargetFaction = Faction.Gang;
        //objBaseTask207.MarksCount = 2;
        //objBaseTask207.MarksTypeNPC = "Kill";
        //objBaseTask207.MarksTypePickUp = "Pickup";

        //objBaseTask207.TaskText = "Kill this black guy";
        //objBaseTask207.AdditionalTimer = 0;
        //objBaseTask207.DialogData = "{\"DialogName\":\"Start_33\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Kill this black guy, it's him.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask207.EndDialogData = "{\"DialogName\":\"9877666555\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"You\",\"Replica\":\"- Reversible b*tch!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //ReachPointTask objBaseTask208 = new ReachPointTask();
        //objBaseTask208.PointPosition = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objBaseTask208.AdditionalPointRadius = 0;

        //objBaseTask208.TaskText = "Back to Carlos";
        //objBaseTask208.AdditionalTimer = 0;
        //objBaseTask208.DialogData = "{\"DialogName\":\"111444777\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"- Move back\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask208.EndDialogData = "";
        //objBaseTask208.NextTask = null;


        //objBaseTask208.PrevTask = objBaseTask207;
        //objBaseTask207.NextTask = objBaseTask208;


        //objBaseTask207.PrevTask = objBaseTask206;
        //objBaseTask206.NextTask = objBaseTask207;
        //objBaseTask206.PrevTask = null;
        //objQwest33.TasksList.SetValue(objBaseTask206, 0);


        //objQwest33.TasksList.SetValue(objBaseTask207, 1);


        //objQwest33.TasksList.SetValue(objBaseTask208, 2);

        //objQwest33.QwestTree = new List<Qwest>();
        //Qwest objQwest34 = new Qwest();
        //objQwest34.Name = "Break down mafiosi";
        //objQwest34.QwestTitle = "Kill one mafia member";

        //objQwest34.Rewards = new UniversalReward();
        //objQwest34.Rewards.ExperienceReward = 3637;
        //objQwest34.Rewards.MoneyReward = 0;
        //objQwest34.Rewards.RewardInGems = false;
        //objQwest34.Rewards.ItemRewardID = -168118;
        //objQwest34.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest34.ShowQwestCompletePanel = true;
        //objQwest34.TimerValue = 0;
        //objQwest34.RepeatableQuest = false;
        //objQwest34.MMMarkId = 8;

        //objQwest34.MarkForMiniMap = null;
        //objQwest34.AdditionalStartPointRadius = 0;
        //objQwest34.StartDialog = "{\"DialogName\":\"sad\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- Okay, now we know his supplier from the mafia side. Find him on the Long Beach and liquidate.\"},{\"Actor\":\"You\",\"Replica\":\"- Listen, I begin to love this city for its action!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest34.EndDialog = "{\"DialogName\":\"8888\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- That's nice of you\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objQwest34.StartPosition = tempV3;
        //objQwest34.TasksList = new BaseTask[3];


        //ReachPointTask objBaseTask209 = new ReachPointTask();
        //objBaseTask209.PointPosition = new Vector3(-878.8027f, 2.017853f, -14.16529f);
        //objBaseTask209.AdditionalPointRadius = 4;

        //objBaseTask209.TaskText = "Find the diller";
        //objBaseTask209.AdditionalTimer = 0;
        //objBaseTask209.DialogData = "{\"DialogName\":\"ololo\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Go find the mafia member\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask209.EndDialogData = "";


        //CollectItemsTask objBaseTask210 = new CollectItemsTask();
        //objBaseTask210.InitialCountToCollect = 1;
        //objBaseTask210.PickupType = QwestPickupType.Note_book;
        //objBaseTask210.TargetFaction = Faction.Mafia;
        //objBaseTask210.MarksCount = 2;
        //objBaseTask210.MarksTypeNPC = "Kill";
        //objBaseTask210.MarksTypePickUp = "Pickup";

        //objBaseTask210.TaskText = "Kill this black guy";
        //objBaseTask210.AdditionalTimer = 0;
        //objBaseTask210.DialogData = "{\"DialogName\":\"Start_33\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Bang! and pick up something\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask210.EndDialogData = "";


        //ReachPointTask objBaseTask211 = new ReachPointTask();
        //objBaseTask211.PointPosition = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objBaseTask211.AdditionalPointRadius = 0;

        //objBaseTask211.TaskText = "Back to Carlos";
        //objBaseTask211.AdditionalTimer = 0;
        //objBaseTask211.DialogData = "";
        //objBaseTask211.EndDialogData = "";
        //objBaseTask211.NextTask = null;


        //objBaseTask211.PrevTask = objBaseTask210;
        //objBaseTask210.NextTask = objBaseTask211;


        //objBaseTask210.PrevTask = objBaseTask209;
        //objBaseTask209.NextTask = objBaseTask210;
        //objBaseTask209.PrevTask = null;
        //objQwest34.TasksList.SetValue(objBaseTask209, 0);


        //objQwest34.TasksList.SetValue(objBaseTask210, 1);


        //objQwest34.TasksList.SetValue(objBaseTask211, 2);

        //objQwest34.QwestTree = new List<Qwest>();
        //Qwest objQwest35 = new Qwest();
        //objQwest35.Name = "Riding";
        //objQwest35.QwestTitle = "Ride for money";

        //objQwest35.Rewards = new UniversalReward();
        //objQwest35.Rewards.ExperienceReward = 2800;
        //objQwest35.Rewards.MoneyReward = 88;
        //objQwest35.Rewards.RewardInGems = true;
        //objQwest35.Rewards.ItemRewardID = 0;
        //objQwest35.Rewards.RelationRewards = new FactionRelationReward[0];

        //objQwest35.ShowQwestCompletePanel = true;
        //objQwest35.TimerValue = 0;
        //objQwest35.RepeatableQuest = true;
        //objQwest35.MMMarkId = 8;

        //objQwest35.MarkForMiniMap = null;
        //objQwest35.AdditionalStartPointRadius = 0;
        //objQwest35.StartDialog = "{\"DialogName\":\"krekerrtek\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- And another one. Now, when it's all clear, the request is to drive my product to the good client. And that's all.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objQwest35.EndDialog = "{\"DialogName\":\"rrreew\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Carlos\",\"Replica\":\"- Thank you very much! See you later!\"},{\"Actor\":\"You\",\"Replica\":\"- Maybe!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";



        //tempV3 = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objQwest35.StartPosition = tempV3;
        //objQwest35.TasksList = new BaseTask[4];


        //StealAVehicleTask objBaseTask212 = new StealAVehicleTask();
        //objBaseTask212.SpecificVehicleName = VehicleList.None;
        //objBaseTask212.VehicleType = VehicleType.Car;
        //objBaseTask212.countVisualMarks = 2;
        //objBaseTask212.markVisualType = "Enter";

        //objBaseTask212.TaskText = "Get wheels";
        //objBaseTask212.AdditionalTimer = 0;
        //objBaseTask212.DialogData = "{\"DialogName\":\"12\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Get a car \"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask212.EndDialogData = "";


        //DriveToPointTask objBaseTask213 = new DriveToPointTask();
        //objBaseTask213.PointPosition = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objBaseTask213.SpecificVehicleName = VehicleList.None;
        //objBaseTask213.PointRadius = 3;
        //objBaseTask213.VehicleType = VehicleType.Car;

        //objBaseTask213.TaskText = "Drive to Carlos";
        //objBaseTask213.AdditionalTimer = 0;
        //objBaseTask213.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to Carlos to get the turkey bags.\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask213.EndDialogData = "";


        //DriveToPointTask objBaseTask214 = new DriveToPointTask();
        //objBaseTask214.PointPosition = new Vector3(543.6273f, 1.517853f, -383.8353f);
        //objBaseTask214.SpecificVehicleName = VehicleList.None;
        //objBaseTask214.PointRadius = 5;
        //objBaseTask214.VehicleType = VehicleType.Car;

        //objBaseTask214.TaskText = "Drive to the client";
        //objBaseTask214.AdditionalTimer = 0;
        //objBaseTask214.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to the client\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask214.EndDialogData = "{\"DialogName\":\"3246\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"Client\",\"Replica\":\"- Oh, thanks!\"},{\"Actor\":\"You\",\"Replica\":\"- You're welcome!\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";


        //DriveToPointTask objBaseTask215 = new DriveToPointTask();
        //objBaseTask215.PointPosition = new Vector3(392.2173f, 1.687866f, -854.8353f);
        //objBaseTask215.SpecificVehicleName = VehicleList.None;
        //objBaseTask215.PointRadius = 3;
        //objBaseTask215.VehicleType = VehicleType.Car;

        //objBaseTask215.TaskText = "Drive to Carlos";
        //objBaseTask215.AdditionalTimer = 0;
        //objBaseTask215.DialogData = "{\"DialogName\":\"12415\",\"SaveDialog\":false,\"Replics\":[{\"Actor\":\"--\",\"Replica\":\"Drive to Carlos to get reward\"}],\"$type\":\"Game.DialogSystem.Dialog\"}";
        //objBaseTask215.EndDialogData = "";
        //objBaseTask215.NextTask = null;


        //objBaseTask215.PrevTask = objBaseTask214;
        //objBaseTask214.NextTask = objBaseTask215;


        //objBaseTask214.PrevTask = objBaseTask213;
        //objBaseTask213.NextTask = objBaseTask214;


        //objBaseTask213.PrevTask = objBaseTask212;
        //objBaseTask212.NextTask = objBaseTask213;
        //objBaseTask212.PrevTask = null;
        //objQwest35.TasksList.SetValue(objBaseTask212, 0);


        //objQwest35.TasksList.SetValue(objBaseTask213, 1);


        //objQwest35.TasksList.SetValue(objBaseTask214, 2);


        //objQwest35.TasksList.SetValue(objBaseTask215, 3);

        //objQwest35.QwestTree = new List<Qwest>();

        //objQwest34.QwestTree.Add(objQwest35);

        //objQwest33.QwestTree.Add(objQwest34);

        //objQwest32.QwestTree.Add(objQwest33);

        //objQwest2.QwestTree.Add(objQwest32);

        objQwest1.QwestTree.Add(objQwest2);

        objQwest0.QwestTree.Add(objQwest1);


        objQwest0.ParentQwest = null;

        lstNewQwests.Add(objQwest0);




        //----------2-----------






        objQwest1.ParentQwest = objQwest0;

        lstNewQwests.Add(objQwest1);




        //----------3-----------






        objQwest2.ParentQwest = objQwest1;

        lstNewQwests.Add(objQwest2);




        //----------4-----------






        objQwest3.ParentQwest = objQwest2;

        lstNewQwests.Add(objQwest3);




        //----------5-----------






        objQwest4.ParentQwest = objQwest3;

        lstNewQwests.Add(objQwest4);




        //----------6-----------






        objQwest5.ParentQwest = objQwest4;

        lstNewQwests.Add(objQwest5);




        //----------7-----------






        objQwest6.ParentQwest = objQwest5;

        lstNewQwests.Add(objQwest6);




        //----------8-----------






        objQwest7.ParentQwest = objQwest6;

        lstNewQwests.Add(objQwest7);




        //----------9-----------






        objQwest8.ParentQwest = objQwest7;

        lstNewQwests.Add(objQwest8);




        //----------10-----------






        objQwest9.ParentQwest = objQwest8;

        lstNewQwests.Add(objQwest9);




        //----------11-----------






        objQwest10.ParentQwest = objQwest9;

        lstNewQwests.Add(objQwest10);




        //----------12-----------






        objQwest11.ParentQwest = objQwest10;

        lstNewQwests.Add(objQwest11);




        //----------13-----------






        objQwest12.ParentQwest = objQwest11;

        lstNewQwests.Add(objQwest12);




        //----------14-----------






        objQwest13.ParentQwest = objQwest12;

        lstNewQwests.Add(objQwest13);




        //----------15-----------






        objQwest14.ParentQwest = objQwest13;

        lstNewQwests.Add(objQwest14);




        //----------16-----------






        //objQwest15.ParentQwest = objQwest14;

        //lstNewQwests.Add(objQwest15);




        //----------17-----------






        //objQwest16.ParentQwest = objQwest15;

        //lstNewQwests.Add(objQwest16);




        //----------18-----------






        //objQwest17.ParentQwest = objQwest16;

        //lstNewQwests.Add(objQwest17);




        //----------19-----------






        //objQwest18.ParentQwest = objQwest13;

        //lstNewQwests.Add(objQwest18);




        ////----------20-----------






        //objQwest19.ParentQwest = objQwest18;

        //lstNewQwests.Add(objQwest19);




        ////----------21-----------






        //objQwest20.ParentQwest = objQwest19;

        //lstNewQwests.Add(objQwest20);




        ////----------22-----------






        //objQwest21.ParentQwest = objQwest20;

        //lstNewQwests.Add(objQwest21);




        ////----------23-----------






        //objQwest22.ParentQwest = objQwest3;

        //lstNewQwests.Add(objQwest22);




        ////----------24-----------






        //objQwest23.ParentQwest = objQwest2;

        //lstNewQwests.Add(objQwest23);




        ////----------25-----------






        //objQwest24.ParentQwest = objQwest23;

        //lstNewQwests.Add(objQwest24);




        ////----------26-----------






        //objQwest25.ParentQwest = objQwest24;

        //lstNewQwests.Add(objQwest25);




        ////----------27-----------






        //objQwest26.ParentQwest = objQwest25;

        //lstNewQwests.Add(objQwest26);




        ////----------28-----------






        //objQwest27.ParentQwest = objQwest26;

        //lstNewQwests.Add(objQwest27);




        ////----------29-----------






        //objQwest28.ParentQwest = objQwest26;

        //lstNewQwests.Add(objQwest28);




        ////----------30-----------






        //objQwest29.ParentQwest = objQwest28;

        //lstNewQwests.Add(objQwest29);




        ////----------31-----------






        //objQwest30.ParentQwest = objQwest29;

        //lstNewQwests.Add(objQwest30);




        ////----------32-----------






        //objQwest31.ParentQwest = objQwest30;

        //lstNewQwests.Add(objQwest31);




        ////----------33-----------






        //objQwest32.ParentQwest = objQwest2;

        //lstNewQwests.Add(objQwest32);




        ////----------34-----------






        //objQwest33.ParentQwest = objQwest32;

        //lstNewQwests.Add(objQwest33);




        ////----------35-----------






        //objQwest34.ParentQwest = objQwest33;

        //lstNewQwests.Add(objQwest34);




        ////----------36-----------






        //objQwest35.ParentQwest = objQwest34;

        //lstNewQwests.Add(objQwest35);





        return lstNewQwests;
    }
}
