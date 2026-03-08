using UnityEngine;

public class RectBannerCaller : MonoBehaviour
{
    public	bool isReverse=false;

	private void OnEnable()
	{
        if (isReverse)
        {
            ADsShower.HideRectBanner();
            Invoke(nameof(HideBanner), 0.1f);
        }
        else
        {
            ADsShower.ShowRectBanner();
        }
	}

	private void OnDisable()
	{
	if (isReverse)
            ADsShower.ShowRectBanner();
		else
            ADsShower.HideRectBanner();
    }

	public void HideBanner()
    {
        ADsShower.HideRectBanner();
    }
}