using UnityEngine;
using System.Collections;
using Game.Character;
using Game.GlobalComponent;
using System.Collections.Generic;
using Game.Shop;
using Game.Character.CharacterController;

public class Data_Ironbolt : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SetPrefs();
    }
    public static void CoinsAddition(int coins)
    {
        //GameObject.Find ("Canvas").GetComponent<ShowAds>().EnableRewarded();
    }
    public static void GoldAddition(int coins)
    {
    }

    void SetPrefs()
    {
        GlobalContants.gemsCounterpack1 = PlayerPrefs.GetInt("pack1Ad");
        GlobalContants.gemsCounterpack2 = PlayerPrefs.GetInt("pack2Ad");
        GlobalContants.gemsCounterpack3 = PlayerPrefs.GetInt("pack3Ad");
        GlobalContants.gemsCounterpack4 = PlayerPrefs.GetInt("pack4Ad");
        GlobalContants.WebThrowCount = PlayerPrefs.GetInt("WebThrow", 2);
        GlobalContants.bubbleThrowCount = PlayerPrefs.GetInt("bubbleThrow", 2);
        GlobalContants.balloonThrowCount = PlayerPrefs.GetInt("balloonThrow", 2);
        //PlayerPrefs.SetInt("pack1Ad", GlobalContants.adCounterpack1);
        //PlayerPrefs.SetInt("pack2Ad", GlobalContants.adCounterpack2);
        //PlayerPrefs.SetInt("pack3Ad", GlobalContants.adCounterpack3);
        //PlayerPrefs.SetInt("pack4Ad", GlobalContants.adCounterpack4);

    }
    public static void UnlockAllPurchased()
    {

        RemoveAdsPurchased();
        Debug.Log("Unlock All Purchased");
    }
    public static void RemoveAdsPurchased()
    {
        PlayerPrefs.SetInt("RemoveAds", 1);
        PlayerPrefs.Save();
        // AdsManager.instance.HideBanner();
        ADsShower.HideAdmobBanner();
    }
    public static void RewardedAdWatched()
    {

        if (GlobalContants.isWatchVideoMoney)
        {
            GlobalContants.isWatchVideoMoney = false;
            int AddedMoney;
            PlayerInfoManager.Money += 500;
            AddedMoney = PlayerInfoManager.Money;
            PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
            Game.UI.UIMenu.instance.itemPickUpPanel.gameObject.SetActive(true);
            Game.UI.UIMenu.instance.itemPickUpPanel.CashReward();
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, AddedMoney.ToString());
        }

        if (GlobalContants.freeGems)
        {
            GlobalContants.freeGems = false;
            int gems;
            PlayerInfoManager.Gems += 50;
            gems = PlayerInfoManager.Gems;
            PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
            Game.UI.UIMenu.instance.itemPickUpPanel.gameObject.SetActive(true);
            Game.UI.UIMenu.instance.itemPickUpPanel.GemsReward();
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
        }

        if (GlobalContants.IsRevived)
        {
            Time.timeScale = 1;
            GlobalContants.IsRevived = false;
            PlayerManager.Instance.Player.Health.Setup(1000, 1000);
            PlayerManager.Instance.Player.Resurrect();
            PlayerDieManager.Instance.Links.revivePanel.SetActive(false);
        }

        if (GlobalContants.WebWatched)
        {
            GlobalContants.WebWatched = false;
            GlobalContants.WebThrowCount += 2;
            PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
        }

        if (GlobalContants.BubbleWatched)
        {
            GlobalContants.BubbleWatched = false;
            GlobalContants.bubbleThrowCount += 2;
            PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
        }

        if (GlobalContants.BallonWatched)
        {
            GlobalContants.BallonWatched = false;
            GlobalContants.balloonThrowCount += 2;
            PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
        }

        if (GlobalContants.FireWatched)
        {
            GlobalContants.FireWatched = false;
            GlobalContants.fireThrowCount += 1;
            PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
        }
        if (GlobalContants.LaserWatched)
        {
            GlobalContants.LaserWatched = false;
            GlobalContants.laserCount += 1;
            PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
        }
        if (GlobalContants.PropsWatched)
        {
            GlobalContants.PropsWatched = false;
            CharacterPropsController.instance.PropHandles(true);
        }

        if (GlobalContants.spinWheel)
        {
            GlobalContants.spinWheel = false;
            FortuneWheel.Instance.AddSpin();
            FortuneWheel.Instance.onClickSpinNow();
        }

        if (GlobalContants.spinDoubleReward)
        {
            GlobalContants.spinDoubleReward = false;
            FortuneWheel.Instance.GiveDoubleReward();
        }

        if (GlobalContants.shopItem)
        {
            GlobalContants.shopItem = false;
            Game.Shop.ShopManager.Instance.Give();
        }

        if (GlobalContants.refillStamina)
        {
            GlobalContants.refillStamina = false;
            Game.Character.PlayerInteractionsManager.Instance.Player.stats.stamina.Setup();
        }

        if (GlobalContants.gemsPack1)
        {
            GlobalContants.gemsPack1 = false;
            GlobalContants.gemsCounterpack1++;

            FindObjectOfType<BuyGems>().UpdateGemsCounterText(GlobalContants.gemsCounterpack1, 2);
            if (GlobalContants.gemsCounterpack1 >= 2)
            {
                int gems;
                PlayerInfoManager.Gems += 100;
                gems = PlayerInfoManager.Gems;
                PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
                GlobalContants.gemsCounterpack1 = 0;
            }
            PlayerPrefs.SetInt("pack1Ad", GlobalContants.gemsCounterpack1);

        }
        if (GlobalContants.gemsPack2)
        {
            GlobalContants.gemsPack2 = false;
            GlobalContants.gemsCounterpack2++;

            FindObjectOfType<BuyGems>().
                UpdateGemsCounterText(
                GlobalContants.gemsCounterpack2,
                3);
            if (GlobalContants.gemsCounterpack2 >= 3)
            {
                int gems;
                PlayerInfoManager.Gems += 200;
                gems = PlayerInfoManager.Gems;
                PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
                GlobalContants.gemsCounterpack2 = 0;
            }
            PlayerPrefs.SetInt("pack2Ad", GlobalContants.gemsCounterpack2);

        }

        if (GlobalContants.gemsPack3)
        {
            GlobalContants.gemsPack3 = false;
            GlobalContants.gemsCounterpack3++;

            FindObjectOfType<BuyGems>().UpdateGemsCounterText(GlobalContants.gemsCounterpack3, 4);
            if (GlobalContants.gemsCounterpack3 >= 4)
            {
                int gems;
                PlayerInfoManager.Gems += 500;
                gems = PlayerInfoManager.Gems;
                PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
                GlobalContants.gemsCounterpack3 = 0;
            }
            PlayerPrefs.SetInt("pack3Ad", GlobalContants.gemsCounterpack3);


        }
        if (GlobalContants.gemsPack4)
        {
            GlobalContants.gemsPack4 = false;
            GlobalContants.gemsCounterpack4++;

            FindObjectOfType<BuyGems>().UpdateGemsCounterText(GlobalContants.gemsCounterpack4, 5);

            if (GlobalContants.gemsCounterpack4 >= 5)
            {
                int gems;
                PlayerInfoManager.Gems += 1000;
                gems = PlayerInfoManager.Gems;
                PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
                GlobalContants.gemsCounterpack4 = 0;
            }
            PlayerPrefs.SetInt("pack4Ad", GlobalContants.gemsCounterpack4);
        }

        if (GlobalContants.gemsPack5)
        {
            int money;
            GlobalContants.gemsPack5 = false;
            PlayerInfoManager.Money += 1000;
            money = PlayerInfoManager.Money;
            //DailyBonusesManager.Instance.cashCollectPanel.SetActive(true);
            Game.Shop.ShopManager.Instance.Links.cashCollectPanel.SetActive(true);
            PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, money.ToString());
        }

        if (GlobalContants.cashPack1)
        {
            GlobalContants.cashPack1 = false;
            GlobalContants.cashCounterpack1++;
            FindObjectOfType<BuyGems>().UpdateCashCounterText(GlobalContants.cashCounterpack1, 2);
            if (GlobalContants.cashCounterpack1 >= 2)
            {
                int money;
                PlayerInfoManager.Money += 1000;
                money = PlayerInfoManager.Money;
                PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, money.ToString());
                GlobalContants.cashCounterpack1 = 0;
                PlayerPrefs.SetInt("cashPack1Ad", 0);
                FindObjectOfType<BuyGems>().UpdateCashCounterText(GlobalContants.cashCounterpack1, 2);
            }
            PlayerPrefs.SetInt("cashPack1Ad", GlobalContants.cashCounterpack1);
        }
        if (GlobalContants.cashPack2)
        {
            GlobalContants.cashPack2 = false;
            GlobalContants.cashCounterpack2++;

            FindObjectOfType<BuyGems>().UpdateCashCounterText(GlobalContants.cashCounterpack2, 3);
            if (GlobalContants.cashCounterpack2 >= 3)
            {
                int money;
                PlayerInfoManager.Money += 5000;
                money = PlayerInfoManager.Money;
                PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, money.ToString());
                GlobalContants.cashCounterpack2 = 0;
            }
            PlayerPrefs.SetInt("cashPack2Ad", GlobalContants.cashCounterpack2);

        }

        if (GlobalContants.cashPack3)
        {
            GlobalContants.cashPack3 = false;
            GlobalContants.cashCounterpack3++;

            FindObjectOfType<BuyGems>().UpdateCashCounterText(GlobalContants.cashCounterpack3, 4);
            if (GlobalContants.cashCounterpack3 >= 4)
            {
                int money;
                PlayerInfoManager.Money += 10000;
                money = PlayerInfoManager.Money;
                PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, money.ToString());
                GlobalContants.cashCounterpack3 = 0;
            }
            PlayerPrefs.SetInt("cashPack3Ad", GlobalContants.cashCounterpack3);
        }

        if (GlobalContants.cashPack4)
        {
            GlobalContants.cashPack4 = false;
            GlobalContants.cashCounterpack4++;

            FindObjectOfType<BuyGems>().UpdateCashCounterText(GlobalContants.cashCounterpack4, 5);

            if (GlobalContants.cashCounterpack4 >= 5)
            {
                int money;
                PlayerInfoManager.Money += 20000;
                money = PlayerInfoManager.Money;
                PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
                //if (InGameLogManager.Instance)
                //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, money.ToString());
                GlobalContants.cashCounterpack4 = 0;
            }
            PlayerPrefs.SetInt("cashPack4Ad", GlobalContants.cashCounterpack4);
        }

        if (GlobalContants.gemsPickUp)
        {
            int gems;
            PlayerInfoManager.Gems += 10;
            gems = PlayerInfoManager.Gems;
            PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
            //InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
            Game.UI.UIGame.Instance.itemPickPanel.gameObject.SetActive(true);
            Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(false);
            Game.UI.UIGame.Instance.itemPickPanel.GemsReward();
            GlobalContants.gemsPickUp = false;
            GlobalContants.loadingRewardedAd = false;
        }

        if (GlobalContants.cashPickUp)
        {
            int money;
            PlayerInfoManager.Money += 100;
            money = PlayerInfoManager.Money;
            PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
            Game.UI.UIGame.Instance.itemPickPanel.gameObject.SetActive(true);
            Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(false);
            Game.UI.UIGame.Instance.itemPickPanel.CashReward();
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Money, money.ToString());
            GlobalContants.cashPickUp = false;
            GlobalContants.loadingRewardedAd = false;
        }
        if (GlobalContants.getBullets)
        {
            GlobalContants.getBullets = false;
            AmmoManager.Instance.AddAmmo(Game.Weapons.AmmoTypes.mm9);
            Game.UI.UIGame.Instance.noBulletsPanel.SetActive(false);
        }

        if (GlobalContants.wingsPickUp)
        {
            GlobalContants.wingsPickUp = false;
            GlobalContants.isWingsOn = true;
            Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(false);
            Game.UI.UIGame.Instance.flyBtn.SetDownState("Fly");
            Game.UI.UIGame.Instance.StartCoroutine("CheckForFlying");
            Game.UI.UIGame.Instance.itemParent.SetActive(false);
        }

        if (GlobalContants.tryVehicle)
        {
            GlobalContants.tryVehicle = false;
            PlayerInteractionsManager.Instance.LastDrivableVehicle.tag = "Untagged";
            PlayerInteractionsManager.Instance.GetIntoVehicle();

        }

        if (GlobalContants.boosterWeapon == 0)
        {
            Game.UI.UIGame.Instance.boosterPackage.Card1();
        }

        if (GlobalContants.boosterWeapon == 1)
        {
            Game.UI.UIGame.Instance.boosterPackage.Card2();
        }

        if (GlobalContants.boosterWeapon == 2)
        {
            Game.UI.UIGame.Instance.boosterPackage.Card3();
        }
    }

    public static void PurchasedGems()
    {
        if (GlobalContants.gemsPack1)
        {
            GlobalContants.gemsPack1 = false;
            int gems;
            PlayerInfoManager.Gems += 500;
            gems = PlayerInfoManager.Gems;
            PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
        }

        if (GlobalContants.gemsPack2)
        {
            GlobalContants.gemsPack2 = false;
            int gems;
            PlayerInfoManager.Gems += 1000;
            gems = PlayerInfoManager.Gems;
            PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
        }

        if (GlobalContants.gemsPack3)
        {
            GlobalContants.gemsPack3 = false;
            int gems;
            PlayerInfoManager.Gems += 5000;
            gems = PlayerInfoManager.Gems;
            PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
        }

        if (GlobalContants.gemsPack4)
        {
            GlobalContants.gemsPack4 = false;
            int gems;
            PlayerInfoManager.Gems += 10000;
            gems = PlayerInfoManager.Gems;
            PlayerPrefs.SetInt("Gems", PlayerInfoManager.Gems);
            //if (InGameLogManager.Instance)
            //    InGameLogManager.Instance.RegisterNewMessage(MessageType.Gems, gems.ToString());
        }
    }

    public static void UnlockEverything()
    {
        Debug.Log("Purchases Done");
        PlayerPrefs.SetString("UnlockEveryThing", "true");
        if (ShopManager.Instance)
        {
            ShopManager.Instance.UnlockEverthing();
        }
        RemoveAdsPurchased();
    }

    public static void SendScreenName(string currentScene)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("Screen", currentScene);

    }

    public static void SendMissionComplete(int Level)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("Mission ", Level);
    }

    public static void SendGameOver(int Level)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("GameOver ", Level);
    }

    public static void SendDeathReason(SuicideAchievment.DethType type)
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("Reason", type);
    }

}
