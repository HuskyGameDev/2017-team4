using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static int score;
    static int force;
    static int res;
    static int dex;

    void Start()
    {
        score = 0;
        force = 0;
        res = 0;
        dex = 0;
    }

    /// <summary>
    /// Gets the score.
    /// </summary>
    /// <returns>The score.</returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// Adjusts the score.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void AdjustScore(int amount)
    {
        score += amount;
    }

    /// <summary>
    /// Gets the force stat.
    /// </summary>
    /// <returns>The force stat.</returns>
    public int GetForceStat()
    {
        return force;
    }

    /// <summary>
    /// Adjusts the force stat.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void AdjustForceStat(int amount)
    {
        force += amount;
    }

    /// <summary>
    /// Gets the resistance stat.
    /// </summary>
    /// <returns>The resistance stat.</returns>
    public int GetResistanceStat()
    {
        return res;
    }

    /// <summary>
    /// Adjusts the resistance stat.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void AdjustResistanceStat(int amount)
    {
        res += amount;
    }

    /// <summary>
    /// Gets the dexterity stat.
    /// </summary>
    /// <returns>The dexterity stat.</returns>
    public int GetDexterityStat()
    {
        return dex;
    }

    /// <summary>
    /// Adjusts the dexterity stat.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void AdjustDexterityStat(int amount)
    {
        dex += amount;
    }
}