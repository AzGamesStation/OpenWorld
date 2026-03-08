using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
using Area730.MoreAppsPage;


[RequireComponent(typeof(MoreAppsScrollController))]
public class MoreAppsHandler : MonoBehaviour
{
    #region Declarations and constants

    private const string KEY_VERSION = "Version";
    private const string KEY_APPLIST = "AppsList";
    private const string KEY_IOS = "-iOS";
    private const string KEY_ANDROID = "-Android";

    public class ItemContainer
    {
        public Sprite sprite;
        public string appName;
        public UnityEngine.Events.UnityAction btnAction;
    }

    private class AppItem
    {
        public string AppTitle { get; set; }
        public string IconUrl { get; set; }
        public string Id { get; set; }

        public AppItem()
        {

        }

        public void Print()
        {
            Debug.Log("Title: " + AppTitle + ", icon url: " + IconUrl + ", id: " + Id);
        }
    }

    private class MoreAppsDescriptor
    {
        public int AppsCount { get; set; }
        public int Version { get; set; }
        public List<AppItem> Items { get; set; }

        public MoreAppsDescriptor()
        {
            Items = new List<AppItem>();
        }

        public void Print()
        {
            Debug.Log("Version: " + Version + ", AppsCount: " + AppsCount);
        }
    }

    private class CoroutineWithData
    {
        public Coroutine coroutine { get; private set; }
        public object result;
        private IEnumerator target;

        public CoroutineWithData(MonoBehaviour owner, IEnumerator target)
        {
            this.target = target;
            this.coroutine = owner.StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            while (target.MoveNext())
            {
                result = target.Current;
                yield return result;
            }
        }
    }

    #endregion

    #region Vars
    public bool logOn = false;

    [SerializeField]
    private Button _moreAppsBtn;

    public string configFileUrl;

    private MoreAppsDescriptor _currentDesc = null;
    private static bool _updatesChecked = false;

    #endregion

    #region Utils

    private static AppItem parseItem(JSONNode node)
    {
        AppItem result = new AppItem();

        result.AppTitle = node["AppTitle"];
        result.IconUrl = node["IconUrl"];
        result.Id = node["Id"];

        return result;
    }

    private static MoreAppsDescriptor parseResponse(string json)
    {
#if UNITY_IOS
        string platformPref = KEY_IOS;
#else
        string platformPref = KEY_ANDROID;
#endif

        try
        {
            MoreAppsDescriptor result = new MoreAppsDescriptor();
            JSONNode rootNode = JSON.Parse(json);
            result.Version = rootNode[KEY_VERSION].AsInt;
            JSONArray appsArray = rootNode[KEY_APPLIST + platformPref].AsArray;
            result.AppsCount = appsArray.Count;

            for (int i = 0; i < appsArray.Count; ++i)
            {
                AppItem item = parseItem(appsArray[i]);
                result.Items.Add(item);
            }

            return result;

        }
        catch (System.Exception e)
        {
            Debug.LogError("MoreAppsPage: Json parse error");
        }

        return null;
    }

    private IEnumerator DownloadJsonDescriptor()
    {
        WWW www = new WWW(configFileUrl);
        yield return www;

        if (www.error != null)
        {
            Debug.LogError("MoreAppsPage: WWW error: " + www.error);
        }
        else
        {
            if (logOn)
            {
                Debug.Log("MoreAppsPage: Descriptor downloaded");
            }

            yield return StartCoroutine(updateMoreAppsPage(www.text));
        }
    }

    private UnityEngine.Events.UnityAction getBtnAction(string id)
    {
        return () =>
        {
#if UNITY_EDITOR
            string link = "https://play.google.com/store/apps/details?id=" + id;
            //string link = "http://itunes.apple.com/app/id" + id;
#elif UNITY_ANDROID
            string link = "https://play.google.com/store/apps/details?id=" + id;
#elif UNITY_IOS
            string link = "http://itunes.apple.com/app/id" + id;
#endif
            Application.OpenURL(link);
        };
    }

    private void checkForUpdates()
    {
        _updatesChecked = true;
        StartCoroutine(DownloadJsonDescriptor());
    }

    private void loadConfig()
    {
        string oldFile = File.ReadAllText(Utils.GetSettingsFilePath());
        _currentDesc = parseResponse(oldFile);
    }

    #endregion


    private IEnumerator updateMoreAppsPage(string responseJson)
    {
        MoreAppsDescriptor desc = parseResponse(responseJson);

        if (desc == null)
        {
            Debug.LogError("MoreAppsPage: Error parsing downloaded descriptor file");
            yield break;
        }

        if (Utils.ConfigFileExists())
        {

            if (desc.Version > _currentDesc.Version)
            {
                // remove old images that wont be replaced
                for (int i = desc.AppsCount; i < _currentDesc.AppsCount; ++i)
                {
                    string imagePath = Utils.GetImagePath(i);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                File.WriteAllText(Utils.GetSettingsFilePath(), responseJson);
                _currentDesc = desc;

                yield return StartCoroutine(updateUI(forceReplace: true));

            }
            else
            {
                if (logOn)
                {
                    Debug.Log("MoreAppsPage: Downloaded version is not new.");
                }
            }

        }
        else
        {
            if (logOn)
            {
                Debug.Log("MoreAppsPage: First time file load");
            }

            File.WriteAllText(Utils.GetSettingsFilePath(), responseJson);
            _currentDesc = desc;

            yield return StartCoroutine(updateUI());
        }

    }

    private IEnumerator updateUI(bool forceReplace = false)
    {
        if (_currentDesc == null)
        {
            Debug.LogError("MoreAppsPage: desciptor is NULL");
            yield break;
        }

        bool listEmpty = false;

        MoreAppsScrollController scrollViewController = GetComponent<MoreAppsScrollController>();


        for (int i = 0; i < _currentDesc.AppsCount; ++i)
        {
            if (!File.Exists(Utils.GetImagePath(i)) || forceReplace)
            {
                CoroutineWithData cd = new CoroutineWithData(this, downloadImage(i));
                yield return cd.coroutine;

                bool success = (bool)cd.result;
                if (!success)
                {
                    Debug.LogError("MoreAppsPage: Failded to load image");
                    continue;
                }
            }

            if (!listEmpty)
            {
                // one time lazy clear
                scrollViewController.ClearList();
                listEmpty = true;
            }
            if (Application.identifier != _currentDesc.Items[i].Id)
            {
                ItemContainer itemData = new ItemContainer();
                itemData.appName = _currentDesc.Items[i].AppTitle;
                string id = _currentDesc.Items[i].Id;
                itemData.btnAction = getBtnAction(id);
                itemData.sprite = Utils.GetSprite(i);

                scrollViewController.AddItem(itemData);
            }
        }

		if (scrollViewController.ItemCount > 0) {
			_moreAppsBtn.gameObject.SetActive (true);
		} else {
			_moreAppsBtn.gameObject.SetActive(false);
		}


        if (!forceReplace && !_updatesChecked)
        {
            checkForUpdates();
        }

    }

    private void loadStaticItems()
    {
        ItemLoader loader = GetComponent<ItemLoader>();
        if (loader != null)
        {
            MoreAppsScrollController scrollViewController = GetComponent<MoreAppsScrollController>();
#if UNITY_IOS
            ItemLoader.ItemElement[] itemArray = loader.IosApps;
#else
            ItemLoader.ItemElement[] itemArray = loader.AndroidApps;
#endif

            foreach (ItemLoader.ItemElement e in itemArray)
            {
                if (Application.identifier != e.AppId)
                {
                    ItemContainer itemData = new ItemContainer();
                    itemData.sprite = e.AppIcon;
                    itemData.appName = e.AppName;
                    itemData.btnAction = getBtnAction(e.AppId);

                    scrollViewController.AddItem(itemData);
                }
            }

            if (scrollViewController.ItemCount > 0)
            {
                _moreAppsBtn.gameObject.SetActive(true);
            }

            Destroy(loader, 0.1f);
        }
    }

    private IEnumerator downloadImage(int index)
    {
        WWW www = new WWW(_currentDesc.Items[index].IconUrl);
        yield return www;


        if (www.error != null)
        {
            Debug.LogError("MoreAppsPage: WWW error: " + www.error);
            yield return false;
        }
        else
        {
            File.WriteAllBytes(Utils.GetImagePath(index), www.bytes);
            yield return true;
        }
    }

    #region Unity methods

    void Start()
    {
        _moreAppsBtn.gameObject.SetActive(false);

        loadStaticItems();

        if (Utils.ConfigFileExists())
        {
            loadConfig();
            StartCoroutine(updateUI());
        }
        else
        {
            checkForUpdates();
        }

        if (logOn)
        {
            Debug.Log("MoreAppsPage: data path: " + Utils.GetSettingsFilePath());
        }

    }


    #endregion
}
