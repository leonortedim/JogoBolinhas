using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerScore = 0;
    [SerializeField] GameObject greenBall;
    [SerializeField] GameObject redBallPrefab;
    [SerializeField] GameObject redBallChasePrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] HiScore hiScoreManager;

    public delegate void RedBallDelegate();
    public static event RedBallDelegate OnShrinkRedBalls;
    public static event RedBallDelegate OnRestoreRedBalls;

    private float timer = 0f;
    public float timenextscene = 30f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Invoke("SpawnPowerUp", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "scene")
        {
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);

            if (timer >= timenextscene)
            {
                TransitionToNewScene();
                timer = 0f;
            }
        }

        if (SceneManager.GetActiveScene().name == "midscene")
        {
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);

            if (timer >= timenextscene)
            {
                TransitionToLastScene();
                timer = 0f;
            }
        }
    }

    private void TransitionToNewScene()
    {
        SceneManager.LoadScene("midscene");
        DestroyAllRedBalls();
        KeepObjects();
    }

    private void TransitionToLastScene()
    {
        SceneManager.LoadScene("VictoryScene");
        DestroyAllRedBalls();
        KeepObjects();

        hiScoreManager.CheckForNewHighScore(playerScore);
    }

    private void DestroyAllRedBalls()
    {
        // Find all game objects tagged as "RedBall" and destroy them
        GameObject[] redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        foreach (GameObject redBall in redBalls)
        {
            Destroy(redBall);
        }
    }

    private void KeepObjects()
    {
        greenBall = GameObject.FindWithTag("GreenBall");
        player = GameObject.FindWithTag("Player");

        DontDestroyOnLoad(greenBall);
        DontDestroyOnLoad(player);
    }

    public void ChangeScore(int amount)
    {
        playerScore += amount;
    }

    private void SpawnPowerUp()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
    public void ShrinkRedBalls()
    {
        OnShrinkRedBalls?.Invoke();
        Invoke("RestoreRedBalls", 10f); // Restore balls after 10 seconds
    }

    private void RestoreRedBalls()
    {
        OnRestoreRedBalls?.Invoke();
    }
}
