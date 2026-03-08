using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ATMLoot : MonoBehaviour {

    public GameObject DrillParticle;
    public GameObject AtmCash;
    public int AtmHealth;
    public Image ImageSlider;
    public GameObject drillingUI;
    public GameObject collectCash;
    public bool isBottom = false;
    public GameObject ShootATM;
    public GameObject ATMPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SHowSparks()
    {
        ShootATM.SetActive(false);
        ATMPoint.SetActive(false);
        DrillParticle.SetActive(true);
        drillingUI.SetActive(true);
        InvokeRepeating("startTimer",0.01f,0.01f);
    }
    int num = 0;
    void startTimer()
    {

        if (ImageSlider.fillAmount<1)
        {
            ImageSlider.fillAmount += 0.001f;
        }
        else
        {
            if (isBottom)
            {
                ImageSlider.fillAmount = 0;
                ImageSlider.gameObject.SetActive(false);
                collectCash.SetActive(true);
                DrillParticle.SetActive(false);
                AtmCash.SetActive(true);
                GetComponent<BoxCollider>().enabled = false;
                this.gameObject.transform.rotation = new Quaternion(0,90,0,0);
                drillingUI.SetActive(false);
               
                CancelInvoke();
            }
            else
            {
                ImageSlider.fillAmount = 0;
                ImageSlider.gameObject.SetActive(false);
                DrillParticle.SetActive(false);
                collectCash.SetActive(true);
                AtmCash.SetActive(true);
                drillingUI.SetActive(false);
                CancelInvoke();
            }
           
        }
       
    }
}
