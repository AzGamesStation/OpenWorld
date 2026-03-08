using UnityEngine;
using System.Collections;
using System;

public enum  ItemType {
	Gold,Cash,UnlockAll,UnlockAllMission,RemoveAds,Garnade,HealthKit,Skins, GemsPack1, GemsPack2, GemsPack3, GemsPack4
}
[System.Serializable]
public class PurchaseID_Controller_Ironbolt
{
	//public UnityEngine.Purchasing.ProductType purchaseableType= UnityEngine.Purchasing.ProductType.Consumable;
	public string purchaseID="";
	public ItemType itemType;


}
