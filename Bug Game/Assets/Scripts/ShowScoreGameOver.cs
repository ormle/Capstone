using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScoreGameOver : MonoBehaviour
{
    public string textValue = "You caught ";

    public string bugsTXT = " bugs!";
    public int scoreValue = 0;
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue + scoreValue + " " + bugsTXT;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey("up"))
		{
            scoreValue++;
			textElement.text = textValue + scoreValue + " " + bugsTXT;
		}
	}
}
