using Game.Character.CharacterController;
using Game.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Character
{

    public class PlayerInfoManager : MonoBehaviour
    {
        public bool IsFirstTime = false;
        private void Start()
        {
            Money = PlayerPrefs.GetInt("Money", 0);
            //Gems = 100;

            //Money = 5000000;
            Level = 1;
            //Experience = 10000;

            if (IsFirstTime)
            {
                //PlayerPrefs.DeleteAll();
            }
        }
        public class InfoItem
        {
            private readonly int minValue;

            private readonly int maxValue;

            private readonly float vipMultipler;

            private readonly int changeToSave;

            private int currentValue;

            private int lastSavedValue;

            private int lastValueChange;

            public int Value
            {
                get
                {
                    return currentValue;
                }
                set
                {
                    ChangeCurrentValue(value - currentValue);
                }
            }

            public InfoItem()
            {
                currentValue = 0;
                minValue = 0;
                maxValue = 1000000;
                vipMultipler = 1f;
                changeToSave = 1;
                lastSavedValue = currentValue;
            }

            public InfoItem(InfoItem other)
            {
                currentValue = other.currentValue;
                minValue = other.minValue;
                maxValue = other.maxValue;
                vipMultipler = other.vipMultipler;
                changeToSave = other.changeToSave;
                lastSavedValue = currentValue;
            }

            public InfoItem(int startValue, int minValue, int maxValue, float vipMultipler, int changeToSave)
            {
                currentValue = startValue;
                this.minValue = minValue;
                this.maxValue = maxValue;
                this.vipMultipler = vipMultipler;
                this.changeToSave = changeToSave;
                lastSavedValue = currentValue;
            }

            public void ChangeCurrentValue(int amount, bool useVipMultipler = false)
            {
                if (useVipMultipler)
                {
                    amount = (int)((float)amount + vipMultipler * (float)VipLevel * (float)amount / 100f);
                }
                currentValue += amount;
                lastValueChange = amount;
                currentValue = Mathf.Clamp(Value, minValue, maxValue);
            }

            public float GetVipMult()
            {
                return vipMultipler;
            }

            public int GetMaxValue()
            {
                return maxValue;
            }

            public bool AvaibleToSave()
            {
                return currentValue - lastSavedValue >= changeToSave;
            }

            public void OnValueSave()
            {
                lastSavedValue = currentValue;
            }

            public int GetLastValueChange()
            {
                return lastValueChange;
            }
        }

        public delegate void OnInfoValueChanged(int newValue);

        private static readonly Dictionary<PlayerInfoType, InfoItem> ItemDefaultValues = new Dictionary<PlayerInfoType, InfoItem>
        {
            {
                PlayerInfoType.VipLvL,
                new InfoItem(0, 0, 10, 1f, 1)
            },
            {
                PlayerInfoType.LvL,
                new InfoItem(1, 1, 50, 1f, 1)
            },
            {
                PlayerInfoType.Money,
                new InfoItem(0, 0, 2147000000, 10f, 1000)
            },
            {
                PlayerInfoType.Experience,
                new InfoItem(0, 0, 1000000, 20f, 1000)
            },
            {
                PlayerInfoType.TotalSpentMoney,
                new InfoItem(0, -1000000, 1000000, 0f, 1000)
            }
        };

        private static readonly List<PlayerInfoType> NotClearedInfo = new List<PlayerInfoType>
        {
            PlayerInfoType.AllReceivedGems,
            PlayerInfoType.TotalReceivedMoney,
            PlayerInfoType.TotalSpentMoney,
            PlayerInfoType.TotalTimeInGame
        };

        private const int UniversalMaxValue = 1000000;

        private const int MoneyMaxValue = 2147000000;

        private const int VipLvLmaxValue = 10;

        private const int LevelMaxValue = 50;

        private const string SavedInfoSubstring = "PlayerInfo";

        private const int MoneyVipMultipler = 10;

        private const int ExpVipMultipler = 20;

        public static PlayerInfoManager Instance;

        public readonly Dictionary<PlayerInfoType, InfoItem> InfoItems = new Dictionary<PlayerInfoType, InfoItem>();

        private readonly Dictionary<PlayerInfoType, List<OnInfoValueChanged>> infoEvents = new Dictionary<PlayerInfoType, List<OnInfoValueChanged>>();

        private OnInfoValueChanged valueChanged;

        public static int Money
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.Money);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.Money, value);
            }
        }

        public static int Gems
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.Gems);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.Gems, value);
            }
        }

        public static int AllRecievedGems
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.AllReceivedGems);
            }
            private set
            {
                Instance.SetInfoValue(PlayerInfoType.AllReceivedGems, value);
            }
        }

        public static int Experience
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.Experience);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.Experience, value);
            }
        }

        public static int Level
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.LvL);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.LvL, value);
            }
        }

        public static int VipLevel
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.VipLvL);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.VipLvL, value);
            }
        }

        public static int UpgradePoints
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.UpgradePoints);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.UpgradePoints, value);
            }
        }

        public static int TotalReceivedMoney
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.TotalReceivedMoney);
            }
            private set
            {
                Instance.SetInfoValue(PlayerInfoType.TotalReceivedMoney, value);
            }
        }

        public static int TotalSpentMoney
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.TotalSpentMoney);
            }
            private set
            {
                Instance.SetInfoValue(PlayerInfoType.TotalSpentMoney, value);
            }
        }

        public static int TotalTimeInGame
        {
            get
            {
                return Instance.GetInfoValue(PlayerInfoType.TotalTimeInGame);
            }
            set
            {
                Instance.SetInfoValue(PlayerInfoType.TotalTimeInGame, value);
            }
        }

        public static void ClearPlayerInfo()
        {
            IEnumerator enumerator = Enum.GetValues(typeof(PlayerInfoType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PlayerInfoType playerInfoType = (PlayerInfoType)enumerator.Current;
                    if (!NotClearedInfo.Contains(playerInfoType))
                    {
                        BaseProfile.ClearValue(playerInfoType + "PlayerInfo");
                    }
                }
            }
            finally
            {
                IDisposable disposable;
                if ((disposable = (enumerator as IDisposable)) != null)
                {
                    disposable.Dispose();
                }
            }
            int value = BaseProfile.ResolveValue(PlayerInfoType.AllReceivedGems + "PlayerInfo", 0);
            BaseProfile.StoreValue(value, PlayerInfoType.Gems + "PlayerInfo");
            if (Instance != null)
            {
                Instance.InitInfoDictionary();
            }
        }

        public int GetInfoValue(PlayerInfoType infoType)
        {
            return InfoItems[infoType].Value;
        }

        public int GetMaxValue(PlayerInfoType infoType)
        {
            return InfoItems[infoType].GetMaxValue();
        }

        public float GetVipMult(PlayerInfoType infoType)
        {
            return (float)VipLevel * InfoItems[infoType].GetVipMult();
        }

        public void SetInfoValue(PlayerInfoType infoType, int value)
        {
            InfoItems[infoType].Value = value;
            CallChangeEvents(infoType);
        }

        public void AddOnValueChangedEvent(PlayerInfoType infoType, OnInfoValueChanged onValueChanged)
        {
            if (!infoEvents.ContainsKey(infoType))
            {
                infoEvents.Add(infoType, new List<OnInfoValueChanged>());
            }
            infoEvents[infoType].Add(onValueChanged);
        }

        public void ChangeInfoValue(PlayerInfoType infoType, int amount, bool useVipMultipler = false)
        {
            InfoItem infoItem = InfoItems[infoType];
            infoItem.ChangeCurrentValue(amount, useVipMultipler);
            CallChangeEvents(infoType);
        }

        public void AddSpendMoney(int money)
        {
            TotalSpentMoney += money;
        }

        private void CallChangeEvents(PlayerInfoType infoType)
        {
            SaveItemInfoValue(infoType);
            if (infoEvents.ContainsKey(infoType))
            {
                InfoItem infoItem = InfoItems[infoType];
                foreach (OnInfoValueChanged item in infoEvents[infoType])
                {
                    item?.Invoke(infoItem.Value);
                }
            }
        }

        public void InitInfoDictionary()
        {
            IEnumerator enumerator = Enum.GetValues(typeof(PlayerInfoType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PlayerInfoType playerInfoType = (PlayerInfoType)enumerator.Current;
                    InfoItem infoItem = (!ItemDefaultValues.ContainsKey(playerInfoType)) ? new InfoItem() : ItemDefaultValues[playerInfoType];
                    if (InfoItems.ContainsKey(playerInfoType))
                    {
                        InfoItems[playerInfoType] = new InfoItem(infoItem);
                    }
                    else
                    {
                        InfoItems.Add(playerInfoType, new InfoItem(infoItem));
                    }
                    InfoItems[playerInfoType].Value = BaseProfile.ResolveValue(playerInfoType + "PlayerInfo", infoItem.Value);
                }
            }
            finally
            {
                IDisposable disposable;
                if ((disposable = (enumerator as IDisposable)) != null)
                {
                    disposable.Dispose();
                }
            }
        }

        private void Awake()
        {
            if (Instance != null)
            {
                UnityEngine.Object.Destroy(base.gameObject);
                return;
            }
            Instance = this;
            SceneManager.sceneUnloaded += OnSceneUnload;
            SceneManager.sceneLoaded += OnSceneLoad;
            InitInfoDictionary();
            UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Game" || scene.name == "Menu")
            {
                AddOnValueChangedEvent(PlayerInfoType.Gems, SaveRecievedGems);
                AddOnValueChangedEvent(PlayerInfoType.Money, AddReceivedMoney);
                if (scene.name == "Game")
                {
                    UIGame instance = UIGame.Instance;
                    instance.OnPausePanelOpen = (Action)Delegate.Combine(instance.OnPausePanelOpen, new Action(OnPausePanelOpen));
                }
            }
        }

        private void OnSceneUnload(Scene scene)
        {
            if (scene.name == "Game" || scene.name == "Menu")
            {
                infoEvents.Clear();
                SaveAllInfoValues();
            }
        }

        private void SaveItemInfoValue(PlayerInfoType infoType)
        {
            InfoItem infoItem = InfoItems[infoType];
            if (infoItem.AvaibleToSave())
            {
                BaseProfile.StoreValue(infoItem.Value, infoType + "PlayerInfo");
                infoItem.OnValueSave();
            }
        }

        private void SaveAllInfoValues()
        {
            if (!(Instance != this))
            {
                foreach (KeyValuePair<PlayerInfoType, InfoItem> infoItem in InfoItems)
                {
                    BaseProfile.StoreValue(infoItem.Value.Value, infoItem.Key + "PlayerInfo");
                }
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveAllInfoValues();
            }
        }

        private void OnApplicationQuit()
        {
            if ((bool)PlayerManager.Instance)
            {
                PlayerManager.Instance.DefaultWeaponController.Deinitialization();
            }
            SaveAllInfoValues();
        }

        private void OnPausePanelOpen()
        {
            SaveAllInfoValues();
        }

        private void SaveRecievedGems(int newGemsValue)
        {
            int lastValueChange = InfoItems[PlayerInfoType.Gems].GetLastValueChange();
            if (lastValueChange > 0)
            {
                AllRecievedGems += lastValueChange;
            }
        }

        private void AddReceivedMoney(int money)
        {
            int lastValueChange = InfoItems[PlayerInfoType.Money].GetLastValueChange();
            if (lastValueChange >= 0)
            {
                TotalReceivedMoney += lastValueChange;
            }
        }

    
    }
}
