using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdsTest_Ironbolt : MonoBehaviour {
    public GameObject MainMenuPannel;
    public GameObject selectionPannel;

	// Use this for initialization
	void Start () {
       // print(AdsIds.CB_Promotion + "CBpromotion.......................................hhhhhh");
    }
	public void BtnMainMenu() {
        MainMenuPannel.SetActive(true);
        selectionPannel.SetActive(false);
    }
    public void BtnSelection()
    {
        MainMenuPannel.SetActive(false);
        selectionPannel.SetActive(true);
    }
    public void BtnGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
