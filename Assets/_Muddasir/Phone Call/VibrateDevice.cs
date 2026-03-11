using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateDevice : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(vibrateRepeat(2));
    }

    // Update is called once per frame
   IEnumerator vibrateRepeat(float sec)
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(sec);
        StartCoroutine(vibrateRepeat (2));
   }
}
