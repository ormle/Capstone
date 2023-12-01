using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score     = 0;
    public int ant       = 0;
    public int ladybug   = 0;
    public int beetle    = 0; //brown
    public int bee       = 0;
    public int butterfly = 0; //monarch
    public int dragonfly = 0; //blueeyed
    
    public int yellowlady   = 0;
    public int blackbeetle  = 0;
    public int butterflywa  = 0;
    public int butterflych  = 0;
    public int butterflybl  = 0;
    public int dragonflygd  = 0; 
    public int dragonflych  = 0; 
    
    public int total = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { Destroy(gameObject); }

        // Retrieve the score from PlayerPrefs when the game starts
        score     = PlayerPrefs.GetInt("Score", 0);
        ant       = PlayerPrefs.GetInt("Ant", 0);
        ladybug   = PlayerPrefs.GetInt("Lady", 0);
        beetle    = PlayerPrefs.GetInt("Beetle", 0);
        bee       = PlayerPrefs.GetInt("Bee", 0);
        butterfly = PlayerPrefs.GetInt("Butterfly", 0);
        dragonfly = PlayerPrefs.GetInt("Dragonfly", 0);
        total     = PlayerPrefs.GetInt("Total", 0);
        
        yellowlady  = PlayerPrefs.GetInt("Yellowlady", 0);
        blackbeetle = PlayerPrefs.GetInt("Blackbeetle", 0);
        butterflywa = PlayerPrefs.GetInt("Butterflywa", 0);
        butterflych = PlayerPrefs.GetInt("Butterflych", 0);
        butterflybl = PlayerPrefs.GetInt("Butterflybl", 0);
        dragonflygd = PlayerPrefs.GetInt("Dragonflygd", 0);
        dragonflych = PlayerPrefs.GetInt("Dragonflych", 0);
        
        
    }
    
    public void BugCounter(int bug)
    {
        if (bug == 1)      { ladybug += 1; }
        else if (bug == 2) { beetle += 1; }
        else if (bug == 3) { bee += 1; }
        else if (bug == 4) { butterfly += 1; }
        else if (bug == 5) { dragonfly += 1; }
        else if (bug == 6) { ant += 1; }
        else if (bug == 7) { yellowlady += 1; }
        else if (bug == 8) { blackbeetle += 1; }
        else if (bug == 9) { butterflywa += 1; }
        else if (bug == 10) { butterflych += 1; }
        else if (bug == 11) { butterflybl += 1; }
        else if (bug == 12) { dragonflygd += 1; }
        else if (bug == 13) { dragonflych += 1; }


        total += 1;
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
        PlayerPrefs.SetInt("Ant", ant);
        PlayerPrefs.SetInt("Lady", ladybug);
        PlayerPrefs.SetInt("Beetle", beetle);
        PlayerPrefs.SetInt("Bee", bee);
        PlayerPrefs.SetInt("Butterfly", butterfly);
        PlayerPrefs.SetInt("Dragonfly", dragonfly);
        PlayerPrefs.SetInt("Total", total);
        PlayerPrefs.SetInt("Yellowlady", yellowlady);
        PlayerPrefs.SetInt("Blackbeetle", blackbeetle);
        PlayerPrefs.SetInt("Butterflywa", butterflywa);
        PlayerPrefs.SetInt("Butterflych", butterflych);
        PlayerPrefs.SetInt("Butterflybl", butterflybl);
        PlayerPrefs.SetInt("Dragonflygd", dragonflygd);
        PlayerPrefs.SetInt("Dragonflych", dragonflych);
        
        PlayerPrefs.Save();
    }
    
    public void ResetScore()
    {
        score     = 0;
        ant       = 0;
        ladybug   = 0;
        beetle    = 0;
        bee       = 0;
        butterfly = 0;
        dragonfly = 0;
        total     = 0;
        yellowlady   = 0;
        blackbeetle  = 0;
        butterflywa  = 0;
        butterflych  = 0;
        butterflybl  = 0;
        dragonflygd  = 0; 
        dragonflych  = 0; 
        SaveScore(); // Save the reset score to PlayerPrefs
    }

}
