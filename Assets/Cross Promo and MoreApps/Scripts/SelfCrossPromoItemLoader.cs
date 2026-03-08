using UnityEngine;

namespace Area730.SelfCrossPromo
{
    public class SelfCrossPromoItemLoader : MonoBehaviour
    {

        [System.Serializable]
        public class ItemElement
        {
            public Sprite AppIcon;
            public string AppName;
            public string AppId;
        }

        public ItemElement[] AndroidApps;
        public ItemElement[] IosApps;


    }

}

