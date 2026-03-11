using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class PlaySoundOnEnable : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public GameObject particleCam;
    public Canvas uiCanvas;
    public ButtonHandler sprintBtn;

    private void OnEnable()
    {
        if (uiCanvas)
            uiCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        source.PlayOneShot(clip);
        if(particleCam)
            particleCam.SetActive(true);
        if(sprintBtn)
            sprintBtn.SetUpState("Sprint");
    }

    private void OnDisable()
    {
        if(uiCanvas)
            uiCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        if (particleCam)
            particleCam.SetActive(false);
    }
}
