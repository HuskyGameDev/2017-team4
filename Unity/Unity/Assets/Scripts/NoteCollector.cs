using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollector : MonoBehaviour
{
    public ActionSuccess actionSuccess;
    public Animator hitzoneAnim;
    public AudioSource missSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Note")
            Destroy(other.gameObject);
        hitzoneAnim.Play("miss");
        missSound.Play();
        actionSuccess.AdjustSuccessRate(-5);
    }
}
