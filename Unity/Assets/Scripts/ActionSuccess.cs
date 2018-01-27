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

    // Use this for initialization
    void Start()
    {
        successRates = new int[3] { 50, 50, 50 };
    }

    public void IncrementSuccess()
    {
        if (successRates[actionIndex] == 100)
            return;        
        indicators[actionIndex].transform.position 
            = new Vector3(indicators[actionIndex].transform.position.x + 0.061F,
            indicators[actionIndex].transform.position.y, 0);
        successRates[actionIndex]++;
        successRateDisplays[actionIndex].text = successRates[actionIndex].ToString();
    }

    public void DecrementSuccess()
    {
        if (successRates[actionIndex] == 0)
            return;        
        indicators[actionIndex].transform.position 
        = new Vector3(indicators[actionIndex].transform.position.x - 0.061F,
            indicators[actionIndex].transform.position.y, 0);
        successRates[actionIndex]--;
        successRateDisplays[actionIndex].text = successRates[actionIndex].ToString();
    }

    public void SetActionIndex(int index)
    {
        actionIndex = index;
    }
}