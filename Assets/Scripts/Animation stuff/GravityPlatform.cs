using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "PlayerCopy")
        {
            animator.SetBool("Touched", true);
        }
    }
}