using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleter : MonoBehaviour
{
    public Image Star1;
    public Image Star2;
    public Image Star3;
    public Image Star4;
    public Image Star5;
    public Image Star6;
    public Image Star7;
    public Image Star8;
    public Image Star9;
    public Image Star10;
    public Image Star11;
    public Image Star12;
    public Image Star13;
    public Image Crown;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Star1Completed") == 1)
        {
            Star1.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star2Completed") == 1)
        {
            Star2.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star3Completed") == 1)
        {
            Star3.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star4Completed") == 1)
        {
            Star4.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star5Completed") == 1)
        {
            Star5.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star6Completed") == 1)
        {
            Star6.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star7Completed") == 1)
        {
            Star7.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star8Completed") == 1)
        {
            Star8.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star9Completed") == 1)
        {
            Star9.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star10Completed") == 1)
        {
            Star10.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star11Completed") == 1)
        {
            Star11.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star12Completed") == 1)
        {
            Star12.enabled = true;
        }
        else if (PlayerPrefs.GetInt("Star13Completed") == 1)
        {
            Star13.enabled = true;
        }
        else if (PlayerPrefs.GetInt("GameCompleted") == 1)
        {
            Crown.enabled = true;
        }
    }

    void Update()
    {
        if (PartEnder.currentLevel == 3)
        {
            Star1.enabled = true;
            PlayerPrefs.SetInt("Star1Completed", 1);
        }
        else if (PartEnder.currentLevel == 4)
        {
            Star2.enabled = true;
            PlayerPrefs.SetInt("Star2Completed" , 1);
        }
        else if (PartEnder.currentLevel == 5)
        {
            Star3.enabled = true;
            PlayerPrefs.SetInt("Star3Completed", 1);
        }
        else if (PartEnder.currentLevel == 6)
        {
            Star4.enabled = true;
            PlayerPrefs.SetInt("Star4Completed", 1);
        }
        else if (PartEnder.currentLevel == 7)
        {
            Star5.enabled = true;
            PlayerPrefs.SetInt("Star5Completed", 1);
        }
        else if (PartEnder.currentLevel == 8)
        {
            Star6.enabled = true;
            PlayerPrefs.SetInt("Star6Completed", 1);
        }
        else if (PartEnder.currentLevel == 9)
        {
            Star7.enabled = true;
            PlayerPrefs.SetInt("Star7Completed", 1);
        }
        else if (PartEnder.currentLevel == 10)
        {
            Star8.enabled = true;
            PlayerPrefs.SetInt("Star8Completed", 1);
        }
        else if (PartEnder.currentLevel == 11)
        {
            Star9.enabled = true;
            PlayerPrefs.SetInt("Star9Completed", 1);
        }
        else if (PartEnder.currentLevel == 12)
        {
            Star10.enabled = true;
            PlayerPrefs.SetInt("Star10Completed", 1);
        }
        else if (PartEnder.currentLevel == 13)
        {
            Star11.enabled = true;
            PlayerPrefs.SetInt("Star11Completed", 1);
        }
        else if (PartEnder.currentLevel == 14)
        {
            Star12.enabled = true;
            PlayerPrefs.SetInt("Star12Completed", 1);
        }
        else if (PartEnder.currentLevel == 15)
        {
            Star13.enabled = true;
            PlayerPrefs.SetInt("Star13Completed", 1);
        }
        else if (GameFinished.finishedGame == 2)
        {
            Crown.enabled = true;
            PlayerPrefs.SetInt("GameCompleted", 1);
        }
    }
}
