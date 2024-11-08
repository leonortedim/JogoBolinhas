using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public TMPro.TextMeshProUGUI scoretext;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }
    void Update()
    {
        // Update the score text every frame to reflect changes in real time
        UpdateScoreText();
    }
    public void ChangeScore()
    {
        GameManager.instance.ChangeScore(1);
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        int playerScore = GameManager.instance.playerScore;
        int currentScore = playerScore;
        scoretext.text = "Score: " + currentScore;
    }

}
