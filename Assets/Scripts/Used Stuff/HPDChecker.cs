using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPDChecker : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject HPD;
    public static bool isHPD = false;

    void Awake()
    {
        if (PlayerPrefs.GetInt("HalfDone") == 1)
        {
            isHPD = true;
        }
        else
        {
            isHPD = false;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            HPD = GameObject.Find("HalfPartDone");

            if (player.transform.position.x > HPD.transform.position.x)
            {
                PlayerPrefs.SetInt("HalfDone", 1);
                isHPD = true;
            }
        }
            
    }
}
