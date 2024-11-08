using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        GameManager.instance.playerScore = 0;
        GameManager.instance.UpdateHiScoreText();
        SceneManager.LoadScene("MainMenu");
    }
}


