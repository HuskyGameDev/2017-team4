using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public Text scoreDisplay;

    
    // Use this for initialization
    void Start()
    {
        playerStats.AdjustScore(100);

        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();

    }


	public void ButtonPlayerClick(int costumeCost)
	{
		if(playerStats.boughtCostume(costumeCost.ToString()) == true)
		{
			return;
		}
		else
		{
			playerStats.buyCostume (costumeCost.ToString());
		}		

		if (checkCost (costumeCost) == true) 
		{
			PurchaseCostume (costumeCost);
		}

	}

	private bool checkCost(int cost)
	{
		bool bought = false;
		var currentScore = playerStats.GetScore();
		if ((currentScore - cost) >= 0) 
		{
			bought = true;
		}
		return bought;
	}


	private void PurchaseCostume(int cost)
    {

		playerStats.AdjustScore (0-cost);

        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();

    }

}