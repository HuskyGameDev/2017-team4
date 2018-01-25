using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSwapper : MonoBehaviour
{
    private Animator anim;

    // Index of the focused action
    // 0 = Defend
    // 1 = Attack
    // 2 = Evade
    private int actionIndex;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        actionIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            SwapAction(-1);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SwapAction(1);
    }

    /// <summary>
    /// Swaps the action.
    /// </summary>
    /// <param name="shiftValue">Shift value.</param>
    void SwapAction(int shiftValue)
    {
        actionIndex = (3 + actionIndex + shiftValue) % 3;

        Debug.Log(actionIndex);

        switch (actionIndex)
        {
            case 1:
                anim.Play("ShiftToAttack");
                break;
            case 2:
                anim.Play("ShiftToEvade");
                break;
            default:
                anim.Play("ShiftToDefend");
                break;
        }
    }
}