using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        highScoreText.SetText(PlayerPrefs.GetInt("HighScore").ToString());
        currentScoreText.SetText("0");
    }

    public void AddPoint()
    {
        currentScore++;
        currentScoreText.SetText(currentScore.ToString());

        if (currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
