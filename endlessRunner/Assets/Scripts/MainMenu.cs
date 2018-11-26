using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public bool textState;
    public Image menuText;

    public Transform sideTab;
    public bool posX;

    void Start()
    {
        textState = true;
        posX = false;
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
            posX = true;
        }
        else
        {
            sideTab.position = new Vector3(960, 560, 0);
            Time.timeScale = 1;
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
}