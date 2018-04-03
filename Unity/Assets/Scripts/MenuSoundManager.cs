using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
	private AudioSource forwardSound;
	private AudioSource backwardSound;
    private AudioSource menuMusic;
    private float playtime;

	// Use this for initialization
	void Start ()
	{
		var sounds = GameObject.FindGameObjectsWithTag ("PersistentMenuSound");
		// DFS - Ensure Forward is listed first
		forwardSound = sounds [1].GetComponent<AudioSource>();
		backwardSound = sounds [2].GetComponent<AudioSource>();
        menuMusic = sounds [0].GetComponent<AudioSource>();

        // Menu scenes: 0,1,2,3,4
        // Non-menu:    5,6
        var index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (!menuMusic.isPlaying && index < 5)
            menuMusic.Play();
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