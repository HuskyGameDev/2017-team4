using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static int score;
    static int force;
    static int res;
    static int dex;

    void Awake()
    {
        score = 1000;
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
    /// Sets the score.
    /// </summary>
    /// <param name="_score">New Score.</param>
    public void SetScore(int _score)
    {
        score = _score;
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
    /// Sets the force stat.
    /// </summary>
    /// <param name="_force">New Force.</param>
    public void SetForceStat(int _force)
    {
        force = _force;
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
    /// Sets the resistance stat.
    /// </summary>
    /// <param name="_res">New Res.</param>
    public void SetResistanceStat(int _res)
    {
        res = _res;
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
    /// Sets the dexterity stat.
    /// </summary>
    /// <param name="_dex">New Dex.</param>
    public void SetDexterityStat(int _dex)
    {
        dex = _dex;
    }
}