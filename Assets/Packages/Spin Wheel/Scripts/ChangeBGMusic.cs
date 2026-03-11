using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeBGMusic : MonoBehaviour
{
    [Range(0,1)]
    public float volume;
    public AudioClip bgMusic;

    float LastVolume;
    AudioClip LastClip;

    private void OnEnable()
    {
        //AdsMediatorManagerZR.instance.hideBanner();
    }

    private void OnDisable()
    {
        //AdsMediatorManagerZR.instance.showBanner();
    }

    //private void OnEnable()
    //{
    //    LastClip = SoundManager.instance.bgAudioSource.clip;
    //    LastVolume = SoundManager.instance.bgAudioSource.volume;

    //    SoundManager.instance.bgAudioSource.Stop();
    //    SoundManager.instance.bgAudioSource.volume = volume;
    //    SoundManager.instance.bgAudioSource.clip = bgMusic;
    //    SoundManager.instance.bgAudioSource.Play();
    //}
    //private void OnDisable()
    //{
    //    SoundManager.instance.bgAudioSource.Stop();
    //    SoundManager.instance.bgAudioSource.volume = LastVolume;
    //    SoundManager.instance.bgAudioSource.clip = LastClip;
    //    SoundManager.instance.bgAudioSource.Play();
    //}
}
