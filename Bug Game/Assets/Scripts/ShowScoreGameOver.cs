using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScoreGameOver : MonoBehaviour
{
    public string textValue = "You caught ";
    public string bugsTXT = " bugs!";
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int scoreValue = PlayerPrefs.GetInt("Total", 0);

        textElement.text = textValue + scoreValue + " " + bugsTXT;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            int scoreValue = PlayerPrefs.GetInt("Total", 0); // Retrieve the score from PlayerPrefs
            scoreValue++; // Increment the score
            textElement.text = textValue + scoreValue + " " + bugsTXT;
        }
    }
}
