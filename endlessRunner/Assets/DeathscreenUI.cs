using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathscreenUI : MonoBehaviour {

    public static bool GameIsOver = false;
    public GameObject deathMenuUI;

    public void Return()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        deathMenuUI.SetActive(false);
        GameIsOver = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        GameIsOver = false;
        ScoreManager.scarabCount = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
