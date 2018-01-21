using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    /// <summary>
    /// Sets the speed of the note.
    /// </summary>
    /// <param name="_speed">Speed.</param>
    public void SetSpeed(float speed)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0.0F, -speed);
    }
}