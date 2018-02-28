using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsValues : MonoBehaviour {
	
	//Values of stats to display
	private int score;
	private int notesHit;
	private int enemiesKilled;
	private int damageDealt;
	private int damageTaken;

	/// <summary>
	/// Gets the score.
	/// </summary>
	/// <returns>The score.</returns>
	public int GetScore ()
	{
		return score;
	}

	/// <summary>
	/// Sets the score.
	/// </summary>
	/// <param name="_score">Score.</param>
	public void SetScore (int _score)
	{
		score = _score;
	}

	/// <summary>
	/// Gets the notes hit.
	/// </summary>
	/// <returns>The notes hit.</returns>
	public int GetNotesHit ()
	{
		return notesHit;
	}

	/// <summary>
	/// Sets the notes hit.
	/// </summary>
	/// <param name="_notesHit">Notes hit.</param>
	public void SetNotesHit (int _notesHit)
	{
		notesHit = _notesHit;
	}

	/// <summary>
	/// Gets the enemies killed.
	/// </summary>
	/// <returns>The enemies killed.</returns>
	public int GetEnemiesKilled ()
	{
		return enemiesKilled;
	}

	/// <summary>
	/// Sets the enemies killed.
	/// </summary>
	/// <param name="_enemiesKilled">Enemies killed.</param>
	public void SetEnemiesKilled (int _enemiesKilled)
	{
		enemiesKilled = _enemiesKilled;
	}

	/// <summary>
	/// Gets the damage dealt.
	/// </summary>
	/// <returns>The damage dealt.</returns>
	public int GetDamageDealt ()
	{
		return damageDealt;
	}

	/// <summary>
	/// Sets the damage dealt.
	/// </summary>
	/// <param name="_damageDealt">Damage dealt.</param>
	public void SetDamageDealt (int _damageDealt)
	{
		damageDealt = _damageDealt;
	}

	/// <summary>
	/// Gets the damage taken.
	/// </summary>
	/// <returns>The damage taken.</returns>
	public int GetDamageTaken ()
	{
		return damageTaken;
	}
	
	/// <summary>
	/// Sets the damage taken.
	/// </summary>
	/// <param name="_damageTaken">Damage taken.</param>
	public void SetDamageTaken (int _damageTaken)
	{
		damageTaken = _damageTaken;
	}
}
