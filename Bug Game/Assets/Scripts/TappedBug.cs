using UnityEngine;
using TouchScript.Gestures;
using System;

public class TappedBug : MonoBehaviour
{
    private AudioSource boinkAudioSource; // Reference to the 'boink' AudioSource
    private countdownTimer countdown; 

    private bool timeUp; //Time given from countdownTimer script

    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture>();
        tapGesture.Tapped += TapGesture_Tapped;

        // Find the 'boink' AudioSource by name in the scene
        boinkAudioSource = GameObject.Find("boink").GetComponent<AudioSource>();

        // Find TimerText in scene
        countdown = GameObject.Find("TimerText").GetComponent<countdownTimer>();
        // Get the timesUp bool
        // Will be false during game time, true when game end
        timeUp = countdown.timesUp.enabled;
        //Debug.Log("CurrentTime: " + currentTime);
    }

    void TapGesture_Tapped(object sender, EventArgs e)
    {
        ScoreManager scoreManager = ScoreManager.instance;
        if (timeUp == false)//Only be able to tap bugs within game time
        {
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
}
