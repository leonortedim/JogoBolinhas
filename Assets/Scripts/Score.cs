using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public TMPro.TextMeshProUGUI scoretext;
    [SerializeField] public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoretext.text = "Score: " + currentScore;
    }
    public void ChangeScore()
    {
        currentScore += 1;
        scoretext.text = "Score: " + currentScore;
    }
}
