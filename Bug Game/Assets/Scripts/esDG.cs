using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class esDG : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the score from PlayerPrefs

        int dragon = PlayerPrefs.GetInt("Dragonfly", 0);
        int gd = PlayerPrefs.GetInt("Dragonflygd", 0);
        int ch = PlayerPrefs.GetInt("Dragonflych", 0);

        textElement.text = ("x0");
        
        if (dragon > 0 || gd > 0 || ch > 0) {
            textElement.text = ("x" + (dragon+gd+ch));
        }
    }
}
