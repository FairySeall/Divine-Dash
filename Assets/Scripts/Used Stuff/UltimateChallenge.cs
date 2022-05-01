using UnityEngine;


public class UltimateChallenge : MonoBehaviour
{

    public float scrollSpeed = 13.0f;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challengesSpawnPoint;
    bool isGameOver = false;
    public GameObject myPlayer;
    public AudioSource myAudioSource;
    ILPlayerScript PS;


    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomChallenge();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }

        GameObject currentChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
        }
    }


    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallenge()
    {
        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;

        counter = 1.0f;
    }

    public void GameOver()
    {
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
        Debug.Log(myAudioSource.time);
    }
}
