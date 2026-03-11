using Common.Analytics;
using System;
using UnityEngine;

public class Analytics : MonoBehaviour
{
	public string trackingID = "UA-XXXXXXX-Y";

	public string newLevelAnalyticsEventPrefix = "level-";

	public bool useHTTPS;

	public bool useOfflineCache = true;

	public static GoogleUniversalAnalytics gua;

	private static Analytics instance;

	private string sceneName = string.Empty;

	private const string disableAnalyticsByUserOptOutPrefKey = "GoogleUniversalAnalytics_optOut";

	private string offlineCacheFileName = "GUA-offline-queue.dat";

	public static Analytics Instance => instance;

	private int getPOSIXTime()
	{
		return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}

	public static void setPlayerPref_disableAnalyticsByUserOptOut(bool analyticsDisabled)
	{
		if (gua != null)
		{
			gua.analyticsDisabled = analyticsDisabled;
		}
		PlayerPrefs.SetInt("GoogleUniversalAnalytics_optOut", analyticsDisabled ? 1 : 0);
		PlayerPrefs.Save();
	}

	private void Awake()
	{
        Common.Analytics.AnalyticsManager analyticsManager = Common.Analytics.BaseAnalyticsManager.Instance as Common.Analytics.AnalyticsManager;
		if (!analyticsManager.GoogleAnalyticIsEnable())
		{
			base.enabled = false;
			return;
		}
		if ((bool)instance)
		{
			UnityEngine.Object.DestroyImmediate(base.gameObject);
			return;
		}
		instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		string text = string.Empty;
		if (PlayerPrefs.HasKey("GoogleUniversalAnalytics_clientID"))
		{
			text = PlayerPrefs.GetString("GoogleUniversalAnalytics_clientID");
		}
		if (text.Length < 8 || !PlayerPrefs.HasKey("GoogleUniversalAnalytics_clientID"))
		{
			text = string.Concat(str2: (SystemInfo.graphicsDeviceName.GetHashCode() ^ SystemInfo.graphicsDeviceVersion.GetHashCode() ^ SystemInfo.operatingSystem.GetHashCode() ^ SystemInfo.processorType.GetHashCode()).ToString("X8"), str0: getPOSIXTime().ToString("X8"), str1: UnityEngine.Random.Range(0, int.MaxValue).ToString("x8"));
			PlayerPrefs.SetString("GoogleUniversalAnalytics_clientID", text);
			PlayerPrefs.Save();
		}
		string offlineCacheFilePath = string.Empty;
		if (useOfflineCache && offlineCacheFileName != null && offlineCacheFileName.Length > 0)
		{
			offlineCacheFilePath = Application.persistentDataPath + '/' + offlineCacheFileName;
		}
		if (gua == null)
		{
			gua = GoogleUniversalAnalytics.Instance;
		}
		gua.initialize(this, trackingID, text, Application.productName, Application.version, useHTTPS, offlineCacheFilePath);
		if (PlayerPrefs.HasKey("GoogleUniversalAnalytics_optOut"))
		{
			gua.analyticsDisabled = (PlayerPrefs.GetInt("GoogleUniversalAnalytics_optOut", 0) != 0);
		}
		if (gua.analyticsDisabled)
		{
			return;
		}
		gua.beginHit(GoogleUniversalAnalytics.HitType.Screenview);
		gua.addScreenResolution(Screen.currentResolution.width, Screen.currentResolution.height);
		gua.addScreenColors((!Handheld.use32BitDisplayBuffer) ? 16 : 32);
		gua.addUserLanguage(Application.systemLanguage.ToString());
		gua.addScreenName(newLevelAnalyticsEventPrefix + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		gua.sendHit();
		if ((useOfflineCache || gua.internetReachable) && !PlayerPrefs.HasKey("GoogleUniversalAnalytics_SystemInfo_since_v001"))
		{
			gua.sendEventHit("SystemInfo_since_v001", "ScreenDPI", ((int)Screen.dpi).ToString(), (int)Screen.dpi);
			gua.sendEventHit("SystemInfo_since_v001", "ScreenResolution", string.Empty + Screen.currentResolution.width + "x" + Screen.currentResolution.height);
			gua.sendEventHit("SystemInfo_since_v001", "operatingSystem", SystemInfo.operatingSystem);
			gua.sendEventHit("SystemInfo_since_v001", "processorType", SystemInfo.processorType);
			gua.sendEventHit("SystemInfo_since_v001", "processorCount", SystemInfo.processorCount.ToString(), SystemInfo.processorCount);
			gua.sendEventHit("SystemInfo_since_v001", "systemMemorySize", (128 * (SystemInfo.systemMemorySize / 128)).ToString(), SystemInfo.systemMemorySize);
			gua.sendEventHit("SystemInfo_since_v001", "graphicsMemorySize", (16 * (SystemInfo.graphicsMemorySize / 16)).ToString(), SystemInfo.graphicsMemorySize);
			gua.sendEventHit("SystemInfo_since_v001", "graphicsDeviceName", SystemInfo.graphicsDeviceName);
			gua.sendEventHit("SystemInfo_since_v001", "graphicsDeviceVendor", SystemInfo.graphicsDeviceVendor);
			gua.sendEventHit("SystemInfo_since_v001", "graphicsDeviceID", SystemInfo.graphicsDeviceID.ToString(), SystemInfo.graphicsDeviceID);
			gua.sendEventHit("SystemInfo_since_v001", "graphicsDeviceVendorID", SystemInfo.graphicsDeviceVendorID.ToString(), SystemInfo.graphicsDeviceVendorID);
			gua.sendEventHit("SystemInfo_since_v001", "graphicsDeviceVersion", SystemInfo.graphicsDeviceVersion);
			int num = 5000;
			if (SystemInfo.graphicsPixelFillrate < 40000)
			{
				num = 2000;
			}
			if (SystemInfo.graphicsPixelFillrate < 10000)
			{
				num = 1000;
			}
			else if (SystemInfo.graphicsPixelFillrate < 4000)
			{
				num = 500;
			}
			else if (SystemInfo.graphicsPixelFillrate < 1300)
			{
				num = 100;
			}
			else if (SystemInfo.graphicsPixelFillrate < 200)
			{
				num = 20;
			}
			else if (SystemInfo.graphicsPixelFillrate < 100)
			{
				num = 10;
			}
			gua.sendEventHit("SystemInfo_since_v001", "deviceType", SystemInfo.deviceType.ToString());
			gua.sendEventHit("SystemInfo_since_v001", "maxTextureSize", (512 * (SystemInfo.maxTextureSize / 512)).ToString(), SystemInfo.maxTextureSize);
			gua.sendEventHit("SystemInfo_since_v001", "deviceModel", SystemInfo.deviceModel);
			PlayerPrefs.SetInt("GoogleUniversalAnalytics_SystemInfo_since_v001", getPOSIXTime());
			PlayerPrefs.Save();
		}
	}

	private void OnLevelWasLoaded(int level)
	{
        Common.Analytics.AnalyticsManager analyticsManager = BaseAnalyticsManager.Instance as Common.Analytics.AnalyticsManager;
		if (!analyticsManager.GoogleAnalyticIsEnable())
		{
			base.enabled = false;
		}
		else if (!sceneName.Equals(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name))
		{
			sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			GoogleUniversalAnalytics googleUniversalAnalytics = GoogleUniversalAnalytics.Instance;
			googleUniversalAnalytics.sendAppScreenHit(newLevelAnalyticsEventPrefix + sceneName);
		}
	}

	private void OnDisable()
	{
		if (gua != null)
		{
			gua.closeOfflineCacheFile();
		}
	}

	private void Start()
	{
	}

	public static void changeScreen(string newScreenName)
	{
		gua.sendAppScreenHit(newScreenName);
	}
}
