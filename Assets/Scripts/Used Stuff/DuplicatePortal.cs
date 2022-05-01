using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatePortal : MonoBehaviour
{
    public GameObject PlayerCopy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector3 CP = (GameObject.FindWithTag("Player").transform.position); 
            Instantiate(PlayerCopy, CP, transform.rotation);
        }
    }
}
