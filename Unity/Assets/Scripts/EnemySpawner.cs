﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    // list of enemy prefabs
    public Enemy[] enemies;

    public Text enemyHealthDisplay;
    public Player player;
    public ResultsValues results;

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
    /// Damages the enemy.
    /// </summary>
    /// <param name="force">Player force.</param>
    /// <param name="accuracy">Accuracy of action.</param>
    public void DamageEnemy(int force, int accuracy = 100)
    {
        currentEnemyHealth -= force;
        results.SetDamageDealt(force + results.GetDamageDealt());
        if (currentEnemyHealth < 0)
        {
            Destroy(currentEnemy.gameObject);
            results.SetEnemiesKilled(results.GetEnemiesKilled() + 1);
            Invoke("SpawnEnemy", 5);
            enemyHealthDisplay.text = "DEAD";
            return;
        }
        enemyHealthDisplay.text = currentEnemyHealth + "/" + currentEnemy.maxHealth;
    }

    public int GetEnemyResistance()
    {
        return currentEnemy.resistance;
    }
}