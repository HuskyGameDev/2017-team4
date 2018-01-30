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
            var acc = (1.28F - Mathf.Abs(note.gameObject.transform.position.y - (-0.67F))) / 1.28;

            if (acc <= 0.25F)
            {
                //Debug.Log("BAD");
                scoreDisplay.IncreaseScore(10);
                actionSuccess.AdjustSuccessRate(-1);
            }
            if (acc > 0.25F && acc <= 0.5F)
            {
                //Debug.Log("OKAY");
                scoreDisplay.IncreaseScore(25);
                actionSuccess.AdjustSuccessRate(0);
            }
            if (acc > 0.5F && acc <= 0.8F)
            {
                //Debug.Log("GOOD");
                scoreDisplay.IncreaseScore(50);
                actionSuccess.AdjustSuccessRate(1);
            }
            if (acc > 0.8F)
            {
                //Debug.Log("PERFECT");
                scoreDisplay.IncreaseScore(100);
                actionSuccess.AdjustSuccessRate(2);
            }
        }
        else
        {
            actionSuccess.AdjustSuccessRate(-2);
            // break combo
        }
        Destroy(note.gameObject);
    }
}