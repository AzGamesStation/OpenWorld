using Area730.SelfCrossPromo;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class NativeAdsHandler : MonoBehaviour
{


    #region Declarations and constants

    private const string KEY_VERSION = "Version";
    private const string KEY_APPLIST = "AppsList";
    private const string KEY_IOS = "-iOS";
    private const string KEY_ANDROID = "-Android";

    public class ItemContainer
    {
        public Sprite sprite;
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

    private class CrossPromoDescriptor
    {
        public int AppsCount { get; set; }
        public int Version { get; set; }
        public List<AppItem> Items { get; set; }

        public CrossPromoDescriptor()
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
            coroutine = owner.StartCoroutine(Run());
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

    public string configFileUrl;
    public Image PromoImage;
    public Button PlayBtn;
    public GameObject closeButton;
    private CrossPromoDescriptor _currentDesc = null;
    private static bool _updatesChecked = false;
    private int randomNumberofApps;
    private string id;
    #endregion

    #region Utils

    private static AppItem parseItem(JSONNode node)
    {
        AppItem result = new AppItem
        {
            AppTitle = node["AppTitle"],
            IconUrl = node["IconUrl"],
            Id = node["Id"]
        };

        return result;
    }

    private static CrossPromoDescriptor parseResponse(string json)
    {
#if UNITY_IOS
        string platformPref = KEY_IOS;
#else
        string platformPref = KEY_ANDROID;
#endif

        try
        {
            CrossPromoDescriptor result = new CrossPromoDescriptor();
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
        catch (System.Exception)
        {
            Debug.LogError("NativeAds: Json parse error");
        }

        return null;
    }

    private IEnumerator DownloadJsonDescriptor()
    {
        WWW www = new WWW(configFileUrl);
        yield return www;

        if (www.error != null)
        {
            Debug.LogError("NativeAds: WWW error: " + www.error);
        }
        else
        {
            if (logOn)
            {
                Debug.Log("NativeAds: Descriptor downloaded");
            }

            yield return StartCoroutine(updateNativeAds(www.text));
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
        string oldFile = File.ReadAllText(NativeAdsUtils.GetSettingsFilePath());
        _currentDesc = parseResponse(oldFile);
    }

    #endregion


    private IEnumerator updateNativeAds(string responseJson)
    {
        CrossPromoDescriptor desc = parseResponse(responseJson);

        if (desc == null)
        {
            Debug.LogError("NativeAds: Error parsing downloaded descriptor file");
            yield break;
        }

        if (NativeAdsUtils.ConfigFileExists())
        {

            if (desc.Version > _currentDesc.Version)
            {
                // remove old images that wont be replaced
                for (int i = desc.AppsCount; i < _currentDesc.AppsCount; ++i)
                {
                    string imagePath = NativeAdsUtils.GetImagePath(i);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                File.WriteAllText(NativeAdsUtils.GetSettingsFilePath(), responseJson);
                _currentDesc = desc;

                yield return StartCoroutine(updateUI(forceReplace: true));

            }
            else
            {
                if (logOn)
                {
                    Debug.Log("NativeAds: Downloaded version is not new.");
                }
            }

        }
        else
        {
            if (logOn)
            {
                Debug.Log("NativeAds: First time file load");
            }

            File.WriteAllText(NativeAdsUtils.GetSettingsFilePath(), responseJson);
            _currentDesc = desc;

            yield return StartCoroutine(updateUI());
        }

    }

    private IEnumerator updateUI(bool forceReplace = false)
    {
        if (_currentDesc == null)
        {
            Debug.LogError("NativeAds: desciptor is NULL");
            yield break;
        }

        for (int i = 0; i < _currentDesc.AppsCount; ++i)
        {
            if (!File.Exists(NativeAdsUtils.GetImagePath(i)) || forceReplace)
            {
                CoroutineWithData cd = new CoroutineWithData(this, downloadImage(i));
                yield return cd.coroutine;

                bool success = (bool)cd.result;
                if (!success)
                {
                    Debug.LogError("NativeAds: Failded to load image");
                    continue;
                }
            }
        }

        ItemContainer itemData = new ItemContainer();
    TriverseAgain:
        randomNumberofApps = Random.Range(0, _currentDesc.Items.Count);
        id = _currentDesc.Items[randomNumberofApps].Id;
			if (Application.identifier == id)
        {
            closeButton.SetActive(false);

            PromoImage.enabled = false;
            //goto TriverseAgain;
        }
        else
        {
            closeButton.SetActive(true);
            PromoImage.enabled = true;
            PromoImage.sprite = NativeAdsUtils.GetSprite(randomNumberofApps);
        }

        itemData.btnAction = getBtnAction(id);
        PlayBtn.onClick.AddListener(getBtnAction(id));
        if (!forceReplace && !_updatesChecked)
        {
            checkForUpdates();
        }

    }

    private IEnumerator downloadImage(int index)
    {
        WWW www = new WWW(_currentDesc.Items[index].IconUrl);
        yield return www;


        if (www.error != null)
        {
            Debug.LogError("NativeAds: WWW error: " + www.error);
            yield return false;
        }
        else
        {
            File.WriteAllBytes(NativeAdsUtils.GetImagePath(index), www.bytes);
            yield return true;
        }
    }

    #region Unity methods

    private void Start()
    {

        //loadStaticItems();

        if (NativeAdsUtils.ConfigFileExists())
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
            Debug.Log("NativeAds: data path: " + NativeAdsUtils.GetSettingsFilePath());
        }

    }
    #endregion
}
