using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingGamePlay : MonoBehaviour
{
	public string scene;
	private float progress;
	AsyncOperation async;
	[SerializeField] Slider ProgressBar;

	private void OnEnable()
	{
		LoadNewScene(scene);
	}

	private void LoadNewScene(string scene)
	{
		async = SceneManager.LoadSceneAsync(scene);
		async.allowSceneActivation = false;


	}

	private void Update()
	{
		progress = async.progress;
		ProgressBar.value = progress;
		if (progress >= 0.9f)
		{
			async.allowSceneActivation = true;
		}
	}
}
