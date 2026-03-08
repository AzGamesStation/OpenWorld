using UnityEngine;
using UnityEngine.UI;

namespace Area730.MoreAppsPage
{

    public class MoreAppsScrollController : MonoBehaviour
    {

        [SerializeField]
        private Image _itemPrefab;

        [SerializeField]
        private ContentSizeFitter _fitter;

        private int _itemCount = 0;

        void Awake()
        {

        }


        public void AddItem(MoreAppsHandler.ItemContainer itemData)
        {
            Image item = Instantiate(_itemPrefab);
            ItemView view = item.GetComponent<ItemView>();

            view.btn.onClick.AddListener(itemData.btnAction);
            view.appName.text = itemData.appName;
            view.icon.sprite = itemData.sprite;

            item.transform.SetParent(_fitter.transform);

            item.transform.localScale = Vector3.one;

            ++(_itemCount);
        }

        public void ClearList()
        {
            _itemCount = 0;

            foreach (Transform item in _fitter.transform)
            {
                if (item != _fitter.transform)
                {
                    Destroy(item.gameObject);
                }
            }
        }

        public int ItemCount { get { return _itemCount; } }

    }

}