using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data;

public class Calculation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI screenCalculationText;

    public string textToCalculate;

    bool lastButtonPressedIsClear = false;
    bool lastButtonPressedIsEquals = false;

    private void Awake() {
        // not needed
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        screenCalculationText.text = textToCalculate;
        Debug.Log("Screen Text = " + screenCalculationText.text);
    }

    string Calculate()
    {
        string s = textToCalculate; 
        string value;

        // code to calculate from string and return answer string
        try 
        {
            value = new DataTable().Compute(s, null).ToString();
        }
        catch(Exception e)
        {
            value = "Syntax Error! Clear Screen!";
            Debug.LogError("Calculation syntax error : " + e);
        }

        Debug.Log("Calc : " + value);
        return value;
    }

    public void UpdateScreen_numbers(int num)
    {
        textToCalculate += num;
    }

    public void UpdateScreen_functions(string str)
    {
        if (str == "EQUALS")
        {
            textToCalculate = Calculate();
        }
        else if (str == "CLEAR")
        {
            textToCalculate = "";
        }
        else if (str == "÷") // Division
        {
            textToCalculate += "/";
        }
        else if (str == "X") // Multiplication
        {
            textToCalculate += "*";
        }
        else // +, -, .
        {
            textToCalculate += str;
        }
    }
}
