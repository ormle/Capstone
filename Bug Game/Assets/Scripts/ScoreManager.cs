using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int ladybug = 0;
    public int beetle = 0;
    public int bee = 0;
    public int butterfly = 0;
    public int dragonfly = 0;

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
        ladybug = PlayerPrefs.GetInt("Lady", 0);
        beetle = PlayerPrefs.GetInt("Beetle", 0);
        bee = PlayerPrefs.GetInt("Bee", 0);
        butterfly = PlayerPrefs.GetInt("Butterfly", 0);
        dragonfly = PlayerPrefs.GetInt("Dragonfly", 0);
    }
    
    public void BugCounter(int bug)
    {
        if (bug == 1) 
            {
                ladybug += 1;
            }
        
        else if (bug == 2) 
            {
                beetle += 1;
            }
            
        else if (bug == 3) 
            {
                bee += 1;
            }
            
        else if (bug == 4) 
            {
                butterfly += 1;
            }
            
        else if (bug == 5) 
            {
                dragonfly += 1;
            }

        SaveScore();
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
        
        PlayerPrefs.SetInt("Lady", ladybug);
        PlayerPrefs.SetInt("Beetle", beetle);
        PlayerPrefs.SetInt("Bee", bee);
        PlayerPrefs.SetInt("Butterfly", butterfly);
        PlayerPrefs.SetInt("Dragonfly", dragonfly);
        
        PlayerPrefs.Save();
    }
    
    public void ResetScore()
    {
        score = 0;
        ladybug = 0;
        beetle = 0;
        bee = 0;
        butterfly = 0;
        dragonfly = 0;
        SaveScore(); // Save the reset score to PlayerPrefs
    }

}
