using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using DG.Tweening;

public class DropBox : MonoBehaviour
{
    //public ParticleSystem particleSystem;
    public PlaneDropManager manager;

    //private void OnEnable()
    //{
    //    Invoke("Delay", 20f);
    //}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            //particleSystem.loop = false;
            Time.timeScale = 0;
            UIGame.Instance.dropRewardPanel.SetActive(true);
            Invoke("Delay", 30f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIGame.Instance.dropRewardPanel.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 8)
        {
            
        }
        else if (collision.gameObject.layer==8)
        {
            transform.parent.gameObject.GetComponent<DOTweenAnimation>().StopAllCoroutines();
        }
    }

    //void Delay()
    //{
    //    transform.parent.gameObject.SetActive(false);
    //    manager.isDrop = true;
    //}

    private void OnDisable()
    {
        //particleSystem.loop = true;
    }
}
