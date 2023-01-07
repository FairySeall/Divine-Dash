using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartEnder : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject player;
    public GameObject partDone;
    public static int currentLevel;

    void Update()
    {
        partDone = GameObject.Find("PartDone");
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (player.transform.position.x > partDone.transform.position.x)
            {
                FadeToMenu();
                currentLevel = SceneManager.GetActiveScene().buildIndex;
            }
        }
        
    }

    public void FadeToMenu()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(0);
    }
}
