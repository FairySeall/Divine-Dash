using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrb : MonoBehaviour
{
    ILPlayerScript PS;
    public Animator animator;

    void Start()
    {
        PS = FindObjectOfType<ILPlayerScript>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerCopy")
        {
            if (PS.jumpedFromGravityOrb)
            {
                animator.SetBool("Pressed", true);
            }
        }
    }
}
