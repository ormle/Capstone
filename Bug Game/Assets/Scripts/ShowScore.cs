using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public string textValue = "Score: ";
    public int scoreValue = 0;
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue + scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey("up"))
		{
            scoreValue++;
			textElement.text = textValue + scoreValue;
		}
	}

    public void AddScore(int points) { 
        scoreValue += points;
		textElement.text = textValue + scoreValue;
	}
}
