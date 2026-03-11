using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankingController : MonoBehaviour
{
    public static FlankingController instance;
    Animator AttackerAnim, VictamAnim;
    public GameObject VictamObject;
    // Start is called before the first frame update
    void Start()
    {
        AttackerAnim = GetComponent<Animator>();
        VictamAnim = VictamObject.GetComponent<Animator>();
    }


public void AttackHandler()
    {
        AttackerAnim.SetTrigger("IsFlanking");
        VictamAnim.SetTrigger("IsFlanking");
    }
}
