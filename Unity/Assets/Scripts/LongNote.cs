using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour {
	private Queue<Note> noteQueue;
	private Animator anim;
	public ScoreDisplay scoreDisplay;
	public ActionSuccess actionSuccess;
	private float timePressed;
	private float timeStartPressed;
	private bool heldNote;

	// Use this for initialization
	void Start()
	{
		Debug.Log ("Started longnote script");
		noteQueue = new Queue<Note>();
		anim = GetComponent<Animator>();
		timePressed = 0.0F;
		timeStartPressed = 0.0F;
		heldNote = false;
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
	
	// Update is called once per frame
	void Update () {
		if (noteQueue.Count == 0)
			return;
		var note = noteQueue.Peek ();
		var acc = (1.28F - Mathf.Abs(note.gameObject.transform.position.y - (-0.67F))) / 1.28;

		if (note.GetNoteKey ().ToString () == "Q" ||
			note.GetNoteKey ().ToString () == "W" ||
			note.GetNoteKey ().ToString () == "E" ||
			note.GetNoteKey ().ToString () == "R") {
			return;
		}

		if (note.GetNoteKey ().ToString() == "A" ||
			note.GetNoteKey ().ToString() == "S" ||
			note.GetNoteKey ().ToString() == "D" ||
			note.GetNoteKey ().ToString() == "F") {

			if (Input.GetKeyDown (KeyCode.Q)) {
				if (acc >= 0.4) {
					note.SetSpeed (0.0F);
					timeStartPressed = Time.time;
					heldNote = true;
				}
			}
			if (Input.GetKeyUp (KeyCode.Q)) {
				timePressed = Time.time - timeStartPressed;
				Destroy(note.gameObject);
				heldNote = false;
				anim.Play("miss");
				actionSuccess.AdjustSuccessRate(-5);
			}
				
			if (Input.GetKeyDown (KeyCode.W)) {
				if (acc >= 0.4) {
					note.SetSpeed (0.0F);
					timeStartPressed = Time.time;
					heldNote = true;
				}
			}
			if (Input.GetKeyUp (KeyCode.W)) {
				timePressed = Time.time - timeStartPressed;
				Destroy(note.gameObject);
				heldNote = false;
				anim.Play("miss");
				actionSuccess.AdjustSuccessRate(-5);
			}


			if (Input.GetKeyDown (KeyCode.E)) {
				if (acc >= 0.4) {
					note.SetSpeed (0.0F);
					timeStartPressed = Time.time;
					heldNote = true;
				}
			}
			if (Input.GetKeyUp (KeyCode.E)) {
				timePressed = Time.time - timeStartPressed;
				Destroy(note.gameObject);
				heldNote = false;
				anim.Play("miss");
				actionSuccess.AdjustSuccessRate(-5);
			}


			if (Input.GetKeyDown (KeyCode.R)) {
				if (acc >= 0.4) {
					note.SetSpeed (0.0F);
					timeStartPressed = Time.time;
					heldNote = true;
				}
			}
			if (Input.GetKeyUp (KeyCode.R)) {
				timePressed = Time.time - timeStartPressed;
				Destroy(note.gameObject);
				heldNote = false;
				anim.Play("miss");
				actionSuccess.AdjustSuccessRate(-5);
			}

			if (heldNote) {
				timePressed = Time.time - timeStartPressed;
				if (timePressed >= 0.4F) {
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
					Destroy (note.gameObject);
					heldNote = false;
				}
			}
		}
	}
}
