using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATB : MonoBehaviour
{
    public float maxFillTime;
    public GameObject fillBar;
    public UnityEvent OnFill;

    private float fillTime;

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
            OnFill.Invoke();
        }
        var currentFill = fillTime / maxFillTime;
        fillBar.transform.localScale = new Vector3(Mathf.Clamp(currentFill, 0, 1), 1, 0);
    }
}