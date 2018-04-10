using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	// action managers for current action and effectiveness
	public ActionSwapper actionSwapper;
	public ActionSuccess actionSuccess;
	// enemy manager (to reference current enemy)
	public EnemySpawner enemy;
	// animator on this player object
	private Animator anim;
	// object holding player stats
	public PlayerStats pStats;
	// players current health
	private int playerHealth;
	public Text playerHealthDisplay;
	// info for current song (for difficulty)
	public LevelInfo info;
	// action stock variables
	public SpriteRenderer[] stockIcons;
	public Sprite evadeIcon;
	public Sprite defendIcon;
	// queue for stocked actions (eva & def)
	private Queue<string> actionStock;
	// result values for accumlating total values
	public ResultsValues results;
	// sounds for each player action
	public AudioSource[] actionSounds;
	//Display damage text
	public Text playerDamageDisplay;
	public Text enemyDamageDisplay;
	private Animator pDamageTextAnim;
	private Animator eDamageTextAnim;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		pDamageTextAnim = playerDamageDisplay.GetComponent<Animator>();
		eDamageTextAnim = enemyDamageDisplay.GetComponent<Animator>();
		playerHealth = pStats.GetMaxHealth();
		playerHealthDisplay.text = playerHealth + "/" + pStats.GetMaxHealth();
		actionStock = new Queue<string>();
	}

    /// <summary>
    /// Performs the whichever action is currently focused on.
    /// </summary>
    public void PerformAction()
    {
        switch (actionSwapper.GetActionIndex())
        {
            case 1:
                // attack
                //Debug.Log("Player attacks...");
                anim.Play("PlayerAttack");
                actionSounds[1].Play();
                enemy.DamageEnemy(CalculateAttack());
                break;
            case 2:
                // evade
                //Debug.Log("Player evades...");
                if (actionStock.Count < 3)
                {
                    stockIcons[actionStock.Count].sprite = evadeIcon;
                    actionStock.Enqueue("evade");
                    //Debug.Log("add evade");
                }
                break;
            default:
                // defend
                //Debug.Log("Player defends...");
                if (actionStock.Count < 3)
                {
                    stockIcons[actionStock.Count].sprite = defendIcon;
                    actionStock.Enqueue("defend");
                    //Debug.Log("add defend");
                }
                break;
        }
    }

    /// <summary>
    /// Damages the player.
    /// </summary>
    /// <param name="enemyForce">Enemy force.</param>
    /// <param name="enemyAccuracy">Enemy accuracy.</param>
    public void DamagePlayer(int potentialDamage)
    {
        var trueDamage = 0;
        // player can evade
        if (actionStock.Count > 0 && actionStock.Peek().Equals("evade"))
        {
            // calculate chance of successful evasion
            if (!CalculateEvasion())
                trueDamage = potentialDamage * Random.Range(1, 15);
            else
            {				
                anim.Play("PlayerEvade");
                actionSounds[2].Play();
            }
            DequeueStockIcons();
        }
		// player can defend
		else if (actionStock.Count > 0 && actionStock.Peek().Equals("defend"))
        {   
            // damage - shielded amount
            trueDamage = potentialDamage * Random.Range(1, 15) * (100 - CalculateDefend(potentialDamage)) / 100;
            anim.Play("PlayerDefend");
            actionSounds[0].Play();
            DequeueStockIcons();
        }
		// player has no stocked actions
		else
            trueDamage = potentialDamage * Random.Range(1, 15);
        playerHealth -= trueDamage;
        results.SetDamageTaken(trueDamage + results.GetDamageTaken());

		//Set damage taken text
		playerDamageDisplay.text = trueDamage.ToString();
		pDamageTextAnim.Play("showDamage");

		// for now, reset player health if killed
		if (playerHealth < 0)
			playerHealth = pStats.GetMaxHealth();
		// set health text
		playerHealthDisplay.text = playerHealth + "/" + pStats.GetMaxHealth();
	}
        
    //Calculate chance to evade
    private bool CalculateEvasion()
    {
        int evade;
        // evasion forumla varies on diffuculty
        switch (info.GetDifficulty())
        {
            case 1:
                evade = actionSuccess.getActionSuccess(2) - Random.Range(0, 15); //Normal difficulty
                break;
            case 2:
                evade = actionSuccess.getActionSuccess(2) - Random.Range(0, 25); //Arcade difficulty
                break;
            default:
                evade = actionSuccess.getActionSuccess(2); //Easy difficulty
                break;
        }
        return Random.Range(0, 100) < evade;
    }

	//Calculate amount of damage for attack
	private int CalculateAttack ()
	{
		var attack = actionSuccess.getActionSuccess (1);
		var enemyResistance = enemy.GetEnemyResistance ();
		// return damage amount, but don't heal the enemy!
		var rtn = (int)(attack / 5.0F + Random.Range (-enemyResistance, enemyResistance / 5.0F));

		//Set damage given text
		if (enemy.IsEnemyAlive () && rtn >= 0) 
		{
			enemyDamageDisplay.text = rtn.ToString ();
			eDamageTextAnim.Play ("showDamage");
		}
		return rtn < 0 ? rtn : 0;
	}

    //Calculate amount of damage to reduce for defend
    private int CalculateDefend(int potentialDamage)
    {
        int damageReduced;
        // defense forumla varies on difficulty
        switch (info.GetDifficulty())
        {
            case 1:
                damageReduced = actionSuccess.getActionSuccess(0) - Random.Range(5, 25) * potentialDamage; //Normal
                break;
            case 2:
                damageReduced = actionSuccess.getActionSuccess(0) - Random.Range(10, 40) * potentialDamage; //Arcade
                break;
            default:
                damageReduced = actionSuccess.getActionSuccess(0) - Random.Range(0, 10) * potentialDamage; //Easy
                break;
        }
        return damageReduced;
    }

    /// <summary>
    /// Dequeues the stock icons.
    /// </summary>
    private void DequeueStockIcons()
    {
        stockIcons[0].sprite = stockIcons[1].sprite;
        stockIcons[1].sprite = stockIcons[2].sprite;
        stockIcons[2].sprite = null;
        actionStock.Dequeue();
    }
}