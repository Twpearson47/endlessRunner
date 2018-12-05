using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIButtonActivate : MonoBehaviour
{

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        PauseMenu.GameIsPaused = false;
        Movement.isDead = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit confirmation has been pressed");
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        PauseMenu.GameIsPaused = false;
        Movement.isDead = false;
        ScoreManager.scarabCount = 0;
    }


    public void DebugLog()
    {
        Debug.Log("This button got clicked");
    }

}