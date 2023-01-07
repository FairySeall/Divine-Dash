using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinished : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject player;
    public GameObject gameDone;
    public static int finishedGame;

    void Update()
    {
        gameDone = GameObject.Find("GameDone");
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (player.transform.position.x > gameDone.transform.position.x)
            {
                FadeToMenuPlease();
                finishedGame = SceneManager.GetActiveScene().buildIndex;
            }
        }

    }

    public void FadeToMenuPlease()
    {
        animator.SetTrigger("FadeOutGame");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(0);
    }
}
