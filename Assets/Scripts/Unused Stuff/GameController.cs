using System.Collections;
using System.Globalization;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    public Text bestText;
    public Text currentText;
    public GameObject newAlert;
    public float RadNum = 0f;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        RadNum = Random.Range(1, 20);
        Debug.Log(RadNum);
        Invoke("ShowOverPanel", 2.0f);
    }
    void ShowOverPanel()
    {
        scoreText.gameObject.SetActive(false);

        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            newAlert.SetActive(true);
        }
        bestText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentText.text = "Current Score : " + score.ToString();

        gameOverPanel.SetActive(true);
    }
    public void Restart ()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

   
}
