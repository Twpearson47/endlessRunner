using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Awake()
    {
        //Set variables
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        GameIsPaused = false;
        ScoreManager.scarabCount = 0;
    }
    public void QuitGame()
    {
        pauseMenuUI.SetActive(false);
        Application.Quit();
    }
}
