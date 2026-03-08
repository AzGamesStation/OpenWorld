using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class LoadingForSec : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Delay());
        //Delay();
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
