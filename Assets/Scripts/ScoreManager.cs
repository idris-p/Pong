using UnityEngine;
using TMPro; // Required for modifying text

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton??

    // Give script access to each piece of text
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    
    private int score1 = 0;
    private int score2 = 0;

    void Awake() // Called when ??
    {
        if (instance is null)
        {
            instance = this;
        }
    }

    public void AddScore(string scorer)
    {
        if (scorer == "Player 1")
        {
            score1++;
        }
        else if (scorer == "Player 2")
        {
            score2++;
        }

        // Update the text
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }
}
