using System.Collections;
using System.Globalization;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject progressBar;


    // Start is called before the first frame update
    void Start()
    {
        if (ChangeImage.active == false)
        {
            progressBar.SetActive(false);
        }
        maxDistance = finish.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        RadNum = Random.Range(1, 50);
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
        else if (RadNum == 26)
        {
            myText.text = "There's still room to grow";
        }
        else if (RadNum == 27)
        {
            myText.text = "Don't give up yet";
        }
        else if (RadNum == 28)
        {
            myText.text = "Be the one to make history";
        }
        else if (RadNum == 29)
        {
            myText.text = "There is hope";
        }
        else if (RadNum == 30)
        {
            myText.text = "Stay determined";
        }
        else if (RadNum == 31)
        {
            myText.text = "Slowly but surely";
        }
        else if (RadNum == 32)
        {
            myText.text = "Whatever it takes";
        }
        else if (RadNum == 33)
        {
            myText.text = "Don't back down yet";
        }
        else if (RadNum == 34)
        {
            myText.text = "Soon you'll get it";
        }
        else if (RadNum == 35)
        {
            myText.text = "Triumphs need their failures as well";
        }
        else if (RadNum == 36)
        {
            myText.text = "Become the hero of the story";
        }
        else if (RadNum == 37)
        {
            myText.text = "As many tries as it takes";
        }
        else if (RadNum == 38)
        {
            myText.text = "Persist";
        }
        else if (RadNum == 39)
        {
            myText.text = "I know you can do it";
        }
        else if (RadNum == 40)
        {
            myText.text = "Play your heart out";
        }
        else if (RadNum == 41)
        {
            myText.text = "Failure after failure but that won't stop you trying";
        }
        else if (RadNum == 42)
        {
            myText.text = "Only way to stay on top is to keep pushing further";
        }
        else if (RadNum == 43)
        {
            myText.text = "Your story starts with you";
        }
        else if (RadNum == 44)
        {
            myText.text = "Failure is what truly gives you reason in the end";
        }
        else if (RadNum == 45)
        {
            myText.text = "Believe in the path you chose to take";
        }
        else if (RadNum == 46)
        {
            myText.text = "Trying means fighting";
        }
        else if (RadNum == 47)
        {
            myText.text = "You are filled with determination";
        }
        else if (RadNum == 48)
        {
            myText.text = "The results don't matter, only your actions do";
        }
        else if (RadNum == 49)
        {
            myText.text = "Push forward through the challenges you face";
        }
        else if (RadNum == 50)
        {
            myText.text = "Fight for the future, the future that you envision";
        }
        Debug.Log(RadNum);
        Invoke("ShowOverPanel", 2.0f);
        finish = GameObject.Find("Finish");
        progress = (maxDistance - finish.transform.position.x) / maxDistance;
        progressPercentage = progress * 100;
    }
    void ShowOverPanel()
    {
        scoreText.gameObject.SetActive(false);

        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            newAlert.SetActive(true);
        }
        currentScore.text = "Current Score : " + progressPercentage.ToString("F2") + "%";
        if (progressPercentage > PlayerPrefs.GetFloat("Best", 0))
        {
            PlayerPrefs.SetFloat("Best", progressPercentage);
            newAlert.SetActive(true);
        }
        bestScore.text = "Best Score : " + PlayerPrefs.GetFloat("Best", 0).ToString("F2");
        bestText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentText.text = "Current Score : " + score.ToString();

        if (ChangeImage.restart == true)
        {
            Restart();
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
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
