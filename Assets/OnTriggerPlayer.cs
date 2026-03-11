using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnTriggerPlayer : MonoBehaviour
{
    public bool isCash, isGems, isHealth, isWings;
    bool isWingsOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("GlobalContants.isWingsOn"+ GlobalContants.isWingsOn);
            GlobalContants.loadingRewardedAd = true;
            if (isCash && GlobalContants.isWingsOn == false)
            {
                Time.timeScale = 0;
                Game.UI.UIGame.Instance.pickUpPanel.isCash = true;
                GlobalContants.cashPickUp = true;
                Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(true);
            }

            if (isGems && GlobalContants.isWingsOn == false)
            {
                Time.timeScale = 0;
                Game.UI.UIGame.Instance.pickUpPanel.isDiamond = true;
                GlobalContants.gemsPickUp = true;
                Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(true);
            }

            if (isWings && GlobalContants.isWingsOn == false && other.GetComponent<Animator>().GetBool("IsSkateBoard") == false)
            {
                Time.timeScale = 0;
                Game.UI.UIGame.Instance.pickUpPanel.isWings = true;
                GlobalContants.wingsPickUp = true;
                Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalContants.loadingRewardedAd = false;
            if (isCash)
            {
                Game.UI.UIGame.Instance.pickUpPanel.isCash = false;
                GlobalContants.cashPickUp = false;
            }

            if (isGems)
            {
                Game.UI.UIGame.Instance.pickUpPanel.isDiamond = false;
                GlobalContants.gemsPickUp = false;
            }
            if (isWings)
            {
                Game.UI.UIGame.Instance.pickUpPanel.isWings = false;
                GlobalContants.wingsPickUp = false;
            }
            Game.UI.UIGame.Instance.pickUpPanel.gameObject.SetActive(false);
        }
    }
}