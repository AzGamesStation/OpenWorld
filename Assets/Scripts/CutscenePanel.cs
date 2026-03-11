using UnityEngine;

public class CutscenePanel : MonoBehaviour
{
	public static CutscenePanel Instance;

	public Animator CutsceneAnimator;

	public Animator mainAnimator;

	public MenuPanelManager MenuManager;

	private void Awake()
	{
		Instance = this;
	}

	public void Open()
	{
		MenuManager.OpenPanel(CutsceneAnimator);
	}

	public void Close()
	{
		MenuManager.OpenPanel(mainAnimator);
	}
}
