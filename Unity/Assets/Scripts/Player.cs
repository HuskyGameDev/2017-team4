using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public ActionSwapper actionSwapper;
    public Text playerHealthDisplay;
    public EnemySpawner enemy;
    private Animator anim;
    public PlayerStats pStats;
    private int playerHealth;
	private ActionSuccess actionSuccess;
	private LevelInfo info;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //pStats = GetComponent<PlayerStats>();
        playerHealth = pStats.GetMaxHealth();
        playerHealthDisplay.text = playerHealth + "/" + pStats.GetMaxHealth();
    }
	
    // Update is called once per frame
    void Update()
    {
		
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
                enemy.DamageEnemy(pStats.GetForceStat());
                break;
            case 2:
                // evade
                //Debug.Log("Player evades...");
                anim.Play("PlayerEvade");
                break;
            default:
                // defend
                //Debug.Log("Player defends...");
                anim.Play("PlayerDefend");
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
		//Remove health
        //playerHealth -= enemyForce * Random.Range(1, 15);
        // TESTING ONLY
        if (playerHealth < 0)
            playerHealth = pStats.GetMaxHealth();
        // MAKE AN END GAME SENARIO HERE PLEASE
        // K THX
        playerHealthDisplay.text = playerHealth + "/" + pStats.GetMaxHealth();
    }


	//Calculate chance to evade
	private int CalculateEvasion()
	{
		int evade;

		switch (info.GetDifficulty()) 
		{
		case 0: 
			evade = actionSuccess.getActionSuccess(2); //Easy difficulty
			break;
		case 1:
			evade = actionSuccess.getActionSuccess(2) - Random.Range(0,15); //Normal difficulty
			break;
		case 2:
			evade = actionSuccess.getActionSuccess(2) - Random.Range(0,25); //Arcade difficulty
			break;
		}

		return Random.Range (0, 100) < evade;
	}


	//Calculate amount of damage for attack
	private int CalculateAttack()
	{
		int attack;
		int enemyResistance;

		attack = actionSuccess.getActionSuccess (1);
		enemyResistance = enemy.GetEnemyResistance ();

		return (attack / 5.0) + Random.Range (-enemyResistance, enemyResistance / 5.0);
	}

	//Calculate amount of damage to reduce for defend
	private int CalculateDefend(int potentialDamage)
	{
		int damageReduced;

		switch (info.GetDifficulty ()) 
		{
		case 0:
			damageReduced = actionSuccess.getActionSuccess(0) - Random.Range (0, 10) * potentialDamage; //Easy
			break;
		case 1:
			damageReduced = actionSuccess.getActionSuccess(0) - Random.Range (5, 25) * potentialDamage; //Normal
			break;
		case 2:
			damageReduced = actionSuccess.getActionSuccess(0) - Random.Range (10, 40) * potentialDamage; //Arcade
			break;
		}

		return damageReduced;
	}
}
