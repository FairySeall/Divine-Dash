using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDuplicatePortal : MonoBehaviour
{
    public GameObject PlayerCopy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(GameObject.Find("PlayerCopy(Clone)"));
        }
    }
}
