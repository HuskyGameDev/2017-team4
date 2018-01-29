using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitzone : MonoBehaviour
{
    public string key;
    public ScoreDisplay scoreDisplay;
    public ActionSuccess actionSuccess;
    private Queue<GameObject> noteQueue;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Note")
        {
            noteQueue.Enqueue(other.gameObject);
            //Debug.Log(noteQueue.Count);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Note")
        {
            noteQueue.Dequeue();
            //Debug.Log(noteQueue.Count);
        }
    }

    // Use this for initialization
    void Start()
    {
        noteQueue = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hit the first note in the queue
        if (Input.GetKeyDown(key))
        {
            if (noteQueue.Count == 0)
                return;
            var note = noteQueue.Peek();
            Destroy(note.gameObject);

            scoreDisplay.IncreaseScore(1);
            actionSuccess.AdjustSuccessRate(1);
        }
    }
}