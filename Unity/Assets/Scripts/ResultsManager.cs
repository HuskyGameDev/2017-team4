using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour {

	public Text scoreText;			//Show score value
	public Text noteText;			//Show number of notes hit
	public Text enemyText;			//Show number of enemies killed
	public Text dealtText;			//Show amount of damage dealt
	public Text takenText;			//Show amount of damage taken
	private ResultsValues results;

	/// <summary>
	/// Set value of statistics Text elements
	/// </summary>
	void Start () {
		results = this.gameObject.GetComponent<ResultsValues>();
		scoreText.text = "Score: " + results.GetScore().ToString();
		noteText.text = "Notes Hit: " + results.GetNotesHit().ToString();
		enemyText.text = "Enemies Killed: " + results.GetEnemiesKilled().ToString();
		dealtText.text = "Damage Dealt: " + results.GetDamageDealt().ToString();
		takenText.text = "Damage Taken: " + results.GetDamageTaken().ToString();
	}
}