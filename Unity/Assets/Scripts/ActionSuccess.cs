using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSuccess : MonoBehaviour
{
    // Index of the focused action
    // 0 = Defend
    // 1 = Attack
    // 2 = Evade
    private int actionIndex;

    public GameObject[] indicators;
    public Text[] successRateDisplays;
    private int[] successRates;

    private float xZero = 1.75F;
    private float xRange = 6.1F;

    // Use this for initialization
    void Start()
    {
        successRates = new int[3] { 50, 50, 50 };
    }

    /// <summary>
    /// Adjusts the success rate.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void AdjustSuccessRate(int amount)
    {
        // make the adjustment
        successRates[actionIndex] += amount;

        // maintain the range
        if (successRates[actionIndex] < 0)
            successRates[actionIndex] = 0;
        if (successRates[actionIndex] > 100)
            successRates[actionIndex] = 100;

        // set the text
        successRateDisplays[actionIndex].text = successRates[actionIndex].ToString();

        // set the position
        var xPos = successRates[actionIndex] / 100F * xRange + xZero;
        indicators[actionIndex].transform.position 
            = new Vector3(xPos, indicators[actionIndex].transform.position.y, 0);
    }

    public void SetActionIndex(int index)
    {
        actionIndex = index;
    }
}