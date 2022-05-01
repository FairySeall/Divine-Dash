using System.Collections;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.InputSystem;

public class ILPlayerScript : MonoBehaviour
{
    public float jumpPower = 7.0f;
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
    float posX = 0.0f;
    public bool isGameOver = false;
    GameController myGameController;
    Transform myTransform;
    public AudioClip death;
    AudioSource myAudioPlayer;
    UltimateChallenge myUltimateChallenge;
    public AudioClip jump;
    public float fallMultiplier = 5f;
    public Animator animator;
    private PlayerInput playerInput;
    public int JumpCount = 0;
    public int MaxJumps = 1;
    CameraFollow Cm;
    public bool orbCheck = false;
    public bool jumpPowerChange = false;
    public bool jumped = false;
    public bool jumpedFromOrb = false;
    bool canSwitchGravity = false;
    bool canReSwitchGravity = false;
    private GameObject currentTeleporter;
    public bool checkTime = false;
    public bool isInOrb = false;
    public int velocityZero = 0;
    public bool duplicated = false;
    public bool jumpedFromJumpOrb = false;
    public bool jumpedFromGravityOrb = false;
    public bool jumpedFromWaveDash = false;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        //   Inputs inputs = new Inputs();
        //  inputs.Player.Enable();
        // inputs.Player.Jump.performed += Jump;
    }


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myGameController = GameObject.FindObjectOfType<GameController>();
        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
        myUltimateChallenge = GameObject.FindObjectOfType<UltimateChallenge>();

        JumpCount = MaxJumps;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isGrounded || Input.GetKey(KeyCode.Space) && isGrounded || Input.GetKey(KeyCode.W) && isGrounded || Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            if (JumpCount > 0)
            {
                myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                isGrounded = false;
                Jumps();
            }
        }

        if (canSwitchGravity == true)
        {
            GravityReversed();
        }
        if (canReSwitchGravity == true)
        {
            GravityReReversed();
        }
    }

    void LateUpdate()
    {
        if (canSwitchGravity == true && fallMultiplier == -1)
        {
            canSwitchGravity = false;
            jumpedFromOrb = false;
        }
        if (canReSwitchGravity == true && fallMultiplier == 5)
        {
            canReSwitchGravity = false;
            jumpedFromOrb = false;
        }
    }

    public void Jumps()
    {
        JumpCount -= 1;
    }

    public void JumpCheck()
    {
        jumped = true;
    }

    void GravityReversed ()
    {
        myRigidbody.gravityScale = -7;
        jumpPowerChange = true;
        fallMultiplier = -1;
    }

    void GravityReReversed()
    {
        myRigidbody.gravityScale = 7;
        jumpPowerChange = false;
        fallMultiplier = 5;
    }

    void Update()
    {
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        if (myRigidbody.velocity.y < 0)
        {
            myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            if (transform.position.x < posX && !isGameOver)
            {
                GameOver();
            }
            if (isGameOver == true)
            {
                jumpPower = 0.0f;
            }
        }
    }

    void GameOver()
    {
        isGameOver = true;
        myAudioPlayer.PlayOneShot(death);
        myUltimateChallenge.GameOver();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Floor")
        {
            isGrounded = true;
            JumpCount = MaxJumps;
            orbCheck = true;
            jumped = false;
            jumpedFromOrb = false;
            velocityZero = 1;
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
                myRigidbody.gravityScale = -7;
            }
            else
            {
                jumpPower = 7.3f;
                myRigidbody.gravityScale = 7;
            }
        }
        if (other.collider.tag == "Enemy")
        {
            GameOver();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Floor")
        {
            isGrounded = true;
            orbCheck = true;
            isInOrb = false;
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
                myRigidbody.gravityScale = -7;
            }
            else
            {
                jumpPower = 7.3f;
                myRigidbody.gravityScale = 7;
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Floor")
        {
            isGrounded = false;
            orbCheck = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed10")
        {
            myUltimateChallenge.scrollSpeed = 30.0f;
        }
        if (other.tag == "CameraMirror")
        {
            Cm.mirror = true;
        }
        if (other.tag == "CameraReMirror")
        {
            Cm.remirror = true;
        }
        if (other.tag == "JumpOrb" && orbCheck == false)
        {
            jumped = false;
            jumpPower = 7.0f;
            JumpCount = MaxJumps;
            isInOrb = true;
            velocityZero = 1;
            if (jumped == true && JumpCount == 1)
            {
                if (velocityZero == 1)
                {
                    myRigidbody.velocity = Vector3.zero;
                    myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                    velocityZero = 0;
                    jumpedFromJumpOrb = true;
                }
            }
        }
        if (other.tag == "GravityJumpOrb" && orbCheck == false)
        {
            jumped = false;
            jumpPower = 7.0f;
            JumpCount = MaxJumps;
            velocityZero = 1;
            if (jumped == true && JumpCount == 1)
            {
                if (velocityZero == 1)
                {
                    myRigidbody.velocity = Vector3.zero;
                    myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                    velocityZero = 0;
                }
            }
        }
        if (other.tag == "GravityReverse")
        {
            GravityReversed();
        }
        if (other.tag == "GravityOrb" && orbCheck != true)
        {
            jumped = false;
            if (jumped == true)
            {
                GravityReversed();
                jumpedFromGravityOrb = true;
            }
        }
        if (other.tag == "GravityReOrb" && orbCheck != true)
        {
            jumped = false;
            if (jumped == true)
            {
                GravityReReversed();
                jumpedFromGravityOrb = true;
            }
        }
        if (other.tag == "GravityReReverse")
        {
            GravityReReversed();
        }
        if (other.tag == "FastGravityOrb")
        {
            if (jumpedFromOrb && jumpPowerChange == false)
            {
                canSwitchGravity = true;
                jumpPowerChange = true;
            }
        }
        if (other.tag == "FastGravityReOrb")
        {
            if (jumpedFromOrb && jumpPowerChange == true)
            {
                canReSwitchGravity = true;
                jumpPowerChange = false;
            }
        }
        if (other.tag == "WaveDash" && orbCheck != true)
        {
            jumped = false;
            if (jumped == true)
            {
                myRigidbody.gravityScale = 80;
                jumpedFromWaveDash = true;
            }
        }
        if (other.tag == "ReverseWaveDash" && orbCheck != true)
        {
            jumped = false;
            if (jumped == true)
            {
                myRigidbody.gravityScale = -100;
                jumpedFromWaveDash = true;
            }
        }
        if (other.tag == "JumpPlatform")
        {
            JumpCount -= 1;
            isGrounded = false;
            velocityZero = 1;
            if (jumpPowerChange == true)
            {
                myRigidbody.gravityScale = -7.0f;
            }
            else
            {
                myRigidbody.gravityScale = 7.0f;
            }
            jumpPower = 10.0f;
            if (velocityZero == 1)
            {
                myRigidbody.velocity = Vector3.zero;
                myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                velocityZero = 0;
            }
        }
        if (other.tag == "GravityPlatform")
        {
            velocityZero = 1;
            jumpPower = 5.0f;
            if (velocityZero == 1)
            {
                myRigidbody.velocity = Vector3.zero;
                myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                velocityZero = 0;
            }
            JumpCount -= 1;
            GravityReversed();
        }
        if (other.tag == "GravityRePlatform")
        {
            velocityZero = 1;
            jumpPower = 5.0f;
            if (velocityZero == 1)
            {
                myRigidbody.velocity = Vector3.zero;
                myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                velocityZero = 0;
            }
            JumpCount -= 1;
            GravityReReversed();
        }
        if (other.tag == ("TeleportOrbStart") && orbCheck != true)
        {
            jumped = false;
            currentTeleporter = other.gameObject;
        }
        if (other.tag == "SpeedFast")
        {
            myUltimateChallenge.scrollSpeed = 17.0f;
        }
        if (other.tag == "SpeedMedium")
        {
            myUltimateChallenge.scrollSpeed = 13.0f;
        }
        if (other.tag == "SpeedSlow")
        {
            myUltimateChallenge.scrollSpeed = 8.0f;
        }
        if (other.tag == "AudioTimeCheck")
        {
            checkTime = true;
        }
        if (other.tag == "DuplicatePortal")
        {
            GameObject.Find("Main Camera").GetComponent<CameraFollowV2>().enabled = false;
        }
        if (other.tag == "UnDuplicatePortal")
        {
            GameObject.Find("Main Camera").GetComponent<CameraFollowV2>().enabled = true;
        }
        if (other.tag == "AudioStart")
        {
            myUltimateChallenge.myAudioSource.Play();
        }
        if (other.tag == "NoJumpArea")
        {
            isGrounded = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "GravityOrb" && orbCheck == false)
        {
            if (jumped == true)
            {
                GravityReversed();
                jumpedFromGravityOrb = true;
            }
        }
        if (other.tag == "JumpOrb" && orbCheck == false)
        {
            isInOrb = true;
            if (jumped == true && JumpCount == 1)
            {
                if (velocityZero == 1)
                {
                    myRigidbody.velocity = Vector3.zero;
                    myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                    velocityZero = 0;
                    jumpedFromJumpOrb = true;
                }
            }
        }
        if (other.tag == "GravityJumpOrb" && orbCheck != true)
        {
            if (jumped == true && JumpCount == 1)
            {
                if (velocityZero == 1)
                {
                    myRigidbody.velocity = Vector3.zero;
                    myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                    velocityZero = 0;
                    jumpedFromOrb = true;
                }
            }
        }
        if (other.tag == "GravityReOrb" && orbCheck != true)
        {
            if (jumped == true)
            {
                GravityReReversed();
                jumpedFromGravityOrb = true;
            }
        }
        if (other.tag == "FastGravityOrb")
        {
            if (jumpedFromOrb && jumped && jumpPowerChange == false)
            {
                canSwitchGravity = true;
            }
        }
        if (other.tag == "FastGravityReOrb")
        {
            if (jumpedFromOrb && jumped && jumpPowerChange == true)
            {
                canReSwitchGravity = true;
            }
        }
        if (other.tag == "WaveDash" && orbCheck != true)
        {
            if (jumped == true && jumpPowerChange == false)
            {
                myRigidbody.gravityScale = 80;
                jumpedFromWaveDash = true;
            }
        }
        if (other.tag == "ReverseWaveDash" && orbCheck != true)
        {
            if (jumped == true && jumpPowerChange == true)
            {
                myRigidbody.gravityScale = -100;
                jumpedFromWaveDash = true;
            }
        }
        if (other.tag == "TeleportOrbStart" && orbCheck != true)
        {
            if (jumped == true)
            {
                if (currentTeleporter != null)
                {
                    transform.position = currentTeleporter.GetComponent<TeleportOrbs>().GetDestination().position;
                    myRigidbody.velocity = Vector3.zero;
                }
            }
        }
        if (other.tag == "NoJumpArea")
        {
            isGrounded = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "JumpOrb")
        {
            isGrounded = false;
            JumpCount -= 1;
            isInOrb = false;
            velocityZero = 1;
            jumpedFromJumpOrb = false;
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
            }
            else
            {
                jumpPower = 7.3f;
            }
        }
        if (other.tag == "GravityOrb")
        {
            isGrounded = false;
            JumpCount -= 1;
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
            }
            else
            {
                jumpPower = 7.3f;
            }
            jumpedFromGravityOrb = false;
        }
        if (other.tag == "GravityReOrb")
        {
            isGrounded = false;
            JumpCount -= 1;
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
            }
            else
            {
                jumpPower = 7.3f;
            }
            jumpedFromGravityOrb = false;
        }
        if (other.tag == "FastGravityOrb")
        {
            canSwitchGravity = false;
        }
        if (other.tag == "WaveDash")
        {
            jumpedFromWaveDash = false;
        }
        if (other.tag == "ReverseWaveDash")
        {
            jumpedFromWaveDash = false;
        }
        if (other.tag == "FastGravityReOrb")
        {
            canReSwitchGravity = false;
        }
        if (other.tag == "GravityJumpOrb")
        {
            JumpCount -= 1;
            velocityZero = 1;
        }
        if (other.tag == "JumpPlatform")
        {
            jumpPower = 7.3f;
            velocityZero = 1;
        }
        if (other.tag == "JumpRePlatform")
        {
            jumpPower = 7.8f;
            velocityZero = 1;
        }
        if (other.tag == "GravityPlatform")
        {
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
            }
            else
            {
                jumpPower = 7.3f;
            }
            velocityZero = 1;
        }
        if (other.tag == "GravityRePlatform")
        {
            if (jumpPowerChange == true)
            {
                jumpPower = 7.8f;
            }
            else
            {
                jumpPower = 7.3f;
            }
            velocityZero = 1;
        }
        if (other.tag == ("TeleportOrbStart"))
        {
            if (other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
