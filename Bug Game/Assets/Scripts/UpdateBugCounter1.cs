using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateBugCounter1 : MonoBehaviour
{
    public string textValue = "Butterfly x";
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int bugCount = PlayerPrefs.GetInt("Butterfly", 0);
        
        if (bugCount == 0) {
            
            textElement.text = "???";
            
            }
            
        else {
            
            textElement.text = textValue + bugCount;
            
            }
    }
}
