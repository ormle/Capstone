using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        ScoreManager scoreManager = ScoreManager.instance;
        if (scoreManager != null)
        {
            scoreText.text = "Score: " + scoreManager.score.ToString();
        }
    }
}
