using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickReward : MonoBehaviour
{
    public Sprite cashIcon, gemIcon, healthIcon;
    public Text description;
    public Image icon;

    public void CashReward()
    {
        description.text = "YOU GOT <color=Orange>500</color> Cash";
        icon.sprite = cashIcon;
    }

    public void GemsReward()
    {
        description.text = "YOU GOT <color=Orange>50</color> Gems";
        icon.sprite = gemIcon;
    }
}