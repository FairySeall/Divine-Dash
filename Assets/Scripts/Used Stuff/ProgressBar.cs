using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject finish;

    Image progressBar;
    float maxDistance;

    void Start()
    {
        progressBar = GetComponent<Image>();

        maxDistance = finish.transform.position.x;
    }

    void Update()
    {
        finish = GameObject.Find("Finish");
        if (progressBar.fillAmount < 1)
        {
            progressBar.fillAmount = (maxDistance - finish.transform.position.x) / maxDistance;
            
        }
    }
}
