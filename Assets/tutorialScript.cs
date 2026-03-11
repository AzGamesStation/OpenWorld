using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public GameObject joystick;
    public GameObject dragPanel;
    public GameObject shopBtn;
    public GameObject shopBackBtn;
    public GameObject ropeBtn;
    public GameObject shootBtn;
    public GameObject netThrow, bubbleThrow, balloonThrow;
    public GameObject chooseWeaponBtn;
    public GameObject selectWeaponBtn;
    public GameObject buyWeaponBtn;
    public GameObject clickBulletBtn;
    public GameObject clickPistolBtn;
    public GameObject buyBulletBtn;
    public GameObject weaponSlot;
    public GameObject jumpBtn;
    public GameObject sprintBtn;
    public GameObject getInCarBtn, getOutCarBtn, superKickBtn, superSlapBn, flameBtn, laserBtn;
    public GameObject carControls;
    public GameObject police1, police2, police3,police4;
    public Transform activeControls, activeControlShop;
    public GameObject completeTutorialPanel;
    public GameObject carSpawner;
    public GameObject raceBtn, brakeBtn, turnLeftBtn, turnRightBtn;
    //public Transform inActiveControls,inActiveConrolShop;
    public Transform tempParent;
    private void Start()
    {
        UseJoyStick();
    }

    void UseJoyStick()
    {
        tempParent = joystick.transform.parent;
        joystick.transform.parent = activeControls;
    }

    public void OpenShop()
    {
        joystick.transform.parent = tempParent;
        joystick.transform.GetChild(2).gameObject.SetActive(false);
        joystick.GetComponent<Joystick>().enabled = false;
        tempParent = shopBtn.transform.parent;
        shopBtn.transform.parent = activeControls;
        shopBtn.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void ChoosePistol()
    {
        Time.timeScale = 1;
        shopBtn.transform.parent = tempParent;
        shopBtn.transform.GetChild(2).gameObject.SetActive(false);
        tempParent = chooseWeaponBtn.transform.parent;
        chooseWeaponBtn.transform.parent = activeControlShop;
    }

    public void BuyPistol()
    {
        chooseWeaponBtn.transform.parent = tempParent;
        chooseWeaponBtn.transform.GetChild(1).gameObject.SetActive(false);
        tempParent = buyWeaponBtn.transform.parent;
        buyWeaponBtn.transform.parent = activeControlShop;
        buyWeaponBtn.SetActive(true);
        buyWeaponBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ChooseWeaponSlot()
    {
        buyWeaponBtn.transform.parent = tempParent;
        buyWeaponBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = weaponSlot.transform.parent;
        weaponSlot.transform.parent = activeControlShop;
        weaponSlot.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ChooseBullets()
    {
        weaponSlot.transform.parent = tempParent;
        weaponSlot.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = clickBulletBtn.transform.parent;
        clickBulletBtn.transform.parent = activeControlShop;
        clickBulletBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void BuyBulletBtn()
    {
        clickBulletBtn.transform.parent = tempParent;
        clickBulletBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = buyBulletBtn.transform.parent;
        buyBulletBtn.transform.parent = activeControlShop;
        buyBulletBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShopBackBtn()
    {
        buyBulletBtn.transform.parent = tempParent;
        buyBulletBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = shopBackBtn.transform.parent;
        shopBackBtn.transform.parent = activeControlShop;
        shopBackBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ClickWeaponChooseBtn()
    {
        shopBackBtn.transform.parent = tempParent;
        shopBackBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = selectWeaponBtn.transform.parent;
        selectWeaponBtn.transform.parent = activeControls;
        selectWeaponBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ClickPistol()
    {
        Time.timeScale = 1;
        selectWeaponBtn.transform.parent = tempParent;
        selectWeaponBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = clickPistolBtn.transform.parent;
        clickPistolBtn.transform.parent = activeControls;
        clickPistolBtn.transform.GetChild(0).gameObject.SetActive(true);
        //police1.SetActive(true);
    }

    public void ClickShootBtn()
    {
        clickPistolBtn.transform.parent = tempParent;
        clickPistolBtn.transform.GetChild(0).gameObject.SetActive(false);
        police1.SetActive(true);
        tempParent = shootBtn.transform.parent;
        dragPanel.transform.parent = activeControls;
        dragPanel.transform.GetChild(0).gameObject.SetActive(true);
        shootBtn.transform.parent = activeControls;
        shootBtn.transform.GetChild(0).gameObject.SetActive(true);
        
    }

    public void WebThrow()
    {
        shootBtn.transform.parent = tempParent;
        shootBtn.transform.GetChild(0).gameObject.SetActive(false);
        shootBtn.GetComponent<LookControlsSwitcher>().enabled = false;
        police1.SetActive(false);
        tempParent = netThrow.transform.parent;
        netThrow.transform.parent = activeControls;
        netThrow.transform.GetChild(0).gameObject.SetActive(true);
        police2.SetActive(true);
    }

    public void BalloonThrow()
    {
        netThrow.transform.parent = tempParent;
        netThrow.transform.GetChild(0).gameObject.SetActive(false);
        police2.SetActive(false);
        tempParent = balloonThrow.transform.parent;
        balloonThrow.transform.parent = activeControls;
        balloonThrow.transform.GetChild(0).gameObject.SetActive(true);
        police3.SetActive(true);
    }

    public void BubbleThrow()
    {
        balloonThrow.transform.parent = tempParent;
        balloonThrow.transform.GetChild(0).gameObject.SetActive(false);
        police3.SetActive(false);
        tempParent = bubbleThrow.transform.parent;
        bubbleThrow.transform.parent = activeControls;
        bubbleThrow.transform.GetChild(0).gameObject.SetActive(true);
        police4.SetActive(true);
    }

    public void SpawnCar()
    {
        bubbleThrow.transform.parent = tempParent;
        bubbleThrow.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = joystick.transform.parent;
        carSpawner.SetActive(true);
        joystick.GetComponent<Joystick>().enabled = true;
        joystick.transform.parent = activeControls;
        joystick.transform.GetChild(2).gameObject.SetActive(true);
        joystick.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Go near to car";
    }

    public void SitInCar()
    {
        joystick.transform.parent = tempParent;
        joystick.transform.GetChild(2).gameObject.SetActive(false);
        tempParent = getInCarBtn.transform.parent;
        getInCarBtn.transform.parent = activeControls;
        getInCarBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DriveTheCar()
    {
        dragPanel.transform.parent = tempParent;
        getInCarBtn.transform.parent = tempParent;
        getInCarBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = carControls.transform.parent;
        carControls.transform.parent = activeControls;
        carControls.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine("WaitForRide");
    }

    public void PressRaceBtn()
    {
        dragPanel.transform.parent = tempParent;
        getInCarBtn.transform.parent = tempParent;
        getInCarBtn.transform.GetChild(0).gameObject.SetActive(false);
        Invoke("RaceBtn", 3f);
       
    }

    void RaceBtn()
    {
        tempParent = raceBtn.transform.parent;
        raceBtn.transform.parent = activeControls;
        raceBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PressBrakeBtn()
    {
        turnRightBtn.transform.parent = tempParent;
        turnRightBtn.transform.GetChild(0).gameObject.SetActive(false);

        tempParent = brakeBtn.transform.parent;
        brakeBtn.transform.parent = activeControls;
        brakeBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PressLeftBtn()
    {
        raceBtn.transform.parent = tempParent;
        raceBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = turnLeftBtn.transform.parent;
        turnLeftBtn.transform.parent = activeControls;
        turnLeftBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PressRightBtn()
    {
        turnLeftBtn.transform.parent = tempParent;
        turnLeftBtn.transform.GetChild(0).gameObject.SetActive(false);
        tempParent = turnRightBtn.transform.parent;
        turnRightBtn.transform.parent = activeControls;
        turnRightBtn.transform.GetChild(0).gameObject.SetActive(true);
        
    }

    public void PressCarOutBtn()
    {
        StartCoroutine("WaitForRide");
    }

    public IEnumerator WaitForRide()
    {
        brakeBtn.transform.parent = tempParent;
        brakeBtn.transform.GetChild(0).gameObject.SetActive(false);
       
        yield return new WaitForSeconds(0.1f);
        getOutCarBtn.SetActive(true);
        getOutCarBtn.transform.parent = activeControls;
        getOutCarBtn.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShowPanel()
    {
        StartCoroutine("ShowCompletePanel");
    }

    IEnumerator ShowCompletePanel()
    {
        yield return new WaitForSeconds(2f);
        completeTutorialPanel.SetActive(true);
    }
}