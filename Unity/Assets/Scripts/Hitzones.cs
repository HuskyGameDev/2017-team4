using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitzones : MonoBehaviour
{
    private Queue<Note> noteQueue;
    public ScoreDisplay scoreDisplay;
    public ActionSuccess actionSuccess;

    // Use this for initialization
    void Start()
    {
        noteQueue = new Queue<Note>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AttemptHitNote(KeyCode.Q);
        if (Input.GetKeyDown(KeyCode.W))
            AttemptHitNote(KeyCode.W);
        if (Input.GetKeyDown(KeyCode.E))
            AttemptHitNote(KeyCode.E);
        if (Input.GetKeyDown(KeyCode.R))
            AttemptHitNote(KeyCode.R);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Note")
            noteQueue.Enqueue(other.gameObject.GetComponent<Note>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Note")
            noteQueue.Dequeue();
    }

    void AttemptHitNote(KeyCode key)
    {
        if (noteQueue.Count == 0)
            return;
        var note = noteQueue.Peek();
        if (note.GetNoteKey() == key)
        {
            scoreDisplay.IncreaseScore(1);
            actionSuccess.AdjustSuccessRate(1);
        }
        else
        {
            actionSuccess.AdjustSuccessRate(-1);
            // break combo
        }
        Destroy(note.gameObject);
    }
}