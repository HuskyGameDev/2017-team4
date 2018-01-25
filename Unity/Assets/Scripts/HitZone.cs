using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
	public string key;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(key))
			Hit();		
	}

	void Hit()
	{
		//Debug.Log("You hit " + key);
	}
}
