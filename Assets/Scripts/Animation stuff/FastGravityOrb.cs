using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastGravityOrb : MonoBehaviour
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
            if (PS.jumpedFromOrb)
            {
                animator.SetBool("Pressed", true);
            }
        }
    }
}
