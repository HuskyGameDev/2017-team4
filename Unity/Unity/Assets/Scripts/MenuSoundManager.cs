using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
	private AudioSource forwardSound;
	private AudioSource backwardSound;

	// Use this for initialization
	void Start ()
	{
		var sounds = GameObject.FindGameObjectsWithTag ("PersistentMenuSound");
		// DFS - Ensure Forward is listed first
		forwardSound = sounds [0].GetComponent<AudioSource>();
		backwardSound = sounds [1].GetComponent<AudioSource>();
	}

	/// <summary>
	/// Plaies the forward sound.
	/// </summary>
	public void PlayForwardSound()
	{
		forwardSound.Play ();
	}

	/// <summary>
	/// Plaies the backward sound.
	/// </summary>
	public void PlayBackwardSound()
	{
		backwardSound.Play ();
	}
}