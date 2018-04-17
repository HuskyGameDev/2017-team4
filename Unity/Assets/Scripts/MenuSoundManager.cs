using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
	private static AudioSource forwardSound;
	private static AudioSource backwardSound;
    private static AudioSource menuMusic;
    private float playtime;

	// Use this for initialization
	void Start ()
	{
		var sounds = GameObject.FindGameObjectsWithTag ("PersistentMenuSound");
		// DFS - Ensure Forward is listed first
        foreach (var sound in sounds)
        {
            if (forwardSound == null && sound.name == "ForwardSound")
                forwardSound = sound.GetComponent<AudioSource>();
            else if (backwardSound == null && sound.name == "BackwardSound")
                backwardSound = sound.GetComponent<AudioSource>();
            else
                menuMusic = sound.GetComponent<AudioSource>();
        }
        // Menu scenes: 0,1,2,3,4
        // Non-menu:    5,6
        var index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		if (menuMusic != null && !menuMusic.isPlaying && index < 5)
            menuMusic.Play();
	}

	/// <summary>
	/// Plaies the forward sound.
	/// </summary>
	public void PlayForwardSound()
	{
		if (forwardSound != null)
			forwardSound.Play ();
	}

	/// <summary>
	/// Plaies the backward sound.
	/// </summary>
	public void PlayBackwardSound()
	{
		if (backwardSound != null)
			backwardSound.Play ();
	}
}