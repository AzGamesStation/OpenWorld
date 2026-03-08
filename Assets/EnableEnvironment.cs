using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableEnvironment : MonoBehaviour
{
    public GameObject environment;
    public Material daySky, NightSky;
    public float rotateSpeed;

    private void OnEnable()
    {
        environment.SetActive(true);
        LoadGame();
    }

    void LoadGame()
    {
        if (GlobalContants.loadTutorial == true)
        {
            SceneManager.LoadSceneAsync("Tutorial", LoadSceneMode.Additive);
        }
        else if (GlobalContants.loadTutorial == false)
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        }
        if(GlobalContants.mode=="night")
        {
            RenderSettings.skybox = NightSky;
        }
        else if(GlobalContants.mode=="day")
        {
            RenderSettings.skybox = daySky;
        }
        
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
    }
}