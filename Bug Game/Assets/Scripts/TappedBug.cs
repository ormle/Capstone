using UnityEngine;
using TouchScript.Gestures;
using System;

public class TappedBug : MonoBehaviour
{
    private AudioSource boinkAudioSource; // Reference to the 'boink' AudioSource

    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture>();
        tapGesture.Tapped += TapGesture_Tapped;

        // Find the 'boink' AudioSource by name in the scene
        boinkAudioSource = GameObject.Find("boink").GetComponent<AudioSource>();
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

        // Play the 'boink' audio clip
        if (boinkAudioSource != null)
        {
            boinkAudioSource.Play();
        }

        Destroy(gameObject);
    }
}
