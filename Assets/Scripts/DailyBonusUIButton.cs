using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;
public class DailyBonusUIButton : MonoBehaviour
{
    public int BonusID;

    public Image Image;

    [SerializeField]
    private Image m_Checkmark;

    public void BonusViewState(bool gained)
    {
        if (m_Checkmark != null)
        {
            m_Checkmark.enabled = gained;
        }
    }

    public void OnClick()
    {
        DailyBonusesManager.Instance.SelectBonusUIButton(this);
    }
}
