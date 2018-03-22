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
    public ActionSuccess actionSuccess;
    public LevelInfo info;

    // action stock variables
    public SpriteRenderer[] stockIcons;
    public Sprite evadeIcon;
    public Sprite defendIcon;

    private Queue<string> actionStock;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //pStats = GetComponent<PlayerStats>();
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
                enemy.DamageEnemy(pStats.GetForceStat());
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
        //Remove health
		
        //player can evade
        if (actionStock.Count > 0 && actionStock.Peek().Equals("evade"))
        {
            // calculate chance of successful evasion
            if (!CalculateEvasion())
                playerHealth -= potentialDamage * Random.Range(1, 15);
            else
                anim.Play("PlayerEvade");
            DequeueStockIcons();
        }
		//player can defend
		else if (actionStock.Count > 0 && actionStock.Peek().Equals("defend"))
        { 							//Determine damage						//Damage to reduce
            playerHealth -= potentialDamage * Random.Range(1, 15) * (100 - CalculateDefend(potentialDamage)) / 100;
            anim.Play("PlayerDefend");
            DequeueStockIcons();
        }
		//player in attack or stock is empty
		else
            playerHealth -= potentialDamage * Random.Range(1, 15);

        //playerHealth -= potentialDamage * Random.Range(1, 15);
        // TESTING ONLY
        if (playerHealth < 0)
            playerHealth = pStats.GetMaxHealth();
        // MAKE AN END GAME SENARIO HERE PLEASE
        // K THX
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
    private int CalculateAttack()
    {
        var attack = actionSuccess.getActionSuccess(1);
        var enemyResistance = enemy.GetEnemyResistance();

        return (int)(attack / 5.0F + Random.Range(-enemyResistance, enemyResistance / 5.0F));
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