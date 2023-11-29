using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class esBF : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int score    = PlayerPrefs.GetInt("Score", 0);
        int bee    = PlayerPrefs.GetInt("Bee", 0);
        int butt   = PlayerPrefs.GetInt("Butterfly", 0);
        int beetle = PlayerPrefs.GetInt("Beetle", 0);
        int dragon = PlayerPrefs.GetInt("Dragonfly", 0);
        int ant    = PlayerPrefs.GetInt("Ant", 0);
        int lady   = PlayerPrefs.GetInt("Lady", 0);

        //Display amount of bug caught
        
        /*
        if (bee > 0) {
            textElement.text += ("Bee x" + bee + "\n"); 
        }*/
        
        if (butt > 0) {
            textElement.text += ("Butterfly x" + butt + "\n"); 
        }/*
    
        if (beetle > 0) {
            textElement.text += ("Beetle x" + beetle + "\n");
        }
        
        if (dragon > 0) {
            textElement.text += ("Dragonfly x" + dragon + "\n");
        }

        if (ant > 0) {
            textElement.text += ("Ant x" + ant + "\n");
        }

        if (lady > 0) {
            textElement.text += ("x" + lady);
        }*/
    
    }
}
