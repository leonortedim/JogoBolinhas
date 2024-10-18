using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hiScoreText;

    void Start()
    {
        hiScoreText.text = $"HiScore: {PlayerPrefs.GetInt("HiScore", 0)}";
    }


}
