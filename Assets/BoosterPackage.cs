using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.PickUps;

public class BoosterPackage : MonoBehaviour
{
    public WeaponPickup[] items;
    public Sprite[] weaponImgs;
    public Image[] weaponBtns;
    public GameObject adscaller;
    WeaponPickup card1Weapon,card2Weapon,card3Weapon;
    int randomNumber;

    

    private void OnEnable()
    {
        randomNumber = Random.Range(0, 22);
        weaponBtns[0].sprite = weaponImgs[randomNumber];
        card1Weapon = items[randomNumber];
        randomNumber = Random.Range(0, 22);
        weaponBtns[1].sprite = weaponImgs[randomNumber];
        card2Weapon = items[randomNumber];
        //randomNumber = Random.Range(0, 22);
        //weaponBtns[2].sprite = weaponImgs[randomNumber];
        //card3Weapon = items[randomNumber];
    }

    public void NoThanksBtn()
    {
        //if (GlobalContants.Ad_time <= 0)
        //    AdsManager.instance.ShowInterstitial("Booster");
        this.gameObject.SetActive(false);
        adscaller.SetActive(false);

    }

    public void WatchVideo(int cardNum)
    {
        GlobalContants.boosterWeapon = cardNum;

        RewardedAdsController.Instance.ShowRewarded("Booster");
    }

    public void Card1()
    {
        GlobalContants.giveBoosterWeapon = true;
            card1Weapon.GivePickup();
    }

    public void Card2()
    {
        GlobalContants.giveBoosterWeapon = true;
        card2Weapon.GivePickup();
    }
    
    public void Card3()
    {
        GlobalContants.giveBoosterWeapon = true;
        card3Weapon.GivePickup();
    }
}
