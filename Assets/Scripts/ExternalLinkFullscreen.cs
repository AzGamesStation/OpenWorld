using UnityEngine;

public class ExternalLinkFullscreen : OfflineAdsFullscreen
{
	public string ExternalLink;

	public override void Click()
	{
		Application.OpenURL(ExternalLink);
	}
}
