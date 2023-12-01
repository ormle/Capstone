using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class esBeetle : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int beetle = PlayerPrefs.GetInt("Beetle", 0);
        int blackbeetle = PlayerPrefs.GetInt("Blackbeetle", 0);
        

        textElement.text = ("x0");
        
        int total = beetle + blackbeetle;
    
        if (beetle > 0 || blackbeetle > 0) {
            textElement.text = ("x" + total);
        }
    }
}
