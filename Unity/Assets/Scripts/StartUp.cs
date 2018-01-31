using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public AudioSource[] Titles;
    public LevelInfo Info;
    public Note[] Notes;
    public float maxSpawnTime;

	private int noteCount;
	private float noteSpeed;
    private float spawnTime;
    private AudioSource song;

    // Use this for initialization
    void Start()
    {
        Info.SetSongIndex(2); // use this line for testing
        song = Instantiate(Titles[Info.GetSongIndex()]);
        song.PlayDelayed(2.9F);

        float beatDelay = 60.0F / (float)Info.GetSongBpm();
        float noteDelay = 0.0F;

        noteCount = 134;
        noteSpeed = 2.5F;

        spawnTime = 0F;
        //InvokeRepeating("SpawnNotes", noteDelay, beatDelay);
    }

    void Update ()
    {
        
        spawnTime += Time.deltaTime;
        if (spawnTime >= maxSpawnTime && song.time < 126)
        {
            spawnTime = 0;
            SpawnNotes();
        }
        else
        {
            Application.Quit();
        }
    
    }


    void SpawnNotes()
    {Debug.Log(song.time);
        var note = Instantiate(Notes[Random.Range(0, 4)]);
        //var note = Instantiate(Notes[0]);
        note.SetSpeed(noteSpeed);
        noteCount--;
        if (noteCount <= 0)
            Destroy(this.gameObject);
    }
}