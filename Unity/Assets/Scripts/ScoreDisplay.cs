using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text scoreText;
    private int score;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: 0";
    }

    /// <summary>
    /// Increases the score.
    /// </summary>
    /// <param name="amount">Add Amount to current score.</param>
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}