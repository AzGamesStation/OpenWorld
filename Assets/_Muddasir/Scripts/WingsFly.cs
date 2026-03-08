using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsFly : MonoBehaviour
{
    public Animator MainAnimator;
    public Animator WingsAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WingsAnimator.SetBool("Flying", MainAnimator.GetBool("IsFlying"));
        WingsAnimator.SetBool("Sprint", MainAnimator.GetBool("Sprint"));
    }
}
