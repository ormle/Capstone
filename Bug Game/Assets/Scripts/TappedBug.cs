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
        if (Time.timeScale == 1)//Only be able to tap bugs during game time
        {
            if (scoreManager != null)
            {
                //Debug.Log(this.instance);
                if (this.name == "TigerBeetle" ||  this.name == "TigerBeetle(Clone)")
                {
                    scoreManager.AddScore(1);
				}
				if (this.name == "ButterflyTemp" || this.name == "ButterflyTemp(Clone)")
				{
                    scoreManager.AddScore(5);
				}
				if (this.name == "DragonflyTest" || this.name == "DragonflyTest(Clone)")
				{
                    scoreManager.AddScore(8);
				}
				if (this.name == "BeeTemp" || this.name == "BeeTemp(Clone)")
				{
                    scoreManager.AddScore(10);
				}
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
