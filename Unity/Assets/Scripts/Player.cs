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
	public AudioSource evasionSound;
	public AudioSource attackSound;
	public AudioSource defenseSound;

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
				anim.Play ("PlayerAttack");
				enemy.DamageEnemy (pStats.GetForceStat ());
				attackSound.Play ();
                break;
			case 2:
                // evade
                //Debug.Log("Player evades...");
				anim.Play ("PlayerEvade");
				evasionSound.Play ();
                break;
			default:
                // defend
                //Debug.Log("Player defends...");
				anim.Play ("PlayerDefend");
				defenseSound.Play ();
                break;
        }
    }

    /// <summary>
    /// Damages the player.
    /// </summary>
    /// <param name="enemyForce">Enemy force.</param>
    /// <param name="enemyAccuracy">Enemy accuracy.</param>
    public void DamagePlayer(int enemyForce, int enemyAccuracy = 100)
    {
        playerHealth -= enemyForce * Random.Range(1, 15);
        // TESTING ONLY
        if (playerHealth < 0)
            playerHealth = pStats.GetMaxHealth();
        // MAKE AN END GAME SENARIO HERE PLEASE
        // K THX
        playerHealthDisplay.text = playerHealth + "/" + pStats.GetMaxHealth();
    }
}
