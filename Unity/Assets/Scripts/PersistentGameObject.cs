using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentGameObject : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (this.gameObject);
		// Prevent these sounds from being duplicated
        if (FindObjectsOfType (GetType ()).Length > 3)
            Destroy (this.gameObject);
	}
}