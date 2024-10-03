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
    public void ChangeScore()
    {
        GameManager.instance.ChangeScore(1);
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        int currentScore = GameManager.instance.playerScore;
        scoretext.text = "Score: " + currentScore;
    }
}
