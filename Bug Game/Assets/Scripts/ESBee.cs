using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ESBee : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int bee = PlayerPrefs.GetInt("Bee", 0);
        
        if (bee > 0) {
            
            textElement.text += ("Bee x" + bee + "\n");
            
        }
        
        int butt = PlayerPrefs.GetInt("Butterfly", 0);
        
        if (butt > 0) {
            
            textElement.text += ("Butterfly x" + butt + "\n");
            
        }
    
        int beetle = PlayerPrefs.GetInt("Beetle", 0);
        
        if (beetle > 0) {
            
            textElement.text += ("Beetle x" + beetle + "\n");
            
        }
        
        int dragon = PlayerPrefs.GetInt("Dragonfly", 0);
        
        if (dragon > 0) {
            
            textElement.text += ("Dragonfly x" + dragon + "\n");
            
        }
    
    }
}
