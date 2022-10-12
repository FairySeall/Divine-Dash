using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarIsHPD : MonoBehaviour
{

    public GameObject PBF;
    public GameObject PBFH;
    
    void Start()
    {
        if (HPDChecker.isHPD == true)
        {
            PBF.SetActive(true);
            PBFH.SetActive(false);
        }
        else
        {
            PBF.SetActive(false) ;
            PBFH.SetActive(true);
        }
    }
}
