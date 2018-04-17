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
        statCosts = new int[3] { 10, 10, 10 };

        statCostTexts[0].text = statCosts[0].ToString();
        statCostTexts[1].text = statCosts[1].ToString();
        statCostTexts[2].text = statCosts[2].ToString();

        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();
    }

    public void PurchaseStat(int statIndex)
    {
        var currentScore = playerStats.GetScore();
        if (currentScore < statCosts[statIndex])
            return;
        switch (statIndex)
        {            
            case 1:                
                // buy attack (force)                    
                playerStats.AdjustForceStat(1);
                break;
            case 2:
                // buy evasion (dexterity)
                playerStats.AdjustDexterityStat(1);
                break;
            default:
                // buy defense (resistance)
                playerStats.AdjustResistanceStat(1);
                break;
        }
        playerStats.AdjustScore(-statCosts[statIndex]);
        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();
    }
}