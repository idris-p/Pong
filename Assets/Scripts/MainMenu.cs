using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject game;
    public BallMovement ball; // Gives script access to the ball GameObject but only the public variables/methods in BallMovement
    public ScoreManager score;
    public Transform player1;
    public Transform player2;

    public void Play()
    {
        mainMenuUI.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1f;
        score.ResetScore();
        ResetPlayers();
        StartCoroutine(DelayedResetBall());
    }

    public void ResetPlayers()
    {
        player1.position = new Vector3(player1.position.x, 0f, player1.position.z);
        player2.position = new Vector3(player2.position.x, 0f, player2.position.z);
    }

    public IEnumerator DelayedResetBall()
    {
        yield return null; // Wait 0 seconds
        ball.ResetBall();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
