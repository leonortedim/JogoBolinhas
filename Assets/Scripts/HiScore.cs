using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public TextMeshProUGUI HiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        int hiscore = PlayerPrefs.GetInt("HiScore", 0);
        HiScoreText.text = "Hi-Score" + hiscore;
    }

    public void CheckForNewHighScore(int currentScore)
    {
        int hiscore = PlayerPrefs.GetInt("HiScore", 0);

        // Check if the current score is higher than the saved high score
        if (currentScore > hiscore)
        {
            // Save the new high score
            PlayerPrefs.SetInt("HiScore", currentScore);
            HiScoreText.text = "New High Score: " + currentScore;
        }
    }
}
