using UnityEngine;
using TMPro; // Required for modifying text

public class ScoreManager : MonoBehaviour
{
    public MainMenu mainMenu;
    public static ScoreManager instance; // Define what will be the one and only ScoreManager

    // Give script access to each piece of text
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;

    public GameObject winScreen;
    public TextMeshProUGUI winnerText;
    public int winningScore = 11;
    
    private int score1 = 0;
    private int score2 = 0;

    void Awake() // Called before Start() even for disabled objects
    {
        // Make sure only one game manager exists
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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

        CheckWin();
    }

    private void CheckWin()
    {
        if (score1 >= winningScore)
        {
            EndGame("Player 1 Wins!");
        }
        else if  (score2 >= winningScore)
        {
            EndGame("Player 2 Wins!");
        }
    }

    private void EndGame(string winner)
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        winnerText.text = winner;
    }

    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();

        mainMenu.ResetPlayers();
        mainMenu.DelayedResetBall();
        winScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
