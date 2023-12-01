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

        int butt = PlayerPrefs.GetInt("Butterfly", 0);
        int wa = PlayerPrefs.GetInt("Butterflywa", 0);
        int ch = PlayerPrefs.GetInt("Butterflych", 0);
        int bl = PlayerPrefs.GetInt("Butterflybl", 0);
        
        if (butt > 0 || wa > 0 || ch > 0 || bl > 0) {
            textElement.text = ("x" + (butt + wa + ch + bl)); }

    }
}
