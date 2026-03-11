using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Game.Character;
using Game.Character.CharacterController;

public class FortuneWheel : MonoBehaviour
{
    public GameObject spinObj;
    public GameObject uiCanvas;
    public string[] prizes = new string[8];
    public GameObject[] winParticles;
    public GameObject confetti;
    public AudioClip tingSound;
    [Range(1, 5)]
    public int speedMultiplier;
    [Range(2, 10)]
    public int duration;
    public bool timedTurn;
    public bool availableTurn;
    public int spinAvailable = 2;
    public bool coinsTurn;
    public int cost = 300;
    public Sprite[] illuminatiDots;
    public AnimationCurve animationCurve;

    [Header("UI Properties")]

    public Button spinButton;
    public GameObject Arrow;
    public GameObject VideoIcon;
    public GameObject CoinsAnim;
    public Text coinsText, selectedText;
    public Image selectedImage;
    public TimerForSpin timer4Spin;
    public const string COINS_COUNT = "COINS_COUNT";
    [Space(20)]
    [Header("Fortune Wheel Properties")]
    public Transform wheelToRotate;
    public Transform wheelPartsParent, lightsParent;

    public GameObject winPanel;
    public GameObject DoubleRewardButton;
    public GameObject TryAgainButton;
    public Text winPanalText;
    public Image winPanalImage;
    public Image winPanalJackPotImage;
    public Sprite selectedSprite;

    AudioSource audioSource;
    [Header("Sounds")]
    public AudioClip coinsCounting;
    public AudioClip Duck;
    public AudioClip crowdLossSound;
    public AudioClip Spin;
    public AudioClip FrypanImapct;
    public AudioClip Jackpot;
    public AudioClip coinPickClip;
    public AudioClip crowdWinSound;
    public AudioClip buttonClickClip;

    int _selectReward, _coins, _gems, count = 0;
    AudioSource[] audSource;
    WheelPart[] wheelParts;
    DotLight[] lightObjs;
    Sprite[] dots = new Sprite[2];
    bool spinning;
    float anglePerReward, anglePerLight;
    public int spinType;

    public int rewardCount { get { return prizes.Length; } }
    public int lightCount { get { return lightObjs.Length; } }

    public int Coins
    {
        get { return _coins; }
        set
        {
            _coins = value;
            coinsText.text = GetValueFormated(_coins);
        }
    }

    public int Gems
    {
        get { return _gems; }
        set
        {
            _gems = value;
            //coinsText.text = GetValueFormated(_coins);
            PlayerPrefs.SetInt("Gems", _gems);
        }
    }

    public int SelectedReward
    {
        get
        {
            return _selectReward;
        }
        set
        {
            _selectReward = Mathf.Clamp(value, 0, prizes.Length);
            if (spinning)
            {
                Arrow.SetActive(false);
                timer4Spin.timerText.gameObject.SetActive(false);
                selectedText.text = prizes[_selectReward];
                selectedImage.gameObject.SetActive(true);
                selectedImage.sprite = selectedSprite;
            }
            else
            {
                selectedText.text = "";
                selectedImage.gameObject.SetActive(false);
                timer4Spin.timerText.gameObject.SetActive(true);
                Arrow.SetActive(true);
            }
        }
    }

    public void OpenSpinPanel()
    {
        spinObj.SetActive(true);
        uiCanvas.SetActive(false);
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Coins = PlayerPrefs.GetInt("Money");     //Get Coins.
        Gems = PlayerPrefs.GetInt("Gems");
        spinAvailable = PlayerPrefs.GetInt("Spins");

        CheckSpinAvailable();

        dots[0] = illuminatiDots[0];
        dots[1] = illuminatiDots[1];
        spinning = false;
        anglePerReward = 360 / rewardCount;
        wheelParts = wheelPartsParent.GetComponentsInChildren<WheelPart>();
        for (int i = 0; i < rewardCount; i++)
        {
            wheelParts[i].transform.localEulerAngles = new Vector3(0, 0, (i * -anglePerReward));
        }
        lightObjs = lightsParent.GetComponentsInChildren<DotLight>();
        int lights = lightCount + 7;
        anglePerLight = 360 / lights;
        int objID = 0;
        for (int i = 0; i < lights; i++)
        {
            if (i >= 7 && i <= 13) continue;
            lightObjs[objID].transform.localEulerAngles = new Vector3(0, 0, (i * -anglePerLight));
            objID++;
        }
        audSource = new AudioSource[5];
        for (int i = 0; i < 5; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.loop = false;
            audSource[i] = source;
        }
        AnimateWheel(true);
    }
    public int targetToStopOn { get { return UnityEngine.Random.Range(0, 12); } }
    void StartSpin()
    {
        if (!spinning)
        {
            float maxAngle = 360 * speedMultiplier + targetToStopOn * anglePerReward;
            AnimateWheel(false);
            StartCoroutine(RotateWheel(duration, maxAngle));
        }
    }
    IEnumerator RotateWheel(float time, float maxAngle)
    {
        spinning = true;
        float timer = 0.0f;
        float startAngle = wheelToRotate.transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;
        while (timer < time)
        {
            //to calculate rotation
            float angle = maxAngle * animationCurve.Evaluate(timer / time);
            wheelToRotate.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }
        wheelToRotate.transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        StartCoroutine(ShowHideParticles());

        //();
    }

    private IEnumerator IncrementCoroutine(Text l, int targetValue, int startingValue = 0)
    {
        float time = 0;
        l.text = startingValue.ToString();
        float incrementTime = 1.5f;
        CoinsAnim.SetActive(true);
        audioSource.PlayOneShot(coinsCounting);
        while (time < incrementTime)
        {
            yield return null;
            time += Time.deltaTime;
            float factor = time / incrementTime;
            l.text = GetValueFormated((int)Mathf.Lerp(startingValue, targetValue, factor));
        }
        audioSource.Stop();
        l.text = GetValueFormated(targetValue);
        yield break;
    }
    internal void HitStart(SpriteRenderer sp)
    {
        PlayHitClip();
    }
    public void AnimateWheel(bool playAnim)
    {
        StopAllCoroutines();
        foreach (var item in lightObjs)
        {
            item.spRend.sprite = dots[0];
        }

        if (playAnim)
        {
            StartCoroutine(PlayAnimationWhenStationary(dots[0], dots[1]));
        }
        else
        {
            StartCoroutine(LightAnimDuringSpinning(0));
            StartCoroutine(LightAnimDuringSpinning(10));
            StartCoroutine(LightAnimDuringSpinning(20));
        }
    }

    IEnumerator PlayAnimationWhenStationary(Sprite sp1, Sprite sp2)
    {
        yield return new WaitForSeconds(0.2f);
        count++;
        for (int i = 0; i < lightObjs.Length; i++)
        {
            lightObjs[i].spRend.sprite = (i % 2 == 0) ? sp1 : sp2;
        }
        if (count < UnityEngine.Random.Range(10, 30))
        {
            StartCoroutine(PlayAnimationWhenStationary(sp2, sp1));
        }
        else
        {
            StartCoroutine(SymetricLightMovement(0));
        }
    }
    IEnumerator LightAnimDuringSpinning(int index)
    {
        yield return new WaitForSeconds(0.05f);
        if (index < lightObjs.Length - 1)
        {
            lightObjs[index].spRend.sprite = dots[1];
            lightObjs[index + 1].spRend.sprite = dots[1];
            yield return new WaitForSeconds(0.1f);
            lightObjs[index].spRend.sprite = dots[0];
            lightObjs[index + 1].spRend.sprite = dots[0];
            StartCoroutine(LightAnimDuringSpinning(index + 2));
        }
        else
        {
            StartCoroutine(LightAnimDuringSpinning(0));
        }
    }
    IEnumerator SymetricLightMovement(int index)
    {
        if (index >= lightObjs.Length)
        {
            count = 0;
            StartCoroutine(PlayAnimationWhenStationary(dots[0], dots[1]));
        }
        else
        {
            lightObjs[index].spRend.sprite = dots[1];
            yield return new WaitForSeconds(0.05f);
            lightObjs[index].spRend.sprite = dots[0];
            yield return new WaitForSeconds(0.0f);
            StartCoroutine(SymetricLightMovement(index + 1));
        }
    }
    public void PlayHitClip()
    {
        for (int i = 0; i < audSource.Length; i++)
        {
            if (!audSource[i].isPlaying)
            {
                audSource[i].clip = tingSound;
                audSource[i].Play();
                break;
            }
        }
    }
    [ContextMenu("Add Cost Coins")]
    public void AddCoins()
    {
        Coins += cost;
        CheckSpinAvailable();
    }
    public void AddSpin()
    {
        spinAvailable++;
        PlayerPrefs.SetInt("Spins", spinAvailable);
        CheckSpinAvailable();
    }
    [ContextMenu("Add Spins")]
    public void AddSpins()
    {
        spinAvailable += 5;
        PlayerPrefs.SetInt("Spins", spinAvailable);
        CheckSpinAvailable();
    }
    private static FortuneWheel _instance;
    public static FortuneWheel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<FortuneWheel>();
            }
            return _instance;
        }
    }

    public static string GetValueFormated(int val)
    {
        PlayerPrefs.SetInt("Money", val);      //Set Coins
        return String.Format("{0:n0}", val);
    }


    void CheckSpinAvailable()
    {
        VideoIcon.SetActive(false);
        if (availableTurn && spinAvailable > 0)
        {
            spinAvailable = PlayerPrefs.GetInt("Spins");
            timer4Spin.enabled = false;
            timer4Spin.ResetTime();
            timer4Spin.timerText.text = string.Format("Spin Left: " + spinAvailable);
            spinType = 2;
            spinButton.interactable = true;
            return;
        }
        if(coinsTurn && Coins >= cost)
        {
            timer4Spin.enabled = false;
            timer4Spin.ResetTime();
            timer4Spin.timerText.text = string.Format("Spin And Win");
            spinType = 3;
            spinButton.interactable = true;
            return;
        }
        if (timedTurn)
        {
            timer4Spin.enabled = true;
            timer4Spin.ResetTime();
            timer4Spin.timerText.text = string.Format("Spin And Win");
            spinType = 1;
            spinButton.interactable = true;
            return;
        }
        timer4Spin.timerText.text = string.Format("Get Spins");
        VideoIcon.SetActive(true);
        spinButton.interactable = true;
    }

    IEnumerator ShowHideParticles()
    {
        foreach (GameObject g in winParticles)
        {
            g.SetActive(false);
        }
        if (prizes[SelectedReward] == "lost")
        {
            audioSource.PlayOneShot(Duck);
            audioSource.PlayOneShot(crowdLossSound);

            yield return new WaitForSeconds(2f);
        }
        else
        {
            switch (prizes[SelectedReward])
            {
                case "spin":
                    audioSource.PlayOneShot(Spin);
                    break;
                case "skateboard":
                    audioSource.PlayOneShot(Spin);
                    break;
                case "pan":
                    audioSource.PlayOneShot(FrypanImapct);
                    break;
                case "jackpot":
                    audioSource.PlayOneShot(Jackpot);
                    break;
                case "1000":
                    audioSource.PlayOneShot(coinPickClip);
                    break;
                case "2000":
                    audioSource.PlayOneShot(coinPickClip);
                    break;
                case "3000":
                    audioSource.PlayOneShot(coinPickClip);
                    break;
                case "100":
                    audioSource.PlayOneShot(coinPickClip);
                    break;
                case "200":
                    audioSource.PlayOneShot(coinPickClip);
                    break;
            }
            foreach (GameObject g in winParticles)
            {
                g.SetActive(true);
            }
            audioSource.PlayOneShot(crowdWinSound);
            yield return new WaitForSeconds(3f);
        }
        //if (winParticles[SelectedReward])
        //{
        //    SoundManager.instance.PlayOneShotClip(SoundManager.instance.crowdWinSound);
        //    confetti.SetActive(true);
        //    yield return new WaitForSeconds(1f);
        //    winParticles[SelectedReward].gameObject.SetActive(true);
        //    yield return new WaitForSeconds(3f);
        //    confetti.SetActive(false);
        //    winParticles[SelectedReward].gameObject.SetActive(false);
        //}
        ShowWinPanal();
    }

    public void onClickSpinNow()
    {
        SelectedReward = 0;
        winPanel.SetActive(false);
        if (VideoIcon.activeSelf)
        {
            WatchVideoToSpin();
            return;
        }
        if (timer4Spin.remainingTime.TotalMinutes <= 0 && spinType == 1)
        {
            spinButton.interactable = false;
            StartSpin();
        }
        else if (spinType == 2)
        {
            spinAvailable--;
            PlayerPrefs.SetInt("Spins", spinAvailable);
            spinButton.interactable = false;
            timer4Spin.timerText.text = string.Format("Spin Left: " + spinAvailable);
            StartSpin();
        }
        else if (spinType == 3)
        {
            Coins -= cost; spinButton.interactable = false;
            StartSpin();
        }
    }

    public void WatchVideoToSpin()
    {
        GlobalContants.spinWheel = true;
        RewardedAdsController.Instance.ShowRewarded("SpinWheel");
    }

    void ShowWinPanal()
    {
        TryAgainButton.SetActive(false);
        DoubleRewardButton.SetActive(true);
        winPanalImage.gameObject.SetActive(true);
        winPanalJackPotImage.gameObject.SetActive(false);
        switch (prizes[SelectedReward])
        {
            case "spin":
                winPanalText.text = "Congrats!!! You Have Won A <color=#00FF0B><b>Free Spin.</b></color>";
                break;
            case "lost":
                winPanalText.text = "Oops!!! \nBetter Luck Next Time.";
                spinning = false;
                DoubleRewardButton.SetActive(false);
                TryAgainButton.SetActive(true);
                break;
            case "balloon":
                winPanalText.text = "Congrats!!! You Have Won 2 <color=#00FF0B><b>Balloons.</b></color>";
                break;
            case "pan":
                winPanalText.text = "Congrats!!! You Have Won 2 <color=#00FF0B><b>Pans.</b></color>";
                break;
            case "jackpot":
                winPanalImage.gameObject.SetActive(false);
                winPanalJackPotImage.gameObject.SetActive(true);
                winPanalText.text = "Great!!!\nYou Have Won 2  <color=#00FF0B><b>Webs</b></color> and <color=#00FF0B><b>1000 Coins.</b></color> and 2  <color=#00FF0B><b>Balloons</b></color>";//<color=#00FF0B><b>Skateboards</b></color>, 2
                DoubleRewardButton.SetActive(false);
                break;
            case "1000":
                winPanalText.text = "Congrats!!! You Have Won <color=#00FF0B><b>1000 Coins.</b></color>";
                break;
            case "2000":
                winPanalText.text = "Congrats!!! You Have Won <color=#00FF0B><b>2000 Coins.</b></color>";
                break;
            case "3000":
                winPanalText.text = "Congrats!!! You Have Won <color=#00FF0B><b>3000 Coins.</b></color>";
                break;
            case "100":
                winPanalText.text = "Congrats!!! You Have Won <color=#00FF0B><b>100 Gems.</b></color>";
                break;
            case "200":
                winPanalText.text = "Congrats!!! You Have Won <color=#00FF0B><b>200 Gems.</b></color>";
                break;
        }
        winPanalImage.sprite = selectedSprite;
        winPanel.SetActive(true);
    }

    public void GiveReward()
    {
        //SoundManager.instance.PlayOneShotClip(SoundManager.instance.buttonClickClip);
        AnimateWheel(true);
        spinning = false;

        switch (prizes[SelectedReward])
        {
            case "spin":
                AddSpin();
                break;
            case "lost":
                break;
            case "balloon":
                //PlayerPrefs.SetInt("skateboard", PlayerPrefs.GetInt("skateboard") + 2);
                GlobalContants.balloonThrowCount += 2;
                PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
                break;
            case "pan":
                //PlayerPrefs.SetInt("pan", PlayerPrefs.GetInt("pan") + 2);
                GlobalContants.fryPanThrowCount += 2;
                PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
                break;
            case "jackpot":
                //PlayerPrefs.SetInt("pan", PlayerPrefs.GetInt("pan") + 2);
                GlobalContants.WebThrowCount += 2;
                GlobalContants.balloonThrowCount += 2;
                //PlayerPrefs.SetInt("skateboard", PlayerPrefs.GetInt("skateboard") + 2);
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 1000, Coins));
                Coins += 1000;
                if (PlayerManager.Instance)
                    PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
                PlayerInfoManager.Money += 1000;
                break;
            case "1000":
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 1000, Coins));
                Coins += 1000;
                PlayerInfoManager.Money += 1000;
                break;
            case "2000":
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 2000, Coins));
                Coins += 2000;
                PlayerInfoManager.Money += 2000;
                break;
            case "3000":
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 3000, Coins));
                Coins += 3000;
                PlayerInfoManager.Money += 3000;
                break;
            case "100":
                Gems += 100;
                PlayerInfoManager.Gems += 100;
                break;
            case "200":
                Gems += 200;
                PlayerInfoManager.Gems += 200;
                break;
        }
        //StartCoroutine(ShowHideParticles());
        winPanel.SetActive(false);

        SelectedReward = 0;
        CheckSpinAvailable();
        foreach (GameObject g in winParticles)
        {
            g.SetActive(false);
        }
    }

    public void WatchVideoSpinReward()
    {
        audioSource.PlayOneShot(buttonClickClip);
        GlobalContants.spinDoubleReward = true;
        RewardedAdsController.Instance.ShowRewarded("SpinWheel");
    }

    public void GiveDoubleReward()
    {
        AnimateWheel(true);
        spinning = false;

        switch (prizes[SelectedReward])
        {
            case "spin":
                AddSpin();
                AddSpin();
                break;
            case "lost":
                break;
            case "balloon":
                GlobalContants.balloonThrowCount += 4;
                PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
                break;
            case "pan":
                //PlayerPrefs.SetInt("pan", PlayerPrefs.GetInt("pan") + 4);
                GlobalContants.fryPanThrowCount += 4;
                PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
                break;
            case "jackpot":
                //PlayerPrefs.SetInt("pan", PlayerPrefs.GetInt("pan") + 4);
                GlobalContants.WebThrowCount += 4;
                GlobalContants.balloonThrowCount += 4;
                //PlayerPrefs.SetInt("skateboard", PlayerPrefs.GetInt("skateboard") + 4);
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 2000, Coins));
                Coins += 2000;
                PlayerManager.Instance.AnimationController.UpdatePowerUpUI();
                PlayerInfoManager.Money += 2000;
                break;
            case "1000":
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 2000, Coins));
                Coins += 2000;
                PlayerInfoManager.Money += 2000;
                break;
            case "2000":
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 4000, Coins));
                Coins += 4000;
                PlayerInfoManager.Money += 4000;
                break;
            case "3000":
                StartCoroutine(IncrementCoroutine(coinsText, Coins + 6000, Coins));
                Coins += 6000;
                PlayerInfoManager.Money += 6000;
                break;
            case "100":
                Gems += 200;
                PlayerInfoManager.Gems += 200;
                break;
            case "200":
                Gems += 400;
                PlayerInfoManager.Gems += 400;
                break;
        }
        //StartCoroutine(ShowHideParticles());
        winPanel.SetActive(false);

        SelectedReward = 0;
        CheckSpinAvailable();
        foreach (GameObject g in winParticles)
        {
            g.SetActive(false);
        }
    }
}