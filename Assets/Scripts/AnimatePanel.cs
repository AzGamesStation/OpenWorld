using Game.GlobalComponent;
using UnityEngine;
using UnityEngine.UI;

public class AnimatePanel : Cutscene
{
	public Color StartColor;

	public Color EndColor;

	public Color CurrentColor;

	public float TimeOut;

	public float Speed = 1f;

	private float timer;

	private Image img;

	public override void StartScene()
	{
		img = CutscenePanel.Instance.gameObject.GetComponent<Image>();
		CurrentColor = StartColor;
		timer = 0f;
		IsPlaying = true;
	}

	public void Update()
	{
		if (IsPlaying)
		{
			if (timer > TimeOut)
			{
				EndScene();
			}
			timer += Time.deltaTime;
			CurrentColor = Color.Lerp(CurrentColor, EndColor, Time.deltaTime * timer * Speed);
			img.color = CurrentColor;
		}
	}

	public override void EndScene(bool isCheck = true)
	{
		base.EndScene(isCheck);
		img.color = new Color(0f, 0f, 0f, 0f);
	}
}
