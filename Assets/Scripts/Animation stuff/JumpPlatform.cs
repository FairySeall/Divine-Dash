using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerCopy")
        {
            animator.SetBool("HaveTouched", true);
        }
    }

    void LateUpdate ()
    {
        //animator.SetBool("HaveTouched", false);
    }
}