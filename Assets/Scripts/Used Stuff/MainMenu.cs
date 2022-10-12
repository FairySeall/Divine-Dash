using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject DD;
    public GameObject DDHPD;
    public GameObject quit;
    public GameObject quitHPD;
    public GameObject no;
    public GameObject yes;
    public GameObject question;
    public GameObject noHPD;
    public GameObject yesHPD;
    public GameObject questionHPD;

    void Awake()
    {
        if (HPDChecker.isHPD == true)
        {
            DD.SetActive(false);  
            quit.SetActive(false);
            no.SetActive(false);
            yes.SetActive(false);
            question.SetActive(false);

            DDHPD.SetActive(true);
            quitHPD.SetActive(true);
            noHPD.SetActive(true);
            yesHPD.SetActive(true);
            questionHPD.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void PlayEndlessGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayMainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayPart1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void PlayPart2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void PlayPart3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
    public void PlayPart4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }
    public void PlayPart5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
    public void PlayPart6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    }
    public void PlayPart7()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    }
    public void PlayPart8()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
    }
    public void PlayPart9()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);
    }
    public void PlayPart10()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 12);
    }
    public void PlayPart11()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 13);
    }
    public void PlayPart12()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 14);
    }
    public void PlayPart13()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 15);
    }
}
