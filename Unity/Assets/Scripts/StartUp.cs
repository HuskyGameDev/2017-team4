﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public AudioSource[] Titles;
    public LevelInfo Info;
    public Note[] Notes;
    public ResultsValues results;
    public EndGame endGame;

    private int noteCount;
    //Number of notes in song
    private float noteSpeed;
    //Speed of notes falling
    private float spawnTime;
    //Current time between note spawns
    private AudioSource song;
    //Current song being played
    private float noteDelay;
    //Delay between note spawns

    public SpriteRenderer sprite;   // player's sprite renderer
    public PlayerStats pStats;      // player stats

    // Use this for initialization
    void Start()
    {
        // reset results
        results.ResetValues();

        //Get index of song
        if (Info.GetSongIndex() == 0) //use this line for testing
            Info.SetSongIndex(3);

        //Instantiate song from array of AudioSource type
        song = Instantiate(Titles[Info.GetSongIndex()]);

        //Delay song start
        song.PlayDelayed(2.9F);

        //Set delay in seconds between notes
        noteDelay = 60.0F / (float)Info.GetSongBpm();

        //Get note count
        //noteCount = 129;  //Silky Smooth
        //noteCount = 359;	//It's a Trap
        //noteCount = 321;	//Digital Demon
        noteCount = Info.GetNoteCount();
        noteSpeed = 2.5F;

        //Initialize time
        spawnTime = 0F;

        var menumusic = GameObject.Find("MenuMusic");
		if (menumusic != null)
			menumusic.GetComponent<AudioSource>().Stop();
	
		if (pStats.getCostume() != null)
        	sprite.sprite = pStats.getCostume();
    }

    //Call note spawn method according to noteDelay
    void Update()
    {
        // when there are no notes, and song is done
        if (noteCount <= 0 && !song.isPlaying)
        {
            endGame.EndSong();
            Destroy(this.gameObject);
        }

        //Increment time between last Update call
        spawnTime += Time.deltaTime;

        //Spawn a note and reset time counter when it is greater than
        //or equal to the specified delay
		if (spawnTime >= noteDelay && noteCount > 0)
        {
            spawnTime = 0;
            SpawnNotes();
        }
    }

    //Spawn notes
    void SpawnNotes()
    {
        //Spawn random note
        var note = Instantiate(Notes[Random.Range(0, 4)]);
        //Set note speed
        note.SetSpeed(noteSpeed);
        //Decrement from total note count
        noteCount--;
    }
}