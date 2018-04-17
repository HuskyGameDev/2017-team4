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
	public Text dialogueBox;

    private int[] statCosts;
	private Sprite tempSprite;

	public Image currentOutfit;
    
    // Use this for initialization
    void Start()
    {
		playerStats.AdjustScore(20);

		tempSprite = playerStats.getCostume();
		currentOutfit.sprite = tempSprite;
		dialogueBox.text = "Welcome to the Costume Shop!";
        scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();
    }

	public void setTempSprite (Sprite current)
	{
		tempSprite = current;
	}

	public void ButtonClick (int cost) {
		int temp = playerStats.GetScore () - cost;

		if (playerStats.checkPurchased (cost) == false) {
			if (temp < 0) {
				dialogueBox.text = "Sorry, not enough points.";
				return;
			}

			playerStats.purchase (cost);
			playerStats.AdjustScore (0 - cost);
			currentOutfit.sprite = tempSprite;
			playerStats.setCostume(tempSprite);
			dialogueBox.text = "Costume purchased successfully!";
		} else {
			currentOutfit.sprite = tempSprite;
			playerStats.setCostume(tempSprite);
			dialogueBox.text = "Costume changed.";
		}
		if (cost == 0){
			dialogueBox.text = "Back to basics!";
		}
		scoreDisplay.text = "Score: " + playerStats.GetScore().ToString();

	}
		
}