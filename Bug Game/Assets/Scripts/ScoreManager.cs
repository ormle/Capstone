using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Retrieve the score from PlayerPrefs when the game starts
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public void AddScore(int points)
    {
        score += points;
        SaveScore();
    }

    // Add a method to save the score to PlayerPrefs
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
    
    public void ResetScore()
    {
        score = 0;
        SaveScore(); // Save the reset score to PlayerPrefs
    }

}
