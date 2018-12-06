using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGameOverPanel : MonoBehaviour {
    public GameObject gameOverPanel;
    public float gameOverWaitSeconds;

    void Update ()
    {
        if (Movement.isDead == true)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        yield return new WaitForSeconds(gameOverWaitSeconds);   //Wait for 
        Debug.Log("End Wait() function and the time is: " + Time.time);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        PauseMenu.GameIsPaused = true;
    }

}
