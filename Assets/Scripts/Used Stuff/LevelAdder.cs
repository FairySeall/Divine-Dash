using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAdder : MonoBehaviour
{
    public GameObject part7;
    public GameObject part8;
    public GameObject part9;
    public GameObject part10;
    public GameObject part11;
    public GameObject part12;
    public GameObject part13;

    void Awake()
    {
        if (HPDChecker.isHPD == true)
        {
            part7.SetActive(true);
            part8.SetActive(true);
            part9.SetActive(true);
            part10.SetActive(true);
            part11.SetActive(true);
            part12.SetActive(true);
            part13.SetActive(true);
        }
    }

}
