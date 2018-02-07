using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
	public AudioSource[] Titles;
	public LevelInfo Info;
	public Note[] Notes;

	private int noteCount;
	private float noteSpeed;
	private float spawnTime;
	private AudioSource song;
	private float beatDelay;

	// Use this for initialization
	void Start ()
	{
		if (Info.GetSongIndex () == 0) // use this line for testing
            Info.SetSongIndex (3);
		song = Instantiate (Titles [Info.GetSongIndex ()]);
		song.PlayDelayed (2.9F);

		beatDelay = 60.0F / (float)Info.GetSongBpm ();
		float noteDelay = 0.0F;

		//noteCount = 129;  //Silky Smooth
		//noteCount = 359;	//It's a Trap
		//noteCount = 321;	//Digital Demon
		noteCount = Info.GetNoteCount();
		noteSpeed = 2.5F;

		spawnTime = 0F;
	}

	//Call note spawn method according to beatDelay
	void Update ()
	{
		spawnTime += Time.deltaTime;
		if (spawnTime >= beatDelay) {
			spawnTime = 0;
			SpawnNotes ();
		} else {
			//Application.Quit ();
		}
		    
	}

	//Spawn notes
	void SpawnNotes ()
	{
		Debug.Log (noteCount);
		var note = Instantiate (Notes [Random.Range (0, 4)]);
		//var note = Instantiate(Notes[0]);
		note.SetSpeed (noteSpeed);
		noteCount--;
		if (noteCount <= 0)
			Destroy (this.gameObject);
	}
}