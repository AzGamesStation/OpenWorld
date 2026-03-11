using UnityEngine;

public class MenuPanelManager : MonoBehaviour
{
    public Animator FirstOpen;

    private Animator _currentPanelAnimator;

    private const string AnimKey = "Open";
    public bool isShop = false;
    public void Start()
    {
        if ((bool)FirstOpen && _currentPanelAnimator == null)
        {
            OpenPanel(FirstOpen);
        }
        else
        {
            OpenPanel(_currentPanelAnimator);
        }
    }

    private void OnEnable()
    {
        
    }

    public void OpenPanel(Animator panelAnimator)
    {
        if (_currentPanelAnimator == panelAnimator)
        {
            return;
        }
        if (_currentPanelAnimator != null)
        {
            if (_currentPanelAnimator.isInitialized && _currentPanelAnimator.runtimeAnimatorController != null)
            {
                _currentPanelAnimator.SetBool("Open", value: false);
            }
            _currentPanelAnimator.gameObject.SetActive(value: false);
        }
        panelAnimator.gameObject.SetActive(value: true);
        if (panelAnimator.isInitialized && panelAnimator.runtimeAnimatorController != null)
        {
            panelAnimator.SetBool("Open", value: true);
        }
        _currentPanelAnimator = panelAnimator;
        AudioSource component = GetComponent<AudioSource>();
        if (component != null && component.isActiveAndEnabled)
        {
            component.Play();
        }
    }

    public void SwitchPanel(Animator switchPanel)
    {
        if (_currentPanelAnimator == switchPanel)
        {
            if (_currentPanelAnimator.isInitialized && _currentPanelAnimator.runtimeAnimatorController != null)
            {
                _currentPanelAnimator.SetBool("Open", value: false);
            }
            _currentPanelAnimator.gameObject.SetActive(value: false);
            FirstOpen.gameObject.SetActive(value: true);
            if (FirstOpen.isInitialized && FirstOpen.runtimeAnimatorController != null)
            {
                FirstOpen.SetBool("Open", value: false);
            }
            _currentPanelAnimator = FirstOpen;

        }
        else if (_currentPanelAnimator != switchPanel)
        {
            if (_currentPanelAnimator.isInitialized && _currentPanelAnimator.runtimeAnimatorController != null)
            {
                _currentPanelAnimator.SetBool("Open", value: false);
            }
            _currentPanelAnimator.gameObject.SetActive(value: false);
            if (switchPanel.isInitialized && switchPanel.runtimeAnimatorController != null)
            {
                switchPanel.SetBool("Open", value: false);
            }
            switchPanel.gameObject.SetActive(value: true);
            _currentPanelAnimator = switchPanel;
        }
        AudioSource component = GetComponent<AudioSource>();
        if (component != null && component.isActiveAndEnabled)
        {
            component.Play();
        }
    }

    public Animator GetCurrentPanel()
    {
        return _currentPanelAnimator;
    }

    public void ResetSaves()
    {
        BaseProfile.ClearBaseProfileWithoutSystemSettings();
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void PrivacyPolicy()
    {
        Application.OpenURL("https://ragegamestudio.blogspot.com/2021/08/rage-games-studio.html");
    }

    public void RemoveAds()
    {
        //MyIAPManager_IronBolt.Instance.RemoveAds();
    }

    public void FreeCashWatchVedio()
    {
        if (RewardedAdsController.Instance)
        {
            RewardedAdsController.Instance.ShowRewarded("FreeCash");
            GlobalContants.isWatchVideoMoney = true;
        }
    }

    public void FreeGemsWatchVedio()
    {
        if (RewardedAdsController.Instance)
        {
            RewardedAdsController.Instance.ShowRewarded("FreeGems");
            GlobalContants.freeGems = true;
        }
    }
}
