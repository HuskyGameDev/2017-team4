using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ActionSwapper actionSwapper;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
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
                //Debug.Log("Player attacks...");
                anim.Play("PlayerAttack");
                break;
            case 2:
                // evade
                //Debug.Log("Player evades...");
                anim.Play("PlayerEvade");
                break;
            default:
                // defend
                //Debug.Log("Player defends...");
                anim.Play("PlayerDefend");
                break;
        }
    }
}
