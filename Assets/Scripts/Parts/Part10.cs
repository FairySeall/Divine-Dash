using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Part10 : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 12);
    }
}
