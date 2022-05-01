using System.Collections;
using System.Security.Permissions;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpPower = 7.0f;
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeController myChallengeController;
    GameController myGameController;
    public AudioClip jump;
    public AudioClip star;
    public AudioClip death;
    AudioSource myAudioPlayer;
   // UltimateChallenge myUltimateChallenge;
    



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
        myGameController = GameObject.FindObjectOfType<GameController>();
        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
      //  myUltimateChallenge = GameObject.FindObjectOfType<UltimateChallenge>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
            myAudioPlayer.PlayOneShot(jump);
            isGrounded = false;
        }
        if (transform.position.x < posX && !isGameOver)
        {
            GameOver();
        }
        if (isGameOver == true)
        {
            jumpPower = 0.0f;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        myAudioPlayer.PlayOneShot(death);
        myChallengeController.GameOver();
       // myUltimateChallenge.GameOver();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Slime" || other.collider.tag == "Honey" || other.collider.tag == "Floater" || other.collider.tag == "Teleporter" || other.collider.tag == "Floor")
        {
            isGrounded = true;
        }
        if (other.collider.tag == "Enemy")
        {
            GameOver();
        }
        if (other.collider.tag == "Slime")
        {
            jumpPower = 14.0f;
            myRigidbody.gravityScale = 5.0f;
        }
        if (other.collider.tag == "Ground")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 5.0f;
        }
        if (other.collider.tag == "Honey")
        {
            jumpPower = 5.0f;
            myRigidbody.gravityScale = 5.0f;
        }
        if (other.collider.tag == "Floater")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 12.0f;
        }
        if (other.collider.tag == "Teleporter")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 24.0f;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Slime" || other.collider.tag == "Honey" || other.collider.tag == "Floater" || other.collider.tag == "Teleporter" || other.collider.tag == "Floor")
        {
            isGrounded = true;
        }
        if (other.collider.tag == "Slime")
        {
            jumpPower = 14.0f;
            myRigidbody.gravityScale = 5.0f;
        }
        if (other.collider.tag == "Ground")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 5.0f;
        }
        if (other.collider.tag == "Honey")
        {
            jumpPower = 5.0f;
            myRigidbody.gravityScale = 5.0f;
        }
        if (other.collider.tag == "Floater")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 12.0f;
        }
        if (other.collider.tag == "Teleporter")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 24.0f;
        }
    }   
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Slime" || other.collider.tag == "Honey" || other.collider.tag == "Floater" || other.collider.tag == "Teleporter" || other.collider.tag == "Floor")
        {
            isGrounded = false;
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Star")
        {
            myGameController.IncrementScore();
            myAudioPlayer.PlayOneShot(star);
            Destroy(other.gameObject);
        }
        if (other.tag == "Sleeper")
        {
            jumpPower = 0.0f;
            myRigidbody.gravityScale = 0.0f;
        }
        if (other.tag == "Awaker")
        {
            jumpPower = 7.0f;
            myRigidbody.gravityScale = 5.0f;
        }
    }
    
}
