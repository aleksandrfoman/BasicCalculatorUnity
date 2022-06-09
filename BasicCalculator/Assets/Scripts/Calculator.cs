using System;
using System.Data;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField calculateInputField;
    [SerializeField]
    private TMP_InputField lastInputField;

    private double Eval(string expression)
    {
        DataTable table = new DataTable();
        return Convert.ToDouble(table.Compute(expression, string.Empty));
    }

    public void Calculate()
    {
        double result = Eval(calculateInputField.text);
        
        if(double.IsNaN(result) || double.IsInfinity(result))
        {
            ClearInput();
        }
        else
        {
            lastInputField.text = calculateInputField.text;
            calculateInputField.text = result.ToString();
        }
    }

    public void ClearInput()
    {
        calculateInputField.text = "";
        lastInputField.text = "";
    }

    public void DeleteLastChar()
    {
        if (!string.IsNullOrEmpty(calculateInputField.text))
        calculateInputField.text = calculateInputField.text.Substring(0, calculateInputField.text.Length - 1);
    }
    public void AddStringToInput(string value)
    {
        calculateInputField.text += value;
    }

    public void CloseCalculator()
    {
        Application.Quit();
    }
}
