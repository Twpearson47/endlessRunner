using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIButtonActivate : MonoBehaviour
{
 /*   public bool panelState;
    public Image panelText;
    public Sprite panelSprite;

        // Use this for initialization
        void Start ()
        {
            panelState = false;
            tab.GetComponent<Image>().sprite = button01;
        }
        // Update is called once per frame
        void Update()
        {
            if (panelState == false)
            {
                Invoke("DisableText", 0.55f);
            }
            if (panelState == true)
            {
                Invoke("EnableText", 0.55f);
            }
        }
    //    public static PanelUI instance = null;
    //    public Image Image;
    //    private bool isClicked;
*/
    public GameObject basePanelWithButtons;
    public GameObject panelToAppearOnTop;
    public GameObject cameraAudio;
    private bool audioOn;

     public void TurnPanelOn()
    {
        basePanelWithButtons.SetActive(false);
        panelToAppearOnTop.SetActive(true);
    }

    public void TurnPanelOff()
    {
        basePanelWithButtons.SetActive(true);
        panelToAppearOnTop.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ConfirmQuit()
    {
        basePanelWithButtons.SetActive(true);
        panelToAppearOnTop.SetActive(false);
        Debug.Log("Confirm Quit Button clicked, need Confirm Quit panel");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DebugText()
    {
            Debug.Log("The credits button got clicked, need Credits panel");
    }

    public void ToggleAudio()
    {
        cameraAudio.GetComponent<AudioListener>().enabled = !cameraAudio.GetComponent<AudioListener>().enabled;
    }
}
