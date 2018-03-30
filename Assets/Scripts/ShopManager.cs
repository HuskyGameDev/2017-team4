using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // The stats associated with actions
    // 0 - Defense (Resistance)
    // 1 - Attack  (Force)
    // 2 - Evade   (Dexterity)
    public Text[] statCostTexts;
    public PlayerStats playerStats;
    public Text scoreDisplay;

    private int[] statCosts;
    
    // Use this for initialization
    void Start()
    {
        playerStats.AdjustScore(100);

        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();
    }

    public void PurchaseStat(int statIndex)
    {
        var currentScore = playerStats.GetScore();

        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();
    }
}