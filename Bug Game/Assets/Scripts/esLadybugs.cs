using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class esLadybugs : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Update()
    {
        int lady   = PlayerPrefs.GetInt("Lady", 0);
        int yellowlady   = PlayerPrefs.GetInt("Yellowlady", 0);
        
        textElement.text = "x0";

        if (lady > 0 || yellowlady > 0) {
            textElement.text = ("x" + (lady + yellowlady));
        }
    
    }
}
