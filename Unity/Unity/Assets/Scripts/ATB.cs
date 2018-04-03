using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATB : MonoBehaviour
{
	public float maxFillTime;
	public GameObject fillBar;
	public GameObject actionGradient;
	public UnityEvent OnFill;

	private float fillTime;

	// Use this for initialization
	void Start ()
	{
		fillTime = 0F;
		// start the fill bar at 0 %
		fillBar.transform.localScale = new Vector3 (0, 1, 1);
		if (actionGradient != null) // Unity spits out false errors without this
			actionGradient.transform.localScale = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{        
		fillTime += Time.deltaTime;
		if (fillTime >= maxFillTime) {
			fillTime = 0;
			OnFill.Invoke ();
		}
		var currentFill = fillTime / maxFillTime;
		fillBar.transform.localScale = new Vector3 (Mathf.Clamp (currentFill, 0, 1), 1, 0);
		var _scale = 0.5F + currentFill * 1.5F;
		if (actionGradient != null) // Unity spits out false errors without this			
			actionGradient.transform.localScale = new Vector3 (_scale, _scale, 0);
	}
}