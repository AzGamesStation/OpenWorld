using UnityEngine;

public class AdsProfiler : MonoBehaviour
{
	private static bool adsEnabled;

	private static bool IsInit;

	public static bool AdsEnabled
	{
		get
		{
			if (!IsInit)
			{
				IsInit = true;
				adsEnabled = BaseProfile.ResolveValue("AdsEnabled", defaultValue: true);
			}
			return adsEnabled;
		}
		set
		{
			adsEnabled = value;
			BaseProfile.StoreValue(value, "AdsEnabled");
		}
	}
}
