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
        // textElement.text = textValue + scoreValue + " " + bugsTXT;
	
	// finds the ShowScore script in the scene
	ShowScore scoreScript = GameObject.FindObjectOfType<ShowScore>();
    
	if (scoreScript != null)
	{
	    // gets the score value from the ShowScore script
	    scoreValue = scoreScript.scoreValue;
	    textElement.text = textValue + scoreValue + " " + bugsTXT;
	    
	    // doesn't work, passes 0 for scoreValue instead of bug score
    }
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
