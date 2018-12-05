using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIButtonActivate : MonoBehaviour
{
    public void TurnCreditsPanelOn()
    {
        Debug.Log("The credits button got clicked, need Credits panel");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button pressed");
    }
}