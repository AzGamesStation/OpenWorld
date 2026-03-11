using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGetFalseWithTime : MonoBehaviour
{
    [SerializeField] float disabledTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        if (disabledTime > 0)
        {
            
            StartCoroutine(DisableDelay(disabledTime));
        }
    }

    IEnumerator DisableDelay(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine("DisableDelay");
        StopAllCoroutines();
    }
}
