using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSwitcher : MonoBehaviour
{
    public Light Sun;
    public GameObject Clouds;
    public GameObject Stars;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, GetComponent<LightMapsManager>().Infos.Length);

        switch (i)
        {
            case 0: // night
                Sun.gameObject.SetActive(false);
                Stars.gameObject.SetActive(true);
                Clouds.gameObject.SetActive(false);
                GetComponent<LightMapsManager>().Switch(0);
                break;
            case 1:
                Sun.gameObject.SetActive(true);
                Stars.gameObject.SetActive(false);
                Clouds.gameObject.SetActive(true);
                GetComponent<LightMapsManager>().Switch(1);
                break;
        }
    }
}
