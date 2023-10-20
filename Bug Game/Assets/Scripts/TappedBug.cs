using UnityEngine;
using TouchScript.Gestures;
using System;

public class TappedBug : MonoBehaviour
{
    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture>();
        tapGesture.Tapped += TapGesture_Tapped;
    }

    void TapGesture_Tapped(object sender, EventArgs e)
    {
        ScoreManager scoreManager = ScoreManager.instance;
        if (scoreManager != null)
        {
            scoreManager.AddScore(1); // Change this value for special bugs
            ShowScore showScore = FindObjectOfType<ShowScore>();
            if (showScore != null)
            {
                showScore.UpdateScoreDisplay();
            }
        }

        Destroy(gameObject);
    }
}
