using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Convert : MonoBehaviour
{
    public string input;
    public GameObject inputField;
    public GameObject timeDisplay;
   
    public void StoreTime()
    {
        input = inputField.GetComponent<Text>().text;
        System.DateTime dateTime = System.DateTime.Parse(input);
        timeDisplay.GetComponent<Text>().text = dateTime.ToString("HH:mm:ss");
       
    }

    
}
