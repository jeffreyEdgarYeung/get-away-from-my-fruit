using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SunDisplay : MonoBehaviour
{
    // State
    [SerializeField] int sun = 50;
    [SerializeField] int maxSunLength = 4;

    TextMeshProUGUI sunText;

    // Start is called before the first frame update
    void Start()
    {
        sunText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        sunText.text = GetSunString();
    }

    public void AddSun( int sunToAdd ){ 
        sun += sunToAdd;
        UpdateDisplay();
    }

    public void SpendSun( int sunToSpend ) { 
        if ( sunToSpend > sun ) { return; }
        sun -= sunToSpend;
        UpdateDisplay();
    }



    private string GetSunString()
    {
        int numZeros = maxSunLength - sun.ToString().Length;

        string zeros = "";

        for (int i = 0; i < numZeros; i++)
        {
            zeros += "0";
        }
        return zeros + sun.ToString();
    }

    public int GetSun() { return sun; }
}
