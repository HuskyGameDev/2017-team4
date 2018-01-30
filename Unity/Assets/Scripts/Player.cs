using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ActionSwapper actionSwapper;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }


    /// <summary>
    /// Performs the whichever action is currently focused on.
    /// </summary>
    public void PerformAction()
    {
        switch (actionSwapper.GetActionIndex())
        {
            case 1:
                // attack
                Debug.Log("Player attacks...");
                break;
            case 2:
                // evade
                Debug.Log("Player evades...");
                break;
            default:
                // defend
                Debug.Log("Player defends...");
                break;
        }
    }
}
