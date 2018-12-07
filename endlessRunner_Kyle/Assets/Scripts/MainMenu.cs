using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool textState;
    public Image menuText;

    public Transform sideTab;
    public bool posX;

    public Button tab;
    public Sprite button01;
    public Sprite button02;

    void Start()
    {
        textState = true;
        posX = false;
        tab.GetComponent<Image>().sprite = button01;
    }

    void Update()
    {
        if (textState == true)
        {
            Invoke("DisableText", 0.55f);
        }
        if (textState == false)
        {
            Invoke("EnableText", 0.55f);
        }
    }

    public void Extra()
    {
        if (posX == false)
        {
            sideTab.position = new Vector3(165, 560, 0);
            Time.timeScale = 0;
            tab.GetComponent<Image>().sprite = button02;
            posX = true;
        }
        else
        {
            sideTab.position = new Vector3(960, 560, 0);
            Time.timeScale = 1;
            tab.GetComponent<Image>().sprite = button01;
            posX = false;
        }
    }

    void DisableText()
    {
        menuText.enabled = false;
        textState = false;
    }

    void EnableText()
    {
        menuText.enabled = true;
        textState = true;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}