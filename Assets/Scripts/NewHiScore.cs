using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewHiScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NewHiScoreMessageText;

    private int savedHiScore;
    private int currentScore;

    private void Start()
    {
        
        savedHiScore = PlayerPrefs.GetInt("HiScore", 0);
        currentScore = GameManager.instance.playerScore;

        
        NewHiScoreMessageText.gameObject.SetActive(false);

        
        if (currentScore > savedHiScore)
        {
            
            PlayerPrefs.SetInt("HiScore", currentScore);
            PlayerPrefs.Save();

            
            NewHiScoreMessageText.text = "NEW HISCORE! GOOD JOB";
            NewHiScoreMessageText.gameObject.SetActive(true);
        }
    }
}
