using UnityEngine;
using UnityEngine.SceneManagement;

public class PartEnder : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject player;
    public GameObject partDone;

    void Update()
    {
        partDone = GameObject.Find("PartDone");
        if (player.transform.position.x > partDone.transform.position.x)
        {
            FadeToMenu();
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
