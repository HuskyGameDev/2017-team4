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

    // Use this for initialization
    void Start()
    {
        if (Info.GetSongIndex() == 0) // use this line for testing
            Info.SetSongIndex(2);
        var song = Instantiate(Titles[Info.GetSongIndex()]);
        song.PlayDelayed(2.1F);

        float beatDelay = 60.0F / (float)Info.GetSongBpm();
        float noteDelay = 0.0F;

        noteCount = 300;
        noteSpeed = 2.5F;

        InvokeRepeating("SpawnNotes", noteDelay, beatDelay);
    }

    void SpawnNotes()
    {
        var note = Instantiate(Notes[Random.Range(0, 4)]);
        //var note = Instantiate(Notes[0]);
        note.SetSpeed(noteSpeed);
        noteCount--;
        if (noteCount <= 0)
            Destroy(this.gameObject);
    }
}