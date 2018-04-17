using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // public variables to other gameobjects
    public Text scoreText;
    public Text scoreReqText;
    public Text songTitle;
    public LevelInfo info;
    public ResultsValues results;

    // keep track of current score
    private int score;

    // Use this for initialization
    void Start()
    {
        // unity errors if this isn't here
        if (info == null || scoreText == null || songTitle == null)
            return;
        scoreText.text = "Score: 00000000";
        scoreReqText.text = "/ " + info.GetSongScoreRequirement().ToString().PadLeft(8,'0');
        songTitle.text = info.GetSongTitle();
    }

    /// <summary>
    /// Increases the score.
    /// </summary>
    /// <param name="amount">Add Amount to current score.</param>
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString().PadLeft(8,'0');
        results.SetScore(score);
    }
}