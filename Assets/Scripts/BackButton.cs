using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
	public static bool BackButtonsActive = true;

	public static List<Button> s_Buttons = new List<Button>();

	private Button _button;

	private Button GetButton
	{
		get
		{
			if (_button == null)
			{
				_button = GetComponent<Button>();
			}
			return _button;
		}
	}

	public static void ChangeBackButtonsStatus(bool active)
	{
		BackButtonsActive = active;
	}

	private void OnEnable()
	{
		if (!s_Buttons.Contains(GetButton))
		{
			s_Buttons.Add(GetButton);
		}
	}

	private void SceneManager_sceneLoaded(Scene arg0)
	{
		s_Buttons.Clear();
	}

	private void OnDisable()
	{
		if (s_Buttons.Contains(GetButton))
		{
			s_Buttons.Remove(GetButton);
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
		if (BackButtonsActive && GetButton != null && UnityEngine.Input.GetKeyDown(KeyCode.Escape) && GetButton == s_Buttons.LastOrDefault())
		{
			GetButton.onClick.Invoke();
		}
	}
}
