using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitzones : MonoBehaviour
{
    private Queue<Note> noteQueue;
    private Animator anim;
    public ScoreDisplay scoreDisplay;
    public ActionSuccess actionSuccess;
	public AudioSource noteSuccess;
	public AudioSource noteFail;

    // Use this for initialization
    void Start()
    {
        noteQueue = new Queue<Note>();
        anim = GetComponent<Animator>();
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

            if (acc <= 0.4F)
            {
                anim.Play("bad");
                scoreDisplay.IncreaseScore(10);
                actionSuccess.AdjustSuccessRate(-1);
            }
            if (acc > 0.4F && acc <= 0.75F)
            {
                anim.Play("okay");
                scoreDisplay.IncreaseScore(25);
                actionSuccess.AdjustSuccessRate(0);
            }
            if (acc > 0.75F && acc <= 0.9F)
            {
                anim.Play("good");
                scoreDisplay.IncreaseScore(50);
                actionSuccess.AdjustSuccessRate(1);
            }
            if (acc > 0.9F)
			{
                anim.Play("perfect");
                scoreDisplay.IncreaseScore(100);
                actionSuccess.AdjustSuccessRate(2);
            }
			noteSuccess.Play ();
        }
        else
        {
			noteFail.Play ();
            anim.Play("miss");
            actionSuccess.AdjustSuccessRate(-5);
            // break combo
        }
        Destroy(note.gameObject);
    }
}