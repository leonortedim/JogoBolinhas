using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerScore = 0;
    public GameObject greenBall;
    public GameObject redBallPrefab;
    public GameObject redBallChasePrefab;

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
        DontDestroyOnLoad(greenBall);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timenextscene)
        {
            TransitionToNewScene();
            timer = 0f; // Reinicia o temporizador
        }
    }

    private void TransitionToNewScene()
    {
        SceneManager.LoadScene("midgame");
        DestroyAllRedBalls();
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

    public void ChangeScore(int amount)
    {
        playerScore += amount;
    }
}
