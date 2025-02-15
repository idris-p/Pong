using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Allows pause menu to be accessed by script
    public GameObject mainMenuUI;
    public GameObject game;
    private bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide the pauseMenuUI canvas
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Show the pauseMenuUI canvas
        Time.timeScale = 0f; // Freeze time
        isPaused = true;
    }

    public void QuitGame()
    {
        pauseMenuUI.SetActive(false);
        game.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
