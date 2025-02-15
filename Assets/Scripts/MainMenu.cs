using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject game;

    public void Play()
    {
        mainMenuUI.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
