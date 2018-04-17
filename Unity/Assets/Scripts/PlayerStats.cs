using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static int score;
    static int maxHealth;
    static int force;
    static int res;
    static int dex;

    static List<int> purchasedCostumes;

    static Sprite costume;

    void Start()
    {
        score = 0;
        maxHealth = 999;
        force = 1;
        res = 1;
        dex = 1;
        purchasedCostumes = new List<int>();
        purchasedCostumes.Add (0);
        costume = new Sprite ();
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

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void AdjustMaxHealthStat(int amount)
    {
        maxHealth += amount;
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

    public bool checkPurchased(int key)
    {
        /*if (purchasedCostumes == null)
            Debug.Log ("List");
        if (key == null)
            Debug.Log ("Key");*/
        return purchasedCostumes.Contains (key);
    }

    public void purchase(int key) {
        purchasedCostumes.Add (key);
    }

    public void setCostume(Sprite newCostume)
    {
        costume = newCostume;
    }

    public Sprite getCostume()
    {
        return costume;
    }
}