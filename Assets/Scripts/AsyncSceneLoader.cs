using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class AsyncSceneLoader : MonoBehaviour
{
	[SerializeField]
	private Slider m_Slider;

	[SerializeField]
	private GameObject m_Panel;

	private float progress;

	private bool loading;

	public Animator anim;

	public static int tutorial_type = 0;

	private void Start()
	{
        //if (PlayerPrefs.HasKey("tutorialTesting"))
        //{
        //    tutorial_type = PlayerPrefs.GetInt("tutorialType");
        //}
        //else
        //{
            //GameAnalytics.OnRemoteConfigsUpdatedEvent += MyOnRemoteConfigsUpdateFunction;
        //}
    }
	private void MyOnRemoteConfigsUpdateFunction()
	{
		PlayerPrefs.SetInt("tutorialTesting", 1);
		string value = GameAnalytics.GetRemoteConfigsValueAsString("tutor_test", "0");//key must be 0-12 characters
		switch (value)
		{
			case "0":
				PlayerPrefs.SetInt("tutorialType", 0);
				break;
			case "1":
				PlayerPrefs.SetInt("tutorialType", 1);
				break;
		}
		tutorial_type = PlayerPrefs.GetInt("tutorialType");
	}


	public void LoadScene(string scene)
	{
		//if (PlayerPrefs.GetInt("Tutorial") == 0)
		//{
		//	//if (tutorial_type == 0)
  // //         {
		//		scene = "Environment";
		//		PlayerPrefs.SetInt("Tutorial", 1);
		//		GlobalContants.loadTutorial = true;
		//	//}
		//	//else if (tutorial_type == 1)
  // //         {
		//	//	GlobalContants.loadTutorial = false;
		//	//}
		//}
		//else if(PlayerPrefs.GetInt("Tutorial") == 1)
  //      {
		//	//scene = "Environment";
		//	GlobalContants.loadTutorial = false;
		//}


		loading = true;
		progress = 0f;
		if (m_Panel != null)
		{
			m_Panel.SetActive(value: true);
		}
		StartCoroutine(LoadNewScene(scene));
	}

	private void Update()
	{
		//m_Slider.value = progress + 0.1f;
	}

	private IEnumerator LoadNewScene(string scene)
	{
		yield return new WaitForSeconds(2.5f);
		AsyncOperation async = SceneManager.LoadSceneAsync(scene);
		async.allowSceneActivation = false;
		if (anim)
		{
			anim.enabled = false;
		}
		while (!async.allowSceneActivation)
		{
			progress = async.progress;
			m_Slider.value = progress;
			if (async.progress >=0.9f)
			{
				async.allowSceneActivation = true;
			}
			yield return null;
		}
		//if (m_Panel != null)
		//{
		//	m_Panel.SetActive(value: false);
		//}
		loading = false;
	}
}
