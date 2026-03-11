using Game.Character;
using Game.Managers;
using System;
using UnityEngine;

public class GameplayUtils
{
    private static float _currentTimeScale = 1f;

    public static bool OnPause => Time.timeScale == 0f;

    public static void PauseGame()
    {
        if (Time.timeScale > 0f)
        {
            _currentTimeScale = Time.timeScale;
        }
        Time.timeScale = 0f;
        SoundManager.instance.GameSoundMuted = true;
        //    AdsManager.instance.HideBanner();
        //ADsShower.HideBanner();
        PlayerPrefs.SetInt("Money", PlayerInfoManager.Money);
    }

    public static void ResumeGame(bool ShowBanner)
    {
        SoundManager.instance.GameSoundMuted = false;
        Time.timeScale = _currentTimeScale;

        if (ShowBanner)
        {
            if (Game.UI.UIMenu.instance)
            {
                return;
            }
            //AdsManager.instance.ShowMaxBanner();//comment
        }
    }
    public static void ResumeGame()
    {
        SoundManager.instance.GameSoundMuted = false;
        Time.timeScale = _currentTimeScale;
        if (Game.UI.UIMenu.instance)
        {
            return;
        }
        //AdsManager.instance.ShowMaxBanner();//comment
    }

    public static void PerformScreenshot()
    {
        PerformScreenshot(0);
    }

    public static void PerformScreenshot(int superSize)
    {
        if (superSize < 1)
        {
            superSize = 1;
        }
        string text = Application.persistentDataPath + "/screen-" + superSize * Screen.width + "x" + superSize * Screen.height + "-" + DateTime.Now.ToString("yyMMdd-hhmmss") + ".png";
        UnityEngine.ScreenCapture.CaptureScreenshot(text, superSize);
        UnityEngine.Debug.Log("Screenshot saved to location: " + text);
    }
}
