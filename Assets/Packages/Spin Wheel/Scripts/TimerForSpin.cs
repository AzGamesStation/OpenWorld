using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerForSpin : MonoBehaviour
{
    public Text timerText;
    public Vector3 time;
    private static TimeSpan nextFreeTurn = new TimeSpan(0, 1, 0);
    public TimeSpan remainingTime;
    public const string TIMER_KEY = "TIMER_KEY";
    private DateTime timeStamp;
    private void OnEnable()
    {
        if (FortuneWheel.Instance.timedTurn)
        {
            ResetTime();
        }
    }
    void Update()
    {
        if (FortuneWheel.Instance.timedTurn)
        {
            TimeSpan t = DateTime.Now - timeStamp;
            try
            {
                remainingTime = nextFreeTurn - t;
                timerText.text = string.Format("Next Free Spin: {0:D1}:{1:D2}:{2:D2}",
                    remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
                if (remainingTime.TotalMinutes <= 0)
                {
                    ActivateFreeSpin();
                }
                else
                {
                    FortuneWheel.Instance.spinButton.interactable = false;
                }
            }
            catch (Exception e)
            {
                ActivateFreeSpin();
                print(e.StackTrace);
            }
        }
    }

    public void ActivateFreeSpin()
    {
        timeStamp = DateTime.Now;
        FortuneWheel.Instance.spinButton.interactable = true;
        timerText.text = string.Format("Spin And Win");
        GetComponent<TimerForSpin>().enabled = false;
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause && FortuneWheel.Instance.timedTurn)
        {
            PlayerPrefs.SetString(TIMER_KEY, timeStamp.ToString());
            PlayerPrefs.Save();
        }
    }

    public void ResetTime()
    {
        nextFreeTurn = new TimeSpan((int)time.x, (int)time.y, (int)time.z);
        DateTime.TryParse(PlayerPrefs.GetString(TIMER_KEY, DateTime.Now.ToString()), out timeStamp);
    }
}