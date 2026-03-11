using Game.GlobalComponent;
using UnityEngine;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static bool ShowDebugs;

        public bool IsTransformersGame;

        public ControlsType[] TransformationTypes;

        private static GameManager instance;

        public LineRenderer line;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = UnityEngine.Object.FindObjectOfType<GameManager>();
                }
                return instance;
            }
        }
        private void Start()
        {
            QualitySettings.vSyncCount = 0;
        }
        private void OnDisable()
        {
            //AdsManager.instance.HideBanner();
            //ADsShower.HideBanner();

        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                //Application.targetFrameRate = 60;
            }
            //AdsManager.instance.ShowMaxBanner();//comment
        }
        public float AdTime;
        private void Update()
        {
            AdTime = GlobalContants.Ad_time;
            if (GlobalContants.Ad_time > 0)
                GlobalContants.Ad_time -= Time.deltaTime * 1;
        }
    }
}
