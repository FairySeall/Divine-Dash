using System.Collections;
using System.Globalization;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    public Text bestText;
    public Text currentText;
    public GameObject newAlert;
    public float RadNum = 0f;
    public TextMeshProUGUI myText;
    public GameObject finish;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI bestScore;
    float progressPercentage;
    float maxDistance;
    float progress = 0;


    // Start is called before the first frame update
    void Start()
    {
        maxDistance = finish.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        RadNum = Random.Range(1, 25);
        if (RadNum == 1)
        {
            myText.text = "You win some, you lose some";
        }
        else if (RadNum == 2)
        {
            myText.text = "How about another try?";
        }
        else if (RadNum == 3)
        {
            myText.text = "You fail only after you stop trying";
        }
        else if (RadNum == 4)
        {
            myText.text = "It is possible, you'll get it next time";
        }
        else if (RadNum == 5)
        {
            myText.text = "Improvement is inevitable";
        }
        else if (RadNum == 6)
        {
            myText.text = "The more time you'll spend, the better you'll get";
        }
        else if (RadNum == 7)
        {
            myText.text = "You can't win if you never fail";
        }
        else if (RadNum == 8)
        {
            myText.text = "Don't let others get better than you";
        }
        else if (RadNum == 9)
        {
            myText.text = "Don't stop trying";
        }
        else if (RadNum == 10)
        {
            myText.text = "You know you can get further than that";
        }
        else if (RadNum == 11)
        {
            myText.text = "To fail means to learn from your mistakes";
        }
        else if (RadNum == 12)
        {
            myText.text = "The effort you put in won't ever go away";
        }
        else if (RadNum == 13)
        {
            myText.text = "Don't make the same mistakes twice";
        }
        else if (RadNum == 14)
        {
            myText.text = "Your only mistake would be to give up";
        }
        else if (RadNum == 15)
        {
            myText.text = "You will beat it eventually";
        }
        else if (RadNum == 16)
        {
            myText.text = "Blame the player, not the game";
        }
        else if (RadNum == 17)
        {
            myText.text = "The more you lose, the more likely you are to win";
        }
        else if (RadNum == 18)
        {
            myText.text = "You're constantly improving, even if you don't see it";
        }
        else if (RadNum == 19)
        {
            myText.text = "The next run will go better, you know that yourself";
        }
        else if (RadNum == 20)
        {
            myText.text = "A warrior needs rest as well";
        }
        else if (RadNum == 21)
        {
            myText.text = "Let your motive give you strength";
        }
        else if (RadNum == 22)
        {
            myText.text = "Don't let failure decide your path";
        }
        else if (RadNum == 23)
        {
            myText.text = "Fighting in order to live and living to fight";
        }
        else if (RadNum == 24)
        {
            myText.text = "You can try, try to move forward again";
        }
        else if (RadNum == 25)
        {
            myText.text = "You have a choice, a choice to keep fighting";
        }
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
        finish = GameObject.Find("Finish");
        progress = (maxDistance - finish.transform.position.x) / maxDistance;
        progressPercentage = progress * 100;
        currentScore.text = "Current Score : " + progressPercentage.ToString("F2") + "%";
        if (progressPercentage > PlayerPrefs.GetFloat("Best", 0))
        {
            PlayerPrefs.SetFloat("Best", progressPercentage);
            newAlert.SetActive(true);
        }
        bestScore.text = "Best Score : " + PlayerPrefs.GetFloat("Best", 0).ToString("F2");
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
