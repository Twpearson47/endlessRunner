using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGameOverPanel : MonoBehaviour {
    public GameObject gameOverPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update ()
    {
        if (Movement.isDead == true)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            PauseMenu.GameIsPaused = true;
        }
    }
}
