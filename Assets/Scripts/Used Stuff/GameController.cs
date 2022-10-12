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
    public TextMeshProUGUI myTextHPD;
    public TextMeshProUGUI myTextGD;
    public GameObject finish;
    public GameObject HPD;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI attempts;
    float progressPercentage;
    float maxDistance;
    float midDistance;
    float progress = 0;
    public GameObject progressBar;
    int attemptsCount = 0;
    public static bool died = false;

    void Awake ()
    {
        if (HPDChecker.isHPD == true)
        {
            myText.enabled = false;
            myTextHPD.enabled = false;
            myTextGD.enabled = false;
            if (LevelCompleter.gameCompleted == true)
            {
                myText.enabled = false;
                myTextHPD.enabled = false;
                myTextGD.enabled = true;
            }
        }
    }

    void Start()
    {
        if (ChangeImage.active == false)
        {
            progressBar.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            maxDistance = finish.transform.position.x;
            midDistance = HPD.transform.position.x;
        }
        
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
            myTextHPD.text = "You're wasting your time";
        }
        else if (RadNum == 2)
        {
            myText.text = "How about another try?";
            myTextHPD.text = "What will all this suffering give you?";
        }
        else if (RadNum == 3)
        {
            myText.text = "You fail only after you stop trying";
            myTextHPD.text = "This game won't change anything for you";
        }
        else if (RadNum == 4)
        {
            myText.text = "It is possible, you'll get it next time";
            myTextHPD.text = "Others will do better than you";
        }
        else if (RadNum == 5)
        {
            myText.text = "Improvement is inevitable";
            myTextHPD.text = "The suffering is all yours alone";
        }
        else if (RadNum == 6)
        {
            myText.text = "The more time you'll spend, the better you'll get";
            myTextHPD.text = "How many times will you fail before you quit";
        }
        else if (RadNum == 7)
        {
            myText.text = "You can't win if you never fail";
            myTextHPD.text = "All this effort is simply not worth it";
        }
        else if (RadNum == 8)
        {
            myText.text = "Don't let others get better than you";
            myTextHPD.text = "You're hopeless";
        }
        else if (RadNum == 9)
        {
            myText.text = "Don't stop trying";
            myTextHPD.text = "The clock keeps ticking";
        }
        else if (RadNum == 10)
        {
            myText.text = "You know you can get further than that";
            myTextHPD.text = "Skill issue";
        }
        else if (RadNum == 11)
        {
            myText.text = "To fail means to learn from your mistakes";
            myTextHPD.text = "Same mistakes over and over again";
        }
        else if (RadNum == 12)
        {
            myText.text = "The effort you put in won't ever go away";
            myTextHPD.text = "Go back to playing league";
        }
        else if (RadNum == 13)
        {
            myText.text = "Don't make the same mistakes twice";
            myTextHPD.text = "Touch grass";
        }
        else if (RadNum == 14)
        {
            myText.text = "Your only mistake would be to give up";
            myTextHPD.text = "You'll never be able to beat it";
        }
        else if (RadNum == 15)
        {
            myText.text = "You will beat it eventually";
            myTextHPD.text = "You're wasting your time";
        }
        else if (RadNum == 16)
        {
            myText.text = "Blame the player, not the game";
            myTextHPD.text = "Time well spent huh?";
        }
        else if (RadNum == 17)
        {
            myText.text = "The more you lose, the more likely you are to win";
            myTextHPD.text = "There is no hero in this story";
        }
        else if (RadNum == 18)
        {
            myText.text = "You're constantly improving, even if you don't see it";
            myTextHPD.text = "You're only gonna start failing more";
        }
        else if (RadNum == 19)
        {
            myText.text = "The next run will go better, you know that yourself";
            myTextHPD.text = "You keep fighting, yet for what?";
        }
        else if (RadNum == 20)
        {
            myText.text = "A warrior needs rest as well";
            myTextHPD.text = "Your situation is unsavable";
        }
        else if (RadNum == 21)
        {
            myText.text = "Let your motive give you strength";
            myTextHPD.text = "Too far in to back down but still not able to beat it";
        }
        else if (RadNum == 22)
        {
            myText.text = "Don't let failure decide your path";
            myTextHPD.text = "Is it foolishness that motivates you?";
        }
        else if (RadNum == 23)
        {
            myText.text = "Fighting in order to live and living to fight";
            myTextHPD.text = "The fight was lost as soon as you started it";
        }
        else if (RadNum == 24)
        {
            myText.text = "You can try, try to move forward again";
            myTextHPD.text = "You've hit a wall and now you're stuck in stalemate";
        }
        else if (RadNum == 25)
        {
            myText.text = "You have a choice, a choice to keep fighting";
            myTextHPD.text = "Stuck behind everyone else, only remaining in a shadow";
        }
        else if (RadNum == 26)
        {
            myText.text = "There's still room to grow";
            myTextHPD.text = "The effort you put in won't change anything";
        }
        else if (RadNum == 27)
        {
            myText.text = "Don't give up yet";
            myTextHPD.text = "Have a taste of reality";
        }
        else if (RadNum == 28)
        {
            myText.text = "Be the one to make history";
            myTextHPD.text = "Dreams will always remain as dreams and nothing else";
        }
        else if (RadNum == 29)
        {
            myText.text = "There is hope";
            myTextHPD.text = "Hope is on the other side";
        }
        else if (RadNum == 30)
        {
            myText.text = "Stay determined";
            myTextHPD.text = "You're gonna lose your mind eventually";
        }
        else if (RadNum == 31)
        {
            myText.text = "Slowly but surely";
            myTextHPD.text = "Just think for a second how stupid your ambitions are";
        }
        else if (RadNum == 32)
        {
            myText.text = "Whatever it takes";
            myTextHPD.text = "You'll lose too much without achieving anything";
        }
        else if (RadNum == 33)
        {
            myText.text = "Don't back down yet";
            myTextHPD.text = "Lured into a trap and now unable to get out";
        }
        else if (RadNum == 34)
        {
            myText.text = "Soon you'll get it";
            myTextHPD.text = "Failure is inevitable";
        }
        else if (RadNum == 35)
        {
            myText.text = "Triumphs need their failures as well";
            myTextHPD.text = "The things you could've done with all this time";
        }
        else if (RadNum == 36)
        {
            myText.text = "Become the hero of the story";
            myTextHPD.text = "Stuck in a maze with no exit";
        }
        else if (RadNum == 37)
        {
            myText.text = "As many tries as it takes";
            myTextHPD.text = "Why not just give up already?";
        }
        else if (RadNum == 38)
        {
            myText.text = "Persist";
            myTextHPD.text = "You can never huh?";
        }
        else if (RadNum == 39)
        {
            myText.text = "I know you can do it";
            myTextHPD.text = "You have no place in this story";
        }
        else if (RadNum == 40)
        {
            myText.text = "Play your heart out";
            myTextHPD.text = "Will this be one of the things that you'll later regret?";
        }
        else if (RadNum == 41)
        {
            myText.text = "Failure after failure but that won't stop you trying";
            myTextHPD.text = "In the end, you've changed nothing";
        }
        else if (RadNum == 42)
        {
            myText.text = "Only way to stay on top is to keep pushing further";
            myTextHPD.text = "One of the few to get this far but only suffer in reward";
        }
        else if (RadNum == 43)
        {
            myText.text = "Your story starts with you";
            myTextHPD.text = "Would you rather fail others or yourself?";
        }
        else if (RadNum == 44)
        {
            myText.text = "Failure is what truly gives you reason in the end";
            myTextHPD.text = "The light can't find you";
        }
        else if (RadNum == 45)
        {
            myText.text = "Believe in the path you chose to take";
            myTextHPD.text = "The determination of yours, I can admire it";
        }
        else if (RadNum == 46)
        {
            myText.text = "Trying means fighting";
            myTextHPD.text = "You'll fail at the end either way";
        }
        else if (RadNum == 47)
        {
            myText.text = "You are filled with determination";
            myTextHPD.text = "Time stops for you as long as you're in this game";
        }
        else if (RadNum == 48)
        {
            myText.text = "The results don't matter, only your actions do";
            myTextHPD.text = "Please, stop trying";
        }
        else if (RadNum == 49)
        {
            myText.text = "Push forward through the challenges you face";
            myTextHPD.text = "You should've saw all this happening sooner";
        }
        else if (RadNum == 50)
        {
            myText.text = "Fight for the future, the future that you envision";
            myTextHPD.text = "What is the future that you see?";
        }

        myTextGD.text = "HERO!";

        Invoke("ShowOverPanel", 2.0f);

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (HPDChecker.isHPD == true)
            {
                if (PlayerPrefs.GetInt("PercentageReset") != 1)
                {
                    PlayerPrefs.SetFloat("Best", 0);
                    PlayerPrefs.SetInt("PercentageReset", 1);
                }

                finish = GameObject.Find("Finish");
                progress = (maxDistance - finish.transform.position.x) / maxDistance;
                progressPercentage = progress * 100;
            }
            else
            {
                HPD = GameObject.Find("HalfPartDone");
                progress = (midDistance - HPD.transform.position.x) / midDistance;
                progressPercentage = progress * 100;
            }
        }

        died = true;

        PlayerPrefs.SetInt("Attempts", PlayerPrefs.GetInt("Attempts") + 1);
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
        attempts.text = PlayerPrefs.GetInt("Attempts", 0).ToString();
        bestScore.text = "Best Score : " + PlayerPrefs.GetFloat("Best", 0).ToString("F2") + "%";
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
