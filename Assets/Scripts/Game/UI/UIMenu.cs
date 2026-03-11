using UnityEngine;

namespace Game.UI
{
	public class UIMenu : MonoBehaviour
	{
		public MenuPanelManager PanelManager;

		public LoadSceneController SceneController;

		public ItemPickReward itemPickUpPanel;

		public Animator LoadingPanel;

		public GameObject Background1;

		public static UIMenu instance;
		private void Awake()
		{
            if (!instance)
            {
				instance = this;

			}
		}

        private void Start()
        {
            Invoke("ShowBanner", 2f);
        }

        void ShowBanner()
        {
			//AdsManager.instance.ShowMaxBanner();
		}

        public void StartNewGame()
		{
			UniversalYesNoPanel.Instance.DisplayOffer("START A NEW GAME?", "All progress will be lost.", delegate
			{
				
				PanelManager.ResetSaves();
				PanelManager.OpenPanel(LoadingPanel);
				SceneController.Load();
				if(Background1)
				Background1.SetActive(value: false);
				//AdsManager.instance.ShowInterstitial("StartNewGame");
			});
		}

		public void CloseApplication()
		{
			UniversalYesNoPanel.Instance.DisplayOffer("EXIT GAME", "Are you sure?", delegate
			{
				PanelManager.ExitApplication();
			});
		}

        public void MoreGames()
        {
            //Application.OpenURL("https://play.google.com/store/apps/dev?id=8002703324518409296");
			Application.OpenURL("https://play.google.com/store/apps/dev?id=5704972546024171699");
        }
        public void Rateus()
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
        }

		public void UnlockEverything()
		{
			//MyIAPManager_IronBolt.Instance.UnlockEverything();
		}

		public void ShowDebugger()
        {
		//	MaxSdk.ShowMediationDebugger();
        }
    }
}
