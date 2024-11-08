using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerScore = 0;

    [SerializeField] GameObject greenBall;
    [SerializeField] GameObject redBallPrefab;
    [SerializeField] GameObject redBallChasePrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] TextMeshProUGUI HiScoreText;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "scene") 
        {
            Invoke("SpawnPowerUp", 10f);
        }
    }

    void Start()
    {
        UpdateHiScoreText();
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

        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HiScore", 0))
        {
            PlayerPrefs.SetInt("HiScore", playerScore);
        }
    }

    void UpdateHiScoreText()
    {
        HiScoreText.text = $"HiScore: {PlayerPrefs.GetInt("HiScore", 0)}";
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
