using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject game;
    public BallMovement ball;
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

    void ResetPlayers()
    {
        player1.position = new Vector3(player1.position.x, 0f, player1.position.z);
        player2.position = new Vector3(player2.position.x, 0f, player2.position.z);
    }

    private IEnumerator DelayedResetBall()
    {
        yield return null;
        ball.ResetBall();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
