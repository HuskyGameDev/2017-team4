using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
	public Text songTitle;
    private int score;
	public LevelInfo info;

    // Use this for initialization
    void Start()
    {
		if (scoreText != null)
        	scoreText.text = "Score: 0";
		if (songTitle != null && info != null)		//Unity throws error if these aren't here
			songTitle.text = info.GetSongTitle();
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