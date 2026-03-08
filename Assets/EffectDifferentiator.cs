using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RagdollType
{
    Fire,
    Net,
    ballon,
    Bubble
}
public class EffectDifferentiator : MonoBehaviour
{


    public RagdollType type;
    public GameObject[] effects;
    public GameObject[] DisableEffects;
    public Vector3 BallonStartPos;
    public Vector3 BubbleStartPos;
    [HideInInspector]
    public bool isActualSpawm;

    private void OnEnable()
    {
        if (type == RagdollType.Fire)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                if (i == 0)
                {
                    effects[i].SetActive(true);
                }
                else
                {
                    effects[i].SetActive(false);
                }
            }
        }
        else if (type == RagdollType.Net)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                if (i == 1)
                {
                    effects[i].SetActive(true);
                }
                else
                {
                    effects[i].SetActive(false);
                }
            }
        }
        else if (type == RagdollType.ballon)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                if (i == 2)
                {
                    effects[i].SetActive(true);
                }
                else
                {
                    effects[i].SetActive(false);
                }
            }
        }
        else if (type == RagdollType.Bubble)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                if (i == 3)
                {
                    effects[i].SetActive(true);
                }
                else
                {
                    effects[i].SetActive(false);
                }
            }
        }
    }

    private void OnDisable()
    {
        if (!isActualSpawm)
        {
            return;
        }
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(false);
            effects[2].transform.localPosition = BallonStartPos;
            effects[3].transform.localPosition = BubbleStartPos;
        }
        if (type == RagdollType.ballon || type == RagdollType.Bubble)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                if (i == 0)
                {
                    DisableEffects[i].SetActive(true);
                    DisableEffects[i].transform.parent = null;
                }
            }
        }
        isActualSpawm = false;
    }
}
