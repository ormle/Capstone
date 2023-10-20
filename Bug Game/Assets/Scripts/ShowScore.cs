using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public string textValue = "Score: ";
    public TextMeshProUGUI textElement;

    void Start()
    {
        UpdateScoreDisplay();
    }
    
    public void UpdateScoreDisplay()
    {
        ScoreManager scoreManager = ScoreManager.instance;
        if (scoreManager != null)
        {
            textElement.text = textValue + scoreManager.score.ToString();
            Debug.Log("Score updated to: " + scoreManager.score);
        }
    }

}
