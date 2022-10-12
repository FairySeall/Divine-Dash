using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfFinished : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject player;
    public GameObject HPD;

    void Update()
    {
        if (PlayerPrefs.GetInt("FadedABit") != 1)
        {
            HPD = GameObject.Find("HalfPartDone");

            if (player.transform.position.x > HPD.transform.position.x)
            {
                FadeABit();
                PlayerPrefs.SetInt("FadedABit", 1);
            }
        }
        
    }

    public void FadeABit()
    {
        animator.SetTrigger("FadeKindaOut");
    }
}
