
using UnityEngine;
using UnityEngine.UI;
using Game.Character;

public class BuyGems : MonoBehaviour
{
    public GameObject outOfCashPanel;

    public Text _gemsAdForPack1, _gemsAdForPack2, _gemsAdForPack3, _gemsAdForPack4, _gemsAdForPack5;
    public Text _cashAdForPack1, _cashAdForPack2, _cashAdForPack3, _cashAdForPack4, _cashAdForPack5;
    public int[] packAmounts;

    private void OnEnable()
    {
        PlayerPrefs.GetInt("pack1Ad");
        PlayerPrefs.GetInt("pack2Ad");
        PlayerPrefs.GetInt("pack3Ad");
        PlayerPrefs.GetInt("pack4Ad");
        UpdateGemsCounterText(PlayerPrefs.GetInt("pack1Ad"), 2);
        UpdateGemsCounterText(PlayerPrefs.GetInt("pack2Ad"), 3);
        UpdateGemsCounterText(PlayerPrefs.GetInt("pack3Ad"), 4);
        UpdateGemsCounterText(PlayerPrefs.GetInt("pack4Ad"), 5);
        PlayerPrefs.GetInt("cashPack1Ad");
        PlayerPrefs.GetInt("cashPack2Ad");
        PlayerPrefs.GetInt("cashPack3Ad");
        PlayerPrefs.GetInt("cashPack4Ad");
        UpdateCashCounterText(PlayerPrefs.GetInt("cashPack1Ad"), 2);
        UpdateCashCounterText(PlayerPrefs.GetInt("cashPack2Ad"), 3);
        UpdateCashCounterText(PlayerPrefs.GetInt("cashPack3Ad"), 4);
        UpdateCashCounterText(PlayerPrefs.GetInt("cashPack4Ad"), 5);
    }

    public void UpdateGemsCounterText(int _counter, int _totalAd)
    {
        switch (_totalAd)  // Switch Start on the bases of total Ads
        {
            case 1:
                _gemsAdForPack1.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 2:
                _gemsAdForPack2.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 3:
                _gemsAdForPack3.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 4:
                _gemsAdForPack4.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 5:
                _gemsAdForPack5.text = (_counter + " /" + _totalAd).ToString();
                break;
        }
    }

    public void UpdateCashCounterText(int _counter, int _totalAd)
    {
        print("Counter ===" + _counter);
        switch (_totalAd)  // Switch Start on the bases of total Ads
        {
            case 1:
                _cashAdForPack1.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 2:
                _cashAdForPack2.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 3:
                _cashAdForPack3.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 4:
                _cashAdForPack4.text = (_counter + " /" + _totalAd).ToString();
                break;
            case 5:
                _cashAdForPack5.text = (_counter + " /" + _totalAd).ToString();
                break;
        }
    }

    public void GemsBuy(int pack)
    {
        switch (pack)
        {
            case 1:
                if (PlayerInfoManager.Money >= packAmounts[0])
                {
                    GlobalContants.gemsPack1 = true;
                    PurchasedOnCash(packAmounts[0]);
                    Data_Ironbolt.PurchasedGems();
                }
                else
                {
                    outOfCashPanel.SetActive(true);
                }
                break;

            case 2:
                if (PlayerInfoManager.Money >= packAmounts[1])
                {
                    GlobalContants.gemsPack2 = true;
                    PurchasedOnCash(packAmounts[1]);
                    Data_Ironbolt.PurchasedGems();
                }
                else
                {
                    outOfCashPanel.SetActive(true);
                }
                break;

            case 3:
                if (PlayerInfoManager.Money >= packAmounts[2])
                {
                    GlobalContants.gemsPack3 = true;
                    PurchasedOnCash(packAmounts[2]);
                    Data_Ironbolt.PurchasedGems();
                }
                else
                {
                    outOfCashPanel.SetActive(true);
                }
                break;

            case 4:
                if (PlayerInfoManager.Money >= packAmounts[3])
                {
                    GlobalContants.gemsPack4 = true;
                    PurchasedOnCash(packAmounts[3]);
                    Data_Ironbolt.PurchasedGems();
                }
                else
                {
                    outOfCashPanel.SetActive(true);
                }
                break;
        }
    }

    public void PurchasedOnCash(int _packAmount)
    {
        PlayerInfoManager.Money -= _packAmount;
        PlayerInfoManager.Instance.AddSpendMoney(-_packAmount);
        PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
    }

    public void GemsRewardedVideo(int pack)
    {
        if (RewardedAdsController.Instance)
        {
            switch (pack)
            {
                case 0:
                    GlobalContants.freeGems = true;
                    break;
                case 1:
                    GlobalContants.gemsPack1 = true;
                    break;
                case 2:
                    GlobalContants.gemsPack2 = true;
                    break;
                case 3:
                    GlobalContants.gemsPack3 = true;
                    break;
                case 4:
                    GlobalContants.gemsPack4 = true;
                    break;
            }
            RewardedAdsController.Instance.ShowRewarded("GemsPack");
        }
    }

    public void CashRewardedVideo(int pack)
    {
        if (RewardedAdsController.Instance)
        {
            switch (pack)
            {
                case 0:
                    GlobalContants.freeGems = true;
                    break;

                case 1:
                    GlobalContants.cashPack1 = true;

                    break;
                case 2:
                    GlobalContants.cashPack2 = true;

                    break;
                case 3:
                    GlobalContants.cashPack3 = true;

                    break;
                case 4:
                    GlobalContants.cashPack4 = true;

                    break;

            }
            RewardedAdsController.Instance.ShowRewarded("GemsPack");
        }
    }
}