using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATB : MonoBehaviour
{
    public float maxFillTime;
    private float fillTime;
    public GameObject fillBar;

    // Use this for initialization
    void Start()
    {
        fillTime = 0F;
        // start the fill bar at 0 %
        fillBar.transform.localScale = new Vector3(0, 1, 1);
    }
	
    // Update is called once per frame
    void Update()
    {        
        fillTime += Time.deltaTime;
        if (fillTime >= maxFillTime)
        {
            fillTime = 0;
            // do other crazy stuff here
            // such as performing actions
        }
        var currentFill = fillTime / maxFillTime;
        fillBar.transform.localScale = new Vector3(Mathf.Clamp(currentFill, 0, 1), 1, 0);
    }
}