using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
	public AudioSource[] Titles;
	public LevelInfo Info;
	public Note[] Notes;

	private int noteCount;		//Number of notes in song
	private float noteSpeed;	//Speed of notes falling
	private float spawnTime;	//Current time between note spawns
	private AudioSource song;	//Current song being played
	private float noteDelay;	//Delay between note spawns 

	private float longDelay;
	private bool[] activeLanes = { false, false, false, false };

	// Use this for initialization
	void Start ()
	{
		//Get index of song
		if (Info.GetSongIndex () == 0) //use this line for testing
            Info.SetSongIndex (3);

		//Instantiate song from array of AudioSource type
		song = Instantiate (Titles [Info.GetSongIndex ()]);

		//Delay song start
		song.PlayDelayed (2.9F); 

		//Set delay in seconds between notes
		noteDelay = 60.0F / (float)Info.GetSongBpm ();
		longDelay = 3.0F;

		//Get note count
			//noteCount = 129;  //Silky Smooth
			//noteCount = 359;	//It's a Trap
			//noteCount = 321;	//Digital Demon
		noteCount = Info.GetNoteCount();
		noteSpeed = 2.5F;

		//Initialize time
		spawnTime = 0F;
	}

	//Call note spawn method according to noteDelay
	void Update ()
	{
		//Increment time between last Update call
		spawnTime += Time.deltaTime;

		//Spawn a note and reset time counter when it is greater than
		//or equal to the specified delay
		if (spawnTime >= noteDelay) {
			spawnTime = 0;
			if (Random.Range (0, 2) == 0) {
				SpawnNotes ();
			} else {
				SpawnLongNotes ();
			}
		} else {
			//Application.Quit ();
		}
		    
	}

	//Spawn notes
	void SpawnNotes ()
	{
		//Spawn random note
		int noteIndex = Random.Range (0, 4);
		if (activeLanes [noteIndex] == true) {
			return;
		}
		var note = Instantiate (Notes [noteIndex]);
		activeLanes [noteIndex] = true;

		//Set note speed
		note.SetSpeed (noteSpeed);

		//Decrement from total note count
		noteCount--;
		if (noteCount <= 0) {
			Destroy (this.gameObject);
			activeLanes [noteIndex] = false;
		}
	}

	void SpawnLongNotes ()
	{
		int noteIndex = Random.Range (4, 8);
		var note = Instantiate (Notes [noteIndex]);
		activeLanes [noteIndex - 4] = true;

		note.SetSpeed (noteSpeed);

		noteCount--;
		if (noteCount <= 0) {
			Destroy (this.gameObject);
			activeLanes [noteIndex] = false;
		}
	}
}