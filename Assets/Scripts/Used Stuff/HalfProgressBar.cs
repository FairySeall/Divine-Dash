using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HalfProgressBar : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject HPD;
    public TextMeshProUGUI progress;
    float progressPercentage;

    Image progressBar;
    float maxDistance;

    void Start()
    {
        progressBar = GetComponent<Image>();

        maxDistance = HPD.transform.position.x;
    }

    void Update()
    {
        HPD = GameObject.Find("HalfPartDone");
        if (progressBar.fillAmount < 1)
        {
            progressBar.fillAmount = (maxDistance - HPD.transform.position.x) / maxDistance;
        }
        progressPercentage = progressBar.fillAmount * 100;
        progress.text = progressPercentage.ToString("F2") + "%";
    }
}
