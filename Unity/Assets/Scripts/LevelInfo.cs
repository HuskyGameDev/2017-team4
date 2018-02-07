using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    // Difficulty:
    //  0 = easy
    //  1 = normal
    //  2 = arcade
    static int difficulty;
    // Title:
    //  0 = Theme of Digital Demon™
    //  1 = Silky Smooth Idea
    //  2  = It's A Trap
    static int titleIndex;


    /// <summary>
    /// Gets the difficulty.
    /// </summary>
    /// <returns>The difficulty.</returns>
    public int GetDifficulty()
    {
        return difficulty;
    }

    /// <summary>
    /// Sets the difficulty.
    /// </summary>
    /// <param name="_difficulty">Difficulty.</param>
    public void SetDifficulty(int _difficulty)
    {
        difficulty = _difficulty;
    }

    /// <summary>
    /// Gets the title.
    /// </summary>
    /// <returns>The title.</returns>
    public int GetSongIndex()
    {
        return titleIndex;
    }

    /// <summary>
    /// Sets the title.
    /// </summary>
    /// <param name="_title">Title.</param>
    public void SetSongIndex(int _titleIndex)
    {
        titleIndex = _titleIndex;
    }

    /// <summary>
    /// Gets the song bpm for the current index.
    /// </summary>
    /// <returns>The song bpm.</returns>
    public int GetSongBpm()
    {
        switch (titleIndex)
        {
            case 1:
                // Theme of DD
                return 100;
            case 2:
                // Silky
                return 60;
            case 3:
                // Trap
                return 120;
            default:
                return 0;
        }
    }

	/// <summary>
	/// Gets the number of notes for the current index.
	/// </summary>
	/// <returns>The number of notes in the song.</returns>
	public int GetNoteCount()
	{
		switch (titleIndex)
		{
		case 1:
			// Theme of DD
			return 321;
		case 2:
			// Silky
			return 129;
		case 3:
			// Trap
			return 359;
		default:
			return 0;
		}
	}
}