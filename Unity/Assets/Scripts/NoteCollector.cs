using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollector : MonoBehaviour
{
    public ActionSuccess actionSuccess;
    public Animator hitzoneAnim;

    void OnTriggerEnter2D(Collider2D other)
    {
		/*
		if (other.name == "ENote")
			StartUp.activeLanes [2] = false;
		else if (other.name == "Enote_long")
			StartUp.activeLanes [2] = false;
		else if (other.name == "QNote")
			StartUp.activeLanes [0] = false;
		else if (other.name == "Qnote_long")
			StartUp.activeLanes [0] = false;
		else if (other.name == "RNote")
			StartUp.activeLanes [3] = false;
		else if (other.name == "Rnote_long")
			StartUp.activeLanes [3] = false;
		else if (other.name == "WNote")
			StartUp.activeLanes [1] = false;
		else if (other.name == "Wnote_long")
			StartUp.activeLanes [1] = false;
			*/
		
        if (other.tag == "Note")
            Destroy(other.gameObject);
        hitzoneAnim.Play("miss");
        actionSuccess.AdjustSuccessRate(-5);
    }
}
