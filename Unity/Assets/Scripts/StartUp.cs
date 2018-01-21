﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public AudioSource[] Titles;
    public LevelInfo Info;
    public Note[] Notes;

    private int noteCount;
    private float noteSpeed;

    // Use this for initialization
    void Start()
    {
        var song = Instantiate(Titles[Info.GetSongIndex()]);
        //var song = Instantiate(Titles[2]); // use this line for testing individual songs
        song.PlayDelayed(3);

        float beatDelay = 60.0F / (float)Info.GetSongBpm();
        float noteDelay = 0.0F;

        noteCount = 300;
        noteSpeed = 2.5F;

        InvokeRepeating("SpawnNotes", noteDelay, beatDelay);
    }

    void SpawnNotes()
    {
        var note = Instantiate(Notes[Random.Range(0, 4)]);
        note.SetSpeed(noteSpeed);
        noteCount--;
        if (noteCount <= 0)
            Destroy(this.gameObject);
    }
}