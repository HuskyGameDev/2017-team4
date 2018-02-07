using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemies;
    public Text enemyHealthDisplay;
    public Player player;

    private Enemy currentEnemy;
    private int currentEnemyHealth;

    // Use this for initialization
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {        
        currentEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
        currentEnemyHealth = currentEnemy.maxHealth;
        enemyHealthDisplay.text = currentEnemyHealth + "/" + currentEnemy.maxHealth;
    }

    /// <summary>
    /// Performs the enemy action.
    /// </summary>
    public void PerformEnemyAction()
    {
        player.DamagePlayer(currentEnemy.force);    
    }

    /// <summary>
    /// Damages the player.
    /// </summary>
    /// <param name="enemyForce">Enemy force.</param>
    /// <param name="enemyAccuracy">Enemy accuracy.</param>
    public void DamageEnemy(int force, int accuracy = 100)
    {
        currentEnemyHealth -= force * Random.Range(1, 15);
        if (currentEnemyHealth < 0)
        {
            Destroy(currentEnemy.gameObject);
            Invoke("SpawnEnemy", 5);
            enemyHealthDisplay.text = "DEAD";
            return;
        }
        enemyHealthDisplay.text = currentEnemyHealth + "/" + currentEnemy.maxHealth;
    }
}