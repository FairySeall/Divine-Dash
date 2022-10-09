using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject finish;
    public TextMeshProUGUI progress;
    float progressPercentage;

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
        progressPercentage = progressBar.fillAmount * 100;
        progress.text = progressPercentage.ToString("F2") + "%";
    }
}
