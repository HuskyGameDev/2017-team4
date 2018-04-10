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

	// Use this for initialization
	void Start()
	{
		Debug.Log ("Started longnote script");
		noteQueue = new Queue<Note>();
		anim = GetComponent<Animator>();
		timePressed = 0.0F;
		timeStartPressed = 0.0F;
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

		if (Input.GetKeyDown (KeyCode.Q)) {
			if (acc >= 0.4) {
				note.SetSpeed (0.0F);
				Debug.Log ("Started Pressing note: " + note.GetNoteKey());
				timeStartPressed = Time.time;
			}
		}
		if (Input.GetKeyUp (KeyCode.Q)) {
			timePressed = Time.time - timeStartPressed;
			Debug.Log ("Released note: " + note.GetNoteKey() + " timePressed: " + timePressed);
			Destroy(note.gameObject);
		}


		if (Input.GetKeyDown (KeyCode.W)) {
			if (acc >= 0.4) {
				note.SetSpeed (0.0F);
				Debug.Log ("Started Pressing note: " + note.GetNoteKey());
				timeStartPressed = Time.time;
			}
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			timePressed = Time.time - timeStartPressed;
			Debug.Log ("Released note: " + note.GetNoteKey() + " timePressed: " + timePressed);
			Destroy(note.gameObject);
		}


		if (Input.GetKeyDown (KeyCode.E)) {
			if (acc >= 0.4) {
				note.SetSpeed (0.0F);
				Debug.Log ("Started Pressing note: " + note.GetNoteKey());
				timeStartPressed = Time.time;
			}
		}
		if (Input.GetKeyUp (KeyCode.E)) {
			timePressed = Time.time - timeStartPressed;
			Debug.Log ("Released note: " + note.GetNoteKey() + " timePressed: " + timePressed);
			Destroy(note.gameObject);
		}


		if (Input.GetKeyDown (KeyCode.R)) {
			if (acc >= 0.4) {
				note.SetSpeed (0.0F);
				Debug.Log ("Started Pressing note: " + note.GetNoteKey());
				timeStartPressed = Time.time;
			}
		}
		if (Input.GetKeyUp (KeyCode.R)) {
			timePressed = Time.time - timeStartPressed;
			Debug.Log ("Released note: " + note.GetNoteKey() + " timePressed: " + timePressed);
			Destroy(note.gameObject);
		}


	}
}
